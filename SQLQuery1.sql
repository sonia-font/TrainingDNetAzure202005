USE SampleDB

GO
--------------------------------------------------------
CREATE TABLE Products (
	PROD_ID INT NOT NULL PRIMARY KEY,
	PROD_NAME VARCHAR(50) NOT NULL,
	PROD_STOCK INT NOT NULL,
	PROD_PRICE FLOAT
);

INSERT INTO Products VALUES (1, 'PENCIL', 50, 12.90);
INSERT INTO Products VALUES (2, 'PEN', 50, 15.90);
INSERT INTO Products VALUES (3, 'RUBBER', 50, 8.70);
INSERT INTO Products VALUES (4, 'RULER', 30, 27.90);
--------------------------------------------------------
CREATE TABLE Locations (
	LOC_ID INT NOT NULL PRIMARY KEY,
	LOC_NAME VARCHAR(50) NOT NULL
);

INSERT INTO Locations VALUES (1, 'MUNRO');
INSERT INTO Locations VALUES (2, 'SAN ISIDRO');
INSERT INTO Locations VALUES (3, 'OLIVOS');
INSERT INTO Locations VALUES (4, 'SAN MARTIN');
--------------------------------------------------------
CREATE TABLE Stores (
	STOR_ID INT NOT NULL PRIMARY KEY,
	STOR_NAME VARCHAR(50) NOT NULL,
	STOR_LOC INT NOT NULL,
	FOREIGN KEY (STOR_LOC) REFERENCES Locations (LOC_ID)
);

INSERT INTO Stores VALUES (1, 'LIBRERIA SOL', 1);
INSERT INTO Stores VALUES (2, 'LIBRERIA EL BAUL', 2);
INSERT INTO Stores VALUES (3, 'LIBRERIA LOS AMIGOS', 3);
INSERT INTO Stores VALUES (4, 'LIBRERIA SM', 4);
--------------------------------------------------------
CREATE TABLE Employees (
	EMP_ID INT NOT NULL PRIMARY KEY,
	EMP_NAME VARCHAR(50) NOT NULL,
	EMP_BD DATE NOT NULL,
	EMP_PHONE VARCHAR(50),
	EMP_EMAIL VARCHAR(50),
	EMP_STORE INT NOT NULL,
	FOREIGN KEY (EMP_STORE) REFERENCES Stores (STOR_ID)
);

INSERT INTO Employees VALUES (1, 'OSCAR', '1965-10-12', NULL, NULL, 1);
INSERT INTO Employees VALUES (2, 'CARLA', '1959-02-07', NULL, NULL, 2);
INSERT INTO Employees VALUES (3, 'HORACIO', '1974-06-18', NULL, NULL, 3);
INSERT INTO Employees VALUES (4, 'AMALIA', '1982-10-22', NULL, NULL, 4);
--------------------------------------------------------
CREATE TABLE Customers (
	CUS_ID INT NOT NULL PRIMARY KEY,
	CUS_NAME VARCHAR(50) NOT NULL,
	CUS_PHONE VARCHAR(50),
	CUS_EMAIL VARCHAR(50),
	CUS_STORE INT NOT NULL,
	FOREIGN KEY (CUS_STORE) REFERENCES Stores (STOR_ID)
);

INSERT INTO Customers VALUES (1, 'OMAR', NULL, NULL, 1);
INSERT INTO Customers VALUES (2, 'NELIDA', NULL, NULL, 2);
INSERT INTO Customers VALUES (3, 'MARIANA', NULL, NULL, 3);
INSERT INTO Customers VALUES (4, 'VICTORIA', NULL, NULL, 4);
--------------------------------------------------------


Begin Tran 
SAVE Transaction TABLES_CREATED; 
 
DELETE FROM Customers WHERE CUS_ID = 1;   
SAVE Transaction CUSTOMER_DELETED; 

ROLLBACK Transaction TABLES_CREATED; 

INSERT INTO Customers VALUES (5, 'ORLANDO', NULL, NULL, 2);
SAVE Transaction CUSTOMER_ADDED

UPDATE Customers SET CUS_NAME = 'VICKY' 
WHERE CUS_NAME = 'VICTORIA'; 
SAVE Transaction CUSTOMER_UPDATED

SELECT C.CUS_NAME AS 'NAME', S.STOR_NAME AS 'USUAL STORE'
	FROM Customers AS C
	INNER JOIN Stores AS S ON C.CUS_STORE = S.STOR_ID

COMMIT

--------------------------------------------------------	

CREATE INDEX Store_Index 
ON Stores (STOR_ID)

---------------------------------------------------------

ALTER TABLE Employees
ADD EMP_AGE AS
DATEDIFF(year, EMP_BD, GETDATE())

SELECT * FROM Employees

----------------------------------------------------------
/*CREATE PROCEDURE SelectAllCustomers
AS
SELECT * FROM Customers
GO;

EXEC SelectAllCustomers*/