IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'FI_SP_VerificaBeneficiario'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.FI_SP_VerificaBeneficiario
GO

CREATE PROC FI_SP_VerificaBeneficiario
	@CPF            VARCHAR(11),
    @ID             BIGINT,
	@IDCLIENTE      BIGINT
AS
BEGIN
	SELECT ID FROM BENEFICIARIOS WITH(NOLOCK) 
    WHERE IDCLIENTE = @IDCLIENTE 
        AND CPF = @CPF
        AND ID <> @ID
END