CREATE TABLE [dbo].[AppUser]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Passwd VARBINARY(64) NOT NULL,
	RoleId INT DEFAULT(1),
	NickName VARCHAR(50) NOT NULL
	CONSTRAINT FK_Role_User FOREIGN KEY (RoleId) REFERENCES AppRole(Id)
)