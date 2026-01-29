using System.Text;

namespace SCgrc
{
    public class lista
    {
        public elemento primeiro{get;set;}
        private elemento ultimo{get;set;}
        


        //1. Construtor: Automatizar.
        public lista()
        {
            primeiro=ultimo=new elemento();
        }

        //2. Inserir novo elemento no final da lista.
        public void InserirFim(elemento x)
        {
            ultimo.prox=x;
            ultimo=ultimo.prox;
        }

        //3. Ler todo mundo.
        public void ImprimirTodos()
        {
            Console.Clear();
            elemento i=primeiro;

            if (i.prox != null)
            {
               do
            {
                i=i.prox;
                i.ToString();

            }while(i.prox!=null);
                System.Console.WriteLine($"\nAperte ENTER para voltar");
                Console.ReadKey(); 
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine(" ERRO: Não existem elementos presentes na lista atual\n Insira mais elementos no menu para imprimir elementos.\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }

            
        }

        //4. REMOVER ELEMENTO
        public bool Remover(int index)
        {
            elemento anterior = primeiro;
            elemento atual = primeiro.prox;

            while (atual != null)
            {
                if (atual.Index == index) 
                {
                    anterior.prox = atual.prox;

                    if (atual == ultimo)
                        ultimo = anterior;

                    CorrigeIndex(atual.prox);
                    return true;
                }

                anterior = atual;
                atual = atual.prox;
            }
            return false;
        }

        //5. Salvar dados em documento save.csv
        public void Salvar()
        {
            string path= "data/save.csv";
            StringBuilder saída = new StringBuilder();

            elemento i = primeiro.prox;

            while(i!=null)
            {
                saída.Append($"{i.Index},");
                saída.Append($"{i.nome},");
                saída.Append($"{i.caminho},");
                saída.Append($"{i.categoria},");
                saída.Append($"{i.área},");
                saída.Append($"{i.revisão.Year},");
                saída.Append($"{i.revisão.Month},");
                saída.Append($"{i.revisão.Day}");

                saída.Append('\n');

                
                i=i.prox;

            }
            //5.1 Antes de salvar, o arquivo é excluído.
            File.Delete(path);
            File.AppendAllText(path, saída.ToString());
        }

        //6. Excluir todos os dados presentes dentro do sistema
        public void LimparDados()
        {
            int cont=0;
            while (Contar() >= cont)
            {
            Remover(1);
            cont++;                
            }
        }

        //7. Corrigir ordem de Index.
        public void CorrigeIndex(elemento noInicio)
        {
            elemento i = noInicio;
            while (i != null)
            {
                i.Index--;
                i = i.prox;
            }
        }
        
        //8. Contar elementos.
        public int Contar()
        {
            elemento i = primeiro.prox;
            int cont = 0;

            while(i!=null)
            {
                cont++;
                i=i.prox;

            }

            return cont;
        }

        //9. Buscar elemento com base no parâmetro
         public void Pesquisar(string busca, string opt)
        {
            elemento i = primeiro.prox;
            while (i != null)
            {
                PesquisarResult(i, busca, opt);
                i = i.prox;
            }
        }

        //10. Imprimir elementos com base no parâmetro
        //opt: 1 nome, 2 index
        public void PesquisarResult(elemento j,string busca, string opt)
        {
            if (opt == "1")
            {
                if (busca == j.Index.ToString().ToLower())
                {
                    j.ToString();
                }
            }
            if (opt == "2")
            {
                if (busca == j.nome.ToString().ToLower())
                {
                    j.ToString();
                }
            }
            if (opt == "3")
            {
                if (busca == j.caminho.ToString().ToLower())
                {
                    j.ToString();
                }
            }
            if (opt == "4")
            {
                if (busca == j.categoria.ToString().ToLower())
                {
                    j.ToString();
                }
            }
            if (opt == "5")
            {
                if (busca == j.área.ToString().ToLower())
                {
                    j.ToString();
                }
            }
        }

        public void escrever()
        {
            Console.Clear();
            elemento i=primeiro;

            if (i.prox != null)
            {
               do
            {
                i=i.prox;
                    if (DateTime.Today > i.revisão.AddYears(1))
                    {
                        System.Console.WriteLine("-----Documentos Vencidos-----\n");
                        System.Console.WriteLine("[VENCIDO]");
                        i.ToString();
                    }
            }while(i.prox!=null);
                System.Console.WriteLine($"\nAperte ENTER para voltar");
                Console.ReadKey(); 
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine(" ERRO: Não existem elementos presentes na lista atual\n Insira mais elementos no menu para imprimir elementos.\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }

        }

        public void Atualizar(string index)
        {
                elemento i=primeiro;

                if (i.prox != null)
                {
                   do
                {
                    i=i.prox;
                    if(index == i.Index.ToString())
                        {
                            i.revisão = DateTime.Now;
                            
                            System.Console.WriteLine("> Documento atualizado com êxito!");
                            break;  
                        }    
                }while(i.prox!=null);

                    System.Console.WriteLine($"\nAperte ENTER para voltar");
                    Console.ReadKey(); 
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("ERRO: Não existem elementos presentes na lista atual\n Insira mais elementos no menu para imprimir elementos.\n Aperte ENTER para continuar...");
                    Console.ReadLine();
                }  
            
        }
    }
}
