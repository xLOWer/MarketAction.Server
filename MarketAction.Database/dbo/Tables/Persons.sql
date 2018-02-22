CREATE TABLE [dbo].[Persons] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]   DATETIME2 (7)    NOT NULL,
    [Email]        NVARCHAR (MAX)   NULL,
    [FirstName]    NVARCHAR (MAX)   NULL,
    [IsRemoved]    BIT              NOT NULL,
    [LastEditDate] DATETIME2 (7)    NOT NULL,
    [LastName]     NVARCHAR (MAX)   NULL,
    [PhoneNumber]  NVARCHAR (MAX)   NULL,
    [RemoveDate]   DATETIME2 (7)    NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Persons_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([PersonId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Persons_UserId]
    ON [dbo].[Persons]([UserId] ASC);

