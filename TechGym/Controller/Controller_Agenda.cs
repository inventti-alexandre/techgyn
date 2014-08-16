using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Academia.Controller.Agendas
{
    public class Controller_Agendas
    {
        Model.Bo.Agendas.Model_Bo_Agendas objBoAgenda = new Model.Bo.Agendas.Model_Bo_Agendas();
        Controller.Salas.Controller_Salas contSalas = new Controller.Salas.Controller_Salas();
        Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques contMovEstoq = new Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques();
        Controller.Produtos.Controller_Produtos contProdutos = new Controller.Produtos.Controller_Produtos();

        DataTable dtAgendasLocal = new DataTable();

        public void Incluir(Model.Vo.Agenda.Model_Vo_Agenda pAgendaLocal)
        {
            if ((Validar(pAgendaLocal)))
            {
                objBoAgenda.Incluir(pAgendaLocal);

                MovimentarConsumos(pAgendaLocal);
            }
        }

        private void MovimentarConsumos(Model.Vo.Agenda.Model_Vo_Agenda pAgendaLocal) {

            Model.Vo.Sala.Model_Vo_Sala salaTemp = contSalas.GetSala(pAgendaLocal.IdSala);
            if ((salaTemp.IdProduto > 0))
            {
                Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque estoque = new Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();

                estoque.DataHora = pAgendaLocal.DataHoraReserva;
                estoque.IdClienteSolicitante = pAgendaLocal.IdCliente;
                estoque.IdProduto = salaTemp.IdProduto;
                estoque.IdReservaOrigem = GetAgendaPorDadosController(pAgendaLocal.IdCliente, pAgendaLocal.IdSala, pAgendaLocal.DataHoraReserva).Id;
                estoque.Quantidade = 1.0f;
                estoque.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;
                estoque.ValorUnitario = contProdutos.GetProduto(salaTemp.IdProduto).ValorDeVenda;
                estoque.ValorTotal = (estoque.Quantidade * estoque.ValorUnitario);

                contMovEstoq.Incluir(estoque);
            }
        }

        public Model.Vo.Agenda.Model_Vo_Agenda GetAgendaPorDadosController(int pIdCliente, int pIdSala, DateTime pDatahora)
        {
            Model.Vo.Agenda.Model_Vo_Agenda AgendaLocal = new Model.Vo.Agenda.Model_Vo_Agenda();
            dtAgendasLocal = objBoAgenda.GetAgendaPorDados(pIdCliente, pIdSala, pDatahora);
            if ((dtAgendasLocal.Rows.Count > 0))
            {
                DataTableToVO(AgendaLocal, dtAgendasLocal, AgendaLocal.RegistroNro);
            }

            return AgendaLocal;
        }

        public void Alterar(Model.Vo.Agenda.Model_Vo_Agenda pAgendaLocal)
        {
            if ((Validar(pAgendaLocal)))
                objBoAgenda.Alterar(pAgendaLocal);
        }

        public Boolean Excluir(int piIdAgenda)
        {
            return objBoAgenda.Excluir(piIdAgenda);
        }

        public Model.Vo.Agenda.Model_Vo_Agenda CarregarAgenda(Int32 piNumRegistro)
        {

            Model.Vo.Agenda.Model_Vo_Agenda AgendaLocal = new Model.Vo.Agenda.Model_Vo_Agenda();

            dtAgendasLocal = objBoAgenda.ListaDeAgendas();

            if ((dtAgendasLocal.Rows.Count > 0))
            {
                if ((piNumRegistro >= 0) &&
                    (dtAgendasLocal.Rows.Count > piNumRegistro))
                    AgendaLocal.RegistroNro = piNumRegistro;
                else
                    AgendaLocal.RegistroNro = (dtAgendasLocal.Rows.Count - 1);

                DataTableToVO(AgendaLocal, dtAgendasLocal, AgendaLocal.RegistroNro);
            }
            else
            {
                AgendaLocal.Id = 0;
                AgendaLocal.DataHoraReserva = DateTime.Now;
                AgendaLocal.IdCliente = 0;
                AgendaLocal.IdSala = 0;
                AgendaLocal.RegistroNro = -1;
            }

            return AgendaLocal;
        }

        private void DataTableToVO(Model.Vo.Agenda.Model_Vo_Agenda AgendaLocal, DataTable dtAgendasLocal, Int32 piRegNum)
        {
            AgendaLocal.Id = Convert.ToInt32(dtAgendasLocal.Rows[piRegNum]["id"]);
            if ((dtAgendasLocal.Rows[piRegNum]["datahorareserva"] != DBNull.Value))
                AgendaLocal.DataHoraReserva = ConverteStringData(dtAgendasLocal.Rows[piRegNum]["datahorareserva"].ToString());
            else
                AgendaLocal.DataHoraReserva = DateTime.MinValue;
            AgendaLocal.IdCliente = Convert.ToInt32((dtAgendasLocal.Rows[piRegNum]["idcliente"]));
            AgendaLocal.IdSala = Convert.ToInt32((dtAgendasLocal.Rows[piRegNum]["idsala"]));
        }

        private DateTime ConverteStringData(string sData)
        {
            DateTime data = new DateTime();

            string[] splittedString = sData.Split(new char[] { ' ' });
            if (splittedString.Length != 2) return DateTime.Today;

            string dia = splittedString[0];
            string hora = splittedString[1];

            string[] splDia = dia.Split(new char[] { '-' });
            if (splDia.Length != 3) return DateTime.Now;

            int ano, mes, idia;
            if (!int.TryParse(splDia[0].Substring(1, splDia[0].Length - 1), out ano)) return DateTime.Now;
            if (!int.TryParse(splDia[1], out mes)) return DateTime.Now;
            if (!int.TryParse(splDia[2], out idia)) return DateTime.Now;

            string[] splHora = hora.Split(new char[] { ':' });
            if (splHora.Length != 3) return DateTime.Now;

            int ihora, minuto, segundo;

            if (!int.TryParse(splHora[0].Substring(1,splHora[0].Length - 1) , out ihora)) return DateTime.Now;
            if (!int.TryParse(splHora[1], out minuto)) return DateTime.Now;
            if (!int.TryParse(splHora[2].Split(new char[] { '.' })[0], out segundo)) return DateTime.Now;

            return new DateTime(ano, mes, idia, ihora, minuto, segundo);
            /*
             * String sRetorno = 
                   ("D" + pData.Year.ToString("0000") + "-" +
                          pData.Month.ToString("00") + "-" +
                          pData.Day.ToString("00") +
                   " H" + pData.Hour.ToString("00") + ":" +
                          pData.Minute.ToString("00") + ":" +
                          pData.Second.ToString("00") + "." +
                          pData.Millisecond.ToString("000"));
             */

            //return data;
        }

        public List<Model.Vo.Agenda.Model_Vo_Agenda> ListaDeSalasVO(DataTable dtAgendasLocal)
        {
            List<Model.Vo.Agenda.Model_Vo_Agenda> list = new List<Model.Vo.Agenda.Model_Vo_Agenda>();
            if ((dtAgendasLocal != null))
            {
                for (int i = 0; i < dtAgendasLocal.Rows.Count; i++)
                {
                    Model.Vo.Agenda.Model_Vo_Agenda AgendaLocal = new Model.Vo.Agenda.Model_Vo_Agenda();
                    DataTableToVO(AgendaLocal, dtAgendasLocal, i);

                    list.Add(AgendaLocal);
                }
            }

            return list;
        }

        public List<Model.Vo.Agenda.Model_Vo_Agenda> ListaDeAgendasDoPeriodo(DateTime DataHoraIni, DateTime DataHoraFim)
        {
            DataTable dtTemp = objBoAgenda.ListaDeAgendasDoPeriodo(DataHoraIni, DataHoraFim);
            return ListaDeSalasVO(dtTemp);
        }

        public List<Model.Vo.Agenda.Model_Vo_Agenda> ListaDeAgendasDoCliente(int IdCliente)
        {
            DataTable dtTemp = objBoAgenda.ListaDeAgendasDoCliente(IdCliente);
            return ListaDeSalasVO(dtTemp);
        }

        public List<Model.Vo.Agenda.Model_Vo_Agenda> ListaDeAgendasDaSala(int IdSala)
        {
            DataTable dtTemp = objBoAgenda.ListaDeAgendasDaSala(IdSala);
            return ListaDeSalasVO(dtTemp);
        }

        public List<Model.Vo.Agenda.Model_Vo_Agenda> ListaDeAgendas()
        {
            DataTable dtTemp = objBoAgenda.ListaDeAgendas();
            return ListaDeSalasVO(dtTemp);
        }

        private Boolean Validar(Model.Vo.Agenda.Model_Vo_Agenda pAgendaLocal)
        {
            return objBoAgenda.Validar(pAgendaLocal);
        }

        public Model.Vo.Agenda.Model_Vo_Agenda DevolveValorInicial()
        {

            Model.Vo.Agenda.Model_Vo_Agenda retorno = new Model.Vo.Agenda.Model_Vo_Agenda();            
            retorno.Id = 0;
            retorno.DataHoraReserva = DateTime.Now;
            retorno.IdCliente = 0;
            retorno.IdSala = 0;
            retorno.RegistroNro = 0;

            return retorno;
        }

        public int getNumRegistros()        
        {
            if ((dtAgendasLocal != null))
                return dtAgendasLocal.Rows.Count;
            else
                return 0;
        }

    }


}
