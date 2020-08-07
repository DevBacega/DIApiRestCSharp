SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_UpdateUsers] (
    @Id_User INT
    , @Nm_User VARCHAR(50)
    , @Ps_User VARCHAR(15)
    , @Id_Access INT
    )
AS
BEGIN
    UPDATE Users
    SET Nm_User = @Nm_User
        , Ps_User = @Ps_User
        , Id_Access = @Id_Access
    WHERE Id_User = @Id_User
END;
GO


