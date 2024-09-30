using NUnit.Framework;
using Agenda.Domain;
using NUnit.Framework.Legacy;

namespace Agenda.DAL.Test
    
{
    [TestFixture]
    public class ContatctsTest
    {
        Contacts _contacts;

        [SetUp]
        public void Setup()
        {
            _contacts = new Contacts();
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
                Cpf = "37080604826",
                Nome = "Rafael Vieira de Melo"
            };

            var contactReturn = _contacts.GetContactByCpf(contact);
            ClassicAssert.AreEqual(contact.Cpf, contactReturn.Cpf);
            ClassicAssert.AreEqual(contact.Nome, contactReturn.Nome);
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
