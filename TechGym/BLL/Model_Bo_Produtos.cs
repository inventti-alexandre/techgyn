using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Dao.Produtos;
using System.Data;

namespace Academia.Model.Bo.Produtos
{
    public class Model_Bo_Produtos
    {
        private Model_Dao_Produtos objDAL;

        //Constructor
        public Model_Bo_Produtos()
        {
            objDAL = new Model_Dao_Produtos();
        }

        public void Incluir(Academia.Model.Vo.Produto.Model_Vo_Produto pProduto)
        {
            if ((Validar(pProduto)))
                objDAL.Incluir(pProduto);
        }

        public void Alterar(Academia.Model.Vo.Produto.Model_Vo_Produto pProduto)
        {
            if ((Validar(pProduto)))
                objDAL.Alterar(pProduto);
        }

        public Boolean Excluir(int codigo)
        {
            return objDAL.Excluir(codigo);
        }

        public DataTable ListaDeProdutos()
        {
            return objDAL.ListaDeProdutos();
        }

        public DataTable GetProduto(int pIdproduto)
        {
            return objDAL.GetProduto(pIdproduto);
        }

        public DataTable ListaDeProdutosCom(String psParametro)
        {
            return objDAL.ListaDeProdutosCom(psParametro);
        }

        public Boolean Validar(Academia.Model.Vo.Produto.Model_Vo_Produto pProdutoLocal)
        {
            if ((pProdutoLocal.Descricao.Trim() == String.Empty))
                throw new Exception(("Descricao deve ser informada."));

            return true;
        }
    }
}
