SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_DeleteCategory] (@Id_Category INT)
AS
BEGIN
    DELETE
    FROM Category
    WHERE Id_Category = @Id_Category
END;
GO


