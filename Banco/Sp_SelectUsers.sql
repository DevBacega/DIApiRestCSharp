SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_SelectUsers] (
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


