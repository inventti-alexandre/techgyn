using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academia.Model.Vo.MovimentacaoEstoque
{
    public class Model_Vo_MovimentacaoEstoque
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _DataHora;
        public DateTime DataHora
        {
            get { return _DataHora; }
            set { _DataHora = value; }
        }

        private int _IdReservaOrigem; //FK Não Obrigatório
        public int IdReservaOrigem
        {
            get { return _IdReservaOrigem; }
            set { _IdReservaOrigem = value; }
        }

        private int _IdClienteSolicitante; //FK Não Obrigatório
        public int IdClienteSolicitante
        {
            get { return _IdClienteSolicitante; }
            set { _IdClienteSolicitante = value; }
        }

        private int _IdProduto; //FK OBRIGATÓRIO
        public int IdProduto
        {
            get { return _IdProduto; }
            set { _IdProduto = value; }
        }

        private float _Quantidade;
        public float Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        private float _ValorUnitario;
        public float ValorUnitario
        {
            get { return _ValorUnitario; }
            set { _ValorUnitario = value; }
        }

        private float _ValorTotal;
        public float ValorTotal
        {
            get { return _ValorTotal; }
            set { _ValorTotal = value; }
        }

        private int _registroNro; //Não existe no banco
        public int RegistroNro
        {
            get { return _registroNro; }
            set { _registroNro = value; }
        }

        private eTipoMovimento.Model_Vo_eTipoMovimento _TipoDeMovimento;
        public eTipoMovimento.Model_Vo_eTipoMovimento TipoDeMovimento
        {
            get { return _TipoDeMovimento; }
            set { _TipoDeMovimento = value; }
        }
    }
}
