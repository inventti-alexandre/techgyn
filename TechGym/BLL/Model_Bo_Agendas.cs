using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Dao.Agendas;
using System.Data;

namespace Academia.Model.Bo.Agendas
{
    public class Model_Bo_Agendas
    {
        private Model_Dao_Agendas objDAL;

        //Constructor
        public Model_Bo_Agendas()
        {
            objDAL = new Model_Dao_Agendas();
        }

        public void Incluir(Academia.Model.Vo.Agenda.Model_Vo_Agenda pAgenda)
        {
            if ((Validar(pAgenda)))
                objDAL.Incluir(pAgenda);
        }

        public void Alterar(Academia.Model.Vo.Agenda.Model_Vo_Agenda pAgenda)
        {
            if ((Validar(pAgenda)))
                objDAL.Alterar(pAgenda);
        }

        public Boolean Excluir(int codigo)
        {
            return objDAL.Excluir(codigo);
        }

        public DataTable ListaDeAgendas()
        {
            return objDAL.ListaDeAgendas();
        }

        public DataTable ListaDeAgendasDoPeriodo(DateTime DataHoraIni, DateTime DataHoraFim)
        {
            return objDAL.ListaDeAgendasDoPeriodo(DataHoraIni, DataHoraFim);
        }

        public DataTable ListaDeAgendasDoCliente(int IdCliente)
        {
            return objDAL.ListaDeAgendasDoCliente(IdCliente);
        }

        public DataTable ListaDeAgendasDaSala(int IdSala)
        {
            return objDAL.ListaDeAgendasDaSala(IdSala);
        }

        public DataTable GetAgendaPorDados(int pIdCliente, int pIdSala, DateTime pDatahora)
        {
            return objDAL.GetAgendaPorDados(pIdCliente, pIdSala, pDatahora);
        }

        public Boolean Validar(Academia.Model.Vo.Agenda.Model_Vo_Agenda pAgendaLocal)
        {
            if ((pAgendaLocal.DataHoraReserva == null))
                throw new Exception(("Data e hora da reserva devem ser informadas."));

            if ((pAgendaLocal.IdCliente <= 0))
                throw new Exception(("Cliente da reserva deve ser informado."));

            if ((pAgendaLocal.IdSala <= 0))
                throw new Exception(("Sala da reserva deve ser informada."));

            return true;
        }
    }
}
