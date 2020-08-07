SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_UpdateCategory] (
    @Id_Category INT
    , @Ds_Category VARCHAR(50)
    )
AS
BEGIN
    UPDATE Category
    SET Ds_Category = @Ds_Category
    WHERE Id_Category = @Id_Category
END;
GO


