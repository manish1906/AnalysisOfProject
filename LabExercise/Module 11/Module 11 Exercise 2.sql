USE AdventureWorks
GO
SELECT *FROM Production.ProductAudit

DELETE FROM Production.ProductAudit

ALTER TRIGGER Production.TR_ProductPriceUpdate
ON Production.Product
AFTER UPDATE
AS BEGIN
	SET NOCOUNT ON;
	SELECT *FROM INSERTED ;
	SELECT *FROM DELETED;
	INSERT INTO Production.ProductAudit
	SELECT i.ProductID,SYSDATETIME(),ORIGINAL_LOGIN(),d.ListPrice, i.ListPrice
	FROM deleted as d
	INNER JOIN inserted as i
	ON d.ProductID = i.ProductID
	WHERE d.ListPrice > 10000 OR i.ListPrice > 10000;
END;
GO

UPDATE Production.Product
SET ListPrice=11111
WHERE ProductID=1;

SELECT * FROM Production.ProductAudit




UPDATE Production.Product
SET ListPrice=555
WHERE ProductID=760;

SELECT * FROM Production.ProductAudit



UPDATE Production.Product
SET ListPrice=12000
WHERE ProductID=760;

SELECT * FROM Production.ProductAudit
GO