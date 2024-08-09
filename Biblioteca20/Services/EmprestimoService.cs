using System;
using System.Linq;

namespace Biblioteca;

public class EmprestimoService
{
    private readonly Biblioteca _biblioteca;

    public EmprestimoService(Biblioteca biblioteca)
    {
        _biblioteca = biblioteca;
    }

    public void EmprestarLivro(int idCliente, int idLivro)
    {
        Livro livro = EncontrarLivroDisponivel(idLivro);
        Cliente cliente = EncontrarCliente(idCliente);

        Emprestimo emprestimo = new Emprestimo
        {
            Id = _biblioteca.Emprestimos.Count + 1,
            ClienteEmprestimo = cliente,
            LivroEmprestado = livro,
            DataEmprestimo = DateTime.Today,
            DataDevolucaoPrevista = DateTime.Today.AddDays(7)
        };

        livro.Disponivel = false;
        _biblioteca.Emprestimos.Add(emprestimo);

        Console.WriteLine("Livro emprestado com sucesso!");
    }

    public void DevolverLivro(int idCliente, int idLivro)
    {
        Emprestimo emprestimo = EncontrarEmprestimo(idCliente, idLivro);

        emprestimo.LivroEmprestado.Disponivel = true;
        emprestimo.DataDevolucao = DateTime.Today;

        Console.WriteLine("Livro devolvido com sucesso!");
    }

    private Livro EncontrarLivroDisponivel(int idLivro)
    {
        Livro livro = _biblioteca.Livros.FirstOrDefault(l => l.Id == idLivro && l.Disponivel);
        if (livro == null)
        {
            throw new Exception("Livro não encontrado ou indisponível.");
        }
        return livro;
    }

    private Cliente EncontrarCliente(int idCliente)
    {
        Cliente cliente = _biblioteca.Clientes.FirstOrDefault(c => c.Id == idCliente);
        if (cliente == null)
        {
            throw new Exception("Cliente não encontrado.");
        }
        return cliente;
    }

    private Emprestimo EncontrarEmprestimo(int idCliente, int idLivro)
    {
        Emprestimo emprestimo = _biblioteca.Emprestimos.FirstOrDefault(e => e.ClienteEmprestimo.Id == idCliente && e.LivroEmprestado.Id == idLivro);
        if (emprestimo == null)
        {
            throw new Exception("Empréstimo não encontrado.");
        }
        return emprestimo;
    }
}