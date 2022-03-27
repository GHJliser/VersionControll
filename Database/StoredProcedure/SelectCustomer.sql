CREATE PROCEDURE [Demo].[SelectCustomer]
	@Id int NULL
AS
	SELECT
		[Id],
		[Name],
		[Age]
	FROM Demo.Customer
	WHERE (@Id IS NULL OR [Id] = @Id);
RETURN
