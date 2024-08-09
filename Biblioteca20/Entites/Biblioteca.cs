using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Biblioteca
    {
        // Propriedades com encapsulamento
        public List<Cliente> Clientes { get; private set; } = new List<Cliente>();
        public List<Livro> Livros { get; private set; } = new List<Livro>();
        public List<Emprestimo> Emprestimos { get; private set; } = new List<Emprestimo>();

        private readonly EmprestimoService _emprestimoService;
        private readonly RepositorioBiblioteca _repositorio;

        public Biblioteca()
        {
            _emprestimoService = new EmprestimoService(this);
            _repositorio = new RepositorioBiblioteca(this);
        }

        public void EmprestarLivro(int idCliente, int idLivro)
        {
            try
            {
                _emprestimoService.EmprestarLivro(idCliente, idLivro);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao tentar emprestar o livro: {ex.Message}");
            }
        }

        public void DevolverLivro(int idCliente, int idLivro)
        {
            try
            {
                _emprestimoService.DevolverLivro(idCliente, idLivro);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao tentar devolver o livro: {ex.Message}");
            }
        }

        public void SalvarDados()
        {
            _repositorio.SalvarDados();
        }

        public void CarregarDados()
        {
            _repositorio.CarregarDados();
        }
    }
}
