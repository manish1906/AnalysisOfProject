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



--------------------------------------------------------------------------


USE MarketDev
GO

ALTER TRIGGER Marketing.TR_CampaignBalance_Update
ON Marketing.CampaignBalance
AFTER UPDATE
AS BEGIN
SET NOCOUNT ON;

INSERT Marketing.CampaignAudit 
(AuditTime, ModifyingUser, RemainingBalance)
SELECT SYSDATETIME(),
ORIGINAL_LOGIN(),
inserted.RemainingBalance
FROM deleted
INNER JOIN inserted
ON deleted.CampaignID = inserted.CampaignID 
WHERE ABS(deleted.RemainingBalance  - inserted.RemainingBalance) > 10000;
END;
GO
select *from Marketing.CampaignAudit
delete from Marketing.CampaignAudit
select *from Marketing.CampaignBalance
UPDATE Marketing.CampaignBalance SET RemainingBalance = 20000 WHERE CampaignID=3;