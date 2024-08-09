using System;

namespace Biblioteca
{
    public class ClienteEmprestimoInfo
    {
        public Cliente Cliente { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucaoPrevista { get; private set; }

        public ClienteEmprestimoInfo(Cliente cliente, DateTime dataEmprestimo, DateTime dataDevolucaoPrevista)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");

            if (dataEmprestimo > DateTime.Now)
                throw new ArgumentException("A data de empréstimo não pode ser no futuro.", nameof(dataEmprestimo));

            if (dataDevolucaoPrevista <= dataEmprestimo)
                throw new ArgumentException("A data de devolução prevista deve ser posterior à data de empréstimo.", nameof(dataDevolucaoPrevista));

            Cliente = cliente;
            DataEmprestimo = dataEmprestimo;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
        }
    }
}
