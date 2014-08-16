using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academia.Model.Vo.Agenda
{
    public class Model_Vo_Agenda
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _DataHoraReserva;
        public DateTime DataHoraReserva
        {
            get { return _DataHoraReserva; }
            set { _DataHoraReserva = value; }
        }

        private int _IdSala; //FK Obrigatório
        public int IdSala
        {
            get { return _IdSala; }
            set { _IdSala = value; }
        }

        private int _IdCliente;
        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        private int _registroNro; //Não existe no banco
        public int RegistroNro
        {
            get { return _registroNro; }
            set { _registroNro = value; }
        }       
    }
}
