USE [Test_Invoice]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 08/02/2022 08:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustName] [nvarchar](70) NOT NULL,
	[Adress] [nvarchar](120) NOT NULL,
	[Status] [bit] NOT NULL,
	[CustomerTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerTypes]    Script Date: 08/02/2022 08:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 08/02/2022 08:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalItbis] [money] NOT NULL,
	[SubTotal] [money] NOT NULL,
	[Total] [money] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 08/02/2022 08:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[TotalItbis] [money] NOT NULL,
	[SubTotal] [money] NOT NULL,
	[Total] [money] NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_CustomerType]  DEFAULT ((1)) FOR [CustomerTypeId]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_TotalItbis]  DEFAULT ((0)) FOR [TotalItbis]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  CONSTRAINT [DF_InvoiceDetail_TotalItbis1]  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  CONSTRAINT [DF_InvoiceDetail_TotalItbis]  DEFAULT ((0)) FOR [TotalItbis]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerTypes] FOREIGN KEY([CustomerTypeId])
REFERENCES [dbo].[CustomerTypes] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_CustomerTypes]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customers]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Invoice]
GO
/****** Object:  StoredProcedure [dbo].[SP_CUSTOMER]    Script Date: 08/02/2022 08:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CUSTOMER]
	@ID INT = NULL,
	@CUSTNAME NVARCHAR(70) = NULL,
	@STATUS BIT = NULL,
	@ADRESS NVARCHAR(120) = NULL,
	@CUSTOMERTYPEID INT = NULL,
	@OPTION VARCHAR(3) = NULL
AS
BEGIN
	IF(@OPTION = 'GET')
	BEGIN
		SELECT 
			c.Id,
			C.Adress,
			C.CustName,
			C.Status,
			T.Description AS 'CustomerType',
			T.Id AS 'CustomerTypeId'
		FROM Customers C
		LEFT JOIN CustomerTypes T ON C.CustomerTypeId = T.Id
		WHERE 1 = 1
			AND (ISNULL(@STATUS, '')='' OR C.Status = @STATUS)
			AND (ISNULL(@ID, '')='' OR C.Id = @ID)
		ORDER BY Id DESC
	END
	IF(@OPTION = 'INS')
	BEGIN
		INSERT INTO Customers
			   (CustName
			   ,Adress
			   ,Status
			   ,CustomerTypeId)
		 VALUES
			   (@CUSTNAME
			   ,@ADRESS
			   ,@STATUS
			   ,@CUSTOMERTYPEID)
	END
	IF(@OPTION = 'UPT')
	BEGIN
		UPDATE Customers
		   SET CustName = @CUSTNAME
			  ,Adress = @ADRESS
			  ,Status = @STATUS
			  ,CustomerTypeId = @CUSTOMERTYPEID
		 WHERE Id = @ID
	END		
	IF(@OPTION = 'DEL')
	BEGIN
		UPDATE Customers
		   SET Status = 0
		 WHERE Id = @ID
	END
 END
GO
/****** Object:  StoredProcedure [dbo].[SP_INVOICE]    Script Date: 08/02/2022 08:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INVOICE]
	@INVOICEID INT = NULL,
	@OPTION VARCHAR(3) = NULL
AS
BEGIN
	IF(@OPTION = 'GET')
	BEGIN
		SELECT 
			I.Id,
			I.TotalItbis,
			I.SubTotal,
			I.Total,
			C.CustName, 
			I.CustomerId
		FROM Invoice I
		LEFT JOIN Customers C ON C.Id = I.CustomerId
		WHERE 1 = 1
		AND (ISNULL(@INVOICEID, '')='' OR I.Id = @INVOICEID)
	END
	IF(@OPTION = 'GEF') --GET DETALLES FACTURA
	BEGIN
		SELECT 
		* 
		FROM InvoiceDetail D
		WHERE 1 = 1
		AND (ISNULL(@InvoiceId, '')='' OR D.InvoiceId = @InvoiceId)
	END
END
GO



INSERT INTO [dbo].[CustomerTypes]
           ([Description])
     VALUES
           ('AL DETALLE'),
		   ('AL POR MAYOR'),
		   ('SOCIO'),
		   ('VIP');


INSERT INTO Customers
           (CustName
           ,Adress
           ,Status
           ,CustomerTypeId)
     VALUES
           ('PETRONILO CARVAJAL'
           ,'CALLE MELLA CASI ESQ. SANCHEZ, #29, SECTOR DUARTE, SAN JOSE DE OCOA'
           ,1
           ,4);

INSERT INTO Customers
           (CustName
           ,Adress
           ,Status
           ,CustomerTypeId)
     VALUES
           ('PEDRO SANCHEZ'
           ,'CALLE DUARTE CASI ESQ. MELLA, #29, SECTOR SANCHEZ, PERAVIA'
           ,1
           ,2);


INSERT INTO [dbo].[Invoice]
           ([CustomerId]
           ,[TotalItbis]
           ,[SubTotal]
           ,[Total])
     VALUES
           (2
           ,180
           ,1000
           ,1180)
GO




INSERT INTO [dbo].[InvoiceDetail]
           ([InvoiceId]
           ,[Qty]
           ,[Price]
           ,[TotalItbis]
           ,[SubTotal]
           ,[Total])
     VALUES
           (2
           ,5
           ,100
           ,60
           ,500
           ,560)
GO

INSERT INTO [dbo].[InvoiceDetail]
           ([InvoiceId]
           ,[Qty]
           ,[Price]
           ,[TotalItbis]
           ,[SubTotal]
           ,[Total])
     VALUES
           (2
           ,5
           ,100
           ,60
           ,500
           ,560)
GO