USE [EVSite]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 24-Dec-2022 06:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityID] [bigint] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](510) NOT NULL,
	[CityChargeRatePerSecond] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 24-Dec-2022 06:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TxID] [bigint] IDENTITY(1,1) NOT NULL,
	[CityID] [bigint] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[ChargingTimeSeconds] [float] NOT NULL,
	[PayableAmount] [float] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([CityID], [CityName], [CityChargeRatePerSecond]) VALUES (1, N'Kochi', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [CityChargeRatePerSecond]) VALUES (2, N'Bangalore', 1.5)
INSERT [dbo].[Cities] ([CityID], [CityName], [CityChargeRatePerSecond]) VALUES (3, N'Chennai', 2)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_StartTime]  DEFAULT (getdate()) FOR [StartTime]
GO
