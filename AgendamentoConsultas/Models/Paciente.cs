namespace AgendamentoConsultas.Models
{
    public class Paciente
    {
        public Guid IdPaciente { get; set; } = Guid.NewGuid();
        public string NomeCompleto { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Telefone { get; set; }
        public DateOnly? DataNascimento { get; set; }

    }
}
