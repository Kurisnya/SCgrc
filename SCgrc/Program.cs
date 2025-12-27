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
        Console.Clear();
        //LOOP PRINCIPAL
        do{
        //CONTROLE DO MY MENU
        var resposta = menus.Main1.ReadChoice(true);
            //SWITCH DO MENU
            switch (resposta.Value)
                {
                    case "1":
                        {
                            reader.Start(minhalista);
                        }
                    break;
                    case "2":
                        {
                            Console.Clear();
                            var opt= menus.Pesquisar.ReadChoice(true);
                            System.Console.WriteLine("Pesquisar por:");
                            string busca= Console.ReadLine();
                            minhalista.Pesquisar(busca, opt.Value);
                            Console.ReadKey();
                        }
                    break;
                    case "3":
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
                            System.Console.WriteLine($"Erro: não é um númeor inteiro...\nPressione ENTER para continuar...");
                            Console.ReadKey();
                        }
                            
                        }
                    break;
                    case "4":
                        {
                            CriarElemento(new elemento(), minhalista);
                        }
                    break;
                    case "5":
                        {
                            System.Console.WriteLine("Tem certeza que deseja salvar?\nO salvamento irá escrever encima do último salvamento.\n(Y/N)");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            minhalista.Salvar();
                            System.Console.WriteLine("Dados salvos com êxito, aperte ENTER para continuar...");
                            Console.ReadKey();
                        }
                        else{break;}
                            
                        }
                    break;
                    case "6":
                        {
                            
                            System.Console.WriteLine("Tem certeza que deseja limpar todos os dados existentes?\nTodo progresso não salvo será perdido...\n(S/N)");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                            {
                            //Lançando duas vezes limpa completamente.
                            minhalista.LimparDados();
                            minhalista.LimparDados();
                            Console.Clear();    
                            System.Console.WriteLine("Todos os dados foram limpos com êxito;\nAperte ENTER para voltar...");
                            Console.ReadKey();
                            }
                            else{break;}
                            

                        }
                    break;
                    case "7":
                        {
                            minhalista.ImprimirTodos();
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
        x.Index= y.Contar()+1;

        Console.Clear();
        System.Console.WriteLine("Insira o Nome do novo elemento:");
        x.nome= Console.ReadLine();

        Console.Clear();
        System.Console.WriteLine("Insira o ID do novo elemento: ");
        x.id= Console.ReadLine();

        y.InserirFim(x);
    }
}
