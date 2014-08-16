using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academia.Model.Vo.LivroCaixa
{
    public class Model_Vo_LivroCaixa
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private DateTime _DataHora;
        public DateTime DataHora
        {
            get { return _DataHora; }
            set { _DataHora = value; }
        }

        private eTipoMovimento.Model_Vo_eTipoMovimento _TipoDeMovimento;
        public eTipoMovimento.Model_Vo_eTipoMovimento TipoDeMovimento
        {
            get { return _TipoDeMovimento; }
            set { _TipoDeMovimento = value; }
        }

        private float _Valor;
        public float Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        private string _Descricao; //Quando vier do contas a receber, preencher automaticamente com o valor informado lá
        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        private int _IdContasAReceber; //FK Não obrigatório
        public int IdContasAReceber
        {
            get { return _IdContasAReceber; }
            set { _IdContasAReceber = value; }
        }

        private int _registroNro; //Não existe no banco
        public int RegistroNro
        {
            get { return _registroNro; }
            set { _registroNro = value; }
        }
    }
}
