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

            do
            {
                i=i.prox;
                i.ToString();

            }while(i.prox!=null);
                System.Console.WriteLine($"\nAperte ENTER para voltar");
                Console.ReadKey();
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
