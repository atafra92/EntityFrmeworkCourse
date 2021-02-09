IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Tags] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Courses] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Description] nvarchar(2000) NOT NULL,
    [Level] int NOT NULL,
    [FullPrice] real NOT NULL,
    [AuthorId] int NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Courses_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [CourseTags] (
    [CourseId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_CourseTags] PRIMARY KEY ([CourseId], [TagId]),
    CONSTRAINT [FK_CourseTags_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CourseTags_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Cover] (
    [Id] int NOT NULL,
    CONSTRAINT [PK_Cover] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cover_Courses_Id] FOREIGN KEY ([Id]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Courses_AuthorId] ON [Courses] ([AuthorId]);

GO

CREATE INDEX [IX_CourseTags_TagId] ON [CourseTags] ([TagId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210209211157_InitialCreate', N'3.1.11');

GO

