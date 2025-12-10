
-- Таблиця: CUSTOMER
CREATE TABLE customer (
    customer_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    phone VARCHAR(50),
);

-- Таблиця: ADDRESS
CREATE TABLE address (
    address_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    street VARCHAR(255) NOT NULL,
    city VARCHAR(100) NOT NULL,
    postal_code VARCHAR(20),
    country VARCHAR(100) NOT NULL,
    customer_id UUID REFERENCES customer(customer_id) ON DELETE CASCADE
);

-- Таблиця: CATEGORY
CREATE TABLE category (
    category_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(100) NOT NULL,
    description TEXT
);

-- Таблиця: SUPPLIER
CREATE TABLE supplier (
    supplier_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(150) NOT NULL,
    contact_email VARCHAR(255)
);

-- Таблиця: PRODUCT
CREATE TABLE product (
    product_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(150) NOT NULL,
    description TEXT,
    price DECIMAL(10,2) NOT NULL CHECK (price >= 0), 
    stock_quantity INT NOT NULL DEFAULT 0 CHECK (stock_quantity >= 0), 
    category_id UUID REFERENCES category(category_id) ON DELETE SET NULL,
    supplier_id UUID REFERENCES supplier(supplier_id) ON DELETE SET NULL,
    is_deleted BOOLEAN DEFAULT FALSE -- Для Soft Delete 
);

-- Таблиця: ORDERS 
CREATE TABLE orders (
    order_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(50) NOT NULL DEFAULT 'Pending',
    total_amount DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK (total_amount >= 0),
    customer_id UUID REFERENCES customer(customer_id) ON DELETE RESTRICT,
    address_id UUID REFERENCES address(address_id)
);

-- Таблиця: ORDER_ITEM
CREATE TABLE order_item (
    order_item_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    quantity INT NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(10,2) NOT NULL CHECK (unit_price >= 0),
    order_id UUID REFERENCES orders(order_id) ON DELETE CASCADE,
    product_id UUID REFERENCES product(product_id)
);

-- Таблиця: PAYMENT
CREATE TABLE payment (
    payment_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    amount DECIMAL(10,2) NOT NULL CHECK (amount > 0),
    method VARCHAR(50) NOT NULL,
    paid_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    order_id UUID REFERENCES orders(order_id) ON DELETE CASCADE
);

CREATE INDEX idx_product_name ON product(name);
CREATE INDEX idx_orders_customer ON orders(customer_id);
CREATE INDEX idx_orders_date ON orders(order_date);