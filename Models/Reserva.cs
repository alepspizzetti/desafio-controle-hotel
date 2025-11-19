namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null || hospedes.Count == 0)
            {
                throw new System.ArgumentException("A lista de hóspedes não pode ser nula ou vazia.", nameof(hospedes));
            }

            if (Suite == null)
            {
                throw new System.InvalidOperationException("Nenhuma suíte cadastrada. Cadastre a suíte antes de adicionar hóspedes.");
            }

            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new System.InvalidOperationException("Capacidade da suíte insuficiente para o número de hóspedes informado.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new System.InvalidOperationException("Nenhuma suíte cadastrada. Cadastre a suíte antes de calcular o valor da diária.");
            }

            if (DiasReservados <= 0)
            {
                throw new System.InvalidOperationException("A quantidade de dias reservados deve ser maior que zero.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;
        }
    }
}