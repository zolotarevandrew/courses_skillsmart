# REST API for snapshot benchmark management

## GET /api/snapshots/benchmark
### Получение всех эталонных снэпшотов
- **Описание**: Метод для получения всех эталонных (бенчмарк) снэпшотов из таблицы `snapshots`.
- **Пример ответа (200 OK)**:
  ```json
  [
    {
      "id": "uuid",
      "test_id": 1,
      "filepath": "s3://bucket/path/to/snapshot.png",
      "created_at": "2025-01-01T12:00:00Z"
    }
  ]
  ```
- **SQL-запрос**:
  ```sql
  SELECT id, test_id, filepath, created_at
  FROM snapshots
  WHERE snapshot_type = 1;
  ```

## POST /api/snapshots/benchmark
### Пометка снэпшотов как эталонных
- **Описание**: Метод для пометки снэпшотов как эталонных (бенчмарк).
- **Тело запроса** (JSON):
  ```json
  {
    "snapshot_ids": ["uuid1", "uuid2"]
  }
  ```
- **Пример ответа (200 OK)**:
  ```json
  {
    "updated_count": 2
  }
  ```
- **SQL-запрос**:
  ```sql
  UPDATE snapshots
  SET snapshot_type = 1
  WHERE id = ANY($1::uuid[]);
  ```

## GET /api/snapshots/search
### Поиск не эталонных снэпшотов для последующей пометки как эталонных
- **Описание**: Метод для поиска снэпшотов по фильтрам.
- **Параметры запроса** (Query params):
  - `run_id` (optional, UUID) — фильтр по идентификатору рана.
  - `test_ids` (optional, array of int) — фильтр по массиву идентификаторов тестов.
  - `env` (optional, string) — фильтр по среде запуска.
- **Пример запроса**:
  ```http
  GET /api/snapshots/search?run_id=uuid&test_ids=1,2,3&env=stage
  ```
- **Пример ответа (200 OK)**:
  ```json
  [
    {
      "id": "uuid",
      "test_id": 1,
      "filepath": "s3://bucket/path/to/snapshot.png",
      "run_id": "uuid",
      "env": "stage"
    },
    {
      "id": "uuid2",
      "test_id": 2,
      "filepath": "s3://bucket/path/to/snapshot2.png",
      "run_id": "uuid",
      "env": "stage"
    }
  ]
  ```
- **SQL-запрос**:
  ```sql
  SELECT s.id, s.test_id, s.filepath, sr.id AS run_id, sr.env, s.snapshot_type
  FROM snapshots s
  JOIN snapshot2runs s2r ON s.id = s2r.snapshot_id
  JOIN snapshot_run sr ON s2r.snapshot_run_id = sr.id
  WHERE s.snapshot_type = 0
    AND ($1 IS NULL OR sr.id = $1)
    AND ($2 IS NULL OR s.test_id = ANY($2::int[]))
    AND ($3 IS NULL OR sr.env = $3);
  ```

