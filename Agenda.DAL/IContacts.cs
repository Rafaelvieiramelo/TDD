using Agenda.Domain;

namespace Agenda.DAL
{
    public interface IContacts
    {
        Task<string> InsertContact(contact contact);
        contact GetContactByCpf(contact contact);
        List<contact> GetContacts();
    }
}