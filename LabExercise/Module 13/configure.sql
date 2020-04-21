sp_configure;
GO 
 
sp_configure 'show advanced options', 1; 
GO 
RECONFIGURE; 
GO 
 
sp_configure 'clr enabled', 1; 
GO
RECONFIGURE;
GO 
sp_configure  'clr strict security',0;
RECONFIGURE;
GO 


use AdventureWorks2014;
SELECT dbo.HelloWorld(); 