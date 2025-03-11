-- Добавление нового продукта
INSERT INTO "Products"("ProductName", "Description", "Price", "QuantityInStock")
VALUES ('Ручка шариковая', 'Ручка Centropen 0,5 синяя', 49.99, 75);


-- Обновление цены продукта
UPDATE "Products"
SET "Price" = 29.99
WHERE "ProductID" = 1;


-- Выбор всех заказов определенного пользователя
SELECT "OrderID", "UserID", "OrderDate", "Status"
FROM "Orders"
WHERE "UserID" = 2;


-- Расчет общей стоимости заказа
SELECT SUM("TotalCost") AS "Total"
FROM "OrderDetails"
GROUP BY "OrderID"
HAVING "OrderID" = 1;


-- Подсчет количества товаров на складе
SELECT SUM("Products"."QuantityInStock") AS "Total"
FROM "Products";


-- Получение 5 самых дорогих товаров
SELECT "ProductName", "Description", "Price", "QuantityInStock"
FROM "Products"
ORDER BY "Price" DESC
LIMIT 5;


-- Список товаров с низким запасом (менее 5 штук)
SELECT "ProductName", "Description", "Price", "QuantityInStock"
FROM "Products"
WHERE "QuantityInStock" < 5;