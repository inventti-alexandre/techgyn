using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Academia.Model.Bo.ExtratoDeSala;

namespace Academia.Controller.Extratos
{
    public class Controller_Extratos
    {

        public Controller_Extratos()
        {
        }

        public static DataTable getExtratoSala(String sala, String parcialdata)
        {
            return Model_Bo_ExtratoDeSala.getExtratoSala(parcialdata, sala);
        }

    }
}
