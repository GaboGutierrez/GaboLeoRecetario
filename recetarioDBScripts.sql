USE [master]
GO
/****** Object:  Database [Recetario]    Script Date: 06/03/2016 07:11:48 p. m. ******/
CREATE DATABASE [Recetario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Recetario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Recetario.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Recetario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Recetario_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Recetario] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Recetario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Recetario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Recetario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Recetario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Recetario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Recetario] SET ARITHABORT OFF 
GO
ALTER DATABASE [Recetario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Recetario] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Recetario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Recetario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Recetario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Recetario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Recetario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Recetario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Recetario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Recetario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Recetario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Recetario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Recetario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Recetario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Recetario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Recetario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Recetario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Recetario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Recetario] SET RECOVERY FULL 
GO
ALTER DATABASE [Recetario] SET  MULTI_USER 
GO
ALTER DATABASE [Recetario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Recetario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Recetario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Recetario] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Recetario', N'ON'
GO
USE [Recetario]
GO
/****** Object:  StoredProcedure [dbo].[spBuscarRecetas]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec spBuscarRecetas 'to', 0, '', 0, 0, 0
CREATE PROCEDURE [dbo].[spBuscarRecetas]
    (
      @Nombre NVARCHAR(50) ,
      @TipoId INT ,
      @Ingredientes NVARCHAR(50) ,
      @Tiempo INT ,
      @Porciones INT ,
      @DificultadId INT
    )
AS
    BEGIN
        DECLARE @query NVARCHAR(MAX);
        SET @query = 'SELECT  RECE_ID ,
                RECE_NOMB ,
                RECE_INGR ,
                RECE_DESC ,
                RECE_TIPO_ID ,
                TIPO_ID ,
                TIPO_NOMB ,
                RECE_DIFI_ID ,
                DIFI_ID ,
                DIFI_NOMB ,
                RECE_PORC ,
                RECE_TIEM ,
                RECE_FOTO ,
                RECE_VIDE ,
                RECE_FECH_ALTA
        FROM    dbo.RECETA
                INNER JOIN dbo.TIPO ON RECE_TIPO_ID = TIPO_ID
                INNER JOIN dbo.DIFICULTAD ON RECE_DIFI_ID = DIFI_ID
        WHERE   RECE_NOMB <> ''''';
        IF @Nombre <> ''
            BEGIN 
                SET @query = @query + ' AND RECE_NOMB LIKE''%' + @Nombre
                    + '%''';
            END;
        IF @TipoId <> 0
            BEGIN
                SET @query = @query + 'AND RECE_TIPO_ID = ' + @TipoId;
            END;
        IF @Ingredientes <> ''
            BEGIN
                SET @query = @query + ' AND RECE_INGR LIKE''%' + @Ingredientes
                    + '%''';
            END;
        IF @Tiempo <> 0
            BEGIN
                SET @query = @query + 'AND RECE_TIEM = ' + @Tiempo;
            END;
        IF @Porciones <> 0
            BEGIN
                SET @query = @query + 'AND RECE_PORC = ' + @Porciones;
            END;
        IF @DificultadId <> 0
            BEGIN
                SET @query = @query + 'AND RECE_DIFI_ID = ' + @DificultadId;
            END;
        PRINT ( @query );
        EXEC (@query);
    END;
        
GO
/****** Object:  StoredProcedure [dbo].[spCargarDificultad]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--spCargarDificultad
CREATE PROC [dbo].[spCargarDificultad]
AS
    BEGIN
        SELECT DIFI_ID ,
               DIFI_NOMB
        FROM    dbo.DIFICULTAD;

    END;

GO
/****** Object:  StoredProcedure [dbo].[spCargarRecetas]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec spCargarRecetas
CREATE PROCEDURE [dbo].[spCargarRecetas]
AS
    BEGIN


        SELECT  RECE_ID ,
                RECE_NOMB ,
                RECE_INGR ,
                RECE_DESC ,
                RECE_TIPO_ID ,
                TIPO_ID ,
                TIPO_NOMB ,
                RECE_DIFI_ID ,
                DIFI_ID ,
                DIFI_NOMB ,
                RECE_PORC ,
                RECE_TIEM ,
                RECE_FOTO ,
                RECE_VIDE ,
                RECE_FECH_ALTA
        FROM    dbo.RECETA
                INNER JOIN dbo.TIPO ON RECE_TIPO_ID = TIPO_ID
                INNER JOIN dbo.DIFICULTAD ON RECE_DIFI_ID = DIFI_ID;
    END;
        
GO
/****** Object:  StoredProcedure [dbo].[spCargarRecetasId]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec spCargarRecetasId 0
CREATE PROCEDURE [dbo].[spCargarRecetasId] @Id INT
AS
    BEGIN
        SELECT  RECE_ID ,
                RECE_NOMB ,
                RECE_INGR ,
                RECE_DESC ,
                RECE_TIPO_ID ,
                TIPO_ID ,
                TIPO_NOMB ,
                RECE_DIFI_ID ,
                DIFI_ID ,
                DIFI_NOMB ,
                RECE_PORC ,
                RECE_TIEM ,
                RECE_FOTO ,
                RECE_VIDE ,
                RECE_FECH_ALTA
        FROM    dbo.RECETA
                INNER JOIN dbo.TIPO ON RECE_TIPO_ID = TIPO_ID
                INNER JOIN dbo.DIFICULTAD ON RECE_DIFI_ID = DIFI_ID
        WHERE   RECE_ID = @Id;
    END;
        
GO
/****** Object:  StoredProcedure [dbo].[spCargarRecetasNuevas]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec spCargarRecetasNuevas
CREATE PROCEDURE [dbo].[spCargarRecetasNuevas]
AS
    BEGIN
        SELECT TOP 5
                RECE_ID ,
                RECE_NOMB ,
                RECE_INGR ,
                RECE_DESC ,
                RECE_TIPO_ID ,
                TIPO_ID ,
                TIPO_NOMB ,
                RECE_DIFI_ID ,
                DIFI_ID ,
                DIFI_NOMB ,
                RECE_PORC ,
                RECE_TIEM ,
                RECE_FOTO ,
                RECE_VIDE ,
                RECE_FECH_ALTA
        FROM    dbo.RECETA
                INNER JOIN dbo.DIFICULTAD ON RECE_DIFI_ID = DIFI_ID
                INNER JOIN dbo.TIPO ON RECE_TIPO_ID = TIPO_ID
        ORDER BY RECE_FECH_ALTA DESC;
    END;
GO
/****** Object:  StoredProcedure [dbo].[spCargarTipos]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--spCargarTipos
CREATE PROC [dbo].[spCargarTipos]
AS
    BEGIN
        SELECT  TIPO_ID ,
                TIPO_NOMB
        FROM    dbo.TIPO;

    END;

GO
/****** Object:  StoredProcedure [dbo].[spRegistrarReceta]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec spRegistrarReceta 'prueba2',2,'prueba2 ingredientes','prueba2 elaboracion',1,5,'08/20/2015',2,'prueba2 video','prueba2 foto'
CREATE PROCEDURE [dbo].[spRegistrarReceta]
    (
      @Nombre NVARCHAR(50) ,
      @TipoId INT ,
      @Ingredientes NVARCHAR(MAX) ,
      @Elaboracion NVARCHAR(MAX) ,
      @Tiempo INT ,
      @Porciones INT ,
      @FechaAlta DATETIME ,
      @DificultadId INT ,
      @Video NVARCHAR(MAX) ,
      @Foto NVARCHAR(MAX)
    )
AS
    BEGIN
        INSERT  dbo.RECETA
                ( RECE_ID ,
                  RECE_NOMB ,
                  RECE_INGR ,
                  RECE_DESC ,
                  RECE_TIPO_ID ,
                  RECE_DIFI_ID ,
                  RECE_PORC ,
                  RECE_TIEM ,
                  RECE_FOTO ,
                  RECE_VIDE ,
                  RECE_FECH_ALTA
                )
        VALUES  ( ( SELECT  ISNULL(MAX(RECE_ID) + 1, 1)
                    FROM    dbo.RECETA
                  ) ,
                  @Nombre ,
                  @Ingredientes ,
                  @Elaboracion ,
                  @TipoId ,
                  @DificultadId ,
                  @Porciones ,
                  @Tiempo ,
                  @Foto ,
                  @Video ,
                  @FechaAlta
                );
    END;
GO
/****** Object:  Table [dbo].[DIFICULTAD]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIFICULTAD](
	[DIFI_ID] [int] NOT NULL,
	[DIFI_NOMB] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DIFICULTAD] PRIMARY KEY CLUSTERED 
(
	[DIFI_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RECETA]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RECETA](
	[RECE_ID] [int] NOT NULL,
	[RECE_NOMB] [nvarchar](50) NOT NULL,
	[RECE_INGR] [nvarchar](max) NOT NULL,
	[RECE_DESC] [nvarchar](max) NOT NULL,
	[RECE_TIPO_ID] [int] NOT NULL,
	[RECE_DIFI_ID] [int] NOT NULL,
	[RECE_PORC] [int] NOT NULL,
	[RECE_TIEM] [int] NOT NULL,
	[RECE_FOTO] [nvarchar](max) NOT NULL,
	[RECE_VIDE] [nvarchar](max) NOT NULL,
	[RECE_FECH_ALTA] [datetime] NOT NULL,
 CONSTRAINT [PK_RECETA] PRIMARY KEY CLUSTERED 
(
	[RECE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIPO]    Script Date: 06/03/2016 07:11:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO](
	[TIPO_ID] [int] NOT NULL,
	[TIPO_NOMB] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TIPO] PRIMARY KEY CLUSTERED 
(
	[TIPO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[RECETA]  WITH CHECK ADD  CONSTRAINT [FK_RECETA_DIFICULTAD] FOREIGN KEY([RECE_DIFI_ID])
REFERENCES [dbo].[DIFICULTAD] ([DIFI_ID])
GO
ALTER TABLE [dbo].[RECETA] CHECK CONSTRAINT [FK_RECETA_DIFICULTAD]
GO
ALTER TABLE [dbo].[RECETA]  WITH CHECK ADD  CONSTRAINT [FK_RECETA_TIPO] FOREIGN KEY([RECE_TIPO_ID])
REFERENCES [dbo].[TIPO] ([TIPO_ID])
GO
ALTER TABLE [dbo].[RECETA] CHECK CONSTRAINT [FK_RECETA_TIPO]
GO
USE [master]
GO
ALTER DATABASE [Recetario] SET  READ_WRITE 
GO
