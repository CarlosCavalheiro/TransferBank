using System;
using System.Collections.Generic;
using Projeto_Tranferbank.Classes;
using Projeto_Tranferbank.Enum;

namespace Projeto_Tranferbank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();        
        static void Main(string[] args)
        {            
           //Carregando contas iniciais
           CarregarContas();

           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                    case "1":
                        Console.Clear();
                        ListarContas();
                        break;

                    case "2":
                        Console.Clear();
                        InserirConta();
                        break;
                    
                    case "3":
                        Console.Clear();
                        Transferir();
                        break;
                    case "4":
                        Console.Clear();
                        Sacar();
                        break;

                    case "5":
                        Console.Clear();
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por usar nossos serviços.");
           Console.ReadLine();
        }

        private static void CarregarContas()
        {
            Console.WriteLine("Carregar Contas Iniciais!");                                                        
            
            listaContas.Add(new Conta(tipoConta: (TipoConta)TipoConta.PessoaFisica,
                                        saldo: 200,
                                        credito: 500,
                                        nome: "João")
                                        );

            listaContas.Add(new Conta(tipoConta: (TipoConta)TipoConta.PessoaFisica,
                                        saldo: 300,
                                        credito: 100,
                                        nome: "Maria")
                                        );                                        
            ListarContas();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferência: valorTransferencia, contaDestino: listaContas[indiceContaDestino]);

        }

        private static void Depositar()
        {
             Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta =  listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("TransferBank a seu banco de todo dia!");
            Console.WriteLine("Informe uma opção:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.Write("Digite 1 para Conta Físia ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inícial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            
            listaContas.Add(novaConta);

        }

    }
}
