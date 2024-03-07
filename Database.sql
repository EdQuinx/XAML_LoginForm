CREATE DATABASE MVVMDatabase
GO

USE MVVMDatabase
GO

CREATE TABLE [Users]
(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	Username nvarchar(50) NOT NULL,
	Password nvarchar(256) NOT NULL,
	Name nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL,
	PhoneNumber nvarchar(20)
)
GO
INSERT INTO [Users] VALUES(NEWID(), 'edquinx2000', 'quypro123', N'Quý', N'Lâm', 'edquinx2000@gmail.com', '+84961951234')
INSERT INTO [Users] VALUES(NEWID(), 'admin01', '123456', N'Administrator', N'EDQUINX', 'edquinx2000@gmail.com', '+84961951234')
GO
