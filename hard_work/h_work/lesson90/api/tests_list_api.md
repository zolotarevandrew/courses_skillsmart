# REST API for tests_list table

## POST /api/tests
### Добавление нового теста в таблицу tests_list
- **Описание**: Метод для добавления нового теста в базу данных.
- **Тело запроса** (JSON):
  ```json
  {
    "name": "string",
    "resolution": "string",
    "language": "string"
  }
  ```
- **Пример ответа (201)**:
  ```json
  {
    "id": 1,
    "name": "Test name",
    "resolution": "1920x1080",
    "language": "en"
  }
  ```
- **SQL-запрос**:
  ```sql
  INSERT INTO tests_list (name, resolution, language)
  VALUES ($1, $2, $3)
  ON CONFLICT (name) DO NOTHING;
  ```

## GET /api/tests
### Получение списка тестов с фильтрацией по имени, разрешению и языку
- **Описание**: Метод для получения списка тестов с возможностью фильтрации.
- **Параметры запроса** (Query params):
  - `name` (optional, string) — фильтр по имени теста.
  - `resolution` (optional, string) — фильтр по разрешению.
  - `language` (optional, string) — фильтр по языку.
- **Пример ответа (200 OK)**:
  ```json
  [
    {
      "id": 1,
      "name": "Test name",
      "resolution": "1920x1080",
      "language": "en"
    }
  ]
  ```
- **SQL-запрос**:
  ```sql
  SELECT id, name, resolution, language
  FROM tests_list
  WHERE ($1 IS NULL OR name ILIKE '%' || $1 || '%')
    AND ($2 IS NULL OR resolution = $2)
    AND ($3 IS NULL OR language = $3)
  LIMIT 20;
  ```
