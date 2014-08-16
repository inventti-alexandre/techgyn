using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Academia.Controller.Produtos
{
    public class Controller_Produtos
    {
        Model.Bo.Produtos.Model_Bo_Produtos objBoProduto = new Model.Bo.Produtos.Model_Bo_Produtos();
        DataTable dtProdutosLocal = new DataTable();

        public void Incluir(Model.Vo.Produto.Model_Vo_Produto pProdutoLocal)
        {
            if ((Validar(pProdutoLocal)))
                objBoProduto.Incluir(pProdutoLocal);
        }

        public void Alterar(Model.Vo.Produto.Model_Vo_Produto pProdutoLocal)
        {
            if ((Validar(pProdutoLocal)))
                objBoProduto.Alterar(pProdutoLocal);
        }

        public Model.Vo.Produto.Model_Vo_Produto GetProduto(int pIdproduto)
        {
            Model.Vo.Produto.Model_Vo_Produto ProdutoLocal = new Model.Vo.Produto.Model_Vo_Produto();
            dtProdutosLocal = objBoProduto.GetProduto(pIdproduto);
            if ((dtProdutosLocal.Rows.Count > 0)) {
                DataTableToVO(ProdutoLocal, dtProdutosLocal, ProdutoLocal.RegistroNro);                
            }

            return ProdutoLocal;
        }

        public Boolean Excluir(int piIdProduto)
        {
            return objBoProduto.Excluir(piIdProduto);
        }

        public Model.Vo.Produto.Model_Vo_Produto CarregarProduto(Int32 piNumRegistro)
        {

            Model.Vo.Produto.Model_Vo_Produto ProdutoLocal = new Model.Vo.Produto.Model_Vo_Produto();

            dtProdutosLocal = objBoProduto.ListaDeProdutos();

            if ((dtProdutosLocal.Rows.Count > 0))
            {

                if ((piNumRegistro >= 0) &&
                    (dtProdutosLocal.Rows.Count > piNumRegistro))
                    ProdutoLocal.RegistroNro = piNumRegistro;
                else
                    ProdutoLocal.RegistroNro = dtProdutosLocal.Rows.Count - 1;

                DataTableToVO(ProdutoLocal, dtProdutosLocal, ProdutoLocal.RegistroNro);
            }
            else
            {
                ProdutoLocal.Id = 0;
                ProdutoLocal.Descricao = String.Empty;
                ProdutoLocal.Estoque = 0.0f;
                ProdutoLocal.Observacao = String.Empty;
                ProdutoLocal.Unidade = String.Empty;
                ProdutoLocal.ValorDeVenda = 0.0f;
            }

            return ProdutoLocal;
        }

        private void DataTableToVO(Model.Vo.Produto.Model_Vo_Produto ProdutoLocal, DataTable dtProdutosLocal, Int32 piRegNum)
        {
            ProdutoLocal.Id = Convert.ToInt32(dtProdutosLocal.Rows[piRegNum]["id"]);
            ProdutoLocal.Descricao = Convert.ToString(dtProdutosLocal.Rows[piRegNum]["descricao"]);
            ProdutoLocal.Estoque = float.Parse(Convert.ToString((dtProdutosLocal.Rows[piRegNum]["estoque"])));
            ProdutoLocal.Observacao = Convert.ToString((dtProdutosLocal.Rows[piRegNum]["observacao"]));
            ProdutoLocal.Unidade = Convert.ToString((dtProdutosLocal.Rows[piRegNum]["unidade"]));
            ProdutoLocal.ValorDeVenda = float.Parse(Convert.ToString((dtProdutosLocal.Rows[piRegNum]["valordevenda"])));
        }

        public List<Model.Vo.Produto.Model_Vo_Produto> ListaDeProdutosVO(DataTable dtProdutosLocal)
        {
            List<Model.Vo.Produto.Model_Vo_Produto> listProd = new List<Model.Vo.Produto.Model_Vo_Produto>();
            if ((dtProdutosLocal != null))
            {
                for (int i = 0; i < dtProdutosLocal.Rows.Count; i++)
                {
                    Model.Vo.Produto.Model_Vo_Produto ProdutoLocal = new Model.Vo.Produto.Model_Vo_Produto();
                    DataTableToVO(ProdutoLocal, dtProdutosLocal, i);

                    listProd.Add(ProdutoLocal);
                }
            }

            return listProd;
        }


        private Boolean Validar(Model.Vo.Produto.Model_Vo_Produto pProdutoLocal)
        {
            return objBoProduto.Validar(pProdutoLocal);
        }

        public Model.Vo.Produto.Model_Vo_Produto DevolveValorInicial()
        {

            Model.Vo.Produto.Model_Vo_Produto retorno = new Model.Vo.Produto.Model_Vo_Produto();
            retorno.Id = 0;
            retorno.Descricao = String.Empty;
            retorno.Estoque = 0.0f;
            retorno.Observacao = String.Empty;
            retorno.Unidade = String.Empty;
            retorno.ValorDeVenda = 0.0f;

            return retorno;
        }

        public int getNumRegistros()
        {
            return dtProdutosLocal.Rows.Count;
        }

    }


}
