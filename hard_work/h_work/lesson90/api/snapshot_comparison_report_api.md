# REST API for snapshot comparison report

## GET /api/reports/snapshot-comparisons
### Получение отчёта по сравнению снэпшотов
- **Описание**: Метод для получения отчёта по сравнению снэпшотов из таблицы `snapshot_comparisons`.
- **Параметры запроса** (Query params):
    - `run_id` (required, UUID) — фильтр по идентификатору рана.

- **Пример запроса**:
  ```http
  GET /api/reports/snapshot-comparisons?run_id=uuid
  ```

- **Пример ответа (200 OK)**:
  ```json
  {
    "total_comparisons": 100,
    "successful_comparisons": 80,
    "failed_comparisons": 20,
    "details": [
      {
        "benchmark_snapshot_id": "uuid1",
        "current_snapshot_id": "uuid2",
        "is_success": true,
        "result": {},
        "created_at": "2025-01-01T12:00:00Z"
      }
    ]
  }
  ```

### SQL-запросы:

1. **Общая статистика по сравнению**:
   ```sql
   SELECT 
       COUNT(*) AS total_comparisons,
       SUM(CASE WHEN is_success THEN 1 ELSE 0 END) AS successful_comparisons,
       SUM(CASE WHEN NOT is_success THEN 1 ELSE 0 END) AS failed_comparisons
   FROM snapshot_comparisons
   WHERE benchmark_snapshot_id IN (
       SELECT s.id
       FROM snapshots s
       JOIN snapshot2runs s2r ON s.id = s2r.snapshot_id
       WHERE s2r.snapshot_run_id = $1
   );
   ```

2. **Детальная информация по сравнению**:
   ```sql
   SELECT 
       sc.benchmark_snapshot_id, 
       sc.current_snapshot_id, 
       sc.is_success, 
       sc.result, 
       sc.created_at
   FROM snapshot_comparisons sc
   WHERE sc.benchmark_snapshot_id IN (
       SELECT s.id
       FROM snapshots s
       JOIN snapshot2runs s2r ON s.id = s2r.snapshot_id
       WHERE s2r.snapshot_run_id = $1
   );
   ```

