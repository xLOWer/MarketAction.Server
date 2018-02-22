CREATE TABLE [dbo].[Actions] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Cost]            DECIMAL (18, 2)  NULL,
    [CreateDate]      DATETIME2 (7)    NOT NULL,
    [DateActionEnd]   DATETIME2 (7)    NULL,
    [DateActionStart] DATETIME2 (7)    NULL,
    [Description]     NVARCHAR (MAX)   NULL,
    [GoodId]          UNIQUEIDENTIFIER NULL,
    [IsRemoved]       BIT              NOT NULL,
    [LastEditDate]    DATETIME2 (7)    NOT NULL,
    [Name]            NVARCHAR (MAX)   NULL,
    [NewCost]         NVARCHAR (MAX)   NULL,
    [RemoveDate]      DATETIME2 (7)    NULL,
    [SalePercent]     NVARCHAR (MAX)   NULL,
    [Weight]          DECIMAL (18, 2)  NULL,
    CONSTRAINT [PK_Actions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Actions_Goods_GoodId] FOREIGN KEY ([GoodId]) REFERENCES [dbo].[Goods] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Actions_GoodId]
    ON [dbo].[Actions]([GoodId] ASC);

