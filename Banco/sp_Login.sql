SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_Login] (
    @nm_User VARCHAR(50)
    , @ps_User VARCHAR(15)
    )
AS
BEGIN
    SELECT ID_User
        , nm_User
        , PS_USER
        , ID_ACCESS
        , ACTIVE
    FROM Users
    WHERE nm_User = @nm_User
        AND PS_USER = @ps_User
END;
GO


