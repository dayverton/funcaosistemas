IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'FI_SP_VerificaCliente'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.FI_SP_VerificaCliente
GO

CREATE PROC FI_SP_VerificaCliente
    @ID     BIGINT,
	@CPF    VARCHAR(11)	
AS
BEGIN
	SELECT ID FROM CLIENTES WITH(NOLOCK) 
    WHERE CPF = @CPF 
        AND ID <> @ID
END

