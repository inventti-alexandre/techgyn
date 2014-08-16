using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Dao.LivroCaixas;
using System.Data;

namespace Academia.Model.Bo.LivroCaixas
{
    public class Model_Bo_LivroCaixas
    {
        private Model_Dao_LivroCaixas objDAL;

        //Constructor
        public Model_Bo_LivroCaixas()
        {
            objDAL = new Model_Dao_LivroCaixas();
        }

        public void Incluir(Academia.Model.Vo.LivroCaixa.Model_Vo_LivroCaixa pLivroCaixa, Boolean pbValidarContasAReceber)
        {
            if ((Validar(pLivroCaixa, pbValidarContasAReceber)))
                objDAL.Incluir(pLivroCaixa);
        }

        public void Alterar(Academia.Model.Vo.LivroCaixa.Model_Vo_LivroCaixa pLivroCaixa, Boolean pbValidarContasAReceber)
        {
            if ((Validar(pLivroCaixa, pbValidarContasAReceber)))
                objDAL.Alterar(pLivroCaixa);
        }

        public Boolean Excluir(int codigo, int piCtaReceb)
        {
            return objDAL.Excluir(codigo, piCtaReceb);
        }

        public DataTable ListaDeLivroCaixas()
        {
            return objDAL.ListaDeLivroCaixas();
        }


        public DataTable ListaDeLivroCaixaPeriodo(DateTime dtIni, DateTime dtFim)
        {
            return objDAL.ListaDeLivroCaixasPeriodo(dtIni, dtFim);
        }
        

        public Boolean Validar(Academia.Model.Vo.LivroCaixa.Model_Vo_LivroCaixa pLivroCaixaLocal, Boolean pbValidarContasAReceber)
        {
            if ((pLivroCaixaLocal.DataHora == null))
                throw new Exception(("Data/hora devem ser informadas."));

            if ((pLivroCaixaLocal.TipoDeMovimento.ToString() == String.Empty))
                throw new Exception(("Tipo do movimento deve ser informado."));

            if ((pbValidarContasAReceber))
            {
                if ((pLivroCaixaLocal.IdContasAReceber <= 0))
                    throw new Exception(("Id do contas a receber deve ser informado."));
            }

            if ((pLivroCaixaLocal.Valor <= 0))
                throw new Exception(("Valor deve ser informado."));

            return true;
        }
    }
}
