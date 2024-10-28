IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'FI_SP_AltBeneficiario'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.FI_SP_AltBeneficiario
GO

CREATE PROC FI_SP_AltBeneficiario
    @NOME          VARCHAR (50) ,    
	@ID				BIGINT,	
	@CPF			VARCHAR (11)
AS
BEGIN
	UPDATE BENEFICIARIOS 
	SET 
		NOME = @NOME, 		
		CPF = @CPF 
	WHERE ID = @ID
END