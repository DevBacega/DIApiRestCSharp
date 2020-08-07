SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_SelectCategory] (
    @Id_Category INT = NULL
    , @Ds_Category VARCHAR(50) = NULL
    )
AS
BEGIN
    SELECT Id_Category
        , Ds_Category
    FROM Category
    WHERE ID_CATEGORY = isnull(@Id_Category, ID_CATEGORY)
        AND DS_CATEGORY LIKE CONCAT (
            '%'
            , isnull(@Ds_Category, DS_CATEGORY)
            , '%'
            )
END;
GO


