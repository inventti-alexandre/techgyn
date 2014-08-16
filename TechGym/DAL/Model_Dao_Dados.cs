using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using System.Collections;

namespace Academia.Model.Dao.Dados
{
    public class Model_Dao_Dados
    {

        private static string bancoDeDados = "techgymdb";  // houve problemas com maiusculas
        private static string usuario = "techgym"; // houve problemas com maiusculas
        private static string senha = "#$TechGym-0166ac48ebb5b2"; 
        
        /*
        private static string bancoDeDados = "techgymdb";  // houve problemas com maiusculas
        private static string usuario = "techgym"; // houve problemas com maiusculas
        private static string senha = "#$TechGym-0166ac48ebb5b2";
        */

        public static string getStringDeConexao()
        {
            string sArquivo = Directory.GetCurrentDirectory() + "\\ConfigBanco.txt";
            if ((File.Exists(sArquivo)))
            {
                string sLine = "";

                StreamReader objReader = new StreamReader(sArquivo);
                try
                {                                        
                    ArrayList arrText = new ArrayList();

                    while (sLine != null)
                    {
                        sLine = objReader.ReadLine();
                        break;
                    }
                }
                finally
                {
                    objReader.Close();
                }

                return sLine;
            }
            else
            {
                //return "Data Source=LOCALHOST;Initial Catalog=TechGym;User ID=sa;Password=12345;";
                return "Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=techgymdb";

                return "Server=localhost;Port=5432" +
                    ";UserId=" + Model_Dao_Dados.usuario +
                        ";Password=" + Model_Dao_Dados.senha +
                        ";Database=" + Model_Dao_Dados.bancoDeDados + ";";
            }
        }

        public static string ConverterDataToStr(DateTime pData, Boolean pbDataFinal)
        {

            DateTime data = DateTime.MinValue;

            if ((pbDataFinal))
            {
                data = new DateTime(pData.Year, pData.Month, pData.Day, 23, 59, 59, 999);
            }
            else
                data = pData;

            String sRetorno =
                   ("D" + data.Year.ToString("0000") + "-" +
                          data.Month.ToString("00") + "-" +
                          data.Day.ToString("00") +
                   " H" + data.Hour.ToString("00") + ":" +
                          data.Minute.ToString("00") + ":" +
                          data.Second.ToString("00") + "." +
                          data.Millisecond.ToString("000"));
            return sRetorno;
        }

        public static DateTime GetDataString(String psData)
        {
            DateTime dtRetorno = DateTime.Now;

            if ((psData != null) &&
                (psData.Trim() != String.Empty))
            {
                psData = psData.Replace(":", "-");
                psData = psData.Replace(".", "-");
                psData = psData.Replace("D", "");
                psData = psData.Replace("H", "");
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

                    if ((data.Length >= 0))
                        int.TryParse(data[0], out ano);
                    if ((data.Length >= 1))
                        int.TryParse(data[1], out mes);

                    if ((data.Length >= 2))
                        int.TryParse(data[2], out dia);

                    if ((data.Length >= 3))
                        int.TryParse(data[3], out hora);

                    if ((data.Length >= 4))
                        int.TryParse(data[4], out minutos);

                    if ((data.Length >= 5))
                        int.TryParse(data[5], out segundos);

                    if ((data.Length >= 6))
                        int.TryParse(data[6], out milisegundos);


                    dtRetorno = new DateTime(ano, mes, dia, hora, minutos, segundos, milisegundos);

                }
            }
            return dtRetorno;
        }

        public static DateTime ConverterStringData(string sData)
        {
            DateTime date = new DateTime();



            return date;

        }
    }
}
