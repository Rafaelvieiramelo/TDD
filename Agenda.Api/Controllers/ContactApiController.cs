using Microsoft.AspNetCore.Mvc;
using Agenda.DAL;
using Agenda.Domain;

namespace Agenda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactApiController : ControllerBase
    {
        private readonly ILogger<ContactApiController> _logger;
        private readonly Contacts Contatos = new();

        public ContactApiController(ILogger<ContactApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetByCpf")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var contato = new contact
            {
                Cpf = cpf
            };

            try
            {
                var Contact = Contatos.GetContactByCpf(contato);
                return Ok(Contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("InsertContact")]
        public async Task<IActionResult> InsertContact(contact contact)
        {
            try
            {
                var mensagem = await Contatos.InsertContact(contact);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao inserir o contato {contact.Nome}: {ex}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Contact = Contatos.GetContacts();
                return Ok(Contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
