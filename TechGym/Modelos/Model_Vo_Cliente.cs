using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academia.Model.Vo.Cliente
{
    public class Model_Vo_Cliente
    {
        private int _id = 0;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nome = String.Empty;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _cpf = String.Empty;
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        private string _rg = String.Empty;
        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
        }

        private String _telefone = String.Empty;
        public String Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        private String _email = String.Empty;
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private String _rua = String.Empty;
        public String Rua
        {
            get { return _rua; }
            set { _rua = value; }
        }

        private String _numero = String.Empty;
        public String Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private String _complemento = String.Empty;
        public String Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        private String _Bairro = String.Empty;
        public String Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }

        private String _Cidade = String.Empty;
        public String Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        private String _UF = String.Empty;
        public String UF
        {
            get { return _UF; }
            set { _UF = value; }
        }

        private String _CEP = String.Empty;
        public String CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        private int _registroNro;
        public int RegistroNro
        {
            get { return _registroNro; }
            set { _registroNro = value; }
        }

        private DateTime _Nascimento;
        public DateTime Nascimento
        {
            get { return _Nascimento; }
            set { _Nascimento = value; }
        }

        private float _ValorMensalidade;
        public float ValorMensalidade
        {
            get { return _ValorMensalidade; }
            set { _ValorMensalidade = value; }
        }

        private String _Observacao;
        public String Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        private Boolean _Ativo;
        public Boolean Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }
    }
}
