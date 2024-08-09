using System;

namespace Biblioteca
{
    public class Emprestimo
    {
        // Propriedades com encapsulamento apropriado (getters públicos e setters privados)
        public int Id { get; private set; }
        public Cliente ClienteEmprestimo { get; private set; }
        public Livro LivroEmprestado { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucaoPrevista { get; private set; }
        public DateTime? DataDevolucao { get; private set; } // Aceita nulo

        // Propriedade calculada para verificar se o livro foi devolvido
        public bool Devolvido => DataDevolucao != null;

        // Construtor para garantir que o empréstimo seja criado com todos os dados necessários
        public Emprestimo(int id, Cliente cliente, Livro livro, DateTime dataEmprestimo, DateTime dataDevolucaoPrevista)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
            
            if (livro == null)
                throw new ArgumentNullException(nameof(livro), "O livro não pode ser nulo.");
            
            if (dataEmprestimo > DateTime.Now)
                throw new ArgumentException("A data de empréstimo não pode ser no futuro.", nameof(dataEmprestimo));

            if (dataDevolucaoPrevista <= dataEmprestimo)
                throw new ArgumentException("A data de devolução prevista deve ser posterior à data de empréstimo.", nameof(dataDevolucaoPrevista));

            Id = id;
            ClienteEmprestimo = cliente;
            LivroEmprestado = livro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
        }

        // Método para registrar a devolução do livro
        public void RegistrarDevolucao(DateTime dataDevolucao)
        {
            if (dataDevolucao < DataEmprestimo)
                throw new ArgumentException("A data de devolução não pode ser anterior à data de empréstimo.", nameof(dataDevolucao));

            DataDevolucao = dataDevolucao;
        }

        // Método para calcular multas ou outras ações, se necessário
        public decimal CalcularMulta(decimal valorPorDia)
        {
            if (!Devolvido || DataDevolucao <= DataDevolucaoPrevista)
                return 0m;

            TimeSpan diasAtraso = DataDevolucao.Value - DataDevolucaoPrevista;
            return diasAtraso.Days * valorPorDia;
        }
    }
}
