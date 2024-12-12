using NUnit.Framework;
using Agenda.Domain;
using NUnit.Framework.Legacy;

namespace Agenda.DAL.Test
    
{
    [TestFixture]
    public class ContatctsTest
    {
        InMemoryContacts _contacts;

        [SetUp]
        public void Setup()
        {
            var inMemoryRepository = new InMemoryContacts();
            _contacts = new InMemoryContacts();
        }

        [Test]
        public void InsertContactTest()
        {
            var contatct = new contact()
            {
                Nome = "Rafael Melo",
                Cpf = "12345678901",
                Telefone = "11999999999"
            };

            _contacts.InsertContact(contatct);

            ClassicAssert.True(true);
        }

        [Test]
        public void GetContactByCpfTest()
        {
            var contact = new contact()
            {   
                Cpf = "12345678901",
                Nome = "Rafael Melo",
                Telefone = "11999999999"
            };

            _contacts.InsertContact(contact);

            var contactReturn = _contacts.GetContactByCpf(contact);

            ClassicAssert.Null(contactReturn);
            ClassicAssert.AreEqual(contact.Cpf, contactReturn.Cpf);
            ClassicAssert.AreEqual(contact.Nome, contactReturn.Nome);
            ClassicAssert.AreEqual(contact.Telefone, contactReturn.Telefone);
        }
                
        [Test]
        public void GetContacts()
        {
            var contactsReturn = _contacts.GetContacts();

            foreach (var contact in contactsReturn)
            {
                ClassicAssert.NotNull(contact.Cpf);
                ClassicAssert.NotNull(contact.Nome);
            }
        }

        [TearDown]
        public void TearDown()
        {
            _contacts = null;
        }
    }
}
