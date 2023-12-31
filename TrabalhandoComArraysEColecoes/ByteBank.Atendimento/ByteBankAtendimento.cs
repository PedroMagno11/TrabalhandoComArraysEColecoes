using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhandoComArraysEColecoes.ByteBank.Exceptions;

namespace TrabalhandoComArraysEColecoes.ByteBank.Atendimento
{
    internal class ByteBankAtendimento
    {
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        {
            new ContaCorrente(95, "123456-x"){Saldo=100, Titular = new Cliente{Cpf="11111",Nome="Pedro"} },
            new ContaCorrente(95, "974352-x"){Saldo=200, Titular = new Cliente{Cpf="22222",Nome="Marcos"} },
            new ContaCorrente(94, "987631-x"){Saldo=60, Titular = new Cliente{Cpf="33333",Nome="Joana"} },
        };


        public void AtendimentoCliente()
        {

            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("=============================");
                    Console.WriteLine("===     Atendimento       ===");
                    Console.WriteLine("===1 - Cadastrar Conta    ===");
                    Console.WriteLine("===2 - Listar Contas      ===");
                    Console.WriteLine("===3 - Remover Conta      ===");
                    Console.WriteLine("===4 - Ordenar Contas     ===");
                    Console.WriteLine("===5 - Pesquisar Conta    ===");
                    Console.WriteLine("===6 - Sair do Sistema    ===");
                    Console.WriteLine("=============================");
                    Console.WriteLine("\n\n");
                    Console.Write("Digite a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception ex)
                    {
                        throw new ByteBankException(ex.Message, ex);
                    }
                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarContas();
                            break;
                        case '6':
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opção não implementada.");
                            break;
                    }
                }

            }
            catch (ByteBankException ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void EncerrarAplicacao()
        {
            Console.WriteLine("... Encerrando aplicação ...");
        }

        private void PesquisarContas()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("===     PESQUISAR CONTAS     ===");
            Console.WriteLine("================================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA ou (2) CPF DO TITULAR ou (3) NÚMERO DA AGÊNCIA");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Informe o número da Conta: ");
                    string _numeroDaConta = Console.ReadLine();
                    ContaCorrente consultaConta = ConsultarPorNumeroDaConta(_numeroDaConta);
                    Console.WriteLine(consultaConta);
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Write("Informe o CPF do Titular: ");
                    string _cpf = Console.ReadLine();
                    ContaCorrente consultaCpf = ConsultarPorCPFDoTitular(_cpf);
                    Console.WriteLine(consultaCpf);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Write("Informe o número da Agência: ");
                    int _numeroDaAgencia = int.Parse(Console.ReadLine());
                    var contasPorAgencia = ConsultarPorAgencia(_numeroDaAgencia);
                    ExibirListaDeContas(contasPorAgencia);
                    Console.ReadKey();
                    break;
                default:
                    break;
            }

        }

        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia.Count == null)
            {
                Console.WriteLine("... A consulta não retornou dados");
            }
            else
            {
                foreach (ContaCorrente item in contasPorAgencia)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private List<ContaCorrente> ConsultarPorAgencia(int numeroDaAgencia)
        {
            var consulta = (
                from conta in _listaDeContas
                where conta.Numero_agencia == numeroDaAgencia
                select conta).ToList();
            return consulta;
        }

        private ContaCorrente ConsultarPorCPFDoTitular(string? cpf)
        {
            return _listaDeContas.FirstOrDefault(conta => conta.Titular.Cpf == cpf);
        }

        private ContaCorrente ConsultarPorNumeroDaConta(string? numeroDaConta)
        {
            return _listaDeContas.FirstOrDefault(conta => conta.Conta == numeroDaConta);
        }

        private void OrdenarContas()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de contas ordenada ...");
            Console.ReadKey();
        }

        private void RemoverContas()
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("===     REMOVER CONTAS     ===");
            Console.WriteLine("==============================");
            Console.WriteLine("\n");
            Console.Write("Informe o número da Conta: ");
            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;
            foreach (var item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta Removida da lista! ...");
            }
            else
            {
                Console.WriteLine("... Conta para remoção não encontrada ...");
            }
            Console.ReadKey();
        }

        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     LISTA DE CONTAS     ==="); ;
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }
            foreach (ContaCorrente item in _listaDeContas)
            {
                Console.WriteLine(item); ;
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();
            }

        }
        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("===      CADASTRO DE CONTAS       ===");
            Console.WriteLine("=====================================");
            Console.WriteLine("\n");
            Console.WriteLine("===   Informe os dados da conta   ===");

            Console.Write("Número da Agência: ");
            int numeroDaAgencia = int.Parse(Console.ReadLine());
            ContaCorrente conta = new ContaCorrente(numeroDaAgencia);
            Console.WriteLine($"Número da conta [Nova]:{conta.Conta}");
            Console.Write("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Informe o nome do Titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Informe o CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Informe a Profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);

            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }
    }
}
