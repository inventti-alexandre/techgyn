using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Dao.Salas;
using System.Data;

namespace Academia.Model.Bo.Salas
{
    public class Model_Bo_Salas
    {
        private Model_Dao_Salas objDAL;

        //Constructor
        public Model_Bo_Salas()
        {
            objDAL = new Model_Dao_Salas();
        }

        public void Incluir(Academia.Model.Vo.Sala.Model_Vo_Sala pSala)
        {
            if ((Validar(pSala)))
                objDAL.Incluir(pSala);
        }

        public void Alterar(Academia.Model.Vo.Sala.Model_Vo_Sala pSala)
        {
            if ((Validar(pSala)))
                objDAL.Alterar(pSala);
        }

        public DataTable GetSala(int pIdSala)
        {
            return objDAL.GetSala(pIdSala);
        }

        public Boolean Excluir(int codigo)
        {
            return objDAL.Excluir(codigo);
        }

        public Model.Vo.Sala.Model_Vo_Sala BuscarSauna()
        {
            DataTable dataSetSalas = objDAL.ListaSauna();

            if (dataSetSalas == null || dataSetSalas.Rows.Count == 0) return null;

            return CarregarSalaVoDataRow(dataSetSalas.Rows[0]);
        }

        public List<Model.Vo.Sala.Model_Vo_Sala> ListaDeSalas()
        {
            List<Model.Vo.Sala.Model_Vo_Sala> listaSalas = new List<Model.Vo.Sala.Model_Vo_Sala>();

            DataTable dataSetSalas = objDAL.ListaDeSalas();

            if (dataSetSalas == null) return listaSalas;

            foreach (DataRow dr in dataSetSalas.Rows)
            {
                Model.Vo.Sala.Model_Vo_Sala voSala = CarregarSalaVoDataRow(dr);

                listaSalas.Add(voSala);
            }

            return listaSalas;
        }

        public Model.Vo.Sala.Model_Vo_Sala CarregarSalaVoDataRow(DataRow dr)
        {
            Model.Vo.Sala.Model_Vo_Sala voSala = new Model.Vo.Sala.Model_Vo_Sala();
            voSala.Capacidade = int.Parse(dr["capacidade"].ToString());
            voSala.Id = int.Parse(dr["id"].ToString());
            voSala.Nome = dr["nome"].ToString();
            if ((dr["idproduto"] != DBNull.Value))
                voSala.IdProduto = Convert.ToInt32(dr["idproduto"]);
            else
                voSala.IdProduto = 0;
            voSala.Tipo = (Model.Vo.eTipoSala.Model_Vo_eTipoSala)Enum.Parse(typeof(Model.Vo.eTipoSala.Model_Vo_eTipoSala), dr["tipo"].ToString());

            return voSala;
        }


        public DataTable ListaDeSalasDt()
        {
            return objDAL.ListaDeSalas();
        }
        
        public DataTable ListaDeSalasCom(String psParametro)
        {
            return objDAL.ListaDeSalasCom(psParametro);
        }
        public Boolean Validar(Academia.Model.Vo.Sala.Model_Vo_Sala pSalaLocal)
        {
            if ((pSalaLocal.Nome.Trim() == String.Empty))
                throw new Exception(("Nome deve ser informado."));

            if ((pSalaLocal.Capacidade <= 0))
                throw new Exception(("Capacidade deve ser informada."));

            if ((pSalaLocal.IdProduto <= 0))
                throw new Exception(("Produto do consumo deve ser informado."));

            if ((pSalaLocal.Tipo.ToString().Trim() == String.Empty))
                throw new Exception(("Tipo deve ser informado."));

            return true;
        }
    }
}
