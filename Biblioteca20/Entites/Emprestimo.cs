using System;

namespace Biblioteca;

public class Emprestimo
{
    public int Id { get; private set; }
    public ClienteEmprestimoInfo ClienteInfo { get; private set; }
    public LivroEmprestadoInfo LivroInfo { get; private set; }

    public Emprestimo(int id, ClienteEmprestimoInfo clienteInfo, LivroEmprestadoInfo livroInfo)
    {
        Id = id;
        ClienteInfo = clienteInfo ?? throw new ArgumentNullException(nameof(clienteInfo), "As informações do cliente não podem ser nulas.");
        LivroInfo = livroInfo ?? throw new ArgumentNullException(nameof(livroInfo), "As informações do livro não podem ser nulas.");
    }

    public decimal CalcularMulta(decimal valorPorDia)
    {
        if (!LivroInfo.FoiDevolvido || LivroInfo.DataDevolucao <= ClienteInfo.DataDevolucaoPrevista)
            return 0m;

        TimeSpan diasAtraso = LivroInfo.DataDevolucao.Value - ClienteInfo.DataDevolucaoPrevista;
        return diasAtraso.Days * valorPorDia;
    }
}