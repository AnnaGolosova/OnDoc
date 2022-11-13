using OnDoc.Entities;
using System.Data.SqlClient;

namespace OnDoc.Gateways
{
    public class MriGateway
    {
        private readonly string _connectionString;
        public MriGateway()
        {
            _connectionString = @"Data Source=localhost;Initial Catalog=onDoc;Integrated Security=True";
        }

        public async Task<int> AddMRI(MRI entity)
        {
            string sqlExpression = string.Format("INSERT INTO onDoc.dbo.MRI VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})"
                , entity.Code, entity.DocEntry, entity.Name, entity.Date, entity.Time, entity.Status, entity.Cognates, entity.ServiceCost, entity.Duration, entity.Patient
                , entity.MODIF, entity.Resp);

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
