using OnDoc.Entities;
using System.Data.SqlClient;

namespace OnDoc.Gateways
{
    public class MachinesGateway
    {
        private readonly string _connectionString;
        public MachinesGateway()
        {
            _connectionString = @"Data Source=localhost;Initial Catalog=onDoc;Integrated Security=True";
        }

        public async Task<int> AddMachine(Machines entity)
        {
            string sqlExpression = string.Format("INSERT INTO onDoc.dbo.Machines VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6})"
               , entity.Code, entity.DocEntry, entity.Name, entity.Resp, entity.Release_Year, entity.Power);

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
