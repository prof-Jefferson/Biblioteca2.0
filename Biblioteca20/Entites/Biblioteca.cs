using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Biblioteca
{
	public class Biblioteca
	{
		public List<Cliente> clientes = new List<Cliente>();
		public List<Livro> livros = new List<Livro>();
		public List<Emprestimo> emprestimos = new List<Emprestimo>();
		
		public void EmprestarLivro(int idCliente, int idLivro)
		{
			try
			{
				Livro livro = livros.Find(l => l.Id == idLivro && l.Disponivel == true);
							
				if (livro == null)
				{
					Console.WriteLine("Livro não encontrado ou indisponível.");
					return;
				}
				
				Cliente cliente = clientes.Find(c => c.Id == idCliente);
				
				if (cliente == null)
				{
					Console.WriteLine("Cliente não encontrado.");
					return;
				}			
				
				Emprestimo emprestimo = new Emprestimo			
				{
					Id = emprestimos.Count + 1,
					ClienteEmprestimo = cliente,
					LivroEmprestado = livro,
					DataEmprestimo = DateTime.Today,
					DataDevolucaoPrevista = DateTime.Today.AddDays(7)								
				};
				
				livro.Disponivel = false;
				emprestimos.Add(emprestimo);
				
				Console.WriteLine("Livro emprestado com sucesso!");
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
				Livro livro = livros.Find(l => l.Id == idLivro);
				
				if (livro == null)
				{
					Console.WriteLine("Livro não encontrado");
					return;
				}
				
				Emprestimo emprestimo = emprestimos.Find(e => e.ClienteEmprestimo.Id == idCliente 
				&& e.LivroEmprestado.Id == idLivro);
				
				if (emprestimo == null)
				{
					Console.WriteLine("Cliente não encontrado");
					return;
				}
				
				emprestimo.LivroEmprestado.Disponivel = true;
				emprestimo.DataDevolucao = DateTime.Today;
				
				Console.WriteLine("Livro devolvido com sucesso!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ocorreu um erro ao tentar devolver o livro: {ex.Message}");
			}
		}
		
		public void SalvarDados()
		{
			File.WriteAllText("clientes.json", JsonConvert.SerializeObject(clientes));
			File.WriteAllText("livros.json", JsonConvert.SerializeObject(livros));
			File.WriteAllText("emprestimos.json", JsonConvert.SerializeObject(emprestimos));
		}
		
		public void CarregarDados()
		{
			if (File.Exists("clientes.json"))
			{
				clientes = JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText("clientes.json"));				
			}
			
			if (File.Exists("livros.json"))
			{
				livros = JsonConvert.DeserializeObject<List<Livro>>(File.ReadAllText("livros.json"));
			}
			
			if (File.Exists("emprestimos.json"))
			{
				emprestimos = JsonConvert.DeserializeObject<List<Emprestimo>>(File.ReadAllText("emprestimos.json"));
			}
		}
	
	}
}