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
                            CriarElemento(new elemento(), minhalista);
                        }
                    break;
                    case "2":
                        {
                            minhalista.ImprimirTodos();
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
                            reader.Start(minhalista);
                        }
                    break;
                    case "5":
                        {
                            minhalista.Salvar();
                        }
                    break;
                    case "6":
                        {
                            //Lançando duas vezes limpa completamente.
                            minhalista.LimparDados();
                            minhalista.LimparDados();

                        }
                    break;
                    case "0":
                        {
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
