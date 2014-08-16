using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academia.Controller.Funcoes
{
    public class Controller_Funcoes
    {
        public static DateTime GetDataString(String psData)
        {
            DateTime dtRetorno = DateTime.Now;

            if ((psData != null) &&
                (psData.Trim() != String.Empty))
            {
                psData = psData.Replace(":", "-");
                psData = psData.Replace(".", "-");
                psData = psData.Replace("D", "");
                psData = psData.Replace("H", "-");
                psData = psData.Replace(" ", "");

                String[] data = psData.Split('-');

                if ((data.Length > 0))
                {

                    int ano = 0;
                    int mes = 0;
                    int dia = 0;
                    int hora = 0;
                    int minutos = 0;
                    int segundos = 0;
                    int milisegundos = 0;

                    if ((data.Length >= 1))
                        int.TryParse(data[0], out ano);

                    if ((data.Length >= 2))
                        int.TryParse(data[1], out mes);

                    if ((data.Length >= 3))
                        int.TryParse(data[2], out dia);

                    if ((data.Length >= 4))
                        int.TryParse(data[3], out hora);

                    if ((data.Length >= 5))
                        int.TryParse(data[4], out minutos);

                    if ((data.Length >= 6))
                        int.TryParse(data[5], out segundos);

                    if ((data.Length >= 7))
                        int.TryParse(data[6], out milisegundos);


                    dtRetorno = new DateTime(ano, mes, dia, hora, minutos, segundos, milisegundos);

                }
            }
            return dtRetorno;
        }
    }
}
