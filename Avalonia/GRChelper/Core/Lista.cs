using System;

namespace GRChelper.Core;

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

    //3. Contar a quantidade de elementos já existentes;
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

    //4. Atualizar data por nome
    public void Atualizar(string busca)
        {
            elemento i = primeiro.prox;
            while (i != null)
            {
                AtualizarResult(i, busca);
                i = i.prox;
            }
        }

    public void AtualizarResult(elemento MyElemento,string MyString)
    {
        if(MyElemento.nome == MyString)
        {
            MyElemento.revisão = DateTime.Now;
        }
    }

    
}