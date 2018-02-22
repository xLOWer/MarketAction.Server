CREATE TABLE [dbo].[AccessLevels] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]         DATETIME2 (7)    NOT NULL,
    [IsRemoved]          BIT              NOT NULL,
    [LastEditDate]       DATETIME2 (7)    NOT NULL,
    [Name]               NVARCHAR (MAX)   NULL,
    [ReadAccessLevels]   BIT              NOT NULL,
    [ReadAll]            BIT              NOT NULL,
    [ReadCatalogues]     BIT              NOT NULL,
    [ReadGoods]          BIT              NOT NULL,
    [ReadPersons]        BIT              NOT NULL,
    [ReadStamps]         BIT              NOT NULL,
    [ReadTradeNetworks]  BIT              NOT NULL,
    [ReadUsers]          BIT              NOT NULL,
    [RemoveDate]         DATETIME2 (7)    NULL,
    [UserId]             UNIQUEIDENTIFIER NULL,
    [WriteAccessLevels]  BIT              NOT NULL,
    [WriteAll]           BIT              NOT NULL,
    [WriteCatalogues]    BIT              NOT NULL,
    [WriteGoods]         BIT              NOT NULL,
    [WritePersons]       BIT              NOT NULL,
    [WriteStamps]        BIT              NOT NULL,
    [WriteTradeNetworks] BIT              NOT NULL,
    [WriteUsers]         BIT              NOT NULL,
    CONSTRAINT [PK_AccessLevels] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccessLevels_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccessLevels_UserId]
    ON [dbo].[AccessLevels]([UserId] ASC);

