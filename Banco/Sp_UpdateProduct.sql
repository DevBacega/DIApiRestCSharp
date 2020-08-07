SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_UpdateProduct] (
    @Id_Product INT
    , @Ds_Product VARCHAR(50)
    , @Id_Category INT
    )
AS
BEGIN
    UPDATE Product
    SET Ds_Product = @Ds_product
        , Id_Category = @Id_Category
    WHERE Id_Product = @Id_Product
END;
GO


