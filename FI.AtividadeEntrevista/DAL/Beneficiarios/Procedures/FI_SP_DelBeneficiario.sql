IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'FI_SP_DelBeneficiario'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.FI_SP_DelBeneficiario
GO

CREATE PROC FI_SP_DelBeneficiario
	@ID BIGINT
AS
BEGIN
	DELETE BENEFICIARIOS WHERE ID = @ID
END