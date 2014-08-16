using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Academia;

namespace Academia.Controller.TDD_TESTES
{
    [TestClass]
    public class TestesTechGym
    {
        [TestMethod]
        public void TesteCadastrarSalas()
        {
            Academia.Model.Vo.Sala.Model_Vo_Sala Sala1 = new Academia.Model.Vo.Sala.Model_Vo_Sala();
            Academia.Model.Vo.Sala.Model_Vo_Sala Sala2 = new Academia.Model.Vo.Sala.Model_Vo_Sala();
            Academia.Model.Vo.Sala.Model_Vo_Sala Sala3 = new Academia.Model.Vo.Sala.Model_Vo_Sala();

            Sala1.Capacidade = 4;
            Sala1.Id = 0;
            Sala1.Nome = "Quadra de Squash 1";
            Sala1.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra;

            Sala2.Capacidade = 4;
            Sala2.Id = 0;
            Sala2.Nome = "Quadra de Squash 2";
            Sala2.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra;

            Sala3.Capacidade = 30;
            Sala3.Id = 0;
            Sala3.Nome = "Sauna";
            Sala3.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna;

            Academia.Controller.Salas.Controller_Salas salas = new Academia.Controller.Salas.Controller_Salas();

            salas.Incluir(Sala1);
            salas.Incluir(Sala2);
            salas.Incluir(Sala3);
        }

        [TestMethod]
        public void TesteCadastrarClientes()
        {
            Academia.Model.Vo.Cliente.Model_Vo_Cliente Cliente1 = new Academia.Model.Vo.Cliente.Model_Vo_Cliente();
            Academia.Model.Vo.Cliente.Model_Vo_Cliente Cliente2 = new Academia.Model.Vo.Cliente.Model_Vo_Cliente();

            Cliente1.Ativo = true;
            Cliente1.Bairro = "Monte Bérico";
            Cliente1.CEP = "95330-000";
            Cliente1.Cidade = "Veranópolis";
            Cliente1.Complemento = "Casa";
            Cliente1.Cpf = "";
            Cliente1.Email = "etorezan@gmail.com";
            Cliente1.Id = 0;
            Cliente1.Nascimento = new DateTime(1986, 04, 05);
            Cliente1.Nome = "Eduardo Picetti Torezan";
            Cliente1.Numero = "265";
            Cliente1.Observacao = "Nehuma observação ajdasdhjkasdkas";
            Cliente1.Rg = "8090448385";
            Cliente1.Rua = "Rua Thomás Flores";
            Cliente1.Telefone = "54-9959-5048";
            Cliente1.UF = "RS";
            Cliente1.ValorMensalidade = 200.00f;

            Cliente2.Ativo = true;
            Cliente2.Bairro = "Monte Bérico";
            Cliente2.CEP = "95330-000";
            Cliente2.Cidade = "Veranópolis";
            Cliente2.Complemento = "Casa";
            Cliente2.Cpf = "";
            Cliente2.Email = "etorezan@gmail.com";
            Cliente2.Id = 0;
            Cliente2.Nascimento = new DateTime(1999, 07, 27);
            Cliente2.Nome = "Manoela Picetti Torezan";
            Cliente2.Numero = "265";
            Cliente2.Observacao = "Nehuma observação ajdasdhjkasdkas";
            Cliente2.Rg = "";
            Cliente2.Rua = "Rua Thomás Flores";
            Cliente2.Telefone = "54-3441-0081";
            Cliente2.UF = "RS";
            Cliente2.ValorMensalidade = 180.00f;

            Academia.Controller.Clientes.Controller_Clientes contCliente = new Academia.Controller.Clientes.Controller_Clientes();

            contCliente.Incluir(Cliente1);
            contCliente.Incluir(Cliente2);
        }

