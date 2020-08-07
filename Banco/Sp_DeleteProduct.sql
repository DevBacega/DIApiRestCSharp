SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_DeleteProduct] (@Id_Product INT)
AS
BEGIN
    DELETE
    FROM Product
    WHERE Id_Product = @Id_Product
END;
GO


