
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2025 19:08:53
-- Generated from EDMX file: C:\Users\Alumnos MCSD Tarde\LaboratorioGit\laboratorio\C\ApuntesClase\EjercicioLinqClase\EjercicioLinqClase\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [miTiendaDB];
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

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [IdCliente] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [IdProducto] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [UnitPrice] float  NOT NULL
);
GO

-- Creating table 'Ordenes'
CREATE TABLE [dbo].[Ordenes] (
    [IdOrden] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [Cliente] int  NOT NULL,
    [Producto] int  NOT NULL,
    [Cliente1_IdCliente] int  NOT NULL,
    [Producto1_IdProducto] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCliente] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([IdCliente] ASC);
GO

-- Creating primary key on [IdProducto] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([IdProducto] ASC);
GO

-- Creating primary key on [IdOrden] in table 'Ordenes'
ALTER TABLE [dbo].[Ordenes]
ADD CONSTRAINT [PK_Ordenes]
    PRIMARY KEY CLUSTERED ([IdOrden] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cliente1_IdCliente] in table 'Ordenes'
ALTER TABLE [dbo].[Ordenes]
ADD CONSTRAINT [FK_ClienteOrden]
    FOREIGN KEY ([Cliente1_IdCliente])
    REFERENCES [dbo].[Clientes]
        ([IdCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteOrden'
CREATE INDEX [IX_FK_ClienteOrden]
ON [dbo].[Ordenes]
    ([Cliente1_IdCliente]);
GO

-- Creating foreign key on [Producto1_IdProducto] in table 'Ordenes'
ALTER TABLE [dbo].[Ordenes]
ADD CONSTRAINT [FK_ProductoOrden]
    FOREIGN KEY ([Producto1_IdProducto])
    REFERENCES [dbo].[Productos]
        ([IdProducto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoOrden'
CREATE INDEX [IX_FK_ProductoOrden]
ON [dbo].[Ordenes]
    ([Producto1_IdProducto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------