using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using Lib.ConsoleHelper;

namespace SCgrc;


class Program
{
    static void Main(string[] args)
    {
        AllMenus menus= new AllMenus();
        CSVReader reader = new CSVReader(menus);
        lista minhalista= new lista();
        bool start=true;
        bool start2=true;
        bool start3=true;
        Console.Clear();
        //LOOP PRINCIPAL
        do{
        //CONTROLE DO MY MENU
        var resposta1= menus.MainRoot.ReadChoice(true);
            //SWITCH DO MENU
            switch (resposta1.Value)
            {
                case "1":
                    {
                        start2=true;
                        do
                            {
                            var resposta = menus.Main1.ReadChoice(true);
                            //SWITCH DO MENU
                            switch (resposta.Value)
                                {
                                    case "1":
                                    {
                                        if (minhalista.primeiro.prox != null)
                                        {
                                            Console.WriteLine("> Sistema alimentado;\n> Arquivos caregados: "+minhalista.Contar());
                                            Console.ReadKey(true);                            
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("> Nenhum arquivo carregado no momento.");
                                            Console.ReadKey(true);                            
                                        }
                                    }
                                    break;
                                    case "2":
                                        {
                                        if (minhalista.primeiro.prox == null)
                                        {
                                            reader.Start(minhalista);
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Tem certeza que deseja importar outro arquivo? Todo dado NÃO SALVO será perdido...(S/N)");
                                            if (Console.ReadKey(true).Key != ConsoleKey.S)
                                            {
                                                break;
                                            }
                                            //LIMPA TUDO
                                            minhalista.LimparDados();
                                            minhalista.LimparDados();

                                            reader.Start(minhalista);
                                        }
                                        }
                                    break;
                                    case "3":
                                        {
                                        while (start == true)
                                            {
                                                Console.Clear();
                                                var opt= menus.Pesquisar.ReadChoice(true);
                                                if(opt.Value=="0")
                                                    break;  
                                                System.Console.WriteLine("Pesquisar por:");
                                                string busca= Console.ReadLine().ToLower();
                                                System.Console.WriteLine();
                                                minhalista.Pesquisar(busca, opt.Value);
                                                Console.ReadKey();
                                            }
                                        }
                                    break;
                                    case "4":
                                        {
                                            minhalista.ImprimirTodos();
                                        }
                                    break;
                                    case "5":
                                        {
                                            CriarElemento(new elemento(), minhalista);
                                        }
                                    break;
                                    case "6":
                                        {
                                            System.Console.WriteLine("Tem certeza que deseja salvar?\nO salvamento irá escrever encima do último salvamento.\n(S/N)");
                                        if (Console.ReadKey(true).Key == ConsoleKey.S)
                                        {
                                            minhalista.Salvar();
                                        }
                                        else{break;}

                                        }
                                    break;
                                    case "7":
                                        {
                                        
                                            System.Console.WriteLine("Tem certeza que deseja limpar todos os dados existentes?\nTodo progresso não salvo será perdido...\n(S/N)");
                                        if (Console.ReadKey(true).Key == ConsoleKey.S)
                                            {
                                            //Lançando duas vezes limpa completamente.
                                            minhalista.LimparDados();
                                            minhalista.LimparDados();    
                                            }
                                            else{break;}


                                        }
                                    break;
                                    case "8":
                                        {
                                            Console.Clear();
                                            System.Console.WriteLine("Insira o INDEX do elemento que quer excluir:");
                                            string index = Console.ReadLine();
                                                //TESTA SE O NÚMERO É UM INTEIRO;
                                                if(int.TryParse(index, out int indexn))
                                                {
                                                    minhalista.Remover(indexn);
                                                }
                                        else
                                        {
                                            Console.Clear();
                                            System.Console.WriteLine($"Erro: não é um número inteiro...\nPressione ENTER para continuar...");
                                            Console.ReadKey();
                                        }
                                        }
                                    break;
                                    case "0":
                                        {
                                            Console.Clear();
                                            System.Console.WriteLine("Saindo....");
                                            start2=false;
                                        }
                                    break;
                                }    
                            }while(start2==true);

                    }
                break;
                case "2":
                    {
                        start3=true;
                        do
                        {
                            //MENU
                        var resposta3= menus.Prazos.ReadChoice(true);
                        //SWITHC DO MENU
                        switch (resposta3.Value)
                            {
                                case "1":
                                    {
                                        minhalista.escrever();

                                    }
                                break;
                                case "2":
                                    {
                                        Console.Clear();
                                        System.Console.WriteLine("Insira o Index do Documento que você deseja atualizar:");
                                        string resposta4=Console.ReadLine();

                                        minhalista.Atualizar(resposta4);
                                    }
                                break;
                                case "0":
                                    {
                                        Console.Clear();
                                        System.Console.WriteLine("Saindo....");
                                        start3=false;
                                    }
                                break;

                            }
                        }while(start3==true);
                        
                    }
                break;
                case "0":
                    {
                        Console.Clear();
                        System.Console.WriteLine("Saindo....");
                        start=false;
                    }
                break;
            }
            
        }while(start==true);
     }

     

    //Fazer novo elemento.
    static void CriarElemento(elemento x, lista y)
    { 
        Console.Clear();
        System.Console.WriteLine("\n> Todos os elementos possuem os seguintes dados:\n> Nome,Caminho,Categoria e Área.\n> Preencha os campos com os dados do elemento, ou deixe em branco caso não se aplique.\n> Caso cometa algum erro, basta excluir o item no Menu e criar outro com os dados corretos!\n \n--------------------------------\n");
        System.Console.WriteLine();
        
        x.Index= y.Contar()+1;
        
        System.Console.WriteLine("> Insira o Nome do novo elemento:");
        x.nome= Console.ReadLine();

        System.Console.WriteLine("> Insira o Caminho detro do SGPI do novo elemento: ");
        x.caminho= Console.ReadLine();

        System.Console.WriteLine("> Insira a Categoria do novo elemento: ");
        x.categoria= Console.ReadLine();

        System.Console.WriteLine("> Insira a Área do novo elemento: ");
        x.área= Console.ReadLine();

        y.InserirFim(x);
    }
}
