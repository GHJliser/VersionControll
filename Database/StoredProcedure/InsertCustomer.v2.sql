CREATE PROCEDURE [Demo].[InsertCustomer.v2]
	--version 2 change Name to not nullable
	@Name nvarchar(20),
	@Age int NULL,
	@Memo nvarchar(50) NULL
AS
	INSERT INTO [Demo].Customer([Name],[Age],[Memo])
	OUTPUT inserted.Id
	VALUES (@Name,@Age,@Memo);
RETURN 0
