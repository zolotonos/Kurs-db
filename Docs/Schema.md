<img src="./image.png" width="50%" alt="Опис картинки">

# Опис таблиць

### Таблиця: `customer`

**Призначення:** Зберігає основну інформацію про клієнтів магазину.

| Стовпець | Тип | Обмеження | Опис |
| :--- | :--- | :--- | :--- |
| **customer_id** | UUID | PK, DEFAULT gen_random_uuid() | Унікальний ідентифікатор клієнта |
| **first_name** | VARCHAR(100) | NOT NULL | Ім'я клієнта |
| **last_name** | VARCHAR(100) | NOT NULL | Прізвище клієнта |
| **email** | VARCHAR(255) | UNIQUE, NOT NULL | Електронна пошта (логін) |
| **phone** | VARCHAR(50) | NULL | Номер телефону |

**Зв'язки:**
* **1:N** з `address` (клієнт може мати кілька адрес)
* **1:N** з `orders` (клієнт робить замовлення)

---

### Таблиця: `address`

**Призначення:** Зберігає адреси доставки для клієнтів.

| Стовпець | Тип | Обмеження | Опис |
| :--- | :--- | :--- | :--- |
| **address_id** | UUID | PK, DEFAULT gen_random_uuid() | Ідентифікатор адреси |
| **street** | VARCHAR(255) | NOT NULL | Вулиця, будинок, квартира |
| **city** | VARCHAR(100) | NOT NULL | Місто |
| **postal_code** | VARCHAR(20) | NULL | Поштовий індекс |
| **country** | VARCHAR(100) | NOT NULL | Країна |
| **customer_id** | UUID | FK (ON DELETE CASCADE) | Посилання на клієнта (`customer`) |

**Зв'язки:**
* **N:1** з `customer` (адреса належить клієнту)
* **1:N** з `orders` (використовується в замовленнях)

---

### Таблиця: `category`

**Призначення:** Довідник категорій для класифікації товарів.

| Стовпець | Тип | Обмеження | Опис |
| :--- | :--- | :--- | :--- |
| **category_id** | UUID | PK, DEFAULT gen_random_uuid() | Ідентифікатор категорії |
| **name** | VARCHAR(100) | NOT NULL | Назва категорії |
| **description** | TEXT | NULL | Опис категорії |

**Зв'язки:**
* **1:N** з `product` (категорія містить товари)

---

### Таблиця: `supplier`

**Призначення:** База даних постачальників товарів.

| Стовпець | Тип | Обмеження | Опис |
| :--- | :--- | :--- | :--- |
| **supplier_id** | UUID | PK, DEFAULT gen_random_uuid() | Ідентифікатор постачальника |
| **name** | VARCHAR(150) | NOT NULL | Назва компанії |
| **contact_email** | VARCHAR(255) | NULL | Контактний email |

**Зв'язки:**
* **1:N** з `product` (постачальник надає товари)

---

### Таблиця: `product`

**Призначення:** Каталог товарів магазину з цінами та залишками.

| Стовпець | Тип | Обмеження | Опис |
| :--- | :--- | :--- | :--- |
| **product_id** | UUID | PK, DEFAULT gen_random_uuid() | Ідентифікатор товару |
| **name** | VARCHAR(150) | NOT NULL | Назва товару |
| **description** | TEXT | NULL | Опис товару |
| **price** | DECIMAL(10,2) | NOT NULL, CHECK (>= 0) | Ціна за одиницю |
| **stock_quantity**| INT | NOT NULL, DEFAULT 0, CHECK (>= 0)| Залишок на складі |
| **category_id** | UUID | FK (ON DELETE SET NULL) | Категорія товару (`category`) |
| **supplier_id** | UUID | FK (ON DELETE SET NULL) | Постачальник (`supplier`) |
| **is_deleted** | BOOLEAN | DEFAULT FALSE | Прапорець м'якого видалення |

**Індекси:**
* `idx_product_name` на `name` (пошук товару за назвою)

**Зв'язки:**
* **N:1** з `category`
* **N:1** з `supplier`
* **1:N** з `order_item`

---

### Таблиця: `orders`

**Призначення:** Зберігає інформацію про замовлення (хто, коли, сума).

| Стовпець | Тип | Обмеження | Опис |
| :--- | :--- | :--- | :--- |
| **order_id** | UUID | PK, DEFAULT gen_random_uuid() | Ідентифікатор замовлення |
| **order_date** | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP | Дата створення |
| **status** | VARCHAR(50) | NOT NULL, DEFAULT 'Pending' | Статус виконання |
| **total_amount** | DECIMAL(10,2) | NOT NULL, DEFAULT 0 | Загальна сума |
| **customer_id** | UUID | FK (ON DELETE RESTRICT) | Замовник (`customer`) |
| **address_id** | UUID | FK | Адреса доставки (`address`) |

**Індекси:**
* `idx_orders_customer` на `customer_id` (замовлення клієнта)
* `idx_orders_date` на `order_date` (фільтр за датою)

**Зв'язки:**
* **N:1** з `customer`
* **N:1** з `address`
* **1:N** з `order_item` (деталі замовлення)
* **1:N** з `payment` (оплати)

---

### Таблиця: `order_item`

**Призначення:** Деталізація замовлення (список товарів у кошику).

| Стовпець | Тип | Обмеження | Опис |
| :--- | :--- | :--- | :--- |
| **order_item_id** | UUID | PK, DEFAULT gen_random_uuid() | Ідентифікатор рядка замовлення |
| **quantity** | INT | NOT NULL, CHECK (> 0) | Кількість одиниць |
| **unit_price** | DECIMAL(10,2) | NOT NULL, CHECK (>= 0) | Ціна на момент покупки |
| **order_id** | UUID | FK (ON DELETE CASCADE) | Замовлення (`orders`) |
| **product_id** | UUID | FK | Товар (`product`) |

**Зв'язки:**
* **N:1** з `orders`
* **N:1** з `product`

---

### Таблиця: `payment`

**Призначення:** Фіксує факти оплати замовлень.

| Стовпець | Тип | Обмеження | Опис |
| :--- | :--- | :--- | :--- |
| **payment_id** | UUID | PK, DEFAULT gen_random_uuid() | Ідентифікатор транзакції |
| **amount** | DECIMAL(10,2) | NOT NULL, CHECK (> 0) | Сума платежу |
| **method** | VARCHAR(50) | NOT NULL | Метод (Card, Cash, etc.) |
| **paid_at** | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP | Дата та час оплати |
| **order_id** | UUID | FK (ON DELETE CASCADE) | Оплачене замовлення (`orders`) |

**Зв'язки:**
* **N:1** з `orders`