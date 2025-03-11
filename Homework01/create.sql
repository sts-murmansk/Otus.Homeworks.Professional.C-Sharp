-- Последовательность для первичного ключа таблицы "Products"
CREATE SEQUENCE product_id_seq;

-- Создание таблицы "Products" со всеми ограничениями
CREATE TABLE "Products"
(
    "ProductID" bigint NOT NULL DEFAULT NEXTVAL('product_id_seq'),
    "ProductName" character varying(255) NOT NULL,
    "Description" character varying(1023) NOT NULL,
    "Price" money NOT NULL,
    "QuantityInStock" integer NOT NULL,
    CONSTRAINT products_pkey PRIMARY KEY ("ProductID")
);

-- Индекс для запросов по стоимости
CREATE INDEX products_price_idx ON "Products"("Price");

-- Индекс для запросов по остаткам
CREATE INDEX products_quantity_in_stock_idx ON "Products"("QuantityInStock");


-- Последовательность для первичного ключа таблицы "Users"
CREATE SEQUENCE user_id_seq;

-- Создание таблицы "Users" со всеми ограничениями
CREATE TABLE "Users"
(
    "UserID" bigint NOT NULL DEFAULT NEXTVAL('user_id_seq'),
    "UserName" character varying(255) NOT NULL,
    "Email" character varying(255) NOT NULL,
    "RegistrationDate" timestamp with time zone NOT NULL,
    CONSTRAINT users_pkey PRIMARY KEY ("UserID")
);


-- Последовательность для первичного ключа таблицы "Orders"
CREATE SEQUENCE order_id_seq;

-- Создание таблицы "Orders" со всеми ограничениями
CREATE TABLE "Orders"
(
    "OrderID" bigint NOT NULL DEFAULT NEXTVAL('order_id_seq'),
    "UserID" bigint NOT NULL,
    "OrderDate" timestamp with time zone NOT NULL,
    "Status" character varying(255) NOT NULL,
    CONSTRAINT orders_pkey PRIMARY KEY ("OrderID"),
    CONSTRAINT orders_fk_user_id FOREIGN KEY ("UserID") REFERENCES "Users"("UserID") ON DELETE CASCADE
);

-- Индекс для запросов по пользователю
CREATE INDEX orders_user_id_idx ON "Orders"("UserID");


-- Последовательность для первичного ключа таблицы "OrderDetails"
CREATE SEQUENCE order_detail_id_seq;

-- Создание таблицы "OrderDetails" со всеми ограничениями
CREATE TABLE "OrderDetails"
(
    "OrderDetailID" bigint NOT NULL DEFAULT NEXTVAL('order_detail_id_seq'),
    "OrderID" bigint NOT NULL,
    "ProductID" bigint NOT NULL,
    "Quantity" integer NOT NULL,
    "TotalCost" money NOT NULL,
    CONSTRAINT order_details_pkey PRIMARY KEY ("OrderDetailID"),
    CONSTRAINT order_details_fk_order_id FOREIGN KEY ("OrderID") REFERENCES "Orders"("OrderID") ON DELETE CASCADE,
    CONSTRAINT order_details_fk_product_id FOREIGN KEY ("ProductID") REFERENCES "Products"("ProductID") ON DELETE CASCADE
);

-- Индекс для запросов по заказу
CREATE INDEX order_details_order_id_idx ON "OrderDetails"("OrderID");
