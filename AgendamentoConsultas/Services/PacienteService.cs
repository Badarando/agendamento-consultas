using AgendamentoConsultas.Models;

namespace AgendamentoConsultas.Services
{
    public class PacienteService
    {
        private readonly List<Paciente> _pacientes = new();

        public void Cadastrar(Paciente paciente)
        {
            _pacientes.Add(paciente);
        }

        public List<Paciente> ListarTodos()
        {
            return _pacientes.ToList();
        }
    }
}
