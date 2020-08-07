SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_SelectProduct] (
    @DsProduct VARCHAR(15) = NULL
    , @IdCategory INT = NULL
    , @IdProduct INT = NULL
    , @Active INT = 1
    )
AS
BEGIN
    SELECT P.Id_Product
        , P.Ds_Product
        , P.Id_Category
        , C.Ds_Category
        , P.Active
    FROM Product P
    INNER JOIN Category C
        ON P.Id_Category = C.Id_Category
    WHERE P.Ds_Product LIKE CONCAT (
            '%'
            , ISNULL(@DsProduct, P.Ds_Product)
            , '%'
            )
        AND P.Id_Category = ISNULL(@IdCategory, P.Id_Category)
        AND P.Id_Product = ISNULL(@IdProduct, P.Id_Product)
        AND P.Active = @Active
END;
GO


