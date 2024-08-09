using System;

namespace Biblioteca;

public class LivroEmprestadoInfo
{
    public Livro Livro { get; private set; }
    public DateTime? DataDevolucao { get; private set; }

    public LivroEmprestadoInfo(Livro livro)
    {
        if (livro == null)
            throw new ArgumentNullException(nameof(livro), "O livro não pode ser nulo.");

        Livro = livro;
    }

    public void RegistrarDevolucao(DateTime dataDevolucao, DateTime dataEmprestimo)
    {
        if (dataDevolucao < dataEmprestimo)
            throw new ArgumentException("A data de devolução não pode ser anterior à data de empréstimo.", nameof(dataDevolucao));

        DataDevolucao = dataDevolucao;
    }

    public bool FoiDevolvido => DataDevolucao != null;
}