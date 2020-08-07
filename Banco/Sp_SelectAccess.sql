SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_SelectAccess] (
    @Id_Access INT = NULL
    , @Nm_Access VARCHAR(50) = NULL
    )
AS
BEGIN
    SELECT Id_Access
        , Nm_Access
    FROM Access
    WHERE ID_ACCESS = ISNULL(@Id_Access, ID_ACCESS)
        AND NM_ACCESS = ISNULL(@Nm_Access, NM_ACCESS)
END;
GO


