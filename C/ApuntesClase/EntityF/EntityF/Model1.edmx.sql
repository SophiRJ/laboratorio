
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/30/2025 00:34:58
-- Generated from EDMX file: C:\laboratorio\C\ApuntesClase\EntityF\EntityF\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Veterinaria];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [IdPersona] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clase_Animales'
CREATE TABLE [dbo].[Clase_Animales] (
    [IdClase] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Mascotas'
CREATE TABLE [dbo].[Mascotas] (
    [IdMascota] int IDENTITY(1,1) NOT NULL,
    [Clase] int  NOT NULL,
    [Persona] int  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Clase_Animal_IdClase] int  NOT NULL,
    [Persona1_IdPersona] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdPersona] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([IdPersona] ASC);
GO

-- Creating primary key on [IdClase] in table 'Clase_Animales'
ALTER TABLE [dbo].[Clase_Animales]
ADD CONSTRAINT [PK_Clase_Animales]
    PRIMARY KEY CLUSTERED ([IdClase] ASC);
GO

-- Creating primary key on [IdMascota] in table 'Mascotas'
ALTER TABLE [dbo].[Mascotas]
ADD CONSTRAINT [PK_Mascotas]
    PRIMARY KEY CLUSTERED ([IdMascota] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Clase_Animal_IdClase] in table 'Mascotas'
ALTER TABLE [dbo].[Mascotas]
ADD CONSTRAINT [FK_Clase_AnimalMascota]
    FOREIGN KEY ([Clase_Animal_IdClase])
    REFERENCES [dbo].[Clase_Animales]
        ([IdClase])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Clase_AnimalMascota'
CREATE INDEX [IX_FK_Clase_AnimalMascota]
ON [dbo].[Mascotas]
    ([Clase_Animal_IdClase]);
GO

-- Creating foreign key on [Persona1_IdPersona] in table 'Mascotas'
ALTER TABLE [dbo].[Mascotas]
ADD CONSTRAINT [FK_PersonaMascota]
    FOREIGN KEY ([Persona1_IdPersona])
    REFERENCES [dbo].[Personas]
        ([IdPersona])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaMascota'
CREATE INDEX [IX_FK_PersonaMascota]
ON [dbo].[Mascotas]
    ([Persona1_IdPersona]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------