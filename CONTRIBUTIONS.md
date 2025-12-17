# Внески команди

## Учасник 1 (Денис Хміль)
- Налаштування інфраструктури (Docker, PostgreSQL, EF Core).
- Реалізація схеми бази даних (Migrations).
-  ProductsController (CRUD, Soft Delete, Pagination), OrdersController.
 - Звіт по топ-продуктах.
 - Unit-тести для OrderService.

## Учасник 2 (Гліб Осипенко)
- Рефакторинг архітектури: впровадження Service Pattern (OrderService, ProductService, AnalyticsService) та налаштування Dependency Injection.
- Контейнеризація додатку: створення Dockerfile та інтеграція backend-сервісу в docker-compose.yml.
- Реалізація AnalyticsService: розробка складних LINQ-запитів для аналітичних звітів (Top Products, Best Customers).
- Розширення покриття тестами: написання Unit-тестів для AnalyticsService та налагодження запуску тестів.
- Наповнення бази даних: генерації тестових даних (Seeding).