USE [master]
GO
/****** Object:  Database [TestDeveloper]    Script Date: 8/16/2020 11:15:47 AM ******/
CREATE DATABASE [TestDeveloper]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestDeveloper', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER2019\MSSQL\DATA\TestDeveloper.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestDeveloper_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER2019\MSSQL\DATA\TestDeveloper_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestDeveloper].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestDeveloper] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestDeveloper] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestDeveloper] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestDeveloper] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestDeveloper] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestDeveloper] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestDeveloper] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestDeveloper] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestDeveloper] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestDeveloper] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestDeveloper] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestDeveloper] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestDeveloper] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestDeveloper] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestDeveloper] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestDeveloper] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestDeveloper] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestDeveloper] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestDeveloper] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestDeveloper] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestDeveloper] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestDeveloper] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestDeveloper] SET RECOVERY FULL 
GO
ALTER DATABASE [TestDeveloper] SET  MULTI_USER 
GO
ALTER DATABASE [TestDeveloper] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestDeveloper] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestDeveloper] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestDeveloper] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestDeveloper] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestDeveloper', N'ON'
GO
USE [TestDeveloper]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[CodigoCiudad] [int] NOT NULL,
	[NombreCiudad] [nvarchar](50) NOT NULL,
	[Estado] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[CodigoCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[CodigoRegion] [int] NOT NULL,
	[NombreRegion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[CodigoRegion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegionCiudad]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionCiudad](
	[CodigoRegion] [int] NOT NULL,
	[CodigoCiudad] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Ciudad] ([CodigoCiudad], [NombreCiudad], [Estado]) VALUES (1, N'Medellin', N'Activo')
INSERT [dbo].[Ciudad] ([CodigoCiudad], [NombreCiudad], [Estado]) VALUES (2, N'Cartagena', N'Activo')
INSERT [dbo].[Ciudad] ([CodigoCiudad], [NombreCiudad], [Estado]) VALUES (3, N'Bogota', N'Activo')
INSERT [dbo].[Ciudad] ([CodigoCiudad], [NombreCiudad], [Estado]) VALUES (4, N'Barranquilla', N'Activo')
INSERT [dbo].[Ciudad] ([CodigoCiudad], [NombreCiudad], [Estado]) VALUES (5, N'Pereira', N'Activo')
GO
INSERT [dbo].[Region] ([CodigoRegion], [NombreRegion]) VALUES (1, N'Colombia')
INSERT [dbo].[Region] ([CodigoRegion], [NombreRegion]) VALUES (2, N'Andina')
INSERT [dbo].[Region] ([CodigoRegion], [NombreRegion]) VALUES (3, N'Costa')
INSERT [dbo].[Region] ([CodigoRegion], [NombreRegion]) VALUES (4, N'Prueba')
GO
INSERT [dbo].[RegionCiudad] ([CodigoRegion], [CodigoCiudad]) VALUES (1, 1)
GO
ALTER TABLE [dbo].[RegionCiudad]  WITH CHECK ADD  CONSTRAINT [FK_RegionCiudad_Ciudad] FOREIGN KEY([CodigoCiudad])
REFERENCES [dbo].[Ciudad] ([CodigoCiudad])
GO
ALTER TABLE [dbo].[RegionCiudad] CHECK CONSTRAINT [FK_RegionCiudad_Ciudad]
GO
ALTER TABLE [dbo].[RegionCiudad]  WITH CHECK ADD  CONSTRAINT [FK_RegionCiudad_Region] FOREIGN KEY([CodigoRegion])
REFERENCES [dbo].[Region] ([CodigoRegion])
GO
ALTER TABLE [dbo].[RegionCiudad] CHECK CONSTRAINT [FK_RegionCiudad_Region]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCiudad]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarCiudad]
	@IdCodigoCiudad AS int
	, @CodigoCiudad AS int
	, @NombreCiudad AS varchar(255)
	, @Estado AS varchar(15)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Ciudad] SET [CodigoCiudad] = @CodigoCiudad, [NombreCiudad] = @NombreCiudad, [Estado] = @Estado WHERE CodigoCiudad = @IdCodigoCiudad
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarRegion]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarRegion]
	@IdCodigoRegion AS int
	, @CodigoRegion AS int
	, @NombreRegion AS varchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Region] SET [CodigoRegion] = @CodigoRegion ,[NombreRegion] = @NombreRegion WHERE CodigoRegion = @IdCodigoRegion
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCiudad]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarCiudad]
	@CodigoCiudad AS int
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		CodigoCiudad
		, NombreCiudad
		, Estado
	FROM Ciudad
	WHERE CodigoCiudad = @CodigoCiudad 
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCiudades]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarCiudades]
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		CodigoCiudad
		, NombreCiudad
		, Estado
	FROM Ciudad
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarRegion]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarRegion]
	@CodigoRegion AS int
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		CodigoRegion
		, NombreRegion
	FROM Region
	WHERE CodigoRegion = @CodigoRegion 
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarRegionCiudades]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarRegionCiudades]
	@CodigoRegion AS int
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		R.CodigoRegion
		, R.NombreRegion
		, C.CodigoCiudad
		, C.NombreCiudad
		, C.Estado
	FROM RegionCiudad RC
	INNER JOIN Region R ON RC.CodigoRegion = R.CodigoRegion
	INNER JOIN Ciudad C ON RC.CodigoCiudad = C.CodigoCiudad
	WHERE RC.CodigoRegion = @CodigoRegion 
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarRegistros]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarRegistros]
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		CodigoRegion
		, NombreRegion
	FROM Region
END
GO
/****** Object:  StoredProcedure [dbo].[CrearCiudad]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearCiudad]
	@CodigoCiudad AS int
	, @NombreCiudad AS varchar(255)
	, @Estado AS varchar(15)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Ciudad]
	(
		[CodigoCiudad]
		, [NombreCiudad]
		, [Estado]
	)
    VALUES
	(
		@CodigoCiudad
		, @NombreCiudad
		, @Estado
	)
END
GO
/****** Object:  StoredProcedure [dbo].[CrearRegion]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearRegion]
	@CodigoRegion AS int
	, @NombreRegion AS varchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Region]
	(
		[CodigoRegion]
		,[NombreRegion]
	)
    VALUES
	(
		@CodigoRegion
		, @NombreRegion
	)
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCiudad]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarCiudad]
	@CodigoCiudad AS int
AS
BEGIN
	DECLARE @Contador AS Int
	SET NOCOUNT ON;

	SET @Contador = (SELECT COUNT(*) FROM RegionCiudad WHERE CodigoCiudad = @CodigoCiudad)

	IF (@Contador > 0)
	BEGIN
		-- Eliminación del registro en la tabla RegistroCiudad
		DELETE FROM RegionCiudad WHERE CodigoCiudad = @CodigoCiudad

		-- Eliminación del registro en la tabla Ciudad
		DELETE FROM Ciudad WHERE CodigoCiudad = @CodigoCiudad
	END
	ELSE
	BEGIN
		DELETE FROM Ciudad WHERE CodigoCiudad = @CodigoCiudad
	END
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarRegion]    Script Date: 8/16/2020 11:15:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarRegion]
	@CodigoRegion AS int
AS
BEGIN
	DECLARE @Contador AS Int
	SET NOCOUNT ON;

	SET @Contador = (SELECT COUNT(*) FROM RegionCiudad WHERE CodigoRegion = @CodigoRegion)

	IF (@Contador > 0)
	BEGIN
		-- Eliminación del registro en la tabla RegistroCiudad
		DELETE FROM RegionCiudad WHERE CodigoRegion = @CodigoRegion

		-- Eliminación del registro en la tabla Ciudad
		DELETE FROM Region WHERE CodigoRegion = @CodigoRegion
	END
	ELSE
	BEGIN
		DELETE FROM Region WHERE CodigoRegion = @CodigoRegion
	END
END
GO
USE [master]
GO
ALTER DATABASE [TestDeveloper] SET  READ_WRITE 
GO
