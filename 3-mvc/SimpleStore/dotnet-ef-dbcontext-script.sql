CREATE TABLE [Locations] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(80) NULL,
    [Stock] int NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_Location_Stock_Nonnegative] CHECK ([Stock] >= 0)
);
GO


CREATE TABLE [Orders] (
    [Id] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [LocationId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Locations_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [Locations] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Orders_LocationId] ON [Orders] ([LocationId]);
GO


