using System.Text;

namespace SCgrc
{
    public class lista
    {
        private elemento primeiro{get;set;}
        private elemento ultimo{get;set;}
        


        //Construtor: Automatizar.
        public lista()
        {
            primeiro=ultimo=new elemento();
        }

        //Inserir novo elemento no final da lista.
        public void InserirFim(elemento x)
        {
            ultimo.prox=x;
            ultimo=ultimo.prox;
        }

        //Ler todo mundo.
        public void ImprimirTodos()
        {
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

        //REMOVER ELEMENTO
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

        public void Salvar()
        {
            string path= "data/save.csv";
            StringBuilder saída = new StringBuilder();

            elemento i = primeiro.prox;

            while(i!=null)
            {
                saída.Append($"{i.Index},");
                saída.Append($"{i.nome},");
                saída.Append($"{i.id}");
                saída.Append('\n');

                
                i=i.prox;

            }
            File.Delete(path);
            File.AppendAllText(path, saída.ToString());
        }

        public void LimparDados()
        {
            primeiro.prox= ultimo;
            ultimo=null;
        }

        //Corrigir ordem de Index.
        public void CorrigeIndex(elemento noInicio)
        {
            elemento i = noInicio;
            while (i != null)
            {
                i.Index--;
                i = i.prox;
            }
        }
        
        //Contar elementos.
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
    }
}
