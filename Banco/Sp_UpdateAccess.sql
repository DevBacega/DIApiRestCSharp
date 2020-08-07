SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_UpdateAccess] (
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


