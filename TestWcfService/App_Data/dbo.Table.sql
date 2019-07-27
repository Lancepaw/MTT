CREATE TABLE [dbo].[Cheques]
(
	[Id] NVARCHAR(MAX) NOT NULL PRIMARY KEY, 
    [Number] NVARCHAR(50) NOT NULL, 
    [Summ] MONEY NOT NULL, 
    [Discount] MONEY NOT NULL, 
    [Articles] NVARCHAR(MAX) NOT NULL
)
