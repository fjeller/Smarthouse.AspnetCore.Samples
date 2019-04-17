ALTER TABLE [TodoItems] ADD [Description] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190416084359_migv2', N'2.2.3-servicing-35854');

GO

