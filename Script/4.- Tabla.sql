USE BIOMETRICOBD
GO


CREATE TABLE [ESQUEMA_BIOMETRICO].[MODELOS_DEL_BIOMETRICO](
	[CODIGO_DE_TIPO] [numeric](2, 0) NOT NULL,
	[DESCRIPCION_DEL_TIPO] [varchar](200) NULL,
	[FECHA_GRABACION] [datetime] NOT NULL,
	[CODIGO_DE_USUARIO] [char](10) NOT NULL,
 CONSTRAINT [K61] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DE_TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE SYNONYM MODELOS_DEL_BIOMETRICO FOR ESQUEMA_BIOMETRICO.MODELOS_DEL_BIOMETRICO

/*--------------------------------------------------------------------*/

CREATE TABLE [ESQUEMA_BIOMETRICO].[BIOMETRICOS_DE_MARCAJE](
	[CODIGO_DE_RELOJ] [numeric](2, 0) NOT NULL,
	[DESCRIPCION_DEL_RELOJ] [varchar](200) NULL,
	[IP_DEL_RELOJ] [varchar](14) NOT NULL,
	[RELOJ_EN_USO] [char](2) NULL,
	[CODIGO_DE_TIPO] [numeric](2, 0) NOT NULL,
	[FECHA_GRABACION] [datetime] NOT NULL,
	[CODIGO_DE_USUARIO] [char](10) NOT NULL,
 CONSTRAINT [K60] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DE_RELOJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ESQUEMA_BIOMETRICO].[BIOMETRICOS_DE_MARCAJE]  WITH CHECK ADD  CONSTRAINT [F318] FOREIGN KEY([CODIGO_DE_TIPO])
REFERENCES [ESQUEMA_BIOMETRICO].[MODELOS_DEL_BIOMETRICO] ([CODIGO_DE_TIPO])
GO

ALTER TABLE [ESQUEMA_BIOMETRICO].[BIOMETRICOS_DE_MARCAJE] CHECK CONSTRAINT [F318]
GO


CREATE SYNONYM BIOMETRICOS_DE_MARCAJE FOR ESQUEMA_BIOMETRICO.BIOMETRICOS_DE_MARCAJE


/* ----------------------------------------------------------------------------------- */


CREATE TABLE [ESQUEMA_BIOMETRICO].[DESCARGA_DE_MARCAJES](
	[CODIGO_DE_RELOJ] [numeric](2, 0) NOT NULL,
	[CODIGO_DE_MARCAJE] [numeric](11, 0) NOT NULL,
	[FECHA_DE_MARCAJE] [date] NOT NULL,
	[HORA_DE_MARCAJE] [time](7) NOT NULL,
	SECUENCIA_MARCAJES numeric (2) NOT NULL,
	[CODIGO_DE_USUARIO] [char](10) NOT NULL,
	[FECHA_GRABACION] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [ESQUEMA_BIOMETRICO].[DESCARGA_DE_MARCAJES]  WITH CHECK ADD  CONSTRAINT [F319] FOREIGN KEY([CODIGO_DE_RELOJ])
REFERENCES [ESQUEMA_BIOMETRICO].[BIOMETRICOS_DE_MARCAJE] ([CODIGO_DE_RELOJ])
GO

ALTER TABLE [ESQUEMA_BIOMETRICO].[DESCARGA_DE_MARCAJES] CHECK CONSTRAINT [F319]
GO

CREATE SYNONYM DESCARGA_DE_MARCAJES FOR ESQUEMA_BIOMETRICO.DESCARGA_DE_MARCAJES

/* ---------------------------------------------------------------------- */


CREATE TABLE [ESQUEMA_BIOMETRICO].[DESCARGA_DE_MARCAJES_LOG](
	[CODIGO_DE_RELOJ] [numeric](2, 0) NOT NULL,
	[CODIGO_DE_MARCAJE] [numeric](11, 0) NOT NULL,
	[FECHA_DE_MARCAJE] [date] NOT NULL,
	[HORA_DE_MARCAJE] [time](7) NOT NULL,
	SECUENCIA_MARCAJES numeric (2) NOT NULL,
	[CODIGO_DE_USUARIO] [char](10) NOT NULL,
	[FECHA_GRABACION] [datetime] NOT NULL
) ON [PRIMARY]
GO

CREATE SYNONYM DESCARGA_DE_MARCAJES_LOG FOR ESQUEMA_BIOMETRICO.DESCARGA_DE_MARCAJES_LOG

/*-------------------------------------------------------------------------------*/

CREATE TABLE [ESQUEMA_SEGURIDAD].[MENU_BIOMETRICO](
	[OPCION_MENU] [numeric](5, 0) NOT NULL,
	[TEXTO_OPCION_MENU] [char](50) NOT NULL,
	[INDICE_MENU] [numeric](5, 0) NULL,
	[GRUPO_MENU] [numeric](5, 0) NULL,
	[OPCION_HABILITADA] [char](2) NULL,
 CONSTRAINT [K30011] PRIMARY KEY CLUSTERED 
(
	[OPCION_MENU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE SYNONYM ESQUEMA_SEGURIDAD.MENU_BIOMETRICO FOR MENU_BIOMETRICO

/*-------------------------------------------------------------------------------*/

CREATE TABLE [ESQUEMA_SEGURIDAD].[USUARIOS_BIOMETRICO](
	[CODIGO_DE_USUARIO] [char](10) NOT NULL,
	[CODIGO_DE_PERSONAL] [numeric](6, 0) NOT NULL,
	[PERMISO_DE_MARCAJE] [varchar](90) NOT NULL,
	[INDICE_HUELLA_DE_MARCAJE] [numeric](2, 0) NULL,
	[HUELLA_DE_MARCAJE] [binary](1) NULL,
	[USUARIO_ACTIVO] [char](2) NULL,
 CONSTRAINT [K30012] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DE_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE SYNONYM USUARIOS_BIOMETRICO FOR ESQUEMA_SEGURIDAD.USUARIOS_BIOMETRICO


/* -------------------------------------------------------------------------------- */


CREATE TABLE [ESQUEMA_SEGURIDAD].[USUARIOS_MENU_BIOMETRICO](
	[CODIGO_DE_USUARIO] [char](10) NOT NULL,
	[OPCION_MENU] [numeric](5, 0) NOT NULL,
	[S] [char](2) NULL,
	[Q] [char](2) NULL,
	[I] [char](2) NULL,
	[U] [char](2) NULL,
	[P] [char](2) NULL,
	[D] [char](2) NULL,
 CONSTRAINT [K30013] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DE_USUARIO] ASC,
	[OPCION_MENU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ESQUEMA_SEGURIDAD].[USUARIOS_MENU_BIOMETRICO]  WITH CHECK ADD  CONSTRAINT [F30007] FOREIGN KEY([CODIGO_DE_USUARIO])
REFERENCES [ESQUEMA_SEGURIDAD].[USUARIOS_BIOMETRICO] ([CODIGO_DE_USUARIO])
GO

ALTER TABLE [ESQUEMA_SEGURIDAD].[USUARIOS_MENU_BIOMETRICO] CHECK CONSTRAINT [F30007]
GO

ALTER TABLE [ESQUEMA_SEGURIDAD].[USUARIOS_MENU_BIOMETRICO]  WITH CHECK ADD  CONSTRAINT [F30008] FOREIGN KEY([OPCION_MENU])
REFERENCES [ESQUEMA_SEGURIDAD].[MENU_BIOMETRICO] ([OPCION_MENU])
ON UPDATE CASCADE
GO

ALTER TABLE [ESQUEMA_SEGURIDAD].[USUARIOS_MENU_BIOMETRICO] CHECK CONSTRAINT [F30008]
GO

CREATE SYNONYM USUARIOS_MENU_BIOMETRICO FOR ESQUEMA_SEGURIDAD.USUARIOS_MENU_BIOMETRICO

/* -------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------- */

CREATE TABLE [ESQUEMA_RH].[TIPO_DE_PERSONAL](
	[CODIGO_TIPO_PERSONAL] [char](3) NOT NULL,
	[DESCRIPCION_DEL_PERSONAL] [varchar](60) NOT NULL,
 CONSTRAINT [K20009] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TIPO_PERSONAL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/* -------------------------------------------------------------------------------- */

CREATE TABLE [ESQUEMA_RH].[PERSONAL](
	[CODIGO_DE_PERSONAL] [numeric](6, 0) NOT NULL,
	[PRIMER_NOMBRE_PERSONAL] [varchar](15) NOT NULL,
	[SEGUNDO_NOMBRE_PERSONAL] [varchar](15) NULL,
	[TERCER_NOMBRE_PERSONAL] [varchar](15) NULL,
	[PRIMER_APELLIDO_PERSONAL] [varchar](15) NOT NULL,
	[SEGUNDO_APELLIDO_PERSONAL] [varchar](15) NULL,
	[APELLIDO_CASADA_PERSONAL] [varchar](15) NULL,
	[NOMBRE_DEL_PERSONAL] [varchar](50) NOT NULL,
	[GENERO_PERSONAL] [char](1) NOT NULL,
	CODIGO_TIPO_PERSONAL char(3) not null,
	[CODIGO_UNIDAD_TRABAJO] [numeric](2, 0) NOT NULL,
	[CORREO_EMPRESA_PERSONAL] [varchar](35) NULL,
	[PERSONAL_ACTIVO] [char](2) NOT NULL,
	[FECHA_GRABACION_REGISTRO] [date] NOT NULL,
	[HORA_GRABACION_REGISTRO] [time](7) NOT NULL,
	[CODIGO_DE_USUARIO] [char](10) NULL,
	[CODIGO_MARCAJE_RELOJ] [numeric](6, 0) NULL,	
 CONSTRAINT [K20004] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DE_PERSONAL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ESQUEMA_RH].[PERSONAL] ADD  DEFAULT ('SI') FOR [PERSONAL_ACTIVO]
GO

ALTER TABLE [ESQUEMA_RH].[PERSONAL]  WITH CHECK ADD  CONSTRAINT [F20003] FOREIGN KEY([CODIGO_UNIDAD_TRABAJO])
REFERENCES [ESQUEMA_RH].[UNIDADES_DE_TRABAJO] ([CODIGO_UNIDAD_TRABAJO])
GO

ALTER TABLE [ESQUEMA_RH].[PERSONAL] CHECK CONSTRAINT [F20003]
GO

ALTER TABLE [ESQUEMA_RH].[PERSONAL]  WITH CHECK ADD  CONSTRAINT [F20010] FOREIGN KEY([CODIGO_TIPO_PERSONAL])
REFERENCES [ESQUEMA_RH].[TIPO_DE_PERSONAL] ([CODIGO_TIPO_PERSONAL])
GO

ALTER TABLE [ESQUEMA_RH].[PERSONAL] CHECK CONSTRAINT [F20010]
GO


ALTER TABLE [ESQUEMA_RH].[PERSONAL]  WITH CHECK ADD CHECK  (([GENERO_PERSONAL]='F' OR [GENERO_PERSONAL]='M'))
GO

ALTER TABLE [ESQUEMA_RH].[PERSONAL]  WITH CHECK ADD CHECK  (([PERSONAL_ACTIVO]='SI' OR [PERSONAL_ACTIVO]='NO' OR [PERSONAL_ACTIVO]='LI'))
GO
