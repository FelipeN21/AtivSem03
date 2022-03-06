IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Carros] (
    [Id] int NOT NULL IDENTITY,
    [documento] int NOT NULL,
    [modelo] nvarchar(max) NOT NULL,
    [placa] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Carros] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Alunos] (
    [Id] int NOT NULL IDENTITY,
    [matricula] int NOT NULL,
    [nome] nvarchar(max) NOT NULL,
    [telefone] nvarchar(max) NOT NULL,
    [carroId] int NOT NULL,
    CONSTRAINT [PK_Alunos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Alunos_Carros_carroId] FOREIGN KEY ([carroId]) REFERENCES [Carros] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Alunos_carroId] ON [Alunos] ([carroId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220305170501_initial', N'6.0.2');
GO

INSERT INTO Carros (documento, modelo, placa)
VALUES (7071, 'Palio', 'OQQ-1414');
GO
INSERT INTO Carros (documento, modelo, placa)
VALUES (7072, 'ASX', 'OQO-1414');
GO
INSERT INTO Carros (documento, modelo, placa)
VALUES (7073, 'Fusca', 'OQK-1414');
GO
INSERT INTO Carros (documento, modelo, placa)
VALUES (7074, 'Uno', 'OQI-1414');
GO
INSERT INTO Carros (documento, modelo, placa)
VALUES (7075, 'Mareia', 'OQA-1414');
GO
INSERT INTO Alunos (matricula, nome, telefone, carroId)
VALUES (2021, 'Felipe Nepomuceno Coelho', 31984049627,1);
GO
INSERT INTO Alunos (matricula, nome, telefone, carroId)
VALUES (2022, 'Rodrigo Safar', 319840575627,2);
GO
INSERT INTO Alunos (matricula, nome, telefone, carroId)
VALUES (2023, 'Rodrigo Fentanes', 31984899627,3);
GO
INSERT INTO Alunos (matricula, nome, telefone, carroId)
VALUES (2024, 'Lucas Nutriaol', 31984049645,4);
GO
INSERT INTO Alunos (matricula, nome, telefone, carroId)
VALUES (2025, 'Roberto Montreali', 31984049667,5);
GO

COMMIT;
GO

