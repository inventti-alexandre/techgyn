using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Academia.Controller.MovimentacaoEstoques
{
    public class Controller_MovimentacaoEstoques
    {
        Model.Bo.MovimentacaoEstoques.Model_Bo_MovimentacaoEstoques objBoMovimentacaoEstoque = new Model.Bo.MovimentacaoEstoques.Model_Bo_MovimentacaoEstoques();
        Model.Bo.ContasARecebers.Model_Bo_ContasARecebers objBoContasAReceber = new Model.Bo.ContasARecebers.Model_Bo_ContasARecebers();
        DataTable dtMovimentacaoEstoquesLocal = new DataTable();

        public void Incluir(Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque pMovimentacaoEstoqueLocal)
        {
            if ((Validar(pMovimentacaoEstoqueLocal)))
            {
                objBoMovimentacaoEstoque.Incluir(pMovimentacaoEstoqueLocal);

                ValoresDaMovimentacao(pMovimentacaoEstoqueLocal);
            }
        }

        public void Alterar(Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque pMovimentacaoEstoqueLocal)
        {
            if ((Validar(pMovimentacaoEstoqueLocal)))
            {
                objBoMovimentacaoEstoque.Alterar(pMovimentacaoEstoqueLocal);

                ValoresDaMovimentacao(pMovimentacaoEstoqueLocal);
            }
        }

        private void ValoresDaMovimentacao(Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque pMovimentacaoEstoqueLocal)
        {
            if ((pMovimentacaoEstoqueLocal.IdReservaOrigem > 0))
            {
                List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> list = this.MovimentacaoEstoqueAgenda(pMovimentacaoEstoqueLocal.IdReservaOrigem);

                float fTotal = 0.0f;
                foreach (var item in list)
                {
                    fTotal = fTotal + item.ValorTotal;
                }

                Model.Vo.ContasAReceber.Model_Vo_ContasAReceber ctoRec = new Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();

                ctoRec.DataHoraCriacao = pMovimentacaoEstoqueLocal.DataHora;
                ctoRec.Descricao = "Originado da reserva: " + Convert.ToString(pMovimentacaoEstoqueLocal.IdReservaOrigem) + ".";
                ctoRec.IdCliente = pMovimentacaoEstoqueLocal.IdClienteSolicitante;
                ctoRec.IdProduto = pMovimentacaoEstoqueLocal.IdProduto;
                ctoRec.IdReservaOrigem = pMovimentacaoEstoqueLocal.IdReservaOrigem;
                ctoRec.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo;
                ctoRec.Recebido = false;
                ctoRec.ValorAReceber = fTotal;

                int i = objBoContasAReceber.ExisteContasAReceberdaReserva(pMovimentacaoEstoqueLocal.IdReservaOrigem);

                if ((i > 0))
                {
                    ctoRec.Id = i;
                    objBoContasAReceber.Alterar(ctoRec);
                }
                else
                {
                    objBoContasAReceber.Incluir(ctoRec);
                }
            }
        }

        public Boolean Excluir(Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque pMovimentacaoEstoqueLocal)
        {
            if ((objBoMovimentacaoEstoque.Excluir(pMovimentacaoEstoqueLocal.Id, pMovimentacaoEstoqueLocal.IdReservaOrigem)))
            {
                ValoresDaMovimentacao(pMovimentacaoEstoqueLocal);
                return true;
            }
            else
                return false;
        }

        public Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque CarregarMovimentacaoEstoque(Int32 piNumRegistro)
        {

            Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque MovimentacaoEstoqueLocal = new Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();

            dtMovimentacaoEstoquesLocal = objBoMovimentacaoEstoque.ListaDeMovimentacaoEstoques();

            if ((dtMovimentacaoEstoquesLocal.Rows.Count > 0))
            {
                if ((piNumRegistro >= 0) &&
                    (dtMovimentacaoEstoquesLocal.Rows.Count > piNumRegistro))
                    MovimentacaoEstoqueLocal.RegistroNro = piNumRegistro;
                else
                    MovimentacaoEstoqueLocal.RegistroNro = (dtMovimentacaoEstoquesLocal.Rows.Count - 1);

                DataTableToVO(MovimentacaoEstoqueLocal, dtMovimentacaoEstoquesLocal, MovimentacaoEstoqueLocal.RegistroNro);
            }
            else
            {
                MovimentacaoEstoqueLocal.Id = 0;
                MovimentacaoEstoqueLocal.DataHora = DateTime.Now;
                MovimentacaoEstoqueLocal.IdClienteSolicitante = 0;
                MovimentacaoEstoqueLocal.IdProduto = 0;
                MovimentacaoEstoqueLocal.IdReservaOrigem = 0;
                MovimentacaoEstoqueLocal.Quantidade = 1.0f;
                MovimentacaoEstoqueLocal.ValorUnitario = 0.0f;
                MovimentacaoEstoqueLocal.ValorTotal = 0.0f;
                MovimentacaoEstoqueLocal.RegistroNro = -1;
                MovimentacaoEstoqueLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;
            }

            return MovimentacaoEstoqueLocal;
        }

        private void DataTableToVO(Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque MovimentacaoEstoqueLocal, DataTable dtMovimentacaoEstoquesLocal, Int32 piRegNum)
        {
            MovimentacaoEstoqueLocal.Id = Convert.ToInt32(dtMovimentacaoEstoquesLocal.Rows[piRegNum]["id"]);

            if ((dtMovimentacaoEstoquesLocal.Rows[piRegNum]["datahora"] != DBNull.Value))
                MovimentacaoEstoqueLocal.DataHora = Controller.Funcoes.Controller_Funcoes.GetDataString(Convert.ToString(dtMovimentacaoEstoquesLocal.Rows[piRegNum]["datahora"]));
            else
                MovimentacaoEstoqueLocal.DataHora = DateTime.MinValue;

            MovimentacaoEstoqueLocal.IdClienteSolicitante = Convert.ToInt32((dtMovimentacaoEstoquesLocal.Rows[piRegNum]["idclientesolicitante"]));
            MovimentacaoEstoqueLocal.IdProduto = Convert.ToInt32((dtMovimentacaoEstoquesLocal.Rows[piRegNum]["idproduto"]));
            MovimentacaoEstoqueLocal.IdReservaOrigem = Convert.ToInt32((dtMovimentacaoEstoquesLocal.Rows[piRegNum]["idreservaorigem"]));
            MovimentacaoEstoqueLocal.Quantidade = float.Parse(Convert.ToString((dtMovimentacaoEstoquesLocal.Rows[piRegNum]["quantidade"])));
            MovimentacaoEstoqueLocal.ValorUnitario = float.Parse(Convert.ToString((dtMovimentacaoEstoquesLocal.Rows[piRegNum]["valorunitario"])));
            MovimentacaoEstoqueLocal.ValorTotal = float.Parse(Convert.ToString((dtMovimentacaoEstoquesLocal.Rows[piRegNum]["valortotal"])));

            if (Convert.ToString(dtMovimentacaoEstoquesLocal.Rows[piRegNum]["tipodemovimento"]) == Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada.ToString())
                MovimentacaoEstoqueLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada;
            else
                MovimentacaoEstoqueLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;
        }

        public List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> ListaDeMovimentacaoEstoquesVO(DataTable dtMovimentacaoEstoquesLocal)
        {
            List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> list = new List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque>();
            if ((dtMovimentacaoEstoquesLocal != null))
            {
                for (int i = 0; i < dtMovimentacaoEstoquesLocal.Rows.Count; i++)
                {
                    Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque MovEstLocal = new Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();
                    DataTableToVO(MovEstLocal, dtMovimentacaoEstoquesLocal, i);

                    list.Add(MovEstLocal);
                }
            }

            return list;
        }

        public List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> ListaDeMovimentacaoEstoques()
        {
            DataTable dtTemp = objBoMovimentacaoEstoque.ListaDeMovimentacaoEstoques();
            return this.ListaDeMovimentacaoEstoquesVO(dtTemp);
        }

        public List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> ListaDeMovimentacaoEstoquesDoPeriodo(DateTime dtIni, DateTime dtFim)
        {
            DataTable dtTemp = objBoMovimentacaoEstoque.ListaDeMovimentacaoEstoquesDoPeriodo(dtIni, dtFim);
            return this.ListaDeMovimentacaoEstoquesVO(dtTemp);
        }

        public List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> MovimentacaoEstoqueAgenda(int piIdReserva)
        {
            DataTable dtTemp = objBoMovimentacaoEstoque.MovimentacaoEstoqueAgenda(piIdReserva);
            return this.ListaDeMovimentacaoEstoquesVO(dtTemp);
        }

        private Boolean Validar(Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque pMovimentacaoEstoqueLocal)
        {
            return objBoMovimentacaoEstoque.Validar(pMovimentacaoEstoqueLocal);
        }

        public Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque DevolveValorInicial()
        {

            Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque retorno = new Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();
            retorno.Id = 0;
            retorno.DataHora = DateTime.Now;
            retorno.IdClienteSolicitante = 0;
            retorno.IdProduto = 0;
            retorno.IdReservaOrigem = 0;
            retorno.Quantidade = 1.0f;
            retorno.ValorUnitario = 0.0f;
            retorno.ValorTotal = 0.0f;
            retorno.RegistroNro = 0;
            retorno.IdClienteSolicitante = 0;
            retorno.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;

            return retorno;
        }

        public int getNumRegistros()
        {
            if ((dtMovimentacaoEstoquesLocal != null))
                return dtMovimentacaoEstoquesLocal.Rows.Count;
            else
                return 0;
        }

    }


}
