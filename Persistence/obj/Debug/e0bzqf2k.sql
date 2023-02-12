IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'SD') IS NULL EXEC(N'CREATE SCHEMA [SD];');

GO

CREATE TABLE [SD].[TypeOfusers] (
    [TypeOfUserId] int NOT NULL IDENTITY,
    [TypeOfUserName] varchar(50) NOT NULL,
    [TypeOfUserDescription] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_TypeOfusers] PRIMARY KEY ([TypeOfUserId])
);

GO

CREATE TABLE [SD].[Users] (
    [UserId] int NOT NULL IDENTITY,
    [UserName] varchar(50) NOT NULL,
    [UserLastName] varchar(50) NOT NULL,
    [TypeOfUserId] int NOT NULL,
    [UserAdress] nvarchar(50) NOT NULL,
    [UserTelephone] nvarchar(50) NOT NULL,
    [UserEmail] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_Users_Users_TypeOfUserId] FOREIGN KEY ([TypeOfUserId]) REFERENCES [SD].[Users] ([UserId])
);

GO

CREATE INDEX [IX_Users_TypeOfUserId] ON [SD].[Users] ([TypeOfUserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230210225123_Initialize', N'3.1.0');

GO

