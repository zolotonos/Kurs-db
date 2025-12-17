-- 1. CATEGORIES
INSERT INTO category (category_id, name, description) VALUES ('e1e2402f-e8e9-4237-b845-2e622ff7e3c0', 'Електроніка', 'Опис для Електроніка');
INSERT INTO category (category_id, name, description) VALUES ('2719fd85-8f9c-41a4-bb67-d5244f6ecfa1', 'Книги', 'Опис для Книги');
INSERT INTO category (category_id, name, description) VALUES ('79ac4e9e-3115-4488-b597-767dad88dd07', 'Одяг', 'Опис для Одяг');
INSERT INTO category (category_id, name, description) VALUES ('67ad3098-9fe9-4853-bf8a-cd64d9fa5e88', 'Дім', 'Опис для Дім');
INSERT INTO category (category_id, name, description) VALUES ('48220062-1c10-43f4-9b3b-f62d9a0e2b44', 'Спорт', 'Опис для Спорт');

-- 2. SUPPLIERS
INSERT INTO supplier (supplier_id, name, contact_email) VALUES ('31559b0d-7587-409f-9901-3c3649ecc83d', 'Supplier 1', 'contact1@test.com');
INSERT INTO supplier (supplier_id, name, contact_email) VALUES ('06aeeb6c-505f-4647-be00-536b8f20defd', 'Supplier 2', 'contact2@test.com');
INSERT INTO supplier (supplier_id, name, contact_email) VALUES ('a26eb807-0f3f-42f4-b5a4-3097c082a10d', 'Supplier 3', 'contact3@test.com');
INSERT INTO supplier (supplier_id, name, contact_email) VALUES ('044a3cd1-a845-425d-9bbc-e194718c6a28', 'Supplier 4', 'contact4@test.com');
INSERT INTO supplier (supplier_id, name, contact_email) VALUES ('129931e4-9ac0-4255-82f5-e502afd62ee0', 'Supplier 5', 'contact5@test.com');

-- 3. PRODUCTS
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('2bbec8be-e536-47b8-a075-9ece76b729cc', 'iPhone 15 Pro', 'Потужний смартфон', 42000, 20, 'e1e2402f-e8e9-4237-b845-2e622ff7e3c0', '31559b0d-7587-409f-9901-3c3649ecc83d');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('8fca1be9-6550-4e03-a2f9-13954c9d78f4', 'Футболка Nike', 'Спортивна футболка', 1200, 13, '48220062-1c10-43f4-9b3b-f62d9a0e2b44', '31559b0d-7587-409f-9901-3c3649ecc83d');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('bfc8c371-052e-4973-b842-228834658913', 'MacBook Air', 'Легкий ноутбук', 54000, 25, 'e1e2402f-e8e9-4237-b845-2e622ff7e3c0', '129931e4-9ac0-4255-82f5-e502afd62ee0');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('f5bd8d8f-590c-4727-ad86-beb2d1ba6a58', 'Навушники Sony', 'Шумозаглушення', 8500, 50, 'e1e2402f-e8e9-4237-b845-2e622ff7e3c0', '044a3cd1-a845-425d-9bbc-e194718c6a28');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('e62d672d-c2a2-4658-9a1b-ff366d71fc23', 'Диван кутовий', 'Зручний диван', 15000, 30, '67ad3098-9fe9-4853-bf8a-cd64d9fa5e88', '129931e4-9ac0-4255-82f5-e502afd62ee0');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('21239ad7-9dca-41f1-9a0d-ec439247919a', 'Clean Code', 'Книга для програмістів', 1200, 11, '2719fd85-8f9c-41a4-bb67-d5244f6ecfa1', '129931e4-9ac0-4255-82f5-e502afd62ee0');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('d65eefcf-309d-4c1e-b7b6-178a755af887', 'Стіл офісний', 'Дерев''яний стіл', 3500, 45, '67ad3098-9fe9-4853-bf8a-cd64d9fa5e88', '129931e4-9ac0-4255-82f5-e502afd62ee0');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('52b6a56b-f064-47c6-a929-10a502ddfb23', 'Джинси Levi''s', 'Класичні джинси', 2500, 39, '79ac4e9e-3115-4488-b597-767dad88dd07', '044a3cd1-a845-425d-9bbc-e194718c6a28');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('1e9c103e-c1a9-4da8-86df-294a8dae2dca', 'Мишка Logitech', 'Бездротова миша', 1500, 19, 'e1e2402f-e8e9-4237-b845-2e622ff7e3c0', '06aeeb6c-505f-4647-be00-536b8f20defd');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('5636f371-716f-46ca-9f69-77e26b5625dd', 'PowerBank 20000', 'Зарядний пристрій', 2000, 48, 'e1e2402f-e8e9-4237-b845-2e622ff7e3c0', '044a3cd1-a845-425d-9bbc-e194718c6a28');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('3285d1b8-7595-4c5a-ad7d-651585f292dc', 'Гаррі Поттер', 'Колекційне видання', 800, 39, '2719fd85-8f9c-41a4-bb67-d5244f6ecfa1', 'a26eb807-0f3f-42f4-b5a4-3097c082a10d');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('8f733d68-99ef-4ad3-98f1-78dd3b44193a', 'Кобзар', 'Тарас Шевченко', 400, 22, '2719fd85-8f9c-41a4-bb67-d5244f6ecfa1', 'a26eb807-0f3f-42f4-b5a4-3097c082a10d');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('e0932492-cc84-47a2-a3bc-b7341a9074b2', 'Кросівки Puma', 'Бігові кросівки', 3200, 22, '48220062-1c10-43f4-9b3b-f62d9a0e2b44', 'a26eb807-0f3f-42f4-b5a4-3097c082a10d');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('673b2b6d-a475-4371-8741-0be3dd6a5c58', 'Монітор Dell', '24 дюйми', 6000, 15, 'e1e2402f-e8e9-4237-b845-2e622ff7e3c0', '044a3cd1-a845-425d-9bbc-e194718c6a28');
INSERT INTO product (product_id, name, description, price, stock_quantity, category_id, supplier_id) VALUES ('e88e8873-84d1-444f-af81-e2ee427015b0', 'Клавіатура Keychron', 'Механічна', 4500, 43, 'e1e2402f-e8e9-4237-b845-2e622ff7e3c0', '06aeeb6c-505f-4647-be00-536b8f20defd');

-- 4. CUSTOMERS
INSERT INTO customer (customer_id, first_name, last_name, email, phone) VALUES ('322e6095-4640-423e-bfae-3ccb4aaf7e19', 'Олександр', 'Коваль', 'user0@test.com', '123456789');
INSERT INTO address (street, city, postal_code, country, customer_id) VALUES ('Хрещатик 1', 'Kyiv', '00000', 'Ukraine', '322e6095-4640-423e-bfae-3ccb4aaf7e19');
INSERT INTO customer (customer_id, first_name, last_name, email, phone) VALUES ('a756fb58-7bf9-457d-b90f-f6d27f775432', 'Марія', 'Іваненко', 'user1@test.com', '123456789');
INSERT INTO address (street, city, postal_code, country, customer_id) VALUES ('Сумська 10', 'Kharkiv', '00000', 'Ukraine', 'a756fb58-7bf9-457d-b90f-f6d27f775432');
INSERT INTO customer (customer_id, first_name, last_name, email, phone) VALUES ('a749277c-da29-4c9f-8ff7-0530e32efd27', 'Дмитро', 'Петренко', 'user2@test.com', '123456789');
INSERT INTO address (street, city, postal_code, country, customer_id) VALUES ('Дерибасівська 5', 'Odesa', '00000', 'Ukraine', 'a749277c-da29-4c9f-8ff7-0530e32efd27');
INSERT INTO customer (customer_id, first_name, last_name, email, phone) VALUES ('2cbd5285-582d-4a36-ab1e-0dd47ef9b808', 'Олена', 'Сидоренко', 'user3@test.com', '123456789');
INSERT INTO address (street, city, postal_code, country, customer_id) VALUES ('Площа Ринок 1', 'Lviv', '00000', 'Ukraine', '2cbd5285-582d-4a36-ab1e-0dd47ef9b808');
INSERT INTO customer (customer_id, first_name, last_name, email, phone) VALUES ('4013df61-b58e-4334-9617-fc7228b93504', 'Андрій', 'Мельник', 'user4@test.com', '123456789');
INSERT INTO address (street, city, postal_code, country, customer_id) VALUES ('Яворницького 20', 'Dnipro', '00000', 'Ukraine', '4013df61-b58e-4334-9617-fc7228b93504');

