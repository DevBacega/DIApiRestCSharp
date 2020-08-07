SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_InsertUsers] (
    @Nm_Users VARCHAR(50)
    , @Ps_Users VARCHAR(15)
    , @Id_Access INT
    )
AS
BEGIN
    INSERT INTO Users
    VALUES (
        @Nm_Users
        , @Ps_Users
        , @Id_Access
        , 1
        );
END;
GO


