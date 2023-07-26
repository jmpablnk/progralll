-- proyecto final progra 3
--1
USE master
GO
CREATE DATABASE [Proyecto_Final_Gestion_Proyectos]
GO

--2 schemas

USE [Proyecto_Final_Gestion_Proyectos]
GO
CREATE SCHEMA [Schema_Auth]
GO
CREATE SCHEMA [Schema_Proyectos]
GO
CREATE SCHEMA [Schema_Tareas]
GO
CREATE SCHEMA [Schema_General]
GO


--3 tablas
USE [Proyecto_Final_Gestion_Proyectos]

CREATE TABLE [Schema_Auth].[T_Rol]
(
    [Id_Rol] int NOT NULL,
    [Nombre_Rol] VARCHAR(50) NOT NULL,
    [Descripcion] VARCHAR(100) NOT NULL,
)
GO
ALTER TABLE [Schema_Auth].[T_Rol]

    ADD CONSTRAINT [pk_Roles] PRIMARY KEY CLUSTERED
    (
        [Id_Rol] ASC
    )
GO

CREATE TABLE [Schema_Proyectos].[T_Proyecto]
(
    [Id_Proyecto] int NOT NULL,
    [Titulo] VARCHAR(100) NOT NULL,
    [Descripcion] VARCHAR(255) NOT NULL,
    [FechaInicio] DATE,
    [FechaFin] DATE,
)
GO
ALTER TABLE [Schema_Proyectos].[T_Proyecto]

    ADD CONSTRAINT [pk_Proyecto] PRIMARY KEY CLUSTERED
    (
        [Id_Proyecto] ASC
    )
GO



CREATE TABLE [Schema_Proyectos].[T_Usuario_Proyecto]
(
    [Id_Usuario_Proyecto] INT NOT NULL,
    [Id_Usuario] INT NOT NULL,
    [Id_Proyecto] INT NOT NULL,
    [Id_Rol] INT NOT NULL,    
)
GO
ALTER TABLE [Schema_Proyectos].[T_Usuario_Proyecto]

    ADD CONSTRAINT [pk_Usuario_Proyecto] PRIMARY KEY CLUSTERED
    (
        [Id_Usuario_Proyecto] ASC
    )
GO


CREATE TABLE [Schema_General].[T_Usuario]
(
    [Id_Usuario] INT NOT NULL,
    [NombreUsuario] VARCHAR(50) NOT NULL,
    [Contrasena] VARCHAR(100) NOT NULL,
    [Rol] VARCHAR(50),
);

ALTER TABLE [Schema_General].[T_Usuario]

    ADD CONSTRAINT [pk_Usuario] PRIMARY KEY CLUSTERED
    (
        [Id_Usuario] ASC
    )
GO


CREATE TABLE [Schema_Tareas].[T_Tarea]
(
    [Id_Tarea] INT NOT NULL,
    [Titulo] VARCHAR(100) NOT NULL,
    [Descripcion] VARCHAR(255),
    [NivelDificultad] INT,
    [FechaInicio] DATE,
    [FechaFin] DATE,
    [Id_Usuario] INT,
    [Id_Proyecto] INT,
);



ALTER TABLE [Schema_Tareas].[T_Tarea]

    ADD CONSTRAINT [pk_Tarea] PRIMARY KEY CLUSTERED
    (
        [Id_Tarea] ASC
    )
GO


CREATE TABLE [Schema_Tareas].[T_Nivel_Dificultad]
(
    [Id_Nivel_Dificultad] INT NOT NULL,
    [Nivel] INT NOT NULL,
    [Descripcion] VARCHAR(255)
);

ALTER TABLE [Schema_Tareas].[T_Nivel_Dificultad]

    ADD CONSTRAINT [pk_Nivel_Dificultad] PRIMARY KEY CLUSTERED
    (
        [Id_Nivel_Dificultad] ASC
    )
GO

CREATE TABLE  [Schema_Tareas].[T_Estado_Tarea]
(
    [Id_Estado_Tarea] INT NOT NULL,
    [Estado] VARCHAR(50) NOT NULL,
    [Descripcion] VARCHAR(255)
);
ALTER TABLE [Schema_Tareas].[T_Estado_Tarea]

    ADD CONSTRAINT [pk_Estado_Tarea] PRIMARY KEY CLUSTERED
    (
        [Id_Estado_Tarea] ASC
    )
GO


CREATE TABLE  [Schema_Tareas].[T_Usuario_Tarea]
(
    Id_Usuario_Tarea INT NOT NULL,
    Id_Usuario INT NOT NULL,
    Id_Tarea INT NOT NULL,
);



--************** Foreign Keys *********************


ALTER TABLE [Schema_Proyectos].[T_Usuario_Proyecto] WITH NOCHECK
    ADD CONSTRAINT [fk_Usuario_Proyecto_Usuario_Id_Usuario]
    FOREIGN KEY (Id_Usuario)
    REFERENCES [Schema_General].[T_Usuario] ([Id_Usuario])

GO

ALTER TABLE [Schema_Proyectos].[T_Usuario_Proyecto] CHECK CONSTRAINT [fk_Usuario_Proyecto_Usuario_Id_Usuario]

GO


ALTER TABLE [Schema_Tareas].[T_Tarea] WITH NOCHECK
    ADD CONSTRAINT [fk_Tarea_Usuario_Id_Usuario]
    FOREIGN KEY (Id_Usuario)
    REFERENCES [Schema_General].[T_Usuario] ([Id_Usuario])

GO

ALTER TABLE [Schema_Tareas].[T_Tarea] CHECK CONSTRAINT [fk_Tarea_Usuario_Id_Usuario]

GO

ALTER TABLE [Schema_Tareas].[T_Tarea] WITH NOCHECK
    ADD CONSTRAINT [fk_Tarea_Proyecto_Id_Proyecto]
    FOREIGN KEY (Id_Proyecto)
    REFERENCES [Schema_Proyectos].[T_Proyecto] ([Id_Proyecto])

GO


ALTER TABLE [Schema_Tareas].[T_Tarea] CHECK CONSTRAINT [fk_Tarea_Proyecto_Id_Proyecto]

GO




ALTER TABLE [Schema_Tareas].[T_Usuario_Tarea] WITH NOCHECK
    ADD CONSTRAINT [fk_Usuario_Tarea_Usuario_Id_Usuario]
    FOREIGN KEY (Id_Usuario)
    REFERENCES [Schema_General].[T_Usuario] ([Id_Usuario])

GO

ALTER TABLE [Schema_Tareas].[T_Usuario_Tarea]  CHECK CONSTRAINT [fk_Usuario_Tarea_Usuario_Id_Usuario]

GO


ALTER TABLE [Schema_Tareas].[T_Usuario_Tarea] WITH NOCHECK
    ADD CONSTRAINT [fk_Usuario_Tarea_Tarea_Id_Tarea]
    FOREIGN KEY (Id_Tarea)
    REFERENCES [Schema_Tareas].[T_Tarea] ([Id_Tarea])

GO

ALTER TABLE [Schema_Tareas].[T_Usuario_Tarea]  CHECK CONSTRAINT [fk_Usuario_Tarea_Tarea_Id_Tarea]

GO