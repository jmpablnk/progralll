USE [master]
GO

create DATABASE [PROYECTO-FINAL]
GO

USE [PROYECTO-FINAL]
GO

CREATE SCHEMA [SCH_PROYECTOS]
GO

CREATE SCHEMA [SCH_SEGURIDAD]
GO

CREATE SCHEMA [SCH_USUARIO]
GO

--PROYECTOS
CREATE TABLE [SCH_PROYECTOS].[T_PROYECTO](
    [ID_PROYECTO] INT NOT NULL,
    [TITULO] VARCHAR(100) NOT NULL,
    [DESCRIPCION] VARCHAR(200) NOT NULL,
    [FECHA_INICIO] DATE NOT NULL,
    [FECHA_FIN] DATE NOT NULL,
    CONSTRAINT [PK_ID_PROYECTO] PRIMARY KEY CLUSTERED 
	(
        [ID_PROYECTO] ASC
    )
)

--ROLES
CREATE TABLE [SCH_SEGURIDAD].[T_ROLES](
    [ID_ROL] INT NOT NULL,
    [NOMBRE_ROL] VARCHAR(50) NOT NULL,

    CONSTRAINT [PK_ID_ROL] PRIMARY KEY CLUSTERED 
	(
        [ID_ROL] ASC
    )
)
--USUARIO

CREATE TABLE [SCH_USUARIO].[T_USUARIO](
    [ID_USUARIO] INT  NOT NULL,
    [USUARIO] VARCHAR(50) NOT NULL,
    [CONTRASENA] VARCHAR(50) NOT NULL,
    [CEDULA] VARCHAR(25) NOT NULL,
    [ID_ROL] INT NOT NULL,
    CONSTRAINT [PK_ID_USUARIO] PRIMARY KEY CLUSTERED 
	(
        [ID_USUARIO] ASC
    )
)

--TAREA

CREATE TABLE [SCH_PROYECTOS].[T_TAREA](
    [ID_TAREA] INT NOT NULL,
    [ID_PROYECTO] INT NOT NULL,
    [TITULO] VARCHAR(100) NOT NULL,
    [DESCRIPCION] VARCHAR(200) NOT NULL,
    [NIVEL_DIFICULTAD] TINYINT NOT NULL,
    [FECHA_INICIO] DATE NOT NULL,
    [FECHA_FIN] DATE NOT NULL,
    [ID_USUARIO] INT NOT NULL,
    CONSTRAINT [PK_ID_TAREA] PRIMARY KEY CLUSTERED (
        [ID_TAREA] ASC
    )
)


-- LLAVES FORANEAS

ALTER TABLE [SCH_PROYECTOS].[T_TAREA] WITH NOCHECK
ADD CONSTRAINT [FK_ID_PROYECTO_TAREA] FOREIGN KEY ([ID_PROYECTO]) 
REFERENCES [SCH_PROYECTOS].[T_PROYECTO]([ID_PROYECTO])
GO

ALTER TABLE [SCH_PROYECTOS].[T_TAREA]
CHECK CONSTRAINT [FK_ID_PROYECTO_TAREA]
GO

ALTER TABLE [SCH_PROYECTOS].[T_TAREA] WITH NOCHECK
ADD CONSTRAINT [FK_ID_USUARIO_TAREA] FOREIGN KEY ([ID_USUARIO]) 
REFERENCES [SCH_USUARIO].[T_USUARIO]([ID_USUARIO])
GO

ALTER TABLE[SCH_PROYECTOS].[T_TAREA]
CHECK CONSTRAINT [FK_ID_USUARIO_TAREA]
GO

ALTER TABLE [SCH_USUARIO].[T_USUARIO]
ADD CONSTRAINT [FK_ID_ROL_USUARIO] FOREIGN KEY ([ID_ROL]) 
REFERENCES [SCH_SEGURIDAD].[T_ROLES]([ID_ROL])
GO

ALTER TABLE [SCH_USUARIO].[T_USUARIO]
CHECK CONSTRAINT [FK_ID_ROL_USUARIO]
GO