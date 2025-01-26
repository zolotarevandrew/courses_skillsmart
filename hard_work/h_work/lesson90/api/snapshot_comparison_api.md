# REST API for snapshot comparison

## POST /api/snapshots/compare
### Запуск сравнения снэпшотов из конкретного рана
- **Описание**: Метод для сравнения всех снэпшотов из указанного рана с эталонными снэпшотами.
- **Тело запроса** (JSON):
  ```json
  {
    "run_id": "uuid"
  }
  ```
- **Пример ответа (200 OK)**:
  ```json
  {
    "ok": true
  }
  ```

### SQL-запросы:

1. **Получение снэпшотов из указанного рана**:
   ```sql
   SELECT s.id, s.test_id, s.filepath
   FROM snapshots s
   JOIN snapshot2runs s2r ON s.id = s2r.snapshot_id
   WHERE s2r.snapshot_run_id = $1 AND s.snapshot_type = 0;
   ```

2. **Получение эталонного снэпшота для каждого теста**:
   ```sql
   SELECT id, filepath
   FROM snapshots
   WHERE test_id = $1 AND snapshot_type = 1;
   ```

3. **Сохранение результата сравнения**:
   ```sql
   INSERT INTO snapshot_comparisons (
       id, benchmark_snapshot_id, current_snapshot_id, comparison_type, result, is_success, created_at
   ) VALUES (
       gen_random_uuid(), $1, $2, 0, $3::jsonb, $4, NOW()
   );
   ```

### Алгоритм работы:
1. Извлечь все снэпшоты из указанного рана (запрос №1).
2. Для каждого снэпшота запустить Worker через worker_threads (не хочется усложнять с очередьми задач для начала):
   - Найти соответствующий эталонный снэпшот (запрос №2).
   - Если эталонный снэпшот найден, выполняем сравнение через Resemble.js.
   - Сохранить результат сравнения в таблицу `snapshot_comparisons` (запрос №3)
