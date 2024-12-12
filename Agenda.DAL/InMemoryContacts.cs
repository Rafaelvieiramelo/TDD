using Agenda.Domain;

namespace Agenda.DAL
{
    public class InMemoryContacts : IContacts
    {
        private List<contact> _contacts = new List<contact>();

        public async Task<string> InsertContact(contact contact)
        {
            _contacts.Add(contact);

            return $"Contato {contact.Nome} cadastrado com sucesso";
        }

        public contact GetContactByCpf(contact contact)
        {
            return _contacts.FirstOrDefault(c => c.Cpf == contact.Cpf);
        }

        public List<contact> GetContacts()
        {
            return _contacts;
        }
    }
}
