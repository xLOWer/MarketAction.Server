CREATE TABLE [dbo].[Catalogues] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]     DATETIME2 (7)    NOT NULL,
    [GoodId]         UNIQUEIDENTIFIER NULL,
    [IsRemoved]      BIT              NOT NULL,
    [LastEditDate]   DATETIME2 (7)    NOT NULL,
    [Name]           NVARCHAR (MAX)   NULL,
    [RemoveDate]     DATETIME2 (7)    NULL,
    [TradeNetworkId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Catalogues] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Catalogues_Goods_GoodId] FOREIGN KEY ([GoodId]) REFERENCES [dbo].[Goods] ([Id]),
    CONSTRAINT [FK_Catalogues_TradeNetworks_TradeNetworkId] FOREIGN KEY ([TradeNetworkId]) REFERENCES [dbo].[TradeNetworks] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Catalogues_GoodId]
    ON [dbo].[Catalogues]([GoodId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Catalogues_TradeNetworkId]
    ON [dbo].[Catalogues]([TradeNetworkId] ASC);

