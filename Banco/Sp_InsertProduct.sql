SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_InsertProducts] (
    @Ds_Product VARCHAR(50)
    , @Id_Category INT
    )
AS
BEGIN
    INSERT INTO Product
    VALUES (
        @Ds_Product
        , @Id_Category
        , 1
        );
END;
GO


