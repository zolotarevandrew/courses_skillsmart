# REST API for snapshot run management

## POST /api/runs
### Добавление нового рана в таблицу snapshot_run
- **Описание**: Метод для добавления записи о запуске рана. 
- Для каждого выбранного теста выполняется асинхронное снятие снэпшота через worker_threads, с последующим сохранением в minio и в базу данных.
- **Тело запроса** (JSON):
  ```json
  {
    "name": "string",
    "env": "string",
    "test_ids": [1, 2, 3]
  }
  ```
- **Пример ответа (201 Created)**:
  ```json
  {
    "run_id": "uuid",
    "name": "Release 1.0",
    "env": "stage",
    "created_at": "2025-01-01T12:00:00Z"
  }
  ```

### SQL-запросы:

1. **Создание записи о запуске рана**:
   ```sql
   INSERT INTO snapshot_run (id, name, env, created_at)
   VALUES (gen_random_uuid(), $1, $2, NOW())
   RETURNING id;
   ```

2. **Добавление снэпшотов для выбранных тестов**:
   ```sql
   INSERT INTO snapshots (id, test_id, filepath, snapshot_type, created_at)
   VALUES (gen_random_uuid(), $1, $2, 0, NOW())
   RETURNING id;
   ```

    - Параметры:
        - `$1`: идентификатор теста.
        - `$2`: путь к файлу снэпшота (MinIO).

3. **Добавление записи в таблицу snapshot2runs**:
   ```sql
   INSERT INTO snapshot2runs (snapshot_id, snapshot_run_id)
   VALUES ($1, $2);
   ```

    - Параметры:
        - `$1`: идентификатор снэпшота.
        - `$2`: идентификатор рана.


## GET /api/runs
### Получение списка всех ранов с фильтрацией по имени и среде
- **Описание**: Метод для получения списка всех ранов с возможностью фильтрации по имени и среде.
- **Параметры запроса** (Query params):
  - `name` (optional, string) — фильтр по имени рана.
  - `env` (optional, string) — фильтр по среде рана.
- **Пример ответа (200 OK)**:
  ```json
  [
    {
      "id": "uuid",
      "name": "Release 1.0",
      "env": "stage",
      "created_at": "2025-01-01T12:00:00Z"
    }
  ]
  ```
- **SQL-запрос**:
  ```sql
  SELECT id, name, env, created_at
  FROM snapshot_run
  WHERE ($1 IS NULL OR name ILIKE '%' || $1 || '%')
    AND ($2 IS NULL OR env = $2)
  ORDER BY created_at DESC;
  ```
