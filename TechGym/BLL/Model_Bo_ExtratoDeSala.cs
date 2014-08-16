using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Academia.Model.Dao.ExtratoDeSalas;

namespace Academia.Model.Bo.ExtratoDeSala
{
    public class Model_Bo_ExtratoDeSala
    {
        public static DataTable getExtratoSala(String parcialdata, String sala)
        {
            return Model_Dao_ExtratoDeSalas.getExtrato(parcialdata, sala);
        }
    }
}
