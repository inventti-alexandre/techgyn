using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Academia.Controller.ContasARecebers
{
    public class Controller_ContasARecebers
    {
        Model.Bo.ContasARecebers.Model_Bo_ContasARecebers objBoContasAReceber = new Model.Bo.ContasARecebers.Model_Bo_ContasARecebers();
        Controller.LivroCaixas.Controller_LivroCaixas contLivroCaixa = new LivroCaixas.Controller_LivroCaixas();
        Model.Bo.LivroCaixas.Model_Bo_LivroCaixas objBoLivroCaixa = new Model.Bo.LivroCaixas.Model_Bo_LivroCaixas();
        DataTable dtContasARecebersLocal = new DataTable();

        public void Incluir(Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceberLocal)
        {
            if ((Validar(pContasAReceberLocal)))
            {
                objBoContasAReceber.Incluir(pContasAReceberLocal);

                PagarContasAReceber(pContasAReceberLocal);
            }
        }

        public void Alterar(Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceberLocal)
        {
            if ((Validar(pContasAReceberLocal)))
            {
                objBoContasAReceber.Alterar(pContasAReceberLocal);

                PagarContasAReceber(pContasAReceberLocal);
            }
        }

        public void PagarContasAReceber(Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceberLocal)
        {
            if ((pContasAReceberLocal.Origem == Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo))
            {
                if ((pContasAReceberLocal.Recebido))
                {

                    Model.Vo.LivroCaixa.Model_Vo_LivroCaixa livCaixa = new Model.Vo.LivroCaixa.Model_Vo_LivroCaixa();
                    livCaixa.DataHora = pContasAReceberLocal.DataHoraCriacao;
                    livCaixa.Descricao = pContasAReceberLocal.Descricao;
                    livCaixa.IdContasAReceber = pContasAReceberLocal.Id;
                    livCaixa.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada;
                    livCaixa.Valor = pContasAReceberLocal.ValorAReceber;

                    contLivroCaixa.Incluir(livCaixa);
                }
                else if ((pContasAReceberLocal.Recebido == false))
                {
                    if ((pContasAReceberLocal.IdReservaOrigem > 0)) {
                        contLivroCaixa.Excluir(0, pContasAReceberLocal.Id);
                    }
                }
            }
        }

        public void FecharContasAReceber(Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceberLocal)
        {
            if ((ValidarFechamento(pContasAReceberLocal)))
            {
                objBoContasAReceber.FecharContasAReceber(pContasAReceberLocal);

                Model.Vo.LivroCaixa.Model_Vo_LivroCaixa livroCaixa = new Model.Vo.LivroCaixa.Model_Vo_LivroCaixa();

                livroCaixa.DataHora = DateTime.Now;
                livroCaixa.Descricao = "Entrada gerada por consumo da reserva: " + Convert.ToString(pContasAReceberLocal.IdReservaOrigem);
                livroCaixa.Id = 0;
                livroCaixa.IdContasAReceber = pContasAReceberLocal.Id;
                livroCaixa.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada;
                livroCaixa.Valor = pContasAReceberLocal.ValorAReceber;

                objBoLivroCaixa.Incluir(livroCaixa, true);
            }
        }

        public Boolean Excluir(int piIdContasAReceber)
        {
            return objBoContasAReceber.Excluir(piIdContasAReceber);
        }

        public Model.Vo.ContasAReceber.Model_Vo_ContasAReceber CarregarContasAReceber(Int32 piNumRegistro, Int32 pIdAgenda)
        {

            Model.Vo.ContasAReceber.Model_Vo_ContasAReceber ContasAReceberLocal = new Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();

            dtContasARecebersLocal = objBoContasAReceber.ListaDeContasARecebers();

            if ((dtContasARecebersLocal.Rows.Count > 0))
            {

                if ((pIdAgenda >= 0))
                {
                    for (int i = dtContasARecebersLocal.Rows.Count - 1; i >= 0; i--)
                    {
                        if ((dtContasARecebersLocal.Rows[i]["idreservaorigem"] != DBNull.Value) &&
                            (Convert.ToInt32(dtContasARecebersLocal.Rows[i]["idreservaorigem"]) > 0) &&
                            (Convert.ToInt32(dtContasARecebersLocal.Rows[i]["idreservaorigem"]) == pIdAgenda))
                        {
                            piNumRegistro = i;
                            break;
                        }
                    }
                }

                if ((piNumRegistro >= 0) &&
                    (dtContasARecebersLocal.Rows.Count > piNumRegistro))
                    ContasAReceberLocal.RegistroNro = piNumRegistro;
                else
                    ContasAReceberLocal.RegistroNro = (dtContasARecebersLocal.Rows.Count - 1);

                DataTableToVO(ContasAReceberLocal, dtContasARecebersLocal, ContasAReceberLocal.RegistroNro);
            }
            else
            {
                ContasAReceberLocal.Id = 0;
                ContasAReceberLocal.DataHoraCriacao = DateTime.Now;
                ContasAReceberLocal.Descricao = String.Empty;
                ContasAReceberLocal.IdCliente = 0;
                ContasAReceberLocal.IdProduto = 0;
                ContasAReceberLocal.IdReservaOrigem = 0;
                ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo;
                ContasAReceberLocal.Recebido = false;
                ContasAReceberLocal.ValorAReceber = 0.0f;
            }

            return ContasAReceberLocal;
        }

        private void DataTableToVO(Model.Vo.ContasAReceber.Model_Vo_ContasAReceber ContasAReceberLocal, DataTable dtContasARecebersLocal, Int32 piRegNum)
        {
            ContasAReceberLocal.Id = Convert.ToInt32(dtContasARecebersLocal.Rows[piRegNum]["id"]);
            ContasAReceberLocal.DataHoraCriacao = Controller.Funcoes.Controller_Funcoes.GetDataString(Convert.ToString(dtContasARecebersLocal.Rows[piRegNum]["datahoracriacao"]));
            ContasAReceberLocal.Descricao = Convert.ToString(dtContasARecebersLocal.Rows[piRegNum]["descricao"]);
            ContasAReceberLocal.IdCliente = Convert.ToInt32(dtContasARecebersLocal.Rows[piRegNum]["idcliente"]);
            ContasAReceberLocal.IdProduto = Convert.ToInt32(dtContasARecebersLocal.Rows[piRegNum]["idproduto"]);
            ContasAReceberLocal.IdReservaOrigem = Convert.ToInt32(dtContasARecebersLocal.Rows[piRegNum]["idreservaorigem"]);

            if ((Convert.ToString(dtContasARecebersLocal.Rows[piRegNum]["origem"]) == Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo.ToString()))
                ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo;
            else if ((Convert.ToString(dtContasARecebersLocal.Rows[piRegNum]["origem"]) == Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Mensalidade.ToString()))
                ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Mensalidade;
            else if ((Convert.ToString(dtContasARecebersLocal.Rows[piRegNum]["origem"]) == Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.VendaBalcao.ToString()))
                ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.VendaBalcao;
            else
                ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Outros;

            ContasAReceberLocal.Recebido = Convert.ToBoolean((dtContasARecebersLocal.Rows[piRegNum]["recebido"]));
            ContasAReceberLocal.ValorAReceber = float.Parse(Convert.ToString((dtContasARecebersLocal.Rows[piRegNum]["valorareceber"]))); 
        }

        public List<Model.Vo.ContasAReceber.Model_Vo_ContasAReceber> ListaDeContasAReceberVO(DataTable dtContasARecebersLocal)
        {
            List<Model.Vo.ContasAReceber.Model_Vo_ContasAReceber> list = new List<Model.Vo.ContasAReceber.Model_Vo_ContasAReceber>();
            if ((dtContasARecebersLocal != null))
            {
                for (int i = 0; i < dtContasARecebersLocal.Rows.Count; i++)
                {
                    Model.Vo.ContasAReceber.Model_Vo_ContasAReceber CRecebLocal = new Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();
                    DataTableToVO(CRecebLocal, dtContasARecebersLocal, i);

                    list.Add(CRecebLocal);
                }
            }

            return list;
        }

        public List<Model.Vo.ContasAReceber.Model_Vo_ContasAReceber> ListaDeContasAReceber()
        {
            DataTable dttemp = objBoContasAReceber.ListaDeContasARecebers();
            return ListaDeContasAReceberVO(dttemp);
        }

        public List<Model.Vo.ContasAReceber.Model_Vo_ContasAReceber> ListaDeContasAReceberPeriodo(DateTime dtIni, DateTime dtFim)
        {
            DataTable dttemp = objBoContasAReceber.ListaDeContasARecebersPeriodo(dtIni, dtFim);
            return ListaDeContasAReceberVO(dttemp);
        }

        private Boolean Validar(Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceberLocal)
        {
            return objBoContasAReceber.Validar(pContasAReceberLocal);
        }

        private Boolean ValidarFechamento(Model.Vo.ContasAReceber.Model_Vo_ContasAReceber pContasAReceberLocal)
        {
            return objBoContasAReceber.ValidarFechamento(pContasAReceberLocal);
        }

        public Model.Vo.ContasAReceber.Model_Vo_ContasAReceber DevolveValorInicial()
        {

            Model.Vo.ContasAReceber.Model_Vo_ContasAReceber retorno = new Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();
            retorno.Id = 0;
            retorno.DataHoraCriacao = DateTime.Now;
            retorno.Descricao = String.Empty;
            retorno.IdCliente = 0;
            retorno.IdProduto = 0;
            retorno.IdReservaOrigem = 0;
            retorno.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo;
            retorno.Recebido = false;
            retorno.ValorAReceber = 0.0f;

            return retorno;
        }

        public int getNumRegistros()        
        {
            if ((dtContasARecebersLocal != null))
                return dtContasARecebersLocal.Rows.Count;
            else
                return 0;
        }

    }


}
