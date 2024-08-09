using System;

namespace Biblioteca
{
    public class Cliente : Pessoa
    {
        // Propriedades com getters públicos e setters privados para melhor encapsulamento
        public int Id { get; private set; }
        public string Telefone { get; private set; }

        // Construtor que inicializa as propriedades da classe base e as específicas de Cliente
        public Cliente(int id, string nome, DateTime dataNascimento, string telefone)
            : base(nome, dataNascimento)
        {
            if (string.IsNullOrEmpty(telefone))
                throw new ArgumentException("O telefone não pode ser nulo ou vazio.", nameof(telefone));

            Id = id;
            Telefone = telefone;
        }

        // Sobrescrevendo o método ExibirInformacoes para incluir os detalhes do Cliente
        public override void ExibirInformacoes()
        {
            // Chama o método da classe base para exibir as informações básicas
            base.ExibirInformacoes();

            // Adiciona informações específicas do cliente
            Console.WriteLine($"ID: {Id}\nTelefone: {Telefone}");
        }
    }
}
