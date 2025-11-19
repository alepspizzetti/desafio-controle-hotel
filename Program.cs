using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

Console.WriteLine("=== Teste desconto (>=10 dias) ===");
var hospedes2 = new List<Pessoa> { new Pessoa("Hóspede 1"), new Pessoa("Hóspede 2") };
var suite2 = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
var reserva2 = new Reserva(diasReservados: 10);
reserva2.CadastrarSuite(suite2);
reserva2.CadastrarHospedes(hospedes2);
Console.WriteLine($"Hóspedes: {reserva2.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva2.CalcularValorDiaria()}");

Console.WriteLine("=== Teste capacidade insuficiente ===");
try
{
    var hospedes3 = new List<Pessoa> { new Pessoa("H1"), new Pessoa("H2"), new Pessoa("H3") };
    var suite3 = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
    var reserva3 = new Reserva(diasReservados: 5);
    reserva3.CadastrarSuite(suite3);
    reserva3.CadastrarHospedes(hospedes3);
    Console.WriteLine("[ERRO] Exceção não lançada para capacidade insuficiente");
}
catch (System.Exception ex)
{
    Console.WriteLine($"Exceção lançada conforme esperado: {ex.GetType().Name}");
}