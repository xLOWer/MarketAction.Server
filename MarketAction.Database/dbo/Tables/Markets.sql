CREATE TABLE [dbo].[Markets] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Address]        NVARCHAR (MAX)   NULL,
    [CreateDate]     DATETIME2 (7)    NOT NULL,
    [Description]    NVARCHAR (MAX)   NULL,
    [Email]          NVARCHAR (MAX)   NULL,
    [GoodId]         UNIQUEIDENTIFIER NULL,
    [IsRemoved]      BIT              NOT NULL,
    [LastEditDate]   DATETIME2 (7)    NOT NULL,
    [Name]           NVARCHAR (MAX)   NULL,
    [RemoveDate]     DATETIME2 (7)    NULL,
    [TradeNetworkId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Markets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Markets_Goods_GoodId] FOREIGN KEY ([GoodId]) REFERENCES [dbo].[Goods] ([Id]),
    CONSTRAINT [FK_Markets_TradeNetworks_TradeNetworkId] FOREIGN KEY ([TradeNetworkId]) REFERENCES [dbo].[TradeNetworks] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Markets_GoodId]
    ON [dbo].[Markets]([GoodId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Markets_TradeNetworkId]
    ON [dbo].[Markets]([TradeNetworkId] ASC);

