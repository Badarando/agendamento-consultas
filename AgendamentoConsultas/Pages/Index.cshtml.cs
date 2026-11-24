
using AgendamentoConsultas.Models;
using AgendamentoConsultas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AgendamentoConsultas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PacienteService _pacienteService;

        public IndexModel(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [BindProperty]
        public DadosCadastro NovoPaciente { get; set; } = new();

        public List<Paciente> Pacientes { get; set; } = new();

        public class DadosCadastro
        {
            [Required(ErrorMessage = "Informe o nome completo.")]
            public string NomeCompleto { get; set; } = "";

            [Required(ErrorMessage = "Informe o e-mail.")]
            [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
            public string Email { get; set; } = "";

            public string? Telefone { get; set; }

            [DataType(DataType.Date)]
            public DateOnly? DataNascimento { get; set; }
        }

        public void OnGet()
        {
            Pacientes = _pacienteService.ListarTodos();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Pacientes = _pacienteService.ListarTodos();
                return Page();
            }

            var paciente = new Paciente
            {
                NomeCompleto = NovoPaciente.NomeCompleto,
                Email = NovoPaciente.Email,
                Telefone = NovoPaciente.Telefone,
                DataNascimento = NovoPaciente.DataNascimento
            };

            _pacienteService.Cadastrar(paciente);

            TempData["Mensagem"] = "Paciente cadastrado com sucesso!";

            return RedirectToPage();
        }
    }
}
