USE [PropertyManagementDb]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerType]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OwnerType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PropertyOwnerType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[OwnerType] ON
INSERT [dbo].[OwnerType] ([Id], [Type]) VALUES (1, N'Individual')
INSERT [dbo].[OwnerType] ([Id], [Type]) VALUES (2, N'Company')
SET IDENTITY_INSERT [dbo].[OwnerType] OFF
/****** Object:  Table [dbo].[Feature]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feature](
	[FeatureId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED 
(
	[FeatureId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Feature] ON
INSERT [dbo].[Feature] ([FeatureId], [Description]) VALUES (1, N'Pool')
INSERT [dbo].[Feature] ([FeatureId], [Description]) VALUES (2, N'Dishwasher')
INSERT [dbo].[Feature] ([FeatureId], [Description]) VALUES (3, N'Central AC')
INSERT [dbo].[Feature] ([FeatureId], [Description]) VALUES (4, N'Washer/Dryer inside unit')
INSERT [dbo].[Feature] ([FeatureId], [Description]) VALUES (5, N'Washer/Dryer outside unit')
SET IDENTITY_INSERT [dbo].[Feature] OFF
/****** Object:  Table [dbo].[ExpenseIncomeCategories]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExpenseIncomeCategories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Label] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsTaxDeductible] [bit] NOT NULL,
 CONSTRAINT [PK_ExpenseIncomeCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LeaseTerms]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LeaseTerms](
	[LeaseTermId] [int] IDENTITY(1,1) NOT NULL,
	[Duration] [float] NOT NULL,
	[MonthlyRent] [decimal](18, 0) NOT NULL,
	[Description] [varbinary](50) NULL,
 CONSTRAINT [PK_LeaseTerms] PRIMARY KEY CLUSTERED 
(
	[LeaseTermId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers] 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a986b627-a8d7-43f3-a5dd-02ba311021bb', N'carmendiaz83@gmail.com', 0, N'ALm9H/7AJCE6muwk/zQ8bf1kEo9quHBpQB3ivP4RZuXFbBBlqYDlimSHCUzQwfW2RA==', N'2c0b2c96-75bc-402a-aad9-44a57d767309', NULL, 0, 0, NULL, 1, 0, N'carmendiaz83@gmail.com')
/****** Object:  Table [dbo].[Tenant]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tenant](
	[TenantId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DateOfBirth] [nchar](10) NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ResposibleParty]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ResposibleParty](
	[ResposiblePartyId] [int] IDENTITY(1,1) NOT NULL,
	[ResponsibleParty] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ResposibleParty] PRIMARY KEY CLUSTERED 
(
	[ResposiblePartyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyStatus]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertyStatus](
	[PropertyStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PropertyStatus] PRIMARY KEY CLUSTERED 
(
	[PropertyStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyStatus] ON
INSERT [dbo].[PropertyStatus] ([PropertyStatusId], [Status]) VALUES (1, N'Available')
INSERT [dbo].[PropertyStatus] ([PropertyStatusId], [Status]) VALUES (2, N'Leased')
INSERT [dbo].[PropertyStatus] ([PropertyStatusId], [Status]) VALUES (3, N'Sold')
SET IDENTITY_INSERT [dbo].[PropertyStatus] OFF
/****** Object:  Table [dbo].[VendorContractor]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorContractor](
	[ContractorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_VendorContractor] PRIMARY KEY CLUSTERED 
(
	[ContractorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Owner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Address] [varchar](150) NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_PropertyOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Owner] ON
INSERT [dbo].[Owner] ([Id], [Name], [TypeId], [Address], [UserId]) VALUES (1, N'Better Props LLC', 2, N'123 Test Street', N'a986b627-a8d7-43f3-a5dd-02ba311021bb')
SET IDENTITY_INSERT [dbo].[Owner] OFF
/****** Object:  Table [dbo].[Property]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](150) NOT NULL,
	[Size] [float] NULL,
	[Bedrooms] [float] NULL,
	[Bathrooms] [float] NULL,
	[Description] [varchar](250) NULL,
	[PropertyStatusId] [int] NULL,
	[ParentPropertyId] [int] NULL,
	[OwnerId] [int] NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON
INSERT [dbo].[Property] ([Id], [Address], [Size], [Bedrooms], [Bathrooms], [Description], [PropertyStatusId], [ParentPropertyId], [OwnerId]) VALUES (1, N'1551 SW 135 Ter', 900, 2, 2, N'Some description', 2, NULL, 1)
INSERT [dbo].[Property] ([Id], [Address], [Size], [Bedrooms], [Bathrooms], [Description], [PropertyStatusId], [ParentPropertyId], [OwnerId]) VALUES (2, N'50 Antilla Avenue', 1200, 2, 1.5, N'Some other description', 2, NULL, 1)
SET IDENTITY_INSERT [dbo].[Property] OFF
/****** Object:  Table [dbo].[Transaction]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[PropertyOwnerId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[BillId] [int] NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyOwner]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyOwner](
	[OwnerId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyOwner_1] PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC,
	[PropertyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyFeature]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyFeature](
	[PropertyId] [int] NOT NULL,
	[FeatureId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyFeature] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC,
	[FeatureId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PropertyFeature] ([PropertyId], [FeatureId]) VALUES (1, 1)
INSERT [dbo].[PropertyFeature] ([PropertyId], [FeatureId]) VALUES (1, 2)
INSERT [dbo].[PropertyFeature] ([PropertyId], [FeatureId]) VALUES (1, 3)
/****** Object:  Table [dbo].[LeaseApplication]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaseApplication](
	[LeaseApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [int] NOT NULL,
	[LeaseTermsId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_LeaseApplication] PRIMARY KEY CLUSTERED 
(
	[LeaseApplicationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lease]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lease](
	[LeaseId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[Duration] [float] NOT NULL,
	[InitialDeposit] [decimal](18, 0) NOT NULL,
	[InitialDepositDescription] [varchar](50) NOT NULL,
	[MonthlyRent] [decimal](18, 0) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Lease] PRIMARY KEY CLUSTERED 
(
	[LeaseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[PropertyOwnerId] [int] NOT NULL,
	[ResposiblePartyId] [int] NOT NULL,
	[TaskId] [int] NULL,
	[PropertyId] [int] NULL,
	[TenantId] [int] NULL,
	[DueDate] [datetime] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Description] [varchar](50) NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaintenanceRequest]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaintenanceRequest](
	[MaintenanceRequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestedBy] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[Description] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_MaintenanceRequest] PRIMARY KEY CLUSTERED 
(
	[MaintenanceRequestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaintenanceTask]    Script Date: 02/13/2018 21:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaintenanceTask](
	[TaskId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[MaintenanceRequestId] [int] NOT NULL,
	[AssignedTo] [int] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_MaintenanceTask] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_ExpenseIncomeCategories_IsTaxDeductible]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[ExpenseIncomeCategories] ADD  CONSTRAINT [DF_ExpenseIncomeCategories_IsTaxDeductible]  DEFAULT ((0)) FOR [IsTaxDeductible]
GO
/****** Object:  ForeignKey [FK_VendorContractor_AspNetUsers]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[VendorContractor]  WITH CHECK ADD  CONSTRAINT [FK_VendorContractor_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[VendorContractor] CHECK CONSTRAINT [FK_VendorContractor_AspNetUsers]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_Owner_AspNetUsers]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Owner]  WITH CHECK ADD  CONSTRAINT [FK_Owner_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Owner] CHECK CONSTRAINT [FK_Owner_AspNetUsers]
GO
/****** Object:  ForeignKey [FK_PropertyOwner_PropertyOwnerType]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Owner]  WITH CHECK ADD  CONSTRAINT [FK_PropertyOwner_PropertyOwnerType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[OwnerType] ([Id])
GO
ALTER TABLE [dbo].[Owner] CHECK CONSTRAINT [FK_PropertyOwner_PropertyOwnerType]
GO
/****** Object:  ForeignKey [FK_Property_Owner]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Owner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Owner]
GO
/****** Object:  ForeignKey [FK_Property_Property]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Property] FOREIGN KEY([ParentPropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Property]
GO
/****** Object:  ForeignKey [FK_Property_PropertyStatus]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_PropertyStatus] FOREIGN KEY([PropertyStatusId])
REFERENCES [dbo].[PropertyStatus] ([PropertyStatusId])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_PropertyStatus]
GO
/****** Object:  ForeignKey [FK_Transaction_ExpenseIncomeCategories]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_ExpenseIncomeCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ExpenseIncomeCategories] ([CategoryId])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_ExpenseIncomeCategories]
GO
/****** Object:  ForeignKey [FK_Transaction_Owner]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Owner] FOREIGN KEY([PropertyOwnerId])
REFERENCES [dbo].[Owner] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Owner]
GO
/****** Object:  ForeignKey [FK_PropertyOwner_Owner]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[PropertyOwner]  WITH CHECK ADD  CONSTRAINT [FK_PropertyOwner_Owner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([Id])
GO
ALTER TABLE [dbo].[PropertyOwner] CHECK CONSTRAINT [FK_PropertyOwner_Owner]
GO
/****** Object:  ForeignKey [FK_PropertyOwner_Property]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[PropertyOwner]  WITH CHECK ADD  CONSTRAINT [FK_PropertyOwner_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyOwner] CHECK CONSTRAINT [FK_PropertyOwner_Property]
GO
/****** Object:  ForeignKey [FK_PropertyFeature_Feature]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[PropertyFeature]  WITH CHECK ADD  CONSTRAINT [FK_PropertyFeature_Feature] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Feature] ([FeatureId])
GO
ALTER TABLE [dbo].[PropertyFeature] CHECK CONSTRAINT [FK_PropertyFeature_Feature]
GO
/****** Object:  ForeignKey [FK_PropertyFeature_Property]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[PropertyFeature]  WITH CHECK ADD  CONSTRAINT [FK_PropertyFeature_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyFeature] CHECK CONSTRAINT [FK_PropertyFeature_Property]
GO
/****** Object:  ForeignKey [FK_LeaseApplication_LeaseTerms]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[LeaseApplication]  WITH CHECK ADD  CONSTRAINT [FK_LeaseApplication_LeaseTerms] FOREIGN KEY([LeaseTermsId])
REFERENCES [dbo].[LeaseTerms] ([LeaseTermId])
GO
ALTER TABLE [dbo].[LeaseApplication] CHECK CONSTRAINT [FK_LeaseApplication_LeaseTerms]
GO
/****** Object:  ForeignKey [FK_LeaseApplication_Property]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[LeaseApplication]  WITH CHECK ADD  CONSTRAINT [FK_LeaseApplication_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[LeaseApplication] CHECK CONSTRAINT [FK_LeaseApplication_Property]
GO
/****** Object:  ForeignKey [FK_LeaseApplication_Tenant]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[LeaseApplication]  WITH CHECK ADD  CONSTRAINT [FK_LeaseApplication_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([TenantId])
GO
ALTER TABLE [dbo].[LeaseApplication] CHECK CONSTRAINT [FK_LeaseApplication_Tenant]
GO
/****** Object:  ForeignKey [FK_Lease_Property]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[Lease] CHECK CONSTRAINT [FK_Lease_Property]
GO
/****** Object:  ForeignKey [FK_Lease_Tenant]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([TenantId])
GO
ALTER TABLE [dbo].[Lease] CHECK CONSTRAINT [FK_Lease_Tenant]
GO
/****** Object:  ForeignKey [FK_Bill_Owner]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Owner] FOREIGN KEY([PropertyOwnerId])
REFERENCES [dbo].[Owner] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Owner]
GO
/****** Object:  ForeignKey [FK_Bill_Property]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Property]
GO
/****** Object:  ForeignKey [FK_Bill_ResposibleParty]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_ResposibleParty] FOREIGN KEY([ResposiblePartyId])
REFERENCES [dbo].[ResposibleParty] ([ResposiblePartyId])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_ResposibleParty]
GO
/****** Object:  ForeignKey [FK_Bill_Tenant]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([TenantId])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Tenant]
GO
/****** Object:  ForeignKey [FK_MaintenanceRequest_Property]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[MaintenanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceRequest_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[MaintenanceRequest] CHECK CONSTRAINT [FK_MaintenanceRequest_Property]
GO
/****** Object:  ForeignKey [FK_MaintenanceRequest_ResposibleParty]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[MaintenanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceRequest_ResposibleParty] FOREIGN KEY([RequestedBy])
REFERENCES [dbo].[ResposibleParty] ([ResposiblePartyId])
GO
ALTER TABLE [dbo].[MaintenanceRequest] CHECK CONSTRAINT [FK_MaintenanceRequest_ResposibleParty]
GO
/****** Object:  ForeignKey [FK_MaintenanceTask_MaintenanceRequest]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[MaintenanceTask]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceTask_MaintenanceRequest] FOREIGN KEY([MaintenanceRequestId])
REFERENCES [dbo].[MaintenanceRequest] ([MaintenanceRequestId])
GO
ALTER TABLE [dbo].[MaintenanceTask] CHECK CONSTRAINT [FK_MaintenanceTask_MaintenanceRequest]
GO
/****** Object:  ForeignKey [FK_MaintenanceTask_VendorContractor]    Script Date: 02/13/2018 21:50:03 ******/
ALTER TABLE [dbo].[MaintenanceTask]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceTask_VendorContractor] FOREIGN KEY([AssignedTo])
REFERENCES [dbo].[VendorContractor] ([ContractorId])
GO
ALTER TABLE [dbo].[MaintenanceTask] CHECK CONSTRAINT [FK_MaintenanceTask_VendorContractor]
GO
