CREATE TABLE [dbo].[Users] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]    DATETIME2 (7)    NOT NULL,
    [IsRemoved]     BIT              NOT NULL,
    [LastEditDate]  DATETIME2 (7)    NOT NULL,
    [LastEntryDate] DATETIME2 (7)    NOT NULL,
    [Login]         NVARCHAR (MAX)   NULL,
    [Password]      NVARCHAR (MAX)   NULL,
    [PersonId]      UNIQUEIDENTIFIER NOT NULL,
    [RemoveDate]    DATETIME2 (7)    NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AK_Users_PersonId] UNIQUE NONCLUSTERED ([PersonId] ASC)
);

