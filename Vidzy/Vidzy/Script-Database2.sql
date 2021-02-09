IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Genres] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Videos] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [ReleaseTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Videos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [VideoGenre] (
    [VideoId] int NOT NULL,
    [GenreId] int NOT NULL,
    CONSTRAINT [PK_VideoGenre] PRIMARY KEY ([GenreId], [VideoId]),
    CONSTRAINT [FK_VideoGenre_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_VideoGenre_Videos_VideoId] FOREIGN KEY ([VideoId]) REFERENCES [Videos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_VideoGenre_VideoId] ON [VideoGenre] ([VideoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210209101012_InitialCreate', N'3.1.11');

GO

INSERT INTO Genres VALUES ('Action')

GO

INSERT INTO Genres VALUES ('History')

GO

INSERT INTO Genres VALUES ('Comedy')

GO

INSERT INTO Genres VALUES ('SciFi')

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210209101456_PopulateGenresTable', N'3.1.11');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Videos]') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Videos] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Videos] ALTER COLUMN [Name] nvarchar(100) NOT NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Genres]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Genres] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Genres] ALTER COLUMN [Name] nvarchar(100) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210209102604_AddDataAnnotationsToEntitites', N'3.1.11');

GO

ALTER TABLE [Videos] ADD [GenreId] int NULL;

GO

UPDATE Videos SET Videos.GenreId = VideoGenre.GenreId FROM Videos INNER JOIN VideoGenre ON Videos.Id = VideoGenre.VideoId

GO

CREATE INDEX [IX_Videos_GenreId] ON [Videos] ([GenreId]);

GO

ALTER TABLE [Videos] ADD CONSTRAINT [FK_Videos_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE NO ACTION;

GO

DROP TABLE [VideoGenre];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210209154559_UpdateRelationshipToOneToMany', N'3.1.11');

GO

ALTER TABLE [Videos] ADD [Classification] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210209164753_AddClassificationToVideosTable', N'3.1.11');

GO

ALTER TABLE [Videos] DROP CONSTRAINT [FK_Videos_Genres_GenreId];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Videos]') AND [c].[name] = N'Name');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Videos] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Videos] ALTER COLUMN [Name] nvarchar(255) NOT NULL;

GO

DROP INDEX [IX_Videos_GenreId] ON [Videos];
DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Videos]') AND [c].[name] = N'GenreId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Videos] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Videos] ALTER COLUMN [GenreId] int NOT NULL;
CREATE INDEX [IX_Videos_GenreId] ON [Videos] ([GenreId]);

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Videos]') AND [c].[name] = N'Classification');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Videos] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Videos] ALTER COLUMN [Classification] tinyint NOT NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Genres]') AND [c].[name] = N'Name');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Genres] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Genres] ALTER COLUMN [Name] nvarchar(255) NOT NULL;

GO

ALTER TABLE [Videos] ADD CONSTRAINT [FK_Videos_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210209214110_AddFluentAPIToVideoAndGenresTables', N'3.1.11');

GO

