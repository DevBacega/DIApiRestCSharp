USE [RFSystem]
GO
/****** Object:  Table [dbo].[Access]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Access](
	[ID_ACCESS] [int] IDENTITY(1,1) NOT NULL,
	[NM_ACCESS] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_ACCESS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[ID_CATEGORY] [int] IDENTITY(1,1) NOT NULL,
	[DS_CATEGORY] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CATEGORY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT](
	[ID_PRODUCT] [int] IDENTITY(1,1) NOT NULL,
	[DS_PRODUCT] [varchar](50) NOT NULL,
	[ID_CATEGORY] [int] NULL,
	[ACTIVE] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PRODUCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[ID_USER] [int] IDENTITY(1,1) NOT NULL,
	[NM_USER] [varchar](50) NOT NULL,
	[PS_USER] [varchar](15) NOT NULL,
	[ID_ACCESS] [int] NOT NULL,
	[ACTIVE] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PRODUCT] ADD  DEFAULT ((0)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[USERS] ADD  DEFAULT ((0)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProduct] FOREIGN KEY([ID_CATEGORY])
REFERENCES [dbo].[CATEGORY] ([ID_CATEGORY])
GO
ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_CategoryProduct]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [FK_AccessUser] FOREIGN KEY([ID_ACCESS])
REFERENCES [dbo].[Access] ([ID_ACCESS])
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [FK_AccessUser]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteAccess]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DeleteAccess] (@Id_Access INT)
AS
BEGIN
	DELETE FROM ACCESS WHERE Id_Access = @Id_Access
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteCategory]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DeleteCategory] (@Id_Category INT)
AS
BEGIN
	DELETE FROM Category WHERE Id_Category = @Id_Category
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteProduct]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DeleteProduct] (@Id_Product INT)
AS
BEGIN
	DELETE FROM Product WHERE Id_Product = @Id_Product
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteUser]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DeleteUser] (@Id_User INT)
AS
BEGIN
	DELETE FROM Users WHERE Id_User = @Id_User
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_DisableProduct]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DisableProduct] (@Id_Products INT)
AS
BEGIN
	UPDATE PRODUCT SET Active = 0 WHERE ID_PRODUCT = @Id_Products
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_DisableUser]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DisableUser] (@Id_Users INT)
AS
BEGIN
	UPDATE USERS SET Active = 0 WHERE ID_USER = @Id_Users
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertAccess]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertAccess](@Nm_Access varchar(50))
AS
BEGIN
	INSERT INTO Access VALUES(@Nm_Access)
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertCategory]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertCategory](@Ds_Category varchar(50))
AS
BEGIN
	INSERT INTO Category VALUES(@Ds_Category)
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertProducts]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertProducts] (
    @Ds_Product VARCHAR(50)
    , @Id_Category INT
    )
AS
BEGIN
    INSERT INTO Product
    VALUES (
        @Ds_Product
        , @Id_Category
        , 1
        );
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertUsers]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertUsers](@Nm_Users varchar(50), @Ps_Users varchar(15),@Id_Access INT)
AS
BEGIN
	INSERT INTO Users VALUES(@Nm_Users,@Ps_Users, @Id_Access, 1);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Login]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Login] (@nm_User varchar(50), @ps_User varchar(15))
as
begin

SELECT ID_User, nm_User, PS_USER, ID_ACCESS, ACTIVE from Users where nm_User = @nm_User and PS_USER = @ps_User

end;
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectAccess]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_SelectAccess] (@Id_Access int = NULL, @Nm_Access varchar(50) = NULL)
As
Begin

SELECT Id_Access,Nm_Access FROM Access WHERE ID_ACCESS = ISNULL(@Id_Access, ID_ACCESS) AND NM_ACCESS = ISNULL(@Nm_Access,NM_ACCESS)

End;
GO
/****** Object:  StoredProcedure [dbo].[Sp_SelectCategory]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_SelectCategory] (@Id_Category INT = NULL, @Ds_Category varchar(50) = NULL)
As
Begin

SELECT Id_Category,Ds_Category FROM Category WHERE ID_CATEGORY = isnull(@Id_Category,ID_CATEGORY) and DS_CATEGORY like Concat('%',isnull(@Ds_Category,DS_CATEGORY),'%')

End;
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectProduct]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_SelectProduct] (@DsProduct varchar(15) = null, @IdCategory Int = null,@IdProduct Int = null, @Active int = 1)
As
Begin
SELECT
	P.Id_Product,
	P.Ds_Product,
	P.Id_Category,
	C.Ds_Category,
	P.Active
FROM Product P
	INNER JOIN Category C ON P.Id_Category = C.Id_Category
WHERE
	P.Ds_Product LIKE CONCAT('%',ISNULL(@DsProduct, P.Ds_Product),'%')
	AND
	P.Id_Category = ISNULL (@IdCategory, P.Id_Category)
    AND
    P.Id_Product = ISNULL (@IdProduct, P.Id_Product)
	AND
	P.Active = @Active
End;
GO
/****** Object:  StoredProcedure [dbo].[Sp_SelectUsers]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_SelectUsers] (
    @Nm_User VARCHAR(50) = NULL
    , @Id_Access INT = NULL
    , @Id_User INT = NULL
    , @Ps_User VARCHAR(15) = NULL
    , @Active INT = 1
    )
AS
BEGIN
    SELECT U.ID_USER
        , U.NM_USER
        , U.PS_USER
        , U.ID_ACCESS
        , A.NM_ACCESS
        , U.ACTIVE
    FROM USERS U
    INNER JOIN ACCESS A
        ON U.ID_ACCESS = A.ID_ACCESS
    WHERE Active = @Active
        AND U.NM_USER LIKE ISNULL(@Nm_User, U.NM_USER)
        AND U.ID_ACCESS = ISNULL(@Id_Access, U.ID_ACCESS)
        AND U.ID_USER = ISNULL(@Id_User, U.ID_USER)
        AND U.PS_USER = ISNULL(@Ps_User, U.PS_USER)
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateAccess]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_UpdateAccess] (
    @Id_Access INT
    , @Nm_Access VARCHAR(15)
    )
AS
BEGIN
    UPDATE Access
    SET Nm_Access = @Nm_Access
    WHERE Id_Access = @Id_Access
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateCategory]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_UpdateCategory] (@Id_Category INT, @Ds_Category varchar(50))
AS
BEGIN
	UPDATE Category SET Ds_Category = @Ds_Category WHERE Id_Category = @Id_Category
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateProduct]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_UpdateProduct] (
    @Id_Product INT
    , @Ds_Product VARCHAR(50)
    , @Id_Category INT
    )
AS
BEGIN
    UPDATE Product
    SET Ds_Product = @Ds_product
        , Id_Category = @Id_Category
    WHERE Id_Product = @Id_Product
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateUsers]    Script Date: 07/08/2020 03:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_UpdateUsers] (@Id_User INT, @Nm_User varchar(50), @Ps_User varchar(15), @Id_Access int)
AS
BEGIN
	UPDATE Users SET Nm_User = @Nm_User, Ps_User = @Ps_User, Id_Access = @Id_Access WHERE Id_User = @Id_User
END;
GO
