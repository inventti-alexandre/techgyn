using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academia.Model.Vo.Produto
{
    public class Model_Vo_Produto
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private string _unidade;
        public string Unidade
        {
            get { return _unidade; }
            set { _unidade = value; }
        }

        private float _estoque;
        public float Estoque
        {
            get { return _estoque; }
            set { _estoque = value; }
        }

        private float _ValorDeVenda;
        public float ValorDeVenda
        {
            get { return _ValorDeVenda; }
            set { _ValorDeVenda = value; }
        }

        private String _Observacao;
        public String Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        private int _RegistroNro;
        public int RegistroNro
        {
            get { return _RegistroNro; }
            set { _RegistroNro = value; }
        }
    }
}
