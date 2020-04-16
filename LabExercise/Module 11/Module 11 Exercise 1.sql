USE AdventureWorks
GO

CREATE TABLE Production.ProductAudit(
AuditID int  IDENTITY(1,1) NOT NULL,
ProductID int NOT NULL,
UpdateTime datetime2(7) NOT NULL,
ModifyingUser nvarchar(100) NOT NULL,
OriginalListPrice money NULL,
NewListPrice money NULL
)


CREATE TRIGGER Production.TR_ProductPriceUpdate
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
	WHERE d.ListPrice > 1000 OR i.ListPrice > 1000;
END;
GO

UPDATE Production.Product
SET ListPrice=1111
WHERE ProductID=1;

SELECT * FROM Production.ProductAudit




UPDATE Production.Product
SET ListPrice=555
WHERE ProductID=760;

SELECT * FROM Production.ProductAudit



UPDATE Production.Product
SET ListPrice=9999
WHERE ProductID=760;

SELECT * FROM Production.ProductAudit
GO