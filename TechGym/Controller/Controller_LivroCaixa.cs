using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Academia.Controller.LivroCaixas
{
    public class Controller_LivroCaixas
    {
        Model.Bo.LivroCaixas.Model_Bo_LivroCaixas objBoLivroCaixa = new Model.Bo.LivroCaixas.Model_Bo_LivroCaixas();
        DataTable dtLivroCaixasLocal = new DataTable();

        public void Incluir(Model.Vo.LivroCaixa.Model_Vo_LivroCaixa pLivroCaixaLocal)
        {
            if ((Validar(pLivroCaixaLocal)))
                objBoLivroCaixa.Incluir(pLivroCaixaLocal, false);
        }

        public void Alterar(Model.Vo.LivroCaixa.Model_Vo_LivroCaixa pLivroCaixaLocal)
        {
            if ((Validar(pLivroCaixaLocal)))
                objBoLivroCaixa.Alterar(pLivroCaixaLocal, false);
        }

        public Boolean Excluir(int piIdLivroCaixa, int piCtaReceb)
        {
            return objBoLivroCaixa.Excluir(piIdLivroCaixa, piCtaReceb);
        }

        public Model.Vo.LivroCaixa.Model_Vo_LivroCaixa CarregarLivroCaixa(Int32 piNumRegistro)
        {

            Model.Vo.LivroCaixa.Model_Vo_LivroCaixa LivroCaixaLocal = new Model.Vo.LivroCaixa.Model_Vo_LivroCaixa();

            dtLivroCaixasLocal = objBoLivroCaixa.ListaDeLivroCaixas();

            if ((dtLivroCaixasLocal.Rows.Count > 0))
            {
                if ((piNumRegistro >= 0) &&
                    (dtLivroCaixasLocal.Rows.Count > piNumRegistro))
                    LivroCaixaLocal.RegistroNro = piNumRegistro;
                else
                    LivroCaixaLocal.RegistroNro = (dtLivroCaixasLocal.Rows.Count - 1);

                DataTableToVO(LivroCaixaLocal, dtLivroCaixasLocal, LivroCaixaLocal.RegistroNro);
            }
            else
            {
                LivroCaixaLocal.Id = 0;
                LivroCaixaLocal.DataHora = DateTime.Now;
                LivroCaixaLocal.Descricao = String.Empty;
                LivroCaixaLocal.IdContasAReceber = 0;
                LivroCaixaLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;
                LivroCaixaLocal.Valor = 0.0f;
                LivroCaixaLocal.RegistroNro = -1;
            }

            return LivroCaixaLocal;
        }

        private void DataTableToVO(Model.Vo.LivroCaixa.Model_Vo_LivroCaixa LivroCaixaLocal, DataTable dtLivroCaixasLocal, Int32 piRegNum)
        {
            LivroCaixaLocal.Id = Convert.ToInt32(dtLivroCaixasLocal.Rows[piRegNum]["id"]);
            LivroCaixaLocal.DataHora = Convert.ToDateTime(Controller.Funcoes.Controller_Funcoes.GetDataString(Convert.ToString(dtLivroCaixasLocal.Rows[piRegNum]["datahora"])));
            LivroCaixaLocal.Descricao = Convert.ToString((dtLivroCaixasLocal.Rows[piRegNum]["descricao"]));
            LivroCaixaLocal.IdContasAReceber = Convert.ToInt32((dtLivroCaixasLocal.Rows[piRegNum]["idcontasareceber"]));

            if (Convert.ToString(dtLivroCaixasLocal.Rows[piRegNum]["tipodemovimento"]) == Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada.ToString())
                LivroCaixaLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada;
            else
                LivroCaixaLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;

            LivroCaixaLocal.Valor = float.Parse(Convert.ToString(dtLivroCaixasLocal.Rows[piRegNum]["valor"]));
        }

        public List<Model.Vo.LivroCaixa.Model_Vo_LivroCaixa> ListaLivroCaixaVO(DataTable dtLivroCaixasLocal)
        {
            List<Model.Vo.LivroCaixa.Model_Vo_LivroCaixa> list = new List<Model.Vo.LivroCaixa.Model_Vo_LivroCaixa>();
            if ((dtLivroCaixasLocal != null))
            {
                for (int i = 0; i < dtLivroCaixasLocal.Rows.Count; i++)
                {
                    Model.Vo.LivroCaixa.Model_Vo_LivroCaixa LivroCaixaLocal = new Model.Vo.LivroCaixa.Model_Vo_LivroCaixa();
                    DataTableToVO(LivroCaixaLocal, dtLivroCaixasLocal, i);

                    list.Add(LivroCaixaLocal);
                }
            }

            return list;
        }

        public List<Model.Vo.LivroCaixa.Model_Vo_LivroCaixa> ListaLivroCaixa()
        {
            DataTable dttemp = objBoLivroCaixa.ListaDeLivroCaixas();
            return ListaLivroCaixaVO(dttemp);
        }

        public List<Model.Vo.LivroCaixa.Model_Vo_LivroCaixa> ListaLivroCaixaPeriodo(DateTime dtIni, DateTime dtFim)
        {
            DataTable dttemp = objBoLivroCaixa.ListaDeLivroCaixaPeriodo(dtIni, dtFim);
            return ListaLivroCaixaVO(dttemp);
        }

        private Boolean Validar(Model.Vo.LivroCaixa.Model_Vo_LivroCaixa pLivroCaixaLocal)
        {
            return objBoLivroCaixa.Validar(pLivroCaixaLocal, false);
        }

        public Model.Vo.LivroCaixa.Model_Vo_LivroCaixa DevolveValorInicial()
        {

            Model.Vo.LivroCaixa.Model_Vo_LivroCaixa retorno = new Model.Vo.LivroCaixa.Model_Vo_LivroCaixa();
            retorno.Id = 0;
            retorno.DataHora = DateTime.Now;
            retorno.Descricao = String.Empty;
            retorno.IdContasAReceber = 0;
            retorno.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;
            retorno.Valor = 0.0f;
            retorno.RegistroNro = 0;

            return retorno;
        }

        public int getNumRegistros()        
        {
            if ((dtLivroCaixasLocal != null))
                return dtLivroCaixasLocal.Rows.Count;
            else
                return 0;
        }

    }


}
