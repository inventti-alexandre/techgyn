using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Dao.ContasARecebers;
using System.Data;

namespace Academia.Model.Bo.ContasARecebers
{
    public class Model_Bo_ContasARecebers
    {
        private Model_Dao_ContasARecebers objDAL;

        //Constructor
        public Model_Bo_ContasARecebers()
        {
            objDAL = new Model_Dao_ContasARecebers();
        }

        public void Incluir(Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceber)
        {
            if ((Validar(pContasAReceber)))
                objDAL.Incluir(pContasAReceber);
        }

        public void Alterar(Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceber)
        {
            if ((Validar(pContasAReceber)))
                objDAL.Alterar(pContasAReceber);
        }

        public void FecharContasAReceber(Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceber)
        {
            if ((ValidarFechamento(pContasAReceber)))
                objDAL.FecharContasAReceber(pContasAReceber);
        }

        public Boolean Excluir(int codigo)
        {
            return objDAL.Excluir(codigo);
        }

        public DataTable ListaDeContasARecebers()
        {
            return objDAL.ListaDeContasARecebers();
        }

        public DataTable ListaDeContasARecebersPeriodo(DateTime dtIni, DateTime dtFim)
        {
            return objDAL.ListaDeContasARecebersPeriodo(dtIni, dtFim);
        }

        public int ExisteContasAReceberdaReserva(int pIdReserva)
        {
            return objDAL.ExisteContasAReceberdaReserva(pIdReserva);
        }

        public Boolean Validar(Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceberLocal)
        {
            if ((pContasAReceberLocal.DataHoraCriacao == null))
                throw new Exception(("Data/Hora de criação devem ser informadas."));

            if ((pContasAReceberLocal.IdCliente <= 0))
                throw new Exception(("Cliente deve ser informado."));

            if ((pContasAReceberLocal.IdReservaOrigem <= 0) &&
                (pContasAReceberLocal.IdProduto > 0))
                throw new Exception(("Reserva deve ser informada."));

            if ((pContasAReceberLocal.IdReservaOrigem > 0) &&
                (pContasAReceberLocal.IdProduto <= 0))
                throw new Exception(("Produto deve ser informado."));

            if ((pContasAReceberLocal.Origem.ToString() == String.Empty))
                throw new Exception(("Origem deve ser informada."));

            if ((pContasAReceberLocal.IdReservaOrigem <= 0) &&
                (pContasAReceberLocal.ValorAReceber <= 0))
                throw new Exception(("Valor deve ser informado."));

            return true;
        }

        public Boolean ValidarFechamento(Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceberLocal)
        {
            if ((pContasAReceberLocal.IdReservaOrigem <= 0) &&
                (pContasAReceberLocal.IdProduto > 0))
                throw new Exception(("Reserva deve ser informada."));            

            return true;
        }
    }
}