-- 5. ORDERS
INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('d8067c43-3548-4232-8fd6-8feda8b55dd1', 'Completed', 0, 'a749277c-da29-4c9f-8ff7-0530e32efd27', (SELECT address_id FROM address WHERE customer_id='a749277c-da29-4c9f-8ff7-0530e32efd27' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('d8067c43-3548-4232-8fd6-8feda8b55dd1', 'd65eefcf-309d-4c1e-b7b6-178a755af887', 1, (SELECT price FROM product WHERE product_id='d65eefcf-309d-4c1e-b7b6-178a755af887'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='d8067c43-3548-4232-8fd6-8feda8b55dd1') WHERE order_id='d8067c43-3548-4232-8fd6-8feda8b55dd1';
INSERT INTO payment (amount, method, order_id) VALUES ((SELECT total_amount FROM orders WHERE order_id='d8067c43-3548-4232-8fd6-8feda8b55dd1'), 'Card', 'd8067c43-3548-4232-8fd6-8feda8b55dd1');

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('4ecea4ac-7b2c-4a8e-8a31-5aa7edbdd79b', 'Pending', 0, 'a749277c-da29-4c9f-8ff7-0530e32efd27', (SELECT address_id FROM address WHERE customer_id='a749277c-da29-4c9f-8ff7-0530e32efd27' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('4ecea4ac-7b2c-4a8e-8a31-5aa7edbdd79b', '5636f371-716f-46ca-9f69-77e26b5625dd', 1, (SELECT price FROM product WHERE product_id='5636f371-716f-46ca-9f69-77e26b5625dd'));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('4ecea4ac-7b2c-4a8e-8a31-5aa7edbdd79b', 'd65eefcf-309d-4c1e-b7b6-178a755af887', 1, (SELECT price FROM product WHERE product_id='d65eefcf-309d-4c1e-b7b6-178a755af887'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='4ecea4ac-7b2c-4a8e-8a31-5aa7edbdd79b') WHERE order_id='4ecea4ac-7b2c-4a8e-8a31-5aa7edbdd79b';

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('42d9cb7b-6845-4630-a06a-5e79dd24c177', 'Completed', 0, 'a756fb58-7bf9-457d-b90f-f6d27f775432', (SELECT address_id FROM address WHERE customer_id='a756fb58-7bf9-457d-b90f-f6d27f775432' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('42d9cb7b-6845-4630-a06a-5e79dd24c177', 'd65eefcf-309d-4c1e-b7b6-178a755af887', 1, (SELECT price FROM product WHERE product_id='d65eefcf-309d-4c1e-b7b6-178a755af887'));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('42d9cb7b-6845-4630-a06a-5e79dd24c177', 'e0932492-cc84-47a2-a3bc-b7341a9074b2', 1, (SELECT price FROM product WHERE product_id='e0932492-cc84-47a2-a3bc-b7341a9074b2'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='42d9cb7b-6845-4630-a06a-5e79dd24c177') WHERE order_id='42d9cb7b-6845-4630-a06a-5e79dd24c177';
INSERT INTO payment (amount, method, order_id) VALUES ((SELECT total_amount FROM orders WHERE order_id='42d9cb7b-6845-4630-a06a-5e79dd24c177'), 'Card', '42d9cb7b-6845-4630-a06a-5e79dd24c177');

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('df596e49-3cad-4629-9a3a-729b9202042a', 'Pending', 0, '2cbd5285-582d-4a36-ab1e-0dd47ef9b808', (SELECT address_id FROM address WHERE customer_id='2cbd5285-582d-4a36-ab1e-0dd47ef9b808' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('df596e49-3cad-4629-9a3a-729b9202042a', 'e0932492-cc84-47a2-a3bc-b7341a9074b2', 1, (SELECT price FROM product WHERE product_id='e0932492-cc84-47a2-a3bc-b7341a9074b2'));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('df596e49-3cad-4629-9a3a-729b9202042a', '52b6a56b-f064-47c6-a929-10a502ddfb23', 1, (SELECT price FROM product WHERE product_id='52b6a56b-f064-47c6-a929-10a502ddfb23'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='df596e49-3cad-4629-9a3a-729b9202042a') WHERE order_id='df596e49-3cad-4629-9a3a-729b9202042a';

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('e1759355-5192-43f2-baf1-57c16577a14c', 'Completed', 0, 'a756fb58-7bf9-457d-b90f-f6d27f775432', (SELECT address_id FROM address WHERE customer_id='a756fb58-7bf9-457d-b90f-f6d27f775432' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('e1759355-5192-43f2-baf1-57c16577a14c', '2bbec8be-e536-47b8-a075-9ece76b729cc', 1, (SELECT price FROM product WHERE product_id='2bbec8be-e536-47b8-a075-9ece76b729cc'));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('e1759355-5192-43f2-baf1-57c16577a14c', 'e88e8873-84d1-444f-af81-e2ee427015b0', 1, (SELECT price FROM product WHERE product_id='e88e8873-84d1-444f-af81-e2ee427015b0'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='e1759355-5192-43f2-baf1-57c16577a14c') WHERE order_id='e1759355-5192-43f2-baf1-57c16577a14c';
INSERT INTO payment (amount, method, order_id) VALUES ((SELECT total_amount FROM orders WHERE order_id='e1759355-5192-43f2-baf1-57c16577a14c'), 'Card', 'e1759355-5192-43f2-baf1-57c16577a14c');

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('b06cb928-657b-4753-b455-0db0acb38716', 'Pending', 0, '4013df61-b58e-4334-9617-fc7228b93504', (SELECT address_id FROM address WHERE customer_id='4013df61-b58e-4334-9617-fc7228b93504' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('b06cb928-657b-4753-b455-0db0acb38716', '3285d1b8-7595-4c5a-ad7d-651585f292dc', 1, (SELECT price FROM product WHERE product_id='3285d1b8-7595-4c5a-ad7d-651585f292dc'));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('b06cb928-657b-4753-b455-0db0acb38716', '5636f371-716f-46ca-9f69-77e26b5625dd', 1, (SELECT price FROM product WHERE product_id='5636f371-716f-46ca-9f69-77e26b5625dd'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='b06cb928-657b-4753-b455-0db0acb38716') WHERE order_id='b06cb928-657b-4753-b455-0db0acb38716';

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('035d9ea9-259b-4d09-b799-cac38dd96495', 'Completed', 0, 'a756fb58-7bf9-457d-b90f-f6d27f775432', (SELECT address_id FROM address WHERE customer_id='a756fb58-7bf9-457d-b90f-f6d27f775432' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('035d9ea9-259b-4d09-b799-cac38dd96495', '21239ad7-9dca-41f1-9a0d-ec439247919a', 1, (SELECT price FROM product WHERE product_id='21239ad7-9dca-41f1-9a0d-ec439247919a'));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('035d9ea9-259b-4d09-b799-cac38dd96495', 'f5bd8d8f-590c-4727-ad86-beb2d1ba6a58', 1, (SELECT price FROM product WHERE product_id='f5bd8d8f-590c-4727-ad86-beb2d1ba6a58'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='035d9ea9-259b-4d09-b799-cac38dd96495') WHERE order_id='035d9ea9-259b-4d09-b799-cac38dd96495';
INSERT INTO payment (amount, method, order_id) VALUES ((SELECT total_amount FROM orders WHERE order_id='035d9ea9-259b-4d09-b799-cac38dd96495'), 'Card', '035d9ea9-259b-4d09-b799-cac38dd96495');

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('9321ab0f-69dd-4c0b-bdac-60bafcae5c67', 'Pending', 0, 'a756fb58-7bf9-457d-b90f-f6d27f775432', (SELECT address_id FROM address WHERE customer_id='a756fb58-7bf9-457d-b90f-f6d27f775432' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('9321ab0f-69dd-4c0b-bdac-60bafcae5c67', 'e0932492-cc84-47a2-a3bc-b7341a9074b2', 1, (SELECT price FROM product WHERE product_id='e0932492-cc84-47a2-a3bc-b7341a9074b2'));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('9321ab0f-69dd-4c0b-bdac-60bafcae5c67', 'bfc8c371-052e-4973-b842-228834658913', 1, (SELECT price FROM product WHERE product_id='bfc8c371-052e-4973-b842-228834658913'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='9321ab0f-69dd-4c0b-bdac-60bafcae5c67') WHERE order_id='9321ab0f-69dd-4c0b-bdac-60bafcae5c67';

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('c006e0dd-d6a0-4e10-a025-d8968e139765', 'Completed', 0, '2cbd5285-582d-4a36-ab1e-0dd47ef9b808', (SELECT address_id FROM address WHERE customer_id='2cbd5285-582d-4a36-ab1e-0dd47ef9b808' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('c006e0dd-d6a0-4e10-a025-d8968e139765', 'e88e8873-84d1-444f-af81-e2ee427015b0', 1, (SELECT price FROM product WHERE product_id='e88e8873-84d1-444f-af81-e2ee427015b0'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='c006e0dd-d6a0-4e10-a025-d8968e139765') WHERE order_id='c006e0dd-d6a0-4e10-a025-d8968e139765';
INSERT INTO payment (amount, method, order_id) VALUES ((SELECT total_amount FROM orders WHERE order_id='c006e0dd-d6a0-4e10-a025-d8968e139765'), 'Card', 'c006e0dd-d6a0-4e10-a025-d8968e139765');

INSERT INTO orders (order_id, status, total_amount, customer_id, address_id) VALUES ('dd5a8224-2754-4264-83da-95f1ab6e6903', 'Pending', 0, '2cbd5285-582d-4a36-ab1e-0dd47ef9b808', (SELECT address_id FROM address WHERE customer_id='2cbd5285-582d-4a36-ab1e-0dd47ef9b808' LIMIT 1));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('dd5a8224-2754-4264-83da-95f1ab6e6903', '21239ad7-9dca-41f1-9a0d-ec439247919a', 1, (SELECT price FROM product WHERE product_id='21239ad7-9dca-41f1-9a0d-ec439247919a'));
INSERT INTO order_item (order_id, product_id, quantity, unit_price) VALUES ('dd5a8224-2754-4264-83da-95f1ab6e6903', 'e88e8873-84d1-444f-af81-e2ee427015b0', 1, (SELECT price FROM product WHERE product_id='e88e8873-84d1-444f-af81-e2ee427015b0'));
UPDATE orders SET total_amount = (SELECT COALESCE(SUM(quantity * unit_price), 0) FROM order_item WHERE order_id='dd5a8224-2754-4264-83da-95f1ab6e6903') WHERE order_id='dd5a8224-2754-4264-83da-95f1ab6e6903';