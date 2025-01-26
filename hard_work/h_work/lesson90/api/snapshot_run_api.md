# REST API for snapshot_run table

## POST /api/runs
### Добавление нового рана в таблицу snapshot_run
- **Описание**: Метод для добавления записи о запуске рана.
- **Тело запроса** (JSON):
  ```json
  {
    "name": "string",
    "env": "string"
  }
  ```
- **Пример ответа (201 Created)**:
  ```json
  {
    "id": "uuid",
    "name": "Release 1.0",
    "env": "stage",
    "created_at": "2025-01-01T12:00:00Z"
  }
  ```
- **SQL-запрос**:
  ```sql
  INSERT INTO snapshot_run (id, name, env, created_at)
  VALUES (gen_random_uuid(), $1, $2, NOW())
  RETURNING id, name, env, created_at;
  ```

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
  ORDER BY created_at DESC LIMIT 10;
  ```
