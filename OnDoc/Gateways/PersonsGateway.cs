using OnDoc.Entities;
using System.Data.SqlClient;

namespace OnDoc.Gateways
{
    public class PersonsGateway
    {
        private readonly string _connectionString;

        public PersonsGateway()
        {
            _connectionString = @"Data Source=localhost;Initial Catalog=onDoc;Integrated Security=True";
        }

        public async Task<int> AddAccount(ACCOUNTS entity)
        {
            string sqlExpression = string.Format("INSERT INTO onDoc.dbo.ACCOUNTS VALUES({0}, {1}, {2}, {3}, {4})"
               , entity.Code, entity.DocEntry, entity.Name, entity.Login, entity.PASSWORD);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                return number;
            }
        }

        public async Task<ACCOUNTS> GetAccount(string code)
        {
            string sqlExpression = "SELECT * FROM ACCOUNTS WHERE Code = " + code;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                var res = new ACCOUNTS();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        res.Code = reader.GetString(0);
                        res.DocEntry = reader.GetString(1);
                        res.Name = reader.GetString(2);
                        res.Login= reader.GetString(3);
                        res.PASSWORD= reader.GetString(4);
                    }
                }
                else
                {
                    throw new Exception("ERROR. CODE 52-97Y");
                }
                reader.Close();

                return res;
            }
        }

        public async Task<int> AddPacient(PACIENT_INFO entity)
        {
            string sqlExpression = string.Format("INSERT INTO onDoc.dbo.PACIENT_INFO VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})"
                , entity.Code, entity.DocEntry, entity.Name, entity.FirstName, entity.LastName, entity.AGE, entity.ADDRESS
                , entity.DIAGNOSIS);

            var account = new ACCOUNTS();
            try
            {
                account = await GetAccount(entity.Code);
            }
            catch(Exception ex)
            {
                throw new Exception("ERROR. CODE 84-27E");
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                return number;
            }
        }

        public async Task<int> AddExecutor(EXECUTOR entity)
        {
            string sqlExpression = string.Format("INSERT INTO onDoc.dbo.EXECUTOR VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})"
                , entity.Code, entity.DocEntry, entity.Name, entity.FirstName, entity.LastName, entity.AGE, entity.Professional_level
                , entity.Education_level);

            var account = new ACCOUNTS();
            try
            {
                account = await GetAccount(entity.Code);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR. CODE 84-27E");
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                return number;
            }
        }
    }
}
