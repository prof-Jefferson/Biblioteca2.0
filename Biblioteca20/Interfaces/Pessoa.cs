using System;

namespace Biblioteca;

public abstract class Pessoa : IPessoa
{
    // Properties with public getters and private setters for better encapsulation.
    // Propriedades com getters públicos e setters privados para melhor encapsulamento.
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }

    // Constructor to initialize properties.
    //Construtor para inicializar propriedades.
    protected Pessoa(string nome, DateTime dataNascimento)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentException("O nome não pode ser nulo ou vazio.", nameof(nome));

        Nome = nome;
        DataNascimento = dataNascimento;
    }

    // Method with exception handling.
    // Método com tratamento de exceção.
    public virtual void ExibirInformacoes()
    {
        try
        {
            if (Nome == null || DataNascimento == default)
            {
                throw new InvalidOperationException("As informações da pessoa estão incompletas.");
            }

            Console.WriteLine($"Nome: {Nome}\nData de Nascimento: {DataNascimento.ToShortDateString()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao exibir as informações: {ex.Message}");
            // Re-throwing the exception if necessary:
            // throw;
            // Lançando novamente a exceção, se necessário:
            // trou;
        }
    }
}