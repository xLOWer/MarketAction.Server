CREATE TABLE [dbo].[TradeNetworks] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]   DATETIME2 (7)    NOT NULL,
    [Description]  NVARCHAR (MAX)   NULL,
    [Email]        NVARCHAR (MAX)   NULL,
    [IsRemoved]    BIT              NOT NULL,
    [LastEditDate] DATETIME2 (7)    NOT NULL,
    [Name]         NVARCHAR (MAX)   NULL,
    [RemoveDate]   DATETIME2 (7)    NULL,
    CONSTRAINT [PK_TradeNetworks] PRIMARY KEY CLUSTERED ([Id] ASC)
);

