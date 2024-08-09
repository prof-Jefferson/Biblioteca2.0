using System.IO;
using Newtonsoft.Json;

namespace Biblioteca;

public class RepositorioBiblioteca
{
    private readonly Biblioteca _biblioteca;

    public RepositorioBiblioteca(Biblioteca biblioteca)
    {
        _biblioteca = biblioteca;
    }

    public void SalvarDados()
    {
        File.WriteAllText("clientes.json", JsonConvert.SerializeObject(_biblioteca.Clientes));
        File.WriteAllText("livros.json", JsonConvert.SerializeObject(_biblioteca.Livros));
        File.WriteAllText("emprestimos.json", JsonConvert.SerializeObject(_biblioteca.Emprestimos));
    }

    public void CarregarDados()
    {
        if (File.Exists("clientes.json"))
        {
            _biblioteca.Clientes = JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText("clientes.json"));
        }

        if (File.Exists("livros.json"))
        {
            _biblioteca.Livros = JsonConvert.DeserializeObject<List<Livro>>(File.ReadAllText("livros.json"));
        }

        if (File.Exists("emprestimos.json"))
        {
            _biblioteca.Emprestimos = JsonConvert.DeserializeObject<List<Emprestimo>>(File.ReadAllText("emprestimos.json"));
        }
    }
}

