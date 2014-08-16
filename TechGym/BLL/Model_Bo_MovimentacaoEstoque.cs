using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Dao.MovimentacaoEstoques;
using System.Data;

namespace Academia.Model.Bo.MovimentacaoEstoques
{
    public class Model_Bo_MovimentacaoEstoques
    {
        private Model_Dao_MovimentacaoEstoques objDAL;

        //Constructor
        public Model_Bo_MovimentacaoEstoques()
        {
            objDAL = new Model_Dao_MovimentacaoEstoques();
        }

        public void Incluir(Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque pMovimentacaoEstoque)
        {
            if ((Validar(pMovimentacaoEstoque)))
                objDAL.Incluir(pMovimentacaoEstoque);
        }

        public void Alterar(Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque pMovimentacaoEstoque)
        {
            if ((Validar(pMovimentacaoEstoque)))
                objDAL.Alterar(pMovimentacaoEstoque);
        }

        public Boolean Excluir(int idMovimentacaoEstoque, int idAgenda)
        {
            return objDAL.Excluir(idMovimentacaoEstoque, idAgenda);
        }

        public DataTable ListaDeMovimentacaoEstoques()
        {
            return objDAL.ListaDeMovimentacaoEstoques();
        }

        public DataTable ListaDeMovimentacaoEstoquesDoPeriodo(DateTime dtInicial, DateTime dtFinal)
        {
            return objDAL.ListaDeMovimentacaoEstoquesDoPeriodo(dtInicial, dtFinal);
        }

        public DataTable MovimentacaoEstoqueAgenda(int idAgenda)
        {
            return objDAL.MovimentacaoEstoqueAgenda(idAgenda);
        }

        public Boolean Validar(Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque pMovimentacaoEstoqueLocal)
        {
            if ((pMovimentacaoEstoqueLocal.DataHora == null))
                throw new Exception(("Data e hora da reserva devem ser informadas."));

            if ((pMovimentacaoEstoqueLocal.IdProduto <= 0))
                throw new Exception(("Produto deve ser informado."));

            if ((pMovimentacaoEstoqueLocal.Quantidade <= 0.0f))
                throw new Exception(("Quantidade deve ser informada."));

            /*
            if ((pMovimentacaoEstoqueLocal.ValorUnitario <= 0.0f))
                throw new Exception(("Valor unitário deve ser informado."));

            if ((pMovimentacaoEstoqueLocal.ValorTotal <= 0.0f))
                throw new Exception(("Valor total ser informado."));
             */

            return true;
        }
    }
}
