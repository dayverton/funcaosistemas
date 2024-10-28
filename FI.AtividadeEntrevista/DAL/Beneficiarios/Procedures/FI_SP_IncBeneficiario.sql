IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'FI_SP_IncBeneficiario'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.FI_SP_IncBeneficiario
GO

CREATE PROC FI_SP_IncBeneficiario
    @NOME          VARCHAR (50) ,    
    @CPF            VARCHAR (11),
    @IDCLIENTE      BIGINT
AS
BEGIN
	INSERT INTO BENEFICIARIOS (NOME, CPF, IDCLIENTE) 
	VALUES (@NOME, @CPF, @IDCLIENTE)

	SELECT SCOPE_IDENTITY()
END