using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Menu_Lanchonete
{
    class Lanchonete
    {
        static void Main(string[] args)
        {
            List<Funcionario> dados = new List<Funcionario>();
            List<Cardapio> comidas = new List<Cardapio>();
            List<Cardapio> bebidas = new List<Cardapio>();
            bool loop = true;
            dados.Add(new Funcionario
            {
                LoginFuncionario = "funcionario1",
                SenhaFuncionario = "123"
            });

            while (loop)
            {
                Console.Clear();
                Console.Write("O que deseja fazer (1) Adicionar item ao cardápio // (2) Abrir Cardápio // (3) Cadastrar Funcionario: ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Digite login do funcionario: ");
                        string loginDoFuncionario = Console.ReadLine();
                        Console.Write("Digite senha do funcionario: ");
                        string senhaDoFuncionario = Console.ReadLine();
                        if (!dados.Any(p => p.LoginFuncionario == loginDoFuncionario && p.SenhaFuncionario == senhaDoFuncionario))
                        {
                            Console.WriteLine("Acesso invalido");
                            Thread.Sleep(2000);
                            break;
                        }
                        Console.WriteLine("Acesso permitido");
                        Thread.Sleep(2000);

                        bool loop2 = true;
                        while (loop2)
                        {
                            Console.WriteLine("O que deseja adicionar (1) Bebida (2) Comida (3) Sair");
                            string menu1 = Console.ReadLine();
                            switch (menu1)
                            {
                                case "1":
                                    Console.WriteLine("Nome da bebida: ");
                                    string bebida = Console.ReadLine();
                                    Console.WriteLine("preço da bebida");
                                    double precoBebida = double.Parse(Console.ReadLine());
                                    bebidas.Add(new Cardapio
                                    {
                                        NomeProduto = bebida,
                                        PrecoProduto = precoBebida,
                                        ID = bebidas.Count() + 1
                                    });
                                    Console.WriteLine("Bebida cadastrada");
                                    break;
                                case "2":
                                    Console.WriteLine("Nome da comida: ");
                                    string comida = Console.ReadLine();
                                    Console.WriteLine("Preço da comida: ");
                                    double precoComida = double.Parse(Console.ReadLine());
                                    comidas.Add(new Cardapio
                                    {
                                        NomeProduto = comida,
                                        PrecoProduto = precoComida,
                                        ID = comidas.Count() + 1


                                    });
                                    break;
                                case "3":
                                    loop2 = false;
                                    break;

                            }
                        }
                        break;

                    case "2":
                        bool loop3 = true;
                        List<Cardapio> pedido = new List<Cardapio>();
                        Console.Clear();
                        while (loop3)
                        {
                            Console.WriteLine("Menu De Opções");
                            Console.WriteLine("(1) bebidas \n(2) comidas \n(3) Finaliza seu pedido \n (4) Sair");
                            string escolha = Console.ReadLine();
                            switch (escolha)
                            {
                                case "1":
                                    bool loopbebida = true;
                                    while (loopbebida)
                                    {

                                        foreach (var item in bebidas)
                                        {
                                            Console.WriteLine($"{item.ID} {item.NomeProduto}\n R${item.PrecoProduto}");
                                        }
                                        Console.WriteLine("Digite o ID da Bebida ou 0 para sair: ");
                                        int idBebida = int.Parse(Console.ReadLine());
                                        if (idBebida == 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        if (!bebidas.Any(p => p.ID == idBebida))
                                        {
                                            Console.WriteLine("bebida nao encontrada");
                                            Console.Clear();
                                            break;
                                        }
                                        foreach (var item in bebidas)
                                        {
                                            if (idBebida == item.ID)
                                            {
                                                pedido.Add(item);
                                            }
                                        }
                                        Console.Clear();
                                    }
                                    break;
                                case "2":
                                    bool loopcomida = true;
                                    while (loopcomida)
                                    {
                                        foreach (var item in comidas)
                                        {
                                            Console.WriteLine($"{item.ID}{item.NomeProduto}\n R${item.PrecoProduto}");
                                        }
                                        Console.WriteLine("Digite o ID da comida ou 0 para sair: ");
                                        int idComida = int.Parse(Console.ReadLine());
                                        if (idComida == 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        if (!comidas.Any(p => p.ID == idComida))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Comida nao encontrada");
                                        }
                                        foreach (var item in comidas)
                                        {
                                            if (idComida == item.ID)
                                            {
                                                pedido.Add(item);
                                                Console.Clear();
                                            }
                                        }
                                    }
                                    break;
                                case "3":
                                    foreach (var item in pedido)
                                    {
                                        Console.WriteLine($"{item.ID}{item.NomeProduto}\n{item.PrecoProduto}");
                                    }
                                    break;
                            }
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Entre como ADMIN: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Senha: ");
                        string senha = Console.ReadLine();
                        if (login == "admin" && senha == "1010")
                        {
                            Console.WriteLine("Acesso permitido");
                        }
                        else
                        {
                            Console.WriteLine("Acesso negado");
                            Thread.Sleep(2000);
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Login para cadastro");
                        string loginFuncionario = Console.ReadLine();
                        Console.WriteLine("Senha para cadastro");
                        string SenhaFuncionario = Console.ReadLine();
                        dados.Add(new Funcionario
                        {
                            LoginFuncionario = loginFuncionario,
                            SenhaFuncionario = SenhaFuncionario
                        });
                        Console.WriteLine("Cadastro Realizado com sucesso");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}

