USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 3/8/2016 8:08:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 3/8/2016 8:08:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (1, N'Testing', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (2, N'ssdsasd', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (3, N'assadasdsdas', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (4, N'ssaddsd', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (5, N'Testingall', 1)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (6, N'', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (7, N'', 1)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (8, N'dfssdffssfd', 5)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (9, N'sdfdsfsdfdssddfs', 5)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (10, N'Phillis', 4)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (11, N'adsdsadsasdsdaasdsadsda', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (12, N'sfdfds', 1)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (13, N'saddsadsa', 1)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (14, N'dsadsadasdasdasdsdasdas', 7)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (15, N'asasd', 8)
SET IDENTITY_INSERT [dbo].[clients] OFF
