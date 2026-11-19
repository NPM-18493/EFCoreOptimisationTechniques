CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME2 NOT NULL
);

CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
    TotalAmount DECIMAL(18,2) NOT NULL,
    OrderDate DATETIME2 NOT NULL,
    Status NVARCHAR(50) NOT NULL
);

-- Seed Customers (e.g., 10,000 records)
DECLARE @i INT = 1;
WHILE @i <= 10000
BEGIN
    INSERT INTO Customers (Name, Email, CreatedAt)
    VALUES ('Customer ' + CAST(@i AS NVARCHAR), 'customer' + CAST(@i AS NVARCHAR) + '@example.com', DATEADD(DAY, -(@i % 365), GETDATE()));
    SET @i = @i + 1;
END

-- Seed Orders (e.g., 500,000 records using a tally loop)
SET @i = 1;
WHILE @i <= 500000
BEGIN
    INSERT INTO Orders (CustomerId, TotalAmount, OrderDate, Status)
    VALUES (
        (@i % 10000) + 1, 
        CAST((RAND(CHECKSUM(NEWID())) * 500) AS DECIMAL(18,2)), 
        DATEADD(MINUTE, -(@i % 525600), GETDATE()),
        CASE (@i % 3) WHEN 0 THEN 'Pending' WHEN 1 THEN 'Completed' ELSE 'Cancelled' END
    );
    SET @i = @i + 1;
END