using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academia.Model.Vo.Sala
{
    public class Model_Vo_Sala
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private int _capacidade;
        public int Capacidade
        {
            get { return _capacidade; }
            set { _capacidade = value; }
        }

        private int _registroNro;
        public int RegistroNro
        {
            get { return _registroNro; }
            set { _registroNro = value; }
        }

        private Academia.Model.Vo.eTipoSala.Model_Vo_eTipoSala _tipo;
        public Academia.Model.Vo.eTipoSala.Model_Vo_eTipoSala Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private int _IdProduto;
        public int IdProduto
        {
            get { return _IdProduto; }
            set { _IdProduto = value; }
        }

        public override string ToString()
        {
            return _nome;
        }
    }
}
