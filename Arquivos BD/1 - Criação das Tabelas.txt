/****** Object:  Table [dbo].[categoria]    Script Date: 28/04/2017  ******/

CREATE TABLE [dbo].[categoria](
	[idCategoria] [nvarchar](5) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__categori__8A3D240C1538A73E] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientes]    Script Date: 28/04/2017  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idCliente] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nome] [varchar](30) NOT NULL,
	[endereco] [varchar](50) NOT NULL,
	[telefone] [varchar](30) NOT NULL,
	[cpf] [numeric](11, 0) NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalheVenda]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalheVenda](
	[idDetalhe] [int] IDENTITY(1,1) NOT NULL,
	[numFatura] [numeric](18, 0) NOT NULL,
	[idVenda] [numeric](18, 0) NOT NULL,
	[subTotal] [real] NOT NULL,
	[idProduto] [nvarchar](5) NOT NULL,
	[quantidade] [int] NOT NULL,
 CONSTRAINT [PK_detalheVenda] PRIMARY KEY CLUSTERED 
(
	[idDetalhe] ASC,
	[numFatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fatura]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fatura](
	[numFatura] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[data] [date] NOT NULL,
	[TAXA] [real] NOT NULL,
	[total] [real] NOT NULL,
	[numPag] [int] NOT NULL,
	[desconto] [money] NULL,
 CONSTRAINT [PK__fatura__C989668BFDF3359B] PRIMARY KEY CLUSTERED 
(
	[numFatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[modoPag]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modoPag](
	[numPag] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](25) NOT NULL,
	[outrosDetalhes] [nvarchar](50) NULL,
 CONSTRAINT [PK__modoPag__56E7C501338E87C8] PRIMARY KEY CLUSTERED 
(
	[numPag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[produto]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produto](
	[idProduto] [nvarchar](5) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[precoUnitario] [money] NOT NULL,
	[idCategoria] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK__produto__07F4A132F0C57D04] PRIMARY KEY CLUSTERED 
(
	[idProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[vendedor]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendedor](
	[idVendedor] [nvarchar](5) NOT NULL,
	[nome] [nvarchar](30) NOT NULL,
	[cpf] [nvarchar](11) NOT NULL,
	[telefone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__vendedor__A6693F936F5918BB] PRIMARY KEY CLUSTERED 
(
	[idVendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venda]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venda](
	[idVenda] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[total] [real] NOT NULL,
	[idCliente] [numeric](18, 0) NOT NULL,
	[idVendedor] [nvarchar](5) NOT NULL,
	[data] [date] NOT NULL,
	[desconto] [money] NULL,
	[TAXA] [money] NOT NULL,
 CONSTRAINT [PK__pedido__A9F619B72DC663B9] PRIMARY KEY CLUSTERED 
(
	[idVenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Relacionamentos   ******/

ALTER TABLE [dbo].[detalheVenda]  WITH CHECK ADD  CONSTRAINT [FK__detalheFa__idPed__239E4DCF] FOREIGN KEY([idVenda])
REFERENCES [dbo].[venda] ([idVenda])
GO
ALTER TABLE [dbo].[detalheVenda] CHECK CONSTRAINT [FK__detalheFa__idPed__239E4DCF]
GO
ALTER TABLE [dbo].[detalheVenda]  WITH CHECK ADD  CONSTRAINT [FK_detalheFatura_fatura] FOREIGN KEY([numFatura])
REFERENCES [dbo].[fatura] ([numFatura])
GO
ALTER TABLE [dbo].[detalheVenda] CHECK CONSTRAINT [FK_detalheFatura_fatura]
GO
ALTER TABLE [dbo].[detalheVenda]  WITH CHECK ADD  CONSTRAINT [FK_detalheFatura_produto] FOREIGN KEY([idProduto])
REFERENCES [dbo].[produto] ([idProduto])
GO
ALTER TABLE [dbo].[detalheVenda] CHECK CONSTRAINT [FK_detalheFatura_produto]
GO
ALTER TABLE [dbo].[fatura]  WITH CHECK ADD  CONSTRAINT [FK_fatura_modoPag] FOREIGN KEY([numPag])
REFERENCES [dbo].[modoPag] ([numPag])
GO
ALTER TABLE [dbo].[fatura] CHECK CONSTRAINT [FK_fatura_modoPag]
GO
ALTER TABLE [dbo].[produto]  WITH CHECK ADD  CONSTRAINT [FK__produto__idCate__164452B1] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[produto] CHECK CONSTRAINT [FK__produto__idCate__164452B1]
GO
ALTER TABLE [dbo].[venda]  WITH CHECK ADD  CONSTRAINT [FK_venda_cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([idCliente])
GO
ALTER TABLE [dbo].[venda] CHECK CONSTRAINT [FK_venda_cliente]
GO
ALTER TABLE [dbo].[venda]  WITH CHECK ADD  CONSTRAINT [FK_venda_vendedor] FOREIGN KEY([idVendedor])
REFERENCES [dbo].[vendedor] ([idVendedor])
GO
ALTER TABLE [dbo].[venda] CHECK CONSTRAINT [FK_venda_vendedor]
GO
USE [master]
GO
ALTER DATABASE [financeiro] SET  READ_WRITE 
GO
