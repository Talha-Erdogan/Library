USE [Library]
GO
/****** Object:  Table [dbo].[Auth]    Script Date: 18.08.2020 13:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auth](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [int] NULL,
	[DeletedDateTime] [datetime] NULL,
 CONSTRAINT [PK_Auth] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 18.08.2020 13:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AuthorName] [nvarchar](50) NULL,
	[AuthorSurname] [nvarchar](50) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DeletedBy] [int] NULL,
	[DeletedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowBook]    Script Date: 18.08.2020 13:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[IsBring] [bit] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDateTime] [datetime] NULL,
	[ExpirationDateTime] [datetime] NULL,
 CONSTRAINT [PK_BorrowBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 18.08.2020 13:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 18.08.2020 13:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[TC] [nvarchar](12) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[Panel] [bit] NOT NULL,
	[ImageFilePath] [nvarchar](100) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](150) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 18.08.2020 13:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedDateTime] [datetime] NULL,
	[DeletedBy] [int] NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileDetail]    Script Date: 18.08.2020 13:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [int] NOT NULL,
	[AuthId] [int] NOT NULL,
 CONSTRAINT [PK_ProfileDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileMember]    Script Date: 18.08.2020 13:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileMember](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_ProfileEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Auth] ON 

INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (2, N'denemeCode', N'denemeName', 1, 1, CAST(N'2020-08-14T12:52:05.213' AS DateTime))
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (3, N'PAGE_AUTH_LIST', N'Yetki Listeleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (4, N'PAGE_AUTH_ADD', N'Yetki Ekleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (5, N'PAGE_AUTH_EDIT', N'Yetki Düzenleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (6, N'PAGE_AUTH_DISPLAY', N'Yetki Görüntüleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (7, N'PAGE_AUTH_DELETE', N'Yetki Silme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (8, N'PAGE_BOOK_LIST', N'Kitap Listeleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (9, N'PAGE_BOOK_ADD', N'Kitap Ekleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (10, N'PAGE_BOOK_EDIT', N'Kitap Düzenleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (11, N'PAGE_BOOK_DISPLAY', N'Kitap Görüntüleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (12, N'PAGE_PROFILE_LIST', N'Profil Listeleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (13, N'PAGE_PROFILE_ADD', N'Profil Ekleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (14, N'PAGE_PROFILE_EDIT', N'Profil Düzenleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (15, N'PAGE_PROFILE_DISPLAY', N'Profil Görüntüleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (16, N'PAGE_PROFILE_DELETE', N'Profil Silme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (17, N'PAGE_BOOK_DELETE', N'Kitap Silme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (18, N'PAGE_BORROWEDBOOK_LIST', N'Ödünç Verilen Kitapları Görüntüleme Yetkisi', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (19, N'PAGE_BROUGHTBOOK_LIST', N'Getirilen Kitaplar Listesi', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (20, N'PAGE_CATEGORY_LIST', N'Kategori Listesi', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (21, N'PAGE_CATEGORY_ADD', N'Kategori Ekleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (22, N'PAGE_CATEGORY_EDIT', N'Kategori Düzenleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (23, N'PAGE_CATEGORY_DISPLAY', N'Kategori Görüntüleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (24, N'PAGE_MEMBER_LIST', N'Üye Listeleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (25, N'PAGE_MEMBER_ADD', N'Üye Ekleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (26, N'PAGE_MEMBER_EDIT', N'Üye Düzenleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (27, N'PAGE_MEMBER_DISPLAY', N'Üye Görüntüleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (28, N'PAGE_PROFILEDETAIL_BATCHEDIT', N'Profil Detaylarını Görüntüleme', 0, 0, NULL)
INSERT [dbo].[Auth] ([Id], [Code], [Name], [IsDeleted], [DeletedBy], [DeletedDateTime]) VALUES (29, N'PAGE_PROFILEMEMBER_BATCHEDIT', N'Profil Üyelerini Görüntüleme', 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Auth] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (1, 22, N'4.Murat', N'Yavuz', N'Bahadıroğlu', CAST(N'2020-08-14T14:54:17.443' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (2, 1, N'deneme anı', N'deneme anı yazar', N'deneme anı yazar s', CAST(N'2020-08-14T15:02:55.733' AS DateTime), 1, 1, CAST(N'2020-08-14T15:17:31.097' AS DateTime), 1)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (3, 3, N'deneme bilim kurgu', N'deneme bilim kurgu yazar', N'deneme bilim kurgu yazar s', CAST(N'2020-08-14T15:03:20.867' AS DateTime), 1, 1, CAST(N'2020-08-14T15:17:31.210' AS DateTime), 1)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (4, 1, N'Benim Hikayem', N'Michelle', N'Obama', CAST(N'2020-08-17T14:41:20.347' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (5, 1, N'Kırmızı Kartal', N'Miyase', N' Sertbarut', CAST(N'2020-08-17T14:41:54.410' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (6, 2, N'Güç ve Refah', N'Ronald', N' Findlay', CAST(N'2020-08-17T14:42:43.777' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (7, 2, N'Metaların Kerameti', N'Kolektif', N'Kolektif', CAST(N'2020-08-17T14:43:06.890' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (8, 2, N'Osmanlı Vampirleri', N'Salim Fikret ', N'Kırgi', CAST(N'2020-08-17T14:43:41.997' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (9, 3, N'Dijital Ruh', N'Edward Ashford', N' Lee', CAST(N'2020-08-17T14:44:51.367' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (10, 3, N'Mitomani: Apple’dan Işid’e Günümüzün Masalları', N'Peter', N' Conrad', CAST(N'2020-08-17T14:45:21.680' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (11, 4, N'Salondaki En Kötü Koltuk', N'Murat', N' Murathanoğlu', CAST(N'2020-08-17T14:46:06.767' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (12, 4, N'Latife Hanım', N' İpek', N' Çalışlar', CAST(N'2020-08-17T14:46:30.590' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Book] ([Id], [CategoryId], [Name], [AuthorName], [AuthorSurname], [CreatedDateTime], [CreatedBy], [DeletedBy], [DeletedDateTime], [IsDeleted]) VALUES (13, 4, N'Futbolun Büyüsü ve Gerçekleşen Hayaller', N'Mesut', N' Özil', CAST(N'2020-08-17T14:46:51.000' AS DateTime), 1, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[BorrowBook] ON 

INSERT [dbo].[BorrowBook] ([Id], [MemberId], [BookId], [IsBring], [CreatedDateTime], [CreatedBy], [ModifiedBy], [ModifiedDateTime], [ExpirationDateTime]) VALUES (1, 4, 4, 1, CAST(N'2020-08-17T15:48:43.117' AS DateTime), 3, NULL, NULL, CAST(N'2020-09-16T15:48:43.117' AS DateTime))
INSERT [dbo].[BorrowBook] ([Id], [MemberId], [BookId], [IsBring], [CreatedDateTime], [CreatedBy], [ModifiedBy], [ModifiedDateTime], [ExpirationDateTime]) VALUES (2, 2, 4, 1, CAST(N'2020-08-18T13:29:27.113' AS DateTime), 3, NULL, NULL, CAST(N'2020-09-17T13:29:27.113' AS DateTime))
INSERT [dbo].[BorrowBook] ([Id], [MemberId], [BookId], [IsBring], [CreatedDateTime], [CreatedBy], [ModifiedBy], [ModifiedDateTime], [ExpirationDateTime]) VALUES (3, 4, 7, 1, CAST(N'2020-08-18T13:29:37.230' AS DateTime), 3, NULL, NULL, CAST(N'2020-09-17T13:29:37.230' AS DateTime))
SET IDENTITY_INSERT [dbo].[BorrowBook] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Anı')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Araştırma - İnceleme')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Bilim Kurgu')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Biyografi')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'Edebiyat')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'Eğitim')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (7, N'Felsefe')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'Gençlik')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (9, N'Gezi')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (10, N'Hikaye')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (11, N'İnceleme')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (12, N'İş Ekonomi')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (13, N'Hukuk')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (14, N'Kişisel Gelişim')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (15, N'Masal')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (16, N'Mektup')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (17, N'Öykü')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (18, N'Psikiloji')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (19, N'Roman')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (20, N'Sanat')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (21, N'Sağlık')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (22, N'Tarih')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([Id], [Name], [LastName], [TC], [Phone], [CreatedDateTime], [Panel], [ImageFilePath], [UserName], [Password]) VALUES (2, N'Talha', N'Erdogan', N'33344455566', N'5538885665', CAST(N'2020-08-14T00:00:00.000' AS DateTime), 0, N'5f6ebaf8-4a79-4f81-a49a-1a6c12431f03btpro2.jpg', N't', N'1')
INSERT [dbo].[Member] ([Id], [Name], [LastName], [TC], [Phone], [CreatedDateTime], [Panel], [ImageFilePath], [UserName], [Password]) VALUES (3, N'Talha', N'Erdogan Kitap', N'77788899965', N'5559996644', CAST(N'2020-08-14T00:00:00.000' AS DateTime), 0, NULL, N'tt', N'1')
INSERT [dbo].[Member] ([Id], [Name], [LastName], [TC], [Phone], [CreatedDateTime], [Panel], [ImageFilePath], [UserName], [Password]) VALUES (4, N'Talha', N'Erdogan', N'1234569877', N'789654321', CAST(N'2020-08-14T18:08:24.837' AS DateTime), 0, NULL, N'ttt', N'1')
INSERT [dbo].[Member] ([Id], [Name], [LastName], [TC], [Phone], [CreatedDateTime], [Panel], [ImageFilePath], [UserName], [Password]) VALUES (5, N'Talha', N'Erdogan Resimsiz', N'987654321', N'987654321', CAST(N'2020-08-14T18:10:52.733' AS DateTime), 0, NULL, N'tttt', N'1')
INSERT [dbo].[Member] ([Id], [Name], [LastName], [TC], [Phone], [CreatedDateTime], [Panel], [ImageFilePath], [UserName], [Password]) VALUES (6, N'Talha', N'Erdogan Resimsiz', N'9852344', N'123456789', CAST(N'2020-08-14T18:12:46.133' AS DateTime), 0, NULL, N'ttttt', N'1')
INSERT [dbo].[Member] ([Id], [Name], [LastName], [TC], [Phone], [CreatedDateTime], [Panel], [ImageFilePath], [UserName], [Password]) VALUES (7, N'ttt', N'eee', N'324', N'234', CAST(N'2020-08-14T18:29:53.340' AS DateTime), 0, NULL, N'tttttt', N'1')
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
SET IDENTITY_INSERT [dbo].[Profile] ON 

INSERT [dbo].[Profile] ([Id], [Code], [Name], [IsDeleted], [DeletedDateTime], [DeletedBy]) VALUES (1, N'SYSTEMADMIN', N'Sistem Admin Profili', 0, NULL, 0)
INSERT [dbo].[Profile] ([Id], [Code], [Name], [IsDeleted], [DeletedDateTime], [DeletedBy]) VALUES (2, N'denemeee', N'deneme', 1, CAST(N'2020-08-14T15:38:49.390' AS DateTime), 1)
INSERT [dbo].[Profile] ([Id], [Code], [Name], [IsDeleted], [DeletedDateTime], [DeletedBy]) VALUES (3, N'BOOK_MANAGEMENT_PROFILE', N'Kitap Yönetim Profili', 0, NULL, 0)
SET IDENTITY_INSERT [dbo].[Profile] OFF
GO
SET IDENTITY_INSERT [dbo].[ProfileDetail] ON 

INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (1, 3, 10)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (2, 3, 9)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (3, 3, 11)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (5, 3, 8)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (6, 1, 14)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (7, 1, 13)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (8, 1, 15)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (9, 1, 12)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (10, 1, 16)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (11, 1, 5)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (12, 1, 4)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (13, 1, 6)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (14, 1, 3)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (15, 1, 7)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (16, 1, 10)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (17, 1, 9)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (18, 1, 11)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (19, 1, 8)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (20, 3, 19)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (21, 3, 17)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (22, 3, 18)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (23, 1, 22)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (24, 1, 21)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (25, 1, 23)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (26, 1, 20)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (27, 1, 28)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (28, 1, 29)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (29, 1, 26)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (30, 1, 25)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (31, 1, 19)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (32, 1, 17)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (33, 1, 18)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (34, 1, 27)
INSERT [dbo].[ProfileDetail] ([Id], [ProfileId], [AuthId]) VALUES (35, 1, 24)
SET IDENTITY_INSERT [dbo].[ProfileDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[ProfileMember] ON 

INSERT [dbo].[ProfileMember] ([Id], [ProfileId], [MemberId]) VALUES (9, 1, 2)
INSERT [dbo].[ProfileMember] ([Id], [ProfileId], [MemberId]) VALUES (10, 3, 3)
SET IDENTITY_INSERT [dbo].[ProfileMember] OFF
GO
