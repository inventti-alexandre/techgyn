using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academia.Model.Vo.ContasAReceber
{
    public class Model_Vo_ContasAReceber
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private DateTime _DataHoraCriacao;
        public DateTime DataHoraCriacao
        {
            get { return _DataHoraCriacao; }
            set { _DataHoraCriacao = value; }
        }

        private int _IdReservaOrigem; //FK Não obrigatório
        public int IdReservaOrigem
        {
            get { return _IdReservaOrigem; }
            set { _IdReservaOrigem = value; }
        }

        private int _IdCliente; //FK Não obrigatório
        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        private int _IdProduto; //FK Não obrigatório
        public int IdProduto
        {
            get { return _IdProduto; }
            set { _IdProduto = value; }
        }

        private eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber _Origem;
        public eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber Origem
        {
            get { return _Origem; }
            set { _Origem = value; }
        }

        private float _ValorAReceber; //Sempre o valor total a receber, ou seja, o valor da mensalidade ou o total dos itens consumidos.
        public float ValorAReceber
        {
            get { return _ValorAReceber; }
            set { _ValorAReceber = value; }
        }

        private String _Descricao;
        public String Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        private Boolean _Recebido; //Ao setar como true, gerar movimento de entrada no livro caixa.
        public Boolean Recebido
        {
            get { return _Recebido; }
            set { _Recebido = value; }
        }

        private int _registroNro; //Não existe no banco
        public int RegistroNro
        {
            get { return _registroNro; }
            set { _registroNro = value; }
        }
    }
}
