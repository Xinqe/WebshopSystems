
Use WebShopDB;
DROP TABLE OrderItem;
DROP TABLE [Order];
DROP TABLE Account;
DROP TABLE Product;
DROP TABLE [Log];

CREATE TABLE Account (
ID INT PRIMARY KEY IDENTITY NOT NULL,
Username NVARCHAR(100) NOT NULL,
[Password] NVARCHAR(100) NOT NULL,
);



CREATE TABLE [Order] (
ID INT PRIMARY KEY IDENTITY NOT NULL,
AccountID INT FOREIGN KEY REFERENCES Account(ID)  ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
OrderDate DATETIME NOT NULL,
[Status] NVARCHAR(100) NOT NULL
);

CREATE TABLE Product (
ID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(100) NOT NULL,
Description NVARCHAR(MAX),
Price INT NOT NULL,

);

CREATE TABLE OrderItem (
ID INT PRIMARY KEY IDENTITY NOT NULL,
OrderID INT FOREIGN KEY REFERENCES [Order](ID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
ProductID INT FOREIGN KEY REFERENCES Product(ID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
Quantity INT NOT NULL
);

CREATE TABLE Log
(
ID INT PRIMARY KEY IDENTITY NOT NULL,
Description NVARCHAR(MAX) NOT NULL,
)

INSERT INTO Product([Name], Description, Price) VALUES ('Soap', 'A magical soap', 50);
INSERT INTO Product([Name], Description, Price) VALUES ('Spoon', 'A Spoon made out of silver', 150);
INSERT INTO Product([Name], Description, Price) VALUES ('First aid kit', 'A first aid kit for situations', 50);
INSERT INTO Product([Name], Description, Price) VALUES ('Hat', 'A hat made out of wool', 1050);

INSERT INTO Account(Username, [Password]) VALUES ('t', 't');

INSERT INTO [Order](AccountID, OrderDate, [Status]) VALUES (1, SYSDATETIME(), 'Ordered'  );

INSERT INTO OrderItem (OrderID, ProductID, Quantity) VALUES(1, 1, 2);
INSERT INTO OrderItem (OrderID, ProductID, Quantity) VALUES(1, 2, 4);
INSERT INTO OrderItem (OrderID, ProductID, Quantity) VALUES(1, 3, 6);
INSERT INTO	 dbo.Log
(
    Description
)
VALUES
('TESTLOG' -- Description - nvarchar(max)
    )

	SELECT * FROM  [Order];
	SELECT * from OrderItem;