using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Dao.Clientes;
using System.Data;

namespace Academia.Model.Bo.Clientes
{
    public class Model_Bo_Clientes
    {
        private Model_Dao_Clientes objDAL;

        //Constructor
        public Model_Bo_Clientes()
        {
            objDAL = new Model_Dao_Clientes();
        }
        public void Incluir(Academia.Model.Vo.Cliente.Model_Vo_Cliente pCliente)
        {
            if ((Validar(pCliente)))
                objDAL.Incluir(pCliente);
        }

        public void Alterar(Academia.Model.Vo.Cliente.Model_Vo_Cliente pCliente)
        {
            if ((Validar(pCliente)))
                objDAL.Alterar(pCliente);
        }

        public Boolean Excluir(int codigo)
        {
            return objDAL.Excluir(codigo);
        }

        public DataTable ListaDeClientes()
        {
            return objDAL.ListaDeClientes();
        }

        public DataTable GetCliente(int pIdCliente)
        {
            return objDAL.GetCliente(pIdCliente);
        }

        public Academia.Model.Vo.Cliente.Model_Vo_Cliente Pesquisar(int idCliente)
        {
            DataTable dtCliente = objDAL.Pesquisar(idCliente);

            if (dtCliente == null || dtCliente.Rows.Count <= 0) return null;

            Academia.Model.Vo.Cliente.Model_Vo_Cliente voCliente = ConverteDataRowEmVO(dtCliente.Rows[0]);

            return voCliente;

        }

        public List<Academia.Model.Vo.Cliente.Model_Vo_Cliente> Pesquisar(Academia.Model.Vo.Cliente.Model_Vo_Cliente pCliente)
        {
            List<Academia.Model.Vo.Cliente.Model_Vo_Cliente> clientes = new List<Vo.Cliente.Model_Vo_Cliente>();
            DataTable dtCliente = objDAL.Pesquisar(pCliente);

            foreach (DataRow dr in dtCliente.Rows)
            {
                Academia.Model.Vo.Cliente.Model_Vo_Cliente voCliente = ConverteDataRowEmVO(dr);

                clientes.Add(voCliente);
            }

            return clientes;
        }

        private Academia.Model.Vo.Cliente.Model_Vo_Cliente ConverteDataRowEmVO(DataRow dr)
        {
            Academia.Model.Vo.Cliente.Model_Vo_Cliente voCliente = new Academia.Model.Vo.Cliente.Model_Vo_Cliente();

            voCliente.Id = int.Parse(dr["id"].ToString());
            voCliente.Nome = dr["nome"].ToString();
            voCliente.Cpf = dr["cpf"].ToString();
            voCliente.Email = dr["email"].ToString();
            voCliente.Ativo = bool.Parse(dr["ativo"].ToString());
            voCliente.Bairro = dr["bairro"].ToString();
            voCliente.CEP = dr["cep"].ToString();
            voCliente.Cidade = dr["cidade"].ToString();
            voCliente.Complemento = dr["complemento"].ToString();
            voCliente.Nascimento = DateTime.Now;
            voCliente.Numero = dr["numero"].ToString();
            voCliente.Observacao = dr["observacao"].ToString();
            voCliente.Rg = dr["rg"].ToString();
            voCliente.Rua = dr["rua"].ToString();
            voCliente.Telefone = dr["telefone"].ToString();
            voCliente.UF = dr["uf"].ToString();

            if (!string.IsNullOrEmpty(dr["valormensalidade"].ToString()))
                voCliente.ValorMensalidade = float.Parse(dr["valormensalidade"].ToString());

            return voCliente;
        }

        public Boolean Validar(Academia.Model.Vo.Cliente.Model_Vo_Cliente pCliente)
        {
            if (string.IsNullOrEmpty(pCliente.Nome))
                throw new Exception(("Nome deve ser informado."));

            if ((pCliente.Rg.Trim() != String.Empty) &&
                (validateRg(pCliente.Rg)))
                throw new Exception(("RG inválido"));
            if ((pCliente.Cpf.Trim() != String.Empty) &&
                (IsCpf(pCliente.Cpf)))
                throw new Exception(("CPF inválido"));

            return true;
        }
        public bool validateRg(string rg)
        {
            //Elimina da string os traços, pontos e virgulas,
            rg = rg.Replace("-", "").Replace(".", "").Replace(",", "");

            //Verifica se o tamanho da string é 9
            if (rg.Length == 9)
            {
                int[] n = new int[8];

                //obtém cada um dos caracteres do rg
                n[0] = Convert.ToInt32(rg.Substring(0, 1));
                n[1] = Convert.ToInt32(rg.Substring(1, 1));
                n[2] = Convert.ToInt32(rg.Substring(2, 1));
                n[3] = Convert.ToInt32(rg.Substring(3, 1));
                n[4] = Convert.ToInt32(rg.Substring(4, 1));
                n[5] = Convert.ToInt32(rg.Substring(5, 1));
                n[6] = Convert.ToInt32(rg.Substring(6, 1));
                n[7] = Convert.ToInt32(rg.Substring(7, 1));
                n[8] = Convert.ToInt32(rg.Substring(8, 1));

                //Aplica a regra de validação do RG, multiplicando cada digito por valores pré-determinados
                n[0] *= 2;
                n[1] *= 3;
                n[2] *= 4;
                n[3] *= 5;
                n[4] *= 6;
                n[5] *= 7;
                n[6] *= 8;
                n[7] *= 9;
                n[8] *= 100;

                //Valida o RG
                int somaFinal = n[0] + n[1] + n[2] + n[3] + n[4] + n[5] + n[6] + n[7] + n[8];
                if ((somaFinal % 11) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
       
            public static bool IsCpf(string cpf)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }
            public  List<Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> pesquisaExtratos(Academia.Model.Vo.Cliente.Model_Vo_Cliente pCliente)
            {
                List<Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> extratos = new List<Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque>();
                DataTable dtCliente = objDAL.pesquisaExtratos(pCliente);

                foreach (DataRow dr in dtCliente.Rows)
                {
                    Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque voCliente = new Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();

                   
                    voCliente.ValorUnitario = float.Parse(dr["valorunitario"].ToString());
                    voCliente.Quantidade = float.Parse(dr["quantidade"].ToString());
                    voCliente.ValorTotal = float.Parse(dr["valortotal"].ToString());
                    voCliente.DataHora = DateTime.Parse(dr["dataHora"].ToString());
                    voCliente.IdProduto = int.Parse(dr["Idproduto"].ToString());




                    extratos.Add(voCliente);

                }
                    return extratos;
        }

            }

            

    }

