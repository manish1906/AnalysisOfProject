-------------------Exercise 2: Creating an Updateable View --------------------

USE AdventureWorks2016;
GO

CREATE VIEW Sales.vwNewCustomer
AS
SELECT CustomerID, FirstName, LastName 
FROM Sales.CustomerPII;
GO



SELECT * FROM Sales.vwNewCustomer 
ORDER BY CustomerID


INSERT INTO Sales.vwNewCustomer
VALUES
(10001,'Manish', 'Parmar'),
(10002, 'Tushal', 'Parmar');
GO


SELECT * FROM Sales.vwNewCustomer 
ORDER BY CustomerID
