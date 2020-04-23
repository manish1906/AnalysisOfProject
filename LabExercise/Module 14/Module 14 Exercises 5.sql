
-----------------------------------------------------------------------------------------------------
use MarketDev

create procedure Marketing.GetAvailableModelsAsXML  
as 
begin
select mp.ProductID,mp.ProductName,mp.ListPrice,mp.Color,mp.SellStartDate,mpm.ProductModelID,mpm.ProductModel
from Marketing.Product as mp
inner join Marketing.ProductModel as mpm on mp.ProductModelID=mpm.ProductModelID 
where SellStartDate is not null and SellEndDate is null order by SellStartDate, ProductName 
for xml raw('AvailableModel'),root('AvailableModels');
end;

EXEC Marketing.GetAvailableModelsAsXML;

------------------------------------------------------------------------------------------------------
USE AdventureWorks;
GO

CREATE PROCEDURE Sales.UpdateSalesTerritoriesByXML (@SalespersonMods as xml)
AS BEGIN
	UPDATE  Sales.SalesPerson
	SET TerritoryID = updates.SalesTerritoryID
	FROM    Sales.SalesPerson sp
	INNER JOIN (
		SELECT
			SalespersonMod.value('@BusinessEntityID','int') AS BusinessEntityID 
			,SalespersonMod.value('(Mods/Mod/@SalesTerritoryID)[1]','int') AS SalesTerritoryID
		FROM @SalespersonMods.nodes('/SalespersonMods/SalespersonMod') as SalespersonMods(SalespersonMod)
	) AS updates
	ON sp.BusinessEntityID = updates.BusinessEntityID;
END;
GO

DECLARE @xmlTestString nvarchar(2000);
SET @xmlTestString ='
<SalespersonMods>
     <SalespersonMod BusinessEntityID="274">
           <Mods>
               <Mod SalesTerritoryID="3"/>
           </Mods>
     </SalespersonMod>
      <SalespersonMod BusinessEntityID="278">
           <Mods>
                <Mod SalesTerritoryID="4"/>
           </Mods>
     </SalespersonMod>
</SalespersonMods>
)';
DECLARE @testDoc xml;
SET @testDoc = @xmlTestString;

EXEC Sales.UpdateSalesTerritoriesByXML @testDoc;
GO



