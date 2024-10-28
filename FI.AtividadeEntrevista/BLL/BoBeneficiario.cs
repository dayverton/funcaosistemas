using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        public long Incluir(DML.Beneficiario beneficiario)
        {
            var dao = new DAL.DaoBeneficiario();
            bool existe = dao.VerificarExistencia(beneficiario.CPF, 0, beneficiario.IdCliente);

            if (existe)
                return 0;

            return dao.Incluir(beneficiario);
        }
        public bool Alterar(DML.Beneficiario beneficiario)
        {
            var dao = new DAL.DaoBeneficiario();
            bool existe = dao.VerificarExistencia(beneficiario.CPF, beneficiario.Id, beneficiario.IdCliente);

            if (existe)
                return false;

            dao.Alterar(beneficiario);
            return true;
        }
        public void Excluir(long id)
        {
            var dao = new DAL.DaoBeneficiario();
            dao.Excluir(id);
        }
        public List<DML.Beneficiario> Listar(long IdCliente)
        {
            var dao = new DAL.DaoBeneficiario();
            return dao.Listar(IdCliente);
        }
    }
}