        [TestMethod]
        public void TesteCadastrarProdutos()
        {
            Academia.Model.Vo.Produto.Model_Vo_Produto Produto1 = new Academia.Model.Vo.Produto.Model_Vo_Produto();
            Academia.Model.Vo.Produto.Model_Vo_Produto Produto2 = new Academia.Model.Vo.Produto.Model_Vo_Produto();
            Academia.Model.Vo.Produto.Model_Vo_Produto Produto3 = new Academia.Model.Vo.Produto.Model_Vo_Produto();
            Academia.Model.Vo.Produto.Model_Vo_Produto Produto4 = new Academia.Model.Vo.Produto.Model_Vo_Produto();
            Academia.Model.Vo.Produto.Model_Vo_Produto Produto5 = new Academia.Model.Vo.Produto.Model_Vo_Produto();
            Academia.Model.Vo.Produto.Model_Vo_Produto Produto6 = new Academia.Model.Vo.Produto.Model_Vo_Produto();

            Produto1.Descricao = "Água mineral sem gás";
            Produto1.Estoque = 10;
            Produto1.Id = 0;
            Produto1.Observacao = "Sem observações";
            Produto1.Unidade = "UN";
            Produto1.ValorDeVenda = 2.00f;

            Produto2.Descricao = "Água mineral com gás";
            Produto2.Estoque = 20;
            Produto2.Id = 0;
            Produto2.Observacao = "Sem observações";
            Produto2.Unidade = "UN";
            Produto2.ValorDeVenda = 2.50f;

            Produto3.Descricao = "Coca-cola";
            Produto3.Estoque = 30;
            Produto3.Id = 0;
            Produto3.Observacao = "Sem observações";
            Produto3.Unidade = "UN";
            Produto3.ValorDeVenda = 2.50f;

            Produto4.Descricao = "Bola de borracha";
            Produto4.Estoque = 10;
            Produto4.Id = 0;
            Produto4.Observacao = "Sem observações";
            Produto4.Unidade = "UN";
            Produto4.ValorDeVenda = 5.00f;

            Produto5.Descricao = "Sabonete";
            Produto5.Estoque = 50;
            Produto5.Id = 0;
            Produto5.Observacao = "Sem observações";
            Produto5.Unidade = "UN";
            Produto5.ValorDeVenda = 1.00f;

            Produto6.Descricao = "Consumo de reserva da quadra";
            Produto6.Estoque = 0;
            Produto6.Id = 0;
            Produto6.Observacao = "Item de consumo da reserva da quadra, não excluir.";
            Produto6.Unidade = "UN";
            Produto6.ValorDeVenda = 50.00f;

            Produto6.Descricao = "Consumo de reserva da sauna";
            Produto6.Estoque = 0;
            Produto6.Id = 0;
            Produto6.Observacao = "Item de consumo da reserva da sauna, não excluir.";
            Produto6.Unidade = "UN";
            Produto6.ValorDeVenda = 30.00f;

            Academia.Controller.Produtos.Controller_Produtos contProdutos = new Academia.Controller.Produtos.Controller_Produtos();

            contProdutos.Incluir(Produto1);
            contProdutos.Incluir(Produto2);
            contProdutos.Incluir(Produto3);
            contProdutos.Incluir(Produto4);
            contProdutos.Incluir(Produto5);
            contProdutos.Incluir(Produto6);
        }

        [TestMethod]
        public void TesteCadastrarReserva()
        {
            Academia.Model.Vo.Agenda.Model_Vo_Agenda Reserva1 = new Academia.Model.Vo.Agenda.Model_Vo_Agenda();
            Academia.Model.Vo.Agenda.Model_Vo_Agenda Reserva2 = new Academia.Model.Vo.Agenda.Model_Vo_Agenda();
            Academia.Model.Vo.Agenda.Model_Vo_Agenda Reserva3 = new Academia.Model.Vo.Agenda.Model_Vo_Agenda();
            Academia.Model.Vo.Agenda.Model_Vo_Agenda Reserva4 = new Academia.Model.Vo.Agenda.Model_Vo_Agenda();


            Reserva1.DataHoraReserva = DateTime.Now;
            Reserva1.Id = 0;
            Reserva1.IdCliente = 1;
            Reserva1.IdSala = 1;

            Reserva2.DataHoraReserva = DateTime.Now;
            Reserva2.Id = 0;
            Reserva2.IdCliente = 2;
            Reserva2.IdSala = 1;

            Reserva3.DataHoraReserva = DateTime.Now;
            Reserva3.Id = 0;
            Reserva3.IdCliente = 1;
            Reserva3.IdSala = 2;

            Reserva4.DataHoraReserva = DateTime.Now;
            Reserva4.Id = 0;
            Reserva4.IdCliente = 2;
            Reserva4.IdSala = 2;

            Academia.Controller.Agendas.Controller_Agendas contAgenda = new Academia.Controller.Agendas.Controller_Agendas();

            contAgenda.Incluir(Reserva1);
            contAgenda.Incluir(Reserva2);
            contAgenda.Incluir(Reserva3);
            contAgenda.Incluir(Reserva4);

        }

        [TestMethod]
        public void TesteConsumoProdutoComReserva()
        {
            Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque VoMovEstq = new Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();
            Academia.Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques ContMovEst = new Academia.Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques();


            VoMovEstq.DataHora = DateTime.Now;
            VoMovEstq.IdClienteSolicitante = 1;
            VoMovEstq.IdProduto = 1;
            VoMovEstq.IdReservaOrigem = 1; 
            VoMovEstq.Quantidade = 2.0f;
            VoMovEstq.TipoDeMovimento = Academia.Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;
            VoMovEstq.ValorUnitario = 1.50f;
            VoMovEstq.ValorTotal = (VoMovEstq.ValorUnitario * VoMovEstq.Quantidade);

            ContMovEst.Incluir(VoMovEstq);

            VoMovEstq.IdClienteSolicitante = 2;
            VoMovEstq.IdReservaOrigem = 2;
            VoMovEstq.IdProduto = 2;
            ContMovEst.Incluir(VoMovEstq);

            VoMovEstq.IdClienteSolicitante = 2;
            VoMovEstq.IdReservaOrigem = 3;
            VoMovEstq.IdProduto = 3;
            ContMovEst.Incluir(VoMovEstq);

        }

        [TestMethod]
        public void TesteConsumoProdutoSemReserva()
        {
            Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque VoMovEstq = new Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();
            Academia.Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques ContMovEst = new Academia.Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques();


            VoMovEstq.DataHora = DateTime.Now;
            VoMovEstq.IdClienteSolicitante = 0;
            VoMovEstq.IdProduto = 1;
            VoMovEstq.IdReservaOrigem = 0;
            VoMovEstq.Quantidade = 2.0f;
            VoMovEstq.TipoDeMovimento = Academia.Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;
            VoMovEstq.ValorUnitario = 1.50f;
            VoMovEstq.ValorTotal = (VoMovEstq.ValorUnitario * VoMovEstq.Quantidade);

            ContMovEst.Incluir(VoMovEstq);            
        }

        [TestMethod]
        public void TesteFecharContaComPagamento()
        {
            Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber VoCtaReceb = new Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();
            VoCtaReceb.IdReservaOrigem = 1;
            VoCtaReceb.Recebido = true;

            Academia.Controller.ContasARecebers.Controller_ContasARecebers ContMovEst = new Academia.Controller.ContasARecebers.Controller_ContasARecebers();
            ContMovEst.FecharContasAReceber(VoCtaReceb);
        }

        [TestMethod]
        public void TesteFecharContaSemPagamento()
        {
            Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber VoCtaReceb = new Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();
            VoCtaReceb.IdReservaOrigem = 2;
            VoCtaReceb.Recebido = false;

            Academia.Controller.ContasARecebers.Controller_ContasARecebers ContMovEst = new Academia.Controller.ContasARecebers.Controller_ContasARecebers();
            ContMovEst.FecharContasAReceber(VoCtaReceb);
        }
    }
}
