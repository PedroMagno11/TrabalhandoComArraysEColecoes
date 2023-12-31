using bytebank.Modelos.Conta;

namespace TrabalhandoComArraysEColecoes.ByteBank.Util;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private int _proximaPosicao = 0;

    public ListaDeContasCorrentes(int tamanhoInicial = 5)
    {
        this._itens = new ContaCorrente[tamanhoInicial];
    }

    public void Adicionar(ContaCorrente item)
    {
        Console.WriteLine($"Adicionando item na posição {this._proximaPosicao}");
        VerificarCapacidade(this._proximaPosicao + 1);
        this._itens[this._proximaPosicao] = item;
        this._proximaPosicao++;
    }

    public void Remover( ContaCorrente conta)
    {
        int indiceItem = -1;
        for(int i = 0; i<this._proximaPosicao; i++)
        {
            ContaCorrente contaAtual = this._itens[i];
            if(contaAtual == conta)
            {
                indiceItem = i;
                break;
            }
        }

        for(int i = indiceItem; i< this._proximaPosicao - 1; i++)
        {
            this._itens[i] = this._itens[i + 1];
        }
        this._proximaPosicao--;
    }
    public void ContaComMaiorSaldo()
    {
        ContaCorrente auxiliar = this._itens[0];
        for(int i = 0; i < this._itens.Length; i++)
        {
            if (this._itens[i].Saldo >= auxiliar.Saldo)
            {
                auxiliar = this._itens[i];
            }
        }

        Console.WriteLine($"A conta com maior saldo é {auxiliar.Conta} com saldo de R${auxiliar.Saldo}");
    }
    
    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if (this._itens.Length>=tamanhoNecessario)
        {
            return;
        }
        Console.WriteLine("Aumentando a capacidade da lista!");
        Array.Resize(ref this._itens, tamanhoNecessario);
    }

    public void ExibirLista()
    {
        for(int i = 0; i<this._itens.Length; i++)
        {
            if (this._itens[i] != null)
            {
                var conta = this._itens[i];
                Console.WriteLine($"Índice[{i}] = Conta:{conta.Conta} - Nº da Agência: {conta.Numero_agencia}");
            }
        }
    }

    public ContaCorrente RecuperarContaNoIndice(int indice)
    {
        if(indice < 0 || indice >= this._proximaPosicao)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
        return this._itens[indice];
    }

    public int Tamanho
    {
        get
        {
            return this._proximaPosicao;
        }
    }

    public ContaCorrente this[int indice] 
    {
        get
        {
            return this.RecuperarContaNoIndice(indice);
        }
    }
}
