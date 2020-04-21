USE AdventureWorks2014;
GO

--------------- Test the Scalar-Valued Function --------------

SELECT * 
	FROM Production.Product
	WHERE dbo.IsRegexMatch (Name, N'\b[Ww]heel\b') = 1; 

SELECT * 
	FROM Production.Product
	WHERE dbo.IsRegexMatch (Name, N'\bMen\b') = 1; 



---------------------------Test the Table-Valued Function ---------------------


--------------------------------------------------------------------------------
-- Test the function on its own
--
-- The regular expression pattern has the following parts:
--	[fd]	any single character in the set, ie f or d
--	o		literal o
--	[xg]	any single character in the set, ie x or g
--------------------------------------------------------------------------------

SELECT *
	FROM dbo.RegexMatches(N'The quick brown fox jumped over the lazy dog.', N'[fd]o[xg]');



--------------------------------------------------------------------------------
-- Search Product color
--
-- The regular expression pattern has the following parts:
--	Silver|Black	Silver or Black
--
--------------------------------------------------------------------------------

SELECT P.ProductID, P.Color, M.match
	FROM Production.Product AS P
		CROSS APPLY dbo.RegexMatches(P.Color, N'Silver|Black') AS M
	ORDER BY ProductID;


--------------------------------------------------------------------------------
-- Search ProductDescription for The and the following word
--
-- The regular expression pattern has the following parts:
--	[Tt]			any single character in the set, ie T or t
--	he				literal he and space
--	[A-Za-z0-9\-]+	one or more characters A-Z or a-z or 0-9 or hyphen
--
--------------------------------------------------------------------------------

SELECT P.ProductDescriptionID, P.[Description], M.match
	FROM Production.ProductDescription AS P
		CROSS APPLY dbo.RegexMatches(P.[Description], N'[Tt]he [A-Za-z0-9\-]+') AS M
	ORDER BY P.ProductDescriptionID;

	
----------------------------------------------------------------------------
-- Search ProductDescription for numbers and the following word
--
-- The regular expression pattern has the following parts:
--	[0-9]+			one or more characters in the set 0 to 9
--  [ ]?			optional space
--	[A-Za-z0-9\-]+	one or more characters A-Z or a-z or 0-9 or hyphen
--
--------------------------------------------------------------------------------

SELECT P.ProductDescriptionID, P.[Description], M.match
	FROM Production.ProductDescription AS P
		CROSS APPLY dbo.RegexMatches(P.[Description], N'[0-9]+[ ]?[A-Za-z0-9\-]+') AS M
	ORDER BY P.ProductDescriptionID;




--------------------------- Test StringAggregate --------------------------------



SELECT Name
	FROM (VALUES (N'Parmar'),
				(N'Manish'),
				(N'J')) AS X (Name);


SELECT dbo.StringAggregate(Name) AS 'AggregatedName'
	FROM (VALUES (N'Parmar'),
				(N'Manish'),
				(N'J')) AS X (Name);



--------------------------------------------------------------------------------
-- Starter query
-- So we can see how the query works without any grouping
-------------------------------------------------------------------------------

WITH CustomerCategory_CTE AS
(
	SELECT H.CustomerID, PC.Name AS Category
		FROM Sales.SalesOrderHeader AS H
			INNER JOIN Sales.SalesOrderDetail AS D
				ON D.SalesOrderID = H.SalesOrderID
			INNER JOIN Production.Product AS X
				ON X.ProductID = D.ProductID
			INNER JOIN Production.ProductSubcategory AS PS
				ON PS.ProductSubcategoryID = X.ProductSubcategoryID
			INNER JOIN Production.ProductCategory AS PC
				ON PC.ProductCategoryID = PS.ProductCategoryID
		GROUP BY H.CustomerID, PC.Name
)

SELECT P.BusinessEntityID, CONCAT(P.FirstName + N' ', P.MiddleName + N' ', P.LastName) AS PersonName, CC.Category
	FROM CustomerCategory_CTE AS CC
		INNER JOIN Sales.Customer AS C
			ON C.CustomerID = CC.CustomerID
		INNER JOIN Person.Person AS P
			ON P.BusinessEntityID = C.PersonID
	ORDER BY P.LastName, P.FirstName, P.BusinessEntityID;



--------------------------------------------------------------------------------
-- Test StringAggregate
-------------------------------------------------------------------------------

WITH CustomerCategory_CTE AS
(
	SELECT H.CustomerID, PC.Name AS Category
		FROM Sales.SalesOrderHeader AS H
			INNER JOIN Sales.SalesOrderDetail AS D
				ON D.SalesOrderID = H.SalesOrderID
			INNER JOIN Production.Product AS X
				ON X.ProductID = D.ProductID
			INNER JOIN Production.ProductSubcategory AS PS
				ON PS.ProductSubcategoryID = X.ProductSubcategoryID
			INNER JOIN Production.ProductCategory AS PC
				ON PC.ProductCategoryID = PS.ProductCategoryID
		GROUP BY H.CustomerID, PC.Name
)

SELECT P.BusinessEntityID, CONCAT(P.FirstName + N' ', P.MiddleName + N' ', P.LastName) AS PersonName, dbo.StringAggregate(CC.Category) AS Categories
	FROM CustomerCategory_CTE AS CC
		INNER JOIN Sales.Customer AS C
			ON C.CustomerID = CC.CustomerID
		INNER JOIN Person.Person AS P
			ON P.BusinessEntityID = C.PersonID
	GROUP BY P.BusinessEntityID, P.FirstName, P.MiddleName, P.LastName
	ORDER BY P.LastName, P.FirstName, P.BusinessEntityID;



