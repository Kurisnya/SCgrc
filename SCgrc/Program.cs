using Lib.ConsoleHelper;

namespace SCgrc;


class Program
{
    static void Main(string[] args)
    {
        CSVReader reader = new CSVReader();
        ChoiceMenu menu = new ChoiceMenu(reader.SettingMain);
        lista minhalista= new lista();
        bool start=true;
        
        Console.Clear();
        //MENU PRINCIPAL - CONFIGURAÇÕES
        menu.Options.Add(new MenuItem
        {
            Title = "Criar Elemento",
            Value = "1"
        });
                menu.Options.Add(new MenuItem
        {
            Title = "Imprimir Todos",
            Value = "2"
        });
        menu.Options.Add(new MenuItem
        {
            Title = "Excluir elemento",
            Value = "3"
        });
        menu.Options.Add(new MenuItem
        {
            Title = "Exportar da pasta",
            Value = "4"
        });
        menu.Options.Add(new MenuItem
        {
            Title = "Sair",
            Value = "0"
        });

        //LOOP PRINCIPAL
        do{
        //CONTROLE DO MY MENU
        var resposta = menu.ReadChoice(true);
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
                            int index = int.Parse(Console.ReadLine());
                            minhalista.Remover(index);
                        }
                    break;
                    case "4":
                        {
                            reader.Start(minhalista);
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
