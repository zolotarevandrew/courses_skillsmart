namespace OOAP2.lesson20;


//наследование вариаций, базовый класс TicketEditedNotification отправляет нотификацию об изменении тикета,
//и класс TicketEditedWithChangesNotification переопределяет логику TicketEditedNotification добавляя дополнительный текст в нотификацию со списком изменений

//наследование с конкретизацией, базовый класс HttpAuthorizationHandler с набором предопределенных методов через http контекст и его реализации BasicAuthAuthorizationHandler, JwtTokenAuthorizationHandler

//структурное наследование, класс CompanyTotalRisk реализует интерфейс IRiskEntity, позволяющий считать риски по сущностям IRiskEntity из списка или другим образом