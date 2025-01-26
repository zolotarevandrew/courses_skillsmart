-- 1) tests_list — список всех тестов
-- Содержит список всех доступных тестов.
CREATE TABLE tests_list (
                            id SERIAL PRIMARY KEY,         -- Уникальный идентификатор теста
                            name TEXT NOT NULL,            -- Название теста
                            resolution TEXT NOT NULL,      -- Разрешение теста
                            language VARCHAR(2) NOT NULL   -- Язык пользователя
                            UNIQUE (name)
);

CREATE INDEX idx_tests_list_name_trgm ON tests_list USING gin (name gin_trgm_ops);
CREATE INDEX idx_tests_list_resolution ON tests_list (resolution);
CREATE INDEX idx_tests_list_language ON tests_list (language);

-- 2) snapshots — снэпшоты тестов
-- Хранит снэпшоты, сделанные на определенный момент времени.
CREATE TABLE snapshots (
                           id UUID PRIMARY KEY,                     -- Уникальный идентификатор снэпшота
                           test_id INT NOT NULL,                    -- Ссылка на тест
                           filepath TEXT NOT NULL,                  -- Путь к файлу в MinIO
                           created_at TIMESTAMP NOT NULL,           -- Дата и время создания снэпшота
                           snapshot_type INT NOT NULL,              -- Тип (0 - обычный, 1 - бенчмарк)
                           UNIQUE (test_id, snapshot_type) WHERE snapshot_type = 1 -- Уникальный бенчмарк для каждого теста
);

CREATE INDEX idx_snapshots_type_test_id ON snapshots (snapshot_type, test_id);


-- 3) snapshot_run — запуск снэпшот-тестов
-- Содержит информацию о каждом запуске CI/CD для снэпшот-тестов.
CREATE TABLE snapshot_run (
                              id UUID PRIMARY KEY,         -- Уникальный идентификатор запуска
                              created_at TIMESTAMP NOT NULL, -- Дата и время запуска
                              name TEXT NOT NULL          -- Имя (например, номер релиза),
                                  env TEXT NOT NULL          -- среда на которой ран был запущен,
);

CREATE INDEX idx_snapshot_run_name_trgm ON snapshot_run USING gin (name gin_trgm_ops);
CREATE INDEX idx_snapshot_run_env ON snapshot_run (env);

-- 4) snapshot2runs — привязка снэпшотов к конкретному запуску
-- Связывает снэпшоты с их запуском.
CREATE TABLE snapshot2runs (
                               snapshot_id UUID NOT NULL,                  -- Ссылка на снэпшот
                               snapshot_run_id UUID NOT NULL,              -- Ссылка на запуск
                               PRIMARY KEY (snapshot_id, snapshot_run_id)
);

-- 5) snapshot_comparisons — результаты сравнений
-- Хранит результаты сравнения снэпшотов.
CREATE TABLE snapshot_comparisons (
                                      id UUID PRIMARY KEY,                       -- Уникальный идентификатор сравнения
                                      benchmark_snapshot_id UUID NOT NULL,       -- Ссылка на эталонный снэпшот
                                      current_snapshot_id UUID NOT NULL,         -- Ссылка на текущий снэпшот
                                      comparison_type INT NOT NULL,              -- Тип сравнения (0 - resemblejs)
                                      result JSONB NOT NULL,                     -- Специфичная информация по сравнению (для resemble resemble_jsonb_column_schema.json)
                                      is_success BOOLEAN NOT NULL,               -- Успешно ли сравнение
                                      created_at TIMESTAMP NOT NULL              -- Дата сравнения
);