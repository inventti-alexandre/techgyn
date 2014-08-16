using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Academia.Controller.Salas
{
    public class Controller_Salas
    {
        Model.Bo.Salas.Model_Bo_Salas objBoSala = new Model.Bo.Salas.Model_Bo_Salas();
        DataTable dtSalasLocal = new DataTable();

        public void Incluir(Model.Vo.Sala.Model_Vo_Sala pSalaLocal)
        {
            if ((Validar(pSalaLocal)))
                objBoSala.Incluir(pSalaLocal);
        }

        public void Alterar(Model.Vo.Sala.Model_Vo_Sala pSalaLocal)
        {
            if ((Validar(pSalaLocal)))
                objBoSala.Alterar(pSalaLocal);
        }

        public Boolean Excluir(int piIdSala)
        {
            return objBoSala.Excluir(piIdSala);
        }

        public Model.Vo.Sala.Model_Vo_Sala CarregarSala(Int32 piNumRegistro)
        {

            Model.Vo.Sala.Model_Vo_Sala salaLocal = new Model.Vo.Sala.Model_Vo_Sala();

            dtSalasLocal = objBoSala.ListaDeSalasDt();

            if ((dtSalasLocal.Rows.Count > 0))
            {
                if ((piNumRegistro >= 0) &&
                    (dtSalasLocal.Rows.Count > piNumRegistro))
                    salaLocal.RegistroNro = piNumRegistro;
                else
                    salaLocal.RegistroNro = (dtSalasLocal.Rows.Count - 1);

                DataTableToVO(salaLocal, dtSalasLocal, salaLocal.RegistroNro);
            }
            else
            {
                salaLocal.Id = 0;
                salaLocal.Nome = "";
                salaLocal.Capacidade = 0;
                salaLocal.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra;
                salaLocal.RegistroNro = -1;
                salaLocal.IdProduto = 0;
            }

            return salaLocal;
        }

        public Model.Vo.Sala.Model_Vo_Sala GetSala(int pIdSala)
        {
            Model.Vo.Sala.Model_Vo_Sala SalaLocal = new Model.Vo.Sala.Model_Vo_Sala();
            dtSalasLocal = objBoSala.GetSala(pIdSala);
            if ((dtSalasLocal.Rows.Count > 0))
            {
                DataTableToVO(SalaLocal, dtSalasLocal, SalaLocal.RegistroNro);
            }

            return SalaLocal;
        }

        private void DataTableToVO(Model.Vo.Sala.Model_Vo_Sala salaLocal, DataTable dtSalasLocal, Int32 piRegNum)
        {
            salaLocal.Id = Convert.ToInt32(dtSalasLocal.Rows[salaLocal.RegistroNro]["id"]);
            salaLocal.Nome = Convert.ToString(dtSalasLocal.Rows[salaLocal.RegistroNro]["nome"]);
            salaLocal.Capacidade = Convert.ToInt32((dtSalasLocal.Rows[salaLocal.RegistroNro]["capacidade"]));

            if ((dtSalasLocal.Rows[salaLocal.RegistroNro]["idproduto"] != DBNull.Value))
                salaLocal.IdProduto = Convert.ToInt32((dtSalasLocal.Rows[salaLocal.RegistroNro]["idproduto"]));
            else
                salaLocal.IdProduto = 0;

            if (Convert.ToString(dtSalasLocal.Rows[salaLocal.RegistroNro]["tipo"]) == Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna.ToString())
                salaLocal.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna;
            else
                salaLocal.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra;
        }

        public List<Model.Vo.Sala.Model_Vo_Sala> ListaDeSalasVO(DataTable dtSalasLocal)
        {
            List<Model.Vo.Sala.Model_Vo_Sala> list = new List<Model.Vo.Sala.Model_Vo_Sala>();
            if ((dtSalasLocal != null))
            {
                for (int i = 0; i < dtSalasLocal.Rows.Count; i++)
                {
                    Model.Vo.Sala.Model_Vo_Sala SalaLocal = new Model.Vo.Sala.Model_Vo_Sala();
                    DataTableToVO(SalaLocal, dtSalasLocal, i);

                    list.Add(SalaLocal);
                }
            }

            return list;
        }

        private Boolean Validar(Model.Vo.Sala.Model_Vo_Sala pSalaLocal)
        {
            return objBoSala.Validar(pSalaLocal);
        }

        public Model.Vo.Sala.Model_Vo_Sala BuscarSauna()
        {
            Model.Vo.Sala.Model_Vo_Sala sauna = objBoSala.BuscarSauna();
            return sauna;
        }

        public Model.Vo.Sala.Model_Vo_Sala DevolveValorInicial()
        {

            Model.Vo.Sala.Model_Vo_Sala retorno = new Model.Vo.Sala.Model_Vo_Sala();
            retorno.Capacidade = 0;
            retorno.Id = 0;
            retorno.Nome = string.Empty;
            retorno.RegistroNro = 0;
            retorno.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra;
            retorno.IdProduto = 0;

            return retorno;
        }

        public int getNumRegistros()        
        {
            if ((dtSalasLocal != null))
              return dtSalasLocal.Rows.Count;
            else
                return 0;
        }

    }


}
