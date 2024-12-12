using System.Data.SQLite;
using System.Data;
using Agenda.Domain;
using Microsoft.Extensions.Configuration;

namespace Agenda.DAL
{
    public class Contacts : IContacts
    {
        protected readonly string _strCon;
        protected readonly SQLiteConnection _conn;

        public Contacts()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            _strCon = configuration.GetConnectionString("con");

            _conn = new(_strCon);
        }

        public async Task<string> InsertContact(contact contact)
        {
            //teste pipeline
            var contactExisting = GetContactByCpf(contact);

            if (contactExisting != null)
                return $"Contato {contact.Nome} Já foi cadastrado anteriorment";

            await _conn.OpenAsync();

            var query = $"INSERT INTO Contato (Nome, Cpf, Telefone) VALUES ('{contact.Nome}','{contact.Cpf}', '{contact.Telefone}')";
            var data = new SQLiteDataAdapter(query, _conn);
            data.Fill(new DataTable());

            await _conn.CloseAsync();

            return $"Contato {contact.Nome} cadastrado com sucesso";
        }

        public contact GetContactByCpf(contact contato)
        {
            _conn.Open();

            var sql = $"Select * from Contato where cpf ='{contato.Cpf}'";
            var cmd = new SQLiteCommand(sql, _conn);

            var sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();

            var contatoNovo = new contact
            {
                Nome = sqlDataReader["Nome"].ToString(),
                Cpf = sqlDataReader["Cpf"].ToString(),
                Telefone = sqlDataReader["Telefone"].ToString()
            };

            _conn.Close();

            return contatoNovo;
        }

        public List<contact> GetContacts()
        {
            _conn.Open();

            var sql = $"Select * from Contato";
            var cmd = new SQLiteCommand(sql, _conn);

            var sqlDataReader = cmd.ExecuteReader();

            var contactsList = new List<contact>();

            while (sqlDataReader.Read())
            {
                var contact = new contact
                {
                    Nome = sqlDataReader["Nome"].ToString(),
                    Cpf = sqlDataReader["Cpf"].ToString(),
                    Telefone = sqlDataReader["Telefone"].ToString()
                };

                contactsList.Add(contact);
            }

            _conn.Close();

            return contactsList;
        }
    }
}
