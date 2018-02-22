CREATE TABLE [dbo].[Goods] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Cost]         DECIMAL (18, 2)  NULL,
    [CreateDate]   DATETIME2 (7)    NOT NULL,
    [Description]  NVARCHAR (MAX)   NULL,
    [IsRemoved]    BIT              NOT NULL,
    [LastEditDate] DATETIME2 (7)    NOT NULL,
    [Name]         NVARCHAR (MAX)   NULL,
    [RemoveDate]   DATETIME2 (7)    NULL,
    [Weight]       DECIMAL (18, 2)  NULL,
    CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED ([Id] ASC)
);

