# Shop

## Опис проєкту

Shop — це backend-додаток для управління інтернет-магазином, що забезпечує обробку замовлень, управління товарами, клієнтами та складським обліком.

**Предметна область:** електронна комерція

Проєкт розроблено з фокусом на:
* 3НФ (нормалізація БД)
* Транзакційні сценарії
* Soft & Hard Delete
* Unit-тестування

## Технологічний стек

* **Backend:** .NET 9 (ASP.NET Core)
* **DB:** PostgreSQL 16
* **ORM:** Entity Framework Core
* **Testing:** xUnit
* **Infra:** Docker & Docker Compose

## Інструкції з налаштування

### Передумови
* .NET 9 SDK
* Docker

### Запуск додатку

**1. Через Docker Compose:**

    docker compose up -d

Додаток доступний: http://localhost:5161/swagger
БД: localhost:5433 (user: admin, pass: password123)

**2. Локально:**

    cd Src
    dotnet run

### Запуск тестів

    cd Tests
    dotnet test

## Приклади API

### Створення замовлення

**POST** /api/Orders/create

    {
      "customerId": "uuid...",
      "addressId": "uuid...",
      "items": [
        { "productId": "uuid...", "quantity": 2 }
      ]
    }

### Реєстрація клієнта

**POST** /api/Customers/register

    {
      "firstName": "Ivan",
      "lastName": "Test",
      "email": "ivan@test.com",
      "phone": "0500000000",
      "city": "Kyiv",
      "street": "Main St"
    }


## Примітки
* **Soft Delete** реалізовано через прапорець `is_deleted`.
* **Транзакції** гарантують атомарність при створенні замовлення.