USE [master] 
GO 

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Segtrab') 
	CREATE DATABASE [SegTrab];
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'DS_Login')
    CREATE LOGIN [ds_login] WITH PASSWORD=N'ds_senha', 
    DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Português (Brasil)], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE SegTrab
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Treinamento]') AND type in (N'U'))
BEGIN

CREATE TABLE [dbo].[Treinamento](
	[IDTreinamento] [int] NOT NULL,
	[Descricao] [nvarchar](30) NULL,
	[CargaHoraria] [nvarchar](5) NULL,
 CONSTRAINT [PK_Treinamento] PRIMARY KEY CLUSTERED 
(
	[IDTreinamento] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GrupoAcesso]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GrupoAcesso](
	[IDGrupoAcesso] [int] NOT NULL,
	[Descricao] [nvarchar](50) NULL,
 CONSTRAINT [PK_GrupoAcesso] PRIMARY KEY CLUSTERED 
(
	[IDGrupoAcesso] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NR](
	[IDNR] [int] NOT NULL,
	[Descricao] [ntext] NULL,
 CONSTRAINT [PK_NR] PRIMARY KEY CLUSTERED 
(
	[IDNR] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_novacoluna]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_novacoluna]
	@tabela nvarchar(50),
	@coluna nvarchar(50)
AS
	DECLARE @SQL nvarchar(500)
	SET @SQL = ''ALTER TABLE '' +@tabela+ '' ADD '' +@coluna+ '' NVARCHAR(50)''
exec (@SQL)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CBO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CBO](
	[IDCBO] [int] NOT NULL,
	[CodCBO] [nvarchar](10) NULL,
	[Descricao] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CBO_1] PRIMARY KEY CLUSTERED 
(
	[IDCBO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Configuracoes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Configuracoes](
	[Versao] [int] NOT NULL DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Empresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Empresa](
	[IDEmpresa] [int] NOT NULL,
	[RazaoSocial] [nvarchar](50) NOT NULL,
	[NomeFantasia] [nvarchar](30) NOT NULL,
	[Sigla] [nvarchar](5) NOT NULL,
	[Rua] [nvarchar](30) NULL,
	[Numero] [int] NULL,
	[Bairro] [nvarchar](30) NULL,
	[Cidade] [nvarchar](30) NULL,
	[Estado] [nvarchar](2) NULL,
	[Cep] [nvarchar](9) NULL,
	[CNPJ] [nvarchar](14) NULL,
	[Email] [nvarchar](30) NULL,
	[Telefone] [nvarchar](13) NULL,
	[Fax] [nvarchar](13) NULL,
	[Logomarca] [image] NULL,
	[DuracaoCheckList] [int] NULL,
	[AlertaTreinamento] [int] NULL,
	[AlertaEPI] [int] NULL,
	[AlertaDocumento] [int] NULL,
	[AlertaAuditoria] [int] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[IDEmpresa] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcao_Funcionario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcao_Funcionario](
	[IDFuncionario] [int] NOT NULL,
	[IDFuncao] [int] NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataFim] [datetime] NULL,
 CONSTRAINT [PK_Funcao_Funcionario] PRIMARY KEY CLUSTERED 
(
	[IDFuncionario] ASC,
	[IDFuncao] ASC,
	[DataInicio] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcao_Treinamento]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcao_Treinamento](
	[IDFuncao] [int] NOT NULL,
	[IDTreinamento] [int] NOT NULL,
 CONSTRAINT [PK_Funcao_Treinamento] PRIMARY KEY CLUSTERED 
(
	[IDFuncao] ASC,
	[IDTreinamento] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcao_EPI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcao_EPI](
	[IDFuncao] [int] NOT NULL,
	[IDEPI] [int] NOT NULL,
 CONSTRAINT [PK_Funcao_EPI] PRIMARY KEY CLUSTERED 
(
	[IDFuncao] ASC,
	[IDEPI] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Agenda]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Agenda](
	[IDAgendamento] [int] NOT NULL,
	[IDTreinamento] [int] NOT NULL,
	[IDEmpresa] [int] NOT NULL,
	[Data] [datetime] NULL,
	[Descricao] [nvarchar](255) NULL,
	[Ministrante] [nvarchar](50) NULL,
	[CargaHoraria] [nvarchar](5) NULL,
 CONSTRAINT [PK_Agendamento] PRIMARY KEY CLUSTERED 
(
	[IDAgendamento] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Treinamento_Empresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Treinamento_Empresa](
	[IDTreinamento] [int] NOT NULL,
	[IDEmpresa] [int] NOT NULL,
	[Validade] [int] NOT NULL,
 CONSTRAINT [PK_Treinamento_Empresa] PRIMARY KEY CLUSTERED 
(
	[IDTreinamento] ASC,
	[IDEmpresa] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Participantes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Participantes](
	[IDAgendamento] [int] NOT NULL,
	[IDFuncionario] [int] NOT NULL,
 CONSTRAINT [PK_Participantes] PRIMARY KEY CLUSTERED 
(
	[IDAgendamento] ASC,
	[IDFuncionario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GrupoAcessoItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GrupoAcessoItem](
	[Nome] [nvarchar](50) NOT NULL,
	[Menu] [nvarchar](50) NOT NULL,
	[AcessoInserir] [bit] NOT NULL,
	[AcessoExcluir] [bit] NOT NULL,
	[AcessoAlterar] [bit] NOT NULL,
	[AcessoConsultar] [bit] NOT NULL,
	[IDGrupoAcesso] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[IDUsuario] [int] NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[Login] [nvarchar](200) NOT NULL,
	[Senha] [nvarchar](200) NOT NULL,
	[IDGrupoAcesso] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NR_Empresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NR_Empresa](
	[IDNR] [int] NOT NULL,
	[IDEmpresa] [int] NOT NULL,
	[Validade] [int] NULL,
 CONSTRAINT [pk_NR_Empresa] PRIMARY KEY CLUSTERED 
(
	[IDNR] ASC,
	[IDEmpresa] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckList](
	[IDCheckList] [int] NOT NULL,
	[IDEmpresa] [int] NULL,
	[Data] [datetime] NOT NULL,
	[IDNR] [int] NOT NULL,
	[StatusCheckList] [tinyint] NULL,
 CONSTRAINT [PK_CHECKLIST] PRIMARY KEY CLUSTERED 
(
	[IDCheckList] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artigo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Artigo](
	[IDArtigo] [int] NOT NULL,
	[IDNR] [int] NULL,
	[CodArtigo] [nvarchar](20) NULL,
	[Texto] [ntext] NULL,
	[Penalidade] [nvarchar](20) NULL,
	[Letra] [nvarchar](3) NULL,
 CONSTRAINT [PK_Artigos] PRIMARY KEY CLUSTERED 
(
	[IDArtigo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Questao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Questao](
	[IDQuestao] [int] NOT NULL,
	[IDArtigo] [int] NULL,
	[Questao] [ntext] NULL,
	[Acao] [ntext] NULL,
 CONSTRAINT [PK_Questoes] PRIMARY KEY CLUSTERED 
(
	[IDQuestao] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckList_Itens]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckList_Itens](
	[IDItem] [int] NOT NULL,
	[IDCheckList] [int] NOT NULL,
	[IDQuestao] [int] NOT NULL,
	[StatusItem] [tinyint] NULL,
	[Justificativa] [ntext] NULL,
 CONSTRAINT [PK_CheckList_Itens] PRIMARY KEY CLUSTERED 
(
	[IDItem] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Arquivo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Arquivo](
	[IDDocumento] [int] NOT NULL,
	[Arquivo] [varbinary](max) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioEmpresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuarioEmpresa](
	[IDUsuario] [int] NOT NULL,
	[IDEmpresa] [int] NOT NULL,
	[Acesso] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcionario](
	[IDFuncionario] [int] NOT NULL,
	[IDEmpresa] [int] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[CPF] [nvarchar](11) NULL,
	[RG] [nvarchar](15) NULL,
	[dtNascimento] [datetime] NULL,
	[Sexo] [smallint] NULL,
	[Rua] [nvarchar](30) NULL,
	[Numero] [int] NULL,
	[Bairro] [nvarchar](30) NULL,
	[Cidade] [nvarchar](30) NULL,
	[Estado] [nvarchar](2) NULL,
	[Telefone] [nvarchar](13) NULL,
	[Celular] [nvarchar](13) NULL,
	[Email] [nvarchar](30) NULL,
	[IDCBO] [int] NULL,
	[Complemento] [nvarchar](50) NULL,
	[CEP] [nvarchar](9) NULL,
	[Registro] [nvarchar](50) NULL,
	[Admissao] [datetime] NULL,
	[Rescisao] [datetime] NULL,
	[CTPS] [nvarchar](15) NULL,
	[OrgaoEmissor] [nvarchar](6) NULL,
	[DataEmissao] [datetime] NULL,
	[DataImportacao] [datetime] NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[IDFuncionario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Auditoria]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Auditoria](
	[IDAuditoria] [int] NOT NULL,
	[IDCheckList] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [pk_Auditoria] PRIMARY KEY CLUSTERED 
(
	[IDAuditoria] ASC,
	[IDCheckList] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EPI_Empresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EPI_Empresa](
	[IDEmpresa] [int] NOT NULL,
	[IDEPI] [int] NOT NULL,
	[Validade] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Auditoria_Itens]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Auditoria_Itens](
	[IDAuditoria] [int] NOT NULL,
	[IDCheckList] [int] NOT NULL,
	[IDItem] [int] NOT NULL,
	[Status_item] [int] NULL,
	[Justificativa] [ntext] NULL,
 CONSTRAINT [PK_Auditoria_Itens] PRIMARY KEY CLUSTERED 
(
	[IDAuditoria] ASC,
	[IDCheckList] ASC,
	[IDItem] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcao](
	[IDFuncao] [int] NOT NULL,
	[Descricao] [nvarchar](30) NULL,
	[IDEmpresa] [int] NULL,
 CONSTRAINT [PK_Funcao] PRIMARY KEY CLUSTERED 
(
	[IDFuncao] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Documento]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Documento](
	[IDDocumento] [int] NOT NULL,
	[IDEmpresa] [int] NULL,
	[Descricao] [nvarchar](50) NULL,
	[NomeArquivo] [nvarchar](50) NOT NULL,
	[Tipo] [tinyint] NOT NULL,
	[IDTipo] [int] NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[IDDocumento] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EPI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EPI](
	[IDEPI] [int] NOT NULL,
	[IDEmpresa] [int] NOT NULL,
	[Descricao] [nvarchar](50) NULL,
	[CA] [nvarchar](10) NULL,
	[Fornecedor] [nvarchar](30) NULL,
	[Validade] [int] NOT NULL,
	[DevolucaoObrigatoria] [tinyint] NULL,
	[Unidade] [int] NULL,
 CONSTRAINT [PK_EPI] PRIMARY KEY CLUSTERED 
(
	[IDEPI] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionario_EPI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcionario_EPI](
	[IDFuncionario] [int] NOT NULL,
	[IDEPI] [int] NOT NULL,
	[DataEntrega] [datetime] NOT NULL,
	[Inativo] [smallint] NULL,
	[Devolucao] [datetime] NULL,
	[Quantidade] [int] NULL,
 CONSTRAINT [PK_Funcionario_EPI] PRIMARY KEY CLUSTERED 
(
	[IDFuncionario] ASC,
	[IDEPI] ASC,
	[DataEntrega] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Funcionarios_Treinamento]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[Funcionarios_Treinamento] AS SELECT  TOP 100   dbo.Agenda.IDAgendamento, dbo.Agenda.Data, dbo.Treinamento.IDTreinamento, dbo.Treinamento.Descricao, 
                      dbo.Treinamento_Empresa.Validade, dbo.Participantes.IDFuncionario
FROM         dbo.Agenda INNER JOIN
                      dbo.Treinamento ON dbo.Agenda.IDTreinamento = dbo.Treinamento.IDTreinamento INNER JOIN
                      dbo.Treinamento_Empresa ON dbo.Treinamento.IDTreinamento = dbo.Treinamento_Empresa.IDTreinamento INNER JOIN
                      dbo.Participantes ON dbo.Agenda.IDAgendamento = dbo.Participantes.IDAgendamento
ORDER BY dbo.Agenda.IDAgendamento, dbo.Agenda.IDTreinamento' 
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcao_Funcionario_Funcao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcao_Funcionario]'))
ALTER TABLE [dbo].[Funcao_Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcao_Funcionario_Funcao] FOREIGN KEY([IDFuncao])
REFERENCES [dbo].[Funcao] ([IDFuncao])
GO
ALTER TABLE [dbo].[Funcao_Funcionario] CHECK CONSTRAINT [FK_Funcao_Funcionario_Funcao]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcao_Funcionario_Funcionario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcao_Funcionario]'))
ALTER TABLE [dbo].[Funcao_Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcao_Funcionario_Funcionario] FOREIGN KEY([IDFuncionario])
REFERENCES [dbo].[Funcionario] ([IDFuncionario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Funcao_Funcionario] CHECK CONSTRAINT [FK_Funcao_Funcionario_Funcionario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcao_Treinamento_Funcao_Treinamento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcao_Treinamento]'))
ALTER TABLE [dbo].[Funcao_Treinamento]  WITH CHECK ADD  CONSTRAINT [FK_Funcao_Treinamento_Funcao_Treinamento] FOREIGN KEY([IDFuncao])
REFERENCES [dbo].[Funcao] ([IDFuncao])
GO
ALTER TABLE [dbo].[Funcao_Treinamento] CHECK CONSTRAINT [FK_Funcao_Treinamento_Funcao_Treinamento]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcao_Treinamento_Treinamento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcao_Treinamento]'))
ALTER TABLE [dbo].[Funcao_Treinamento]  WITH CHECK ADD  CONSTRAINT [FK_Funcao_Treinamento_Treinamento] FOREIGN KEY([IDTreinamento])
REFERENCES [dbo].[Treinamento] ([IDTreinamento])
GO
ALTER TABLE [dbo].[Funcao_Treinamento] CHECK CONSTRAINT [FK_Funcao_Treinamento_Treinamento]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcao_EPI_EPI]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcao_EPI]'))
ALTER TABLE [dbo].[Funcao_EPI]  WITH CHECK ADD  CONSTRAINT [FK_Funcao_EPI_EPI] FOREIGN KEY([IDEPI])
REFERENCES [dbo].[EPI] ([IDEPI])
GO
ALTER TABLE [dbo].[Funcao_EPI] CHECK CONSTRAINT [FK_Funcao_EPI_EPI]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcao_EPI_Funcao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcao_EPI]'))
ALTER TABLE [dbo].[Funcao_EPI]  WITH CHECK ADD  CONSTRAINT [FK_Funcao_EPI_Funcao] FOREIGN KEY([IDFuncao])
REFERENCES [dbo].[Funcao] ([IDFuncao])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Funcao_EPI] CHECK CONSTRAINT [FK_Funcao_EPI_Funcao]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Agenda_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Agenda]'))
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Agenda_Treinamento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Agenda]'))
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_Treinamento] FOREIGN KEY([IDTreinamento])
REFERENCES [dbo].[Treinamento] ([IDTreinamento])
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Treinamento]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Treinamento_Empresa_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Treinamento_Empresa]'))
ALTER TABLE [dbo].[Treinamento_Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Treinamento_Empresa_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Treinamento_Empresa] CHECK CONSTRAINT [FK_Treinamento_Empresa_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Treinamento_Empresa_Treinamento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Treinamento_Empresa]'))
ALTER TABLE [dbo].[Treinamento_Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Treinamento_Empresa_Treinamento] FOREIGN KEY([IDTreinamento])
REFERENCES [dbo].[Treinamento] ([IDTreinamento])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Treinamento_Empresa] CHECK CONSTRAINT [FK_Treinamento_Empresa_Treinamento]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Participantes_Agenda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Participantes]'))
ALTER TABLE [dbo].[Participantes]  WITH CHECK ADD  CONSTRAINT [FK_Participantes_Agenda] FOREIGN KEY([IDAgendamento])
REFERENCES [dbo].[Agenda] ([IDAgendamento])
GO
ALTER TABLE [dbo].[Participantes] CHECK CONSTRAINT [FK_Participantes_Agenda]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Participantes_Funcionario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Participantes]'))
ALTER TABLE [dbo].[Participantes]  WITH CHECK ADD  CONSTRAINT [FK_Participantes_Funcionario] FOREIGN KEY([IDFuncionario])
REFERENCES [dbo].[Funcionario] ([IDFuncionario])
GO
ALTER TABLE [dbo].[Participantes] CHECK CONSTRAINT [FK_Participantes_Funcionario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GrupoAcessoItem_GrupoAcesso]') AND parent_object_id = OBJECT_ID(N'[dbo].[GrupoAcessoItem]'))
ALTER TABLE [dbo].[GrupoAcessoItem]  WITH CHECK ADD  CONSTRAINT [FK_GrupoAcessoItem_GrupoAcesso] FOREIGN KEY([IDGrupoAcesso])
REFERENCES [dbo].[GrupoAcesso] ([IDGrupoAcesso])
GO
ALTER TABLE [dbo].[GrupoAcessoItem] CHECK CONSTRAINT [FK_GrupoAcessoItem_GrupoAcesso]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_GrupoAcesso]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_GrupoAcesso] FOREIGN KEY([IDGrupoAcesso])
REFERENCES [dbo].[GrupoAcesso] ([IDGrupoAcesso])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_GrupoAcesso]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Empresa_NR_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[NR_Empresa]'))
ALTER TABLE [dbo].[NR_Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_NR_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[NR_Empresa] CHECK CONSTRAINT [FK_Empresa_NR_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NR_NR_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[NR_Empresa]'))
ALTER TABLE [dbo].[NR_Empresa]  WITH CHECK ADD  CONSTRAINT [FK_NR_NR_Empresa] FOREIGN KEY([IDNR])
REFERENCES [dbo].[NR] ([IDNR])
GO
ALTER TABLE [dbo].[NR_Empresa] CHECK CONSTRAINT [FK_NR_NR_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CHECKLIST_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[CheckList]'))
ALTER TABLE [dbo].[CheckList]  WITH CHECK ADD  CONSTRAINT [FK_CHECKLIST_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[CheckList] CHECK CONSTRAINT [FK_CHECKLIST_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NR_Checklist]') AND parent_object_id = OBJECT_ID(N'[dbo].[CheckList]'))
ALTER TABLE [dbo].[CheckList]  WITH CHECK ADD  CONSTRAINT [FK_NR_Checklist] FOREIGN KEY([IDNR])
REFERENCES [dbo].[NR] ([IDNR])
GO
ALTER TABLE [dbo].[CheckList] CHECK CONSTRAINT [FK_NR_Checklist]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NR_Artigo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Artigo]'))
ALTER TABLE [dbo].[Artigo]  WITH CHECK ADD  CONSTRAINT [FK_NR_Artigo] FOREIGN KEY([IDNR])
REFERENCES [dbo].[NR] ([IDNR])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Artigo] CHECK CONSTRAINT [FK_NR_Artigo]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Artigos_Questoes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Questao]'))
ALTER TABLE [dbo].[Questao]  WITH CHECK ADD  CONSTRAINT [FK_Artigos_Questoes] FOREIGN KEY([IDArtigo])
REFERENCES [dbo].[Artigo] ([IDArtigo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questao] CHECK CONSTRAINT [FK_Artigos_Questoes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CheckList_Itens_CheckList]') AND parent_object_id = OBJECT_ID(N'[dbo].[CheckList_Itens]'))
ALTER TABLE [dbo].[CheckList_Itens]  WITH CHECK ADD  CONSTRAINT [FK_CheckList_Itens_CheckList] FOREIGN KEY([IDCheckList])
REFERENCES [dbo].[CheckList] ([IDCheckList])
GO
ALTER TABLE [dbo].[CheckList_Itens] CHECK CONSTRAINT [FK_CheckList_Itens_CheckList]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CheckList_Itens_Questao]') AND parent_object_id = OBJECT_ID(N'[dbo].[CheckList_Itens]'))
ALTER TABLE [dbo].[CheckList_Itens]  WITH CHECK ADD  CONSTRAINT [FK_CheckList_Itens_Questao] FOREIGN KEY([IDQuestao])
REFERENCES [dbo].[Questao] ([IDQuestao])
GO
ALTER TABLE [dbo].[CheckList_Itens] CHECK CONSTRAINT [FK_CheckList_Itens_Questao]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Arquivo_Documento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Arquivo]'))
ALTER TABLE [dbo].[Arquivo]  WITH CHECK ADD  CONSTRAINT [FK_Arquivo_Documento] FOREIGN KEY([IDDocumento])
REFERENCES [dbo].[Documento] ([IDDocumento])
GO
ALTER TABLE [dbo].[Arquivo] CHECK CONSTRAINT [FK_Arquivo_Documento]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioEmpresa_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioEmpresa]'))
ALTER TABLE [dbo].[UsuarioEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioEmpresa_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[UsuarioEmpresa] CHECK CONSTRAINT [FK_UsuarioEmpresa_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioEmpresa_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioEmpresa]'))
ALTER TABLE [dbo].[UsuarioEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioEmpresa_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([IDUsuario])
GO
ALTER TABLE [dbo].[UsuarioEmpresa] CHECK CONSTRAINT [FK_UsuarioEmpresa_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcionario_CBO]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcionario]'))
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_CBO] FOREIGN KEY([IDCBO])
REFERENCES [dbo].[CBO] ([IDCBO])
GO
ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_CBO]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcionario_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcionario]'))
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_CheckList_Auditoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Auditoria]'))
ALTER TABLE [dbo].[Auditoria]  WITH CHECK ADD  CONSTRAINT [fk_CheckList_Auditoria] FOREIGN KEY([IDCheckList])
REFERENCES [dbo].[CheckList] ([IDCheckList])
GO
ALTER TABLE [dbo].[Auditoria] CHECK CONSTRAINT [fk_CheckList_Auditoria]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EPI_Empresa_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[EPI_Empresa]'))
ALTER TABLE [dbo].[EPI_Empresa]  WITH CHECK ADD  CONSTRAINT [FK_EPI_Empresa_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[EPI_Empresa] CHECK CONSTRAINT [FK_EPI_Empresa_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EPI_Empresa_EPI]') AND parent_object_id = OBJECT_ID(N'[dbo].[EPI_Empresa]'))
ALTER TABLE [dbo].[EPI_Empresa]  WITH CHECK ADD  CONSTRAINT [FK_EPI_Empresa_EPI] FOREIGN KEY([IDEPI])
REFERENCES [dbo].[EPI] ([IDEPI])
GO
ALTER TABLE [dbo].[EPI_Empresa] CHECK CONSTRAINT [FK_EPI_Empresa_EPI]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Auditoria_Itens_Auditoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Auditoria_Itens]'))
ALTER TABLE [dbo].[Auditoria_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Auditoria_Itens_Auditoria] FOREIGN KEY([IDAuditoria], [IDCheckList])
REFERENCES [dbo].[Auditoria] ([IDAuditoria], [IDCheckList])
GO
ALTER TABLE [dbo].[Auditoria_Itens] CHECK CONSTRAINT [FK_Auditoria_Itens_Auditoria]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Auditoria_Itens_CheckList_Itens]') AND parent_object_id = OBJECT_ID(N'[dbo].[Auditoria_Itens]'))
ALTER TABLE [dbo].[Auditoria_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Auditoria_Itens_CheckList_Itens] FOREIGN KEY([IDItem])
REFERENCES [dbo].[CheckList_Itens] ([IDItem])
GO
ALTER TABLE [dbo].[Auditoria_Itens] CHECK CONSTRAINT [FK_Auditoria_Itens_CheckList_Itens]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcao_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcao]'))
ALTER TABLE [dbo].[Funcao]  WITH CHECK ADD  CONSTRAINT [FK_Funcao_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[Funcao] CHECK CONSTRAINT [FK_Funcao_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Documento_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Documento]'))
ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_Documento_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EPI_Empresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[EPI]'))
ALTER TABLE [dbo].[EPI]  WITH CHECK ADD  CONSTRAINT [FK_EPI_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[EPI] CHECK CONSTRAINT [FK_EPI_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcionario_EPI_Funcionario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcionario_EPI]'))
ALTER TABLE [dbo].[Funcionario_EPI]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_EPI_Funcionario] FOREIGN KEY([IDFuncionario])
REFERENCES [dbo].[Funcionario] ([IDFuncionario])
GO
ALTER TABLE [dbo].[Funcionario_EPI] CHECK CONSTRAINT [FK_Funcionario_EPI_Funcionario]
GO
INSERT INTO Configuracoes(versao) VALUES(1)
GO
UPDATE Empresa SET DuracaoCheckList = 6