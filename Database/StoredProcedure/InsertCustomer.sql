CREATE PROCEDURE [Demo].[InsertCustomer]
	@Name nvarchar(20) NULL,
	@Age int NULL,
	@Memo nvarchar(50) NULL
AS
	INSERT INTO [Demo].Customer([Name],[Age],[Memo])
	OUTPUT inserted.Id
	VALUES (@Name,@Age,@Memo);
RETURN 0
