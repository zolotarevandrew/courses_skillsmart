### 1) Тест внутреннего API обработчика вебхука от внешнего сервиса верификации
| №  | Признак                                          | Числовое значение | Описание                                                                                   |
|----|--------------------------------------------------|-----------------|----------------------------------------------------------------------------------------------------------|
| 1  | Количество строк кода в продакшене              | 100+ строк      | Верификация подписи (HMACSHA1), десериализация (Newtonsoft.Json), публикация (MassTransit)               |
| 2  | Количество пересечённых границ                  | 3               | Web API (контроллер), Infrastructure (RabbitMQ), Domain сообщения                                        |
| 3  | Кол-во модульных тестов, на которые можно разбить | 3               | Проверка подписи, конвертация байтов в контракт, построение сообщения для RabbitMQ                       |
| 4  | Количество внешних сервисов для запуска         | 1               | RabbitMQ                                                                                           |
| 5  | Сложность запуска                                | 1               | Поднять RabbitMQ локально или взять из тестовой среды                                                    |
| 6  | Сколько строк нужно просмотреть при ошибке      | 200+ строк      | От HTTP API до RabbitMQ: 3 библиотеки, и 100+ строк своего кода                                          |
| 7  | Вероятность сбоя из-за эмерджентности           | 30+%            | 3 основных компонента, возможны ошибки при проблемах с RabbitMQ |

### 2) Тест внешнего API клиента верификации

| №  | Признак                                          | Числовое значение | Описание                                                                              |
|----|--------------------------------------------------|------------------|-----------------------------------------------------------------------------------------------------|
| 1  | Количество строк кода в продакшене              | 100+ строк       | Flurl.Http, middleware для подписания и логирования                                    |
| 2  | Количество пересечённых границ                  | 1                | Infrastructure                                                                          |
| 3  | Кол-во модульных тестов, на которые можно разбить | 1                | Проверяется только вход и выход одного API-метода                                                   |
| 4  | Количество внешних сервисов для запуска         | 1                | Sandbox среда или внутренний мок API                                                                |
| 5  | Сложность запуска                                | 3                | Требуется настройка sandbox, API-ключей или запуск WireMock, json файлы примеров запросов и ответов |
| 6  | Сколько строк нужно просмотреть при ошибке      | 100+ строк       | Ошибки могут быть на этапе десериализации, логирования, HTTP-ответа, среды sandbox                  |
| 7  | Вероятность сбоя из-за эмерджентности           | 50+%             | Sandbox может быть нестабильным: сбой, неверный API-ключ, недоступность среды, поменялись контракты |

### 3) Тест сохранения состояния шага онбординга в базу данных

| №  | Признак                                          | Числовое значение | Описание                                                              |
|----|--------------------------------------------------|------------------|-------------------------------------------------------------------------------------|
| 1  | Количество строк кода в продакшене              | 100+ строк       | Dapper, Npgsql, доменная логика, преобразование в модель хранения                   |
| 2  | Количество пересечённых границ                  | 2                | Infrastructure и Domain                                                             |
| 3  | Кол-во модульных тестов, на которые можно разбить | 2                | Бизнес-логика и сохранение результата в хранилище                                   |
| 4  | Количество внешних сервисов для запуска         | 1                | PostgreSQL                                                                 |
| 5  | Сложность запуска                                | 2                | Нужно поднять PostgreSQL и накатить миграции                                        |
| 6  | Сколько строк нужно просмотреть при ошибке      | 200+ строк       | Доменная логика, работа с Dapper, настройки подключения                             |
| 7  | Вероятность сбоя из-за эмерджентности           | 20+%             | Ошибки возможны при неверной конфигурации PostgreSQL, строки подключения и библиотек |

### 4) Тест обработки сообщения из RabbitMq по изменению состояния онбординга

| №  | Признак                                          | Числовое значение | Описание                                                                 |
|----|--------------------------------------------------|------------------|-----------------------------------------------------------------------------------------|
| 1  | Количество строк кода в продакшене              | 200+ строк       | MassTransit, Dapper, Npgsql, доменная логика, преобразование в модель хранения         |
| 2  | Количество пересечённых границ                  | 2                | Infrastructure и Domain                                                                |
| 3  | Кол-во модульных тестов, на которые можно разбить | 2                | Обработка бизнес-логики и сохранение результата в хранилище                            |
| 4  | Количество внешних сервисов для запуска         | 2                | RabbitMQ и PostgreSQL                                                                  |
| 5  | Сложность запуска                                | 2                | Поднять RabbitMQ, PostgreSQL и накатить миграции                                       |
| 6  | Сколько строк нужно просмотреть при ошибке      | 500+ строк       | Обработка события, бизнес-логика, вызовы через библиотеки, настройки окружения         |
| 7  | Вероятность сбоя из-за эмерджентности           | 50+%             | Возможны сбои RabbitMQ (потери сообщений), ошибки конфигурации PostgreSQL и библиотек  |

### 5) Тест обработки шага оркестрации по выпуску банковской карты для открытия счета

| №  | Признак                                          | Числовое значение | Описание                                                                            |
|----|--------------------------------------------------|-------------------|-------------------------------------------------------------------------------------|
| 1  | Количество строк кода в продакшене              | 200+ строк        | Npgsql, Dapper, API call, доменная логика, изменение статуса оркестрации/онбординга |
| 2  | Количество пересечённых границ                  | 2                 | Infrastructure, Domain                                                              |
| 3  | Кол-во модульных тестов, на которые можно разбить | 2                 | Сохранение состояния и вызов внешнего API                                           |
| 4  | Количество внешних сервисов для запуска         | 2                 | PostgreSQL и WireMock                                                               |
| 5  | Сложность запуска                                | 2                 | Поднять PostgreSQL, накатить миграции, поднять WireMock                             |
| 6  | Сколько строк нужно просмотреть при ошибке      | 500+ строк        | Доменная логика, работа с Dapper, внешние вызовы, конфигурация WireMock             |
| 7  | Вероятность сбоя из-за эмерджентности           | 30+%              | Возможны сбои из-за изменения API контракта, WireMock, конфигурации базы            |

## Итого:

Интуитивно определить интеграционный тест достаточно просто:
чем больше времени, внешних зависимостей и усилий требуется для его реализации и поддержки, тем выше вероятность, что это именно интеграционный тест.

Именно поэтому большинство разработчиков не любит писать такие тесты.

Я стараюсь находить баланс — в зависимости от возможностей компании и размера/сложности проекта.
Иногда достаточно покрыть систему множеством Unit-тестов и лишь небольшой частью интеграционных тестов.
А иногда, требуется большое количество интеграционных и end-to-end тестов.
