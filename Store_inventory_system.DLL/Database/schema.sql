-- Store inventory database (MySQL 8 / MariaDB 10.5+)
-- The app creates the database and runs this script automatically on start-up.
-- To run it by hand in MySQL Workbench or the mysql client:
--     CREATE DATABASE IF NOT EXISTS store_inventory CHARACTER SET utf8mb4;
--     USE store_inventory;
--     then run this script.

CREATE TABLE IF NOT EXISTS Products (
    Id            INT           NOT NULL AUTO_INCREMENT,
    Name          VARCHAR(100)  NOT NULL,
    Price         DECIMAL(12,2) NOT NULL,
    StockQuantity INT           NOT NULL DEFAULT 0,
    ReorderLevel  INT           NOT NULL DEFAULT 10,
    CONSTRAINT PK_Products PRIMARY KEY (Id),
    CONSTRAINT UQ_Products_Name UNIQUE (Name),
    CONSTRAINT CK_Products_Name CHECK (CHAR_LENGTH(TRIM(Name)) > 0),
    CONSTRAINT CK_Products_Price CHECK (Price >= 0),
    CONSTRAINT CK_Products_Stock CHECK (StockQuantity >= 0),
    CONSTRAINT CK_Products_Reorder CHECK (ReorderLevel >= 0),
    KEY IX_Products_StockQuantity (StockQuantity)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE OR REPLACE VIEW vw_LowStockProducts AS
SELECT Id, Name, Price, StockQuantity, ReorderLevel
FROM   Products
WHERE  StockQuantity <= ReorderLevel
ORDER  BY StockQuantity;
