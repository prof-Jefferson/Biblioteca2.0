using System;

namespace Biblioteca
{
    public class Funcionario : Pessoa
    {
        // Propriedades com getters públicos e setters privados para melhor encapsulamento
        public int Id { get; private set; }
        public string Cargo { get; private set; }
        public DateTime DataAdmissao { get; private set; }

        // Construtor que inicializa as propriedades da classe base e as específicas de Funcionario
        public Funcionario(int id, string nome, DateTime dataNascimento, string cargo, DateTime dataAdmissao)
            : base(nome, dataNascimento)
        {
            if (string.IsNullOrEmpty(cargo))
                throw new ArgumentException("O cargo não pode ser nulo ou vazio.", nameof(cargo));
            
            if (dataAdmissao > DateTime.Now)
                throw new ArgumentException("A data de admissão não pode ser no futuro.", nameof(dataAdmissao));
            
            Id = id;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
        }

        // Sobrescrevendo o método ExibirInformacoes para incluir os detalhes do Funcionario
        public override void ExibirInformacoes()
        {
            // Chama o método da classe base para exibir as informações básicas
            base.ExibirInformacoes();
            
            // Adiciona informações específicas do funcionário
            Console.WriteLine($"ID: {Id}\nCargo: {Cargo}\nData de Admissão: {DataAdmissao.ToShortDateString()}");
        }
    }
}
