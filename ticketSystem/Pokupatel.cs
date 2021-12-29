using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketSystem
{
    class Pokupatel
    {
        SqlDataReader dataReader;
        SqlConnection connection = new SqlConnection(connectionStaticStrings.connectionstr);
        SqlCommand command;
        public void createOrder(int ticket_id, float discount, int cost, string date, string time)
        {
            int max_id = 0;
            command = connection.CreateCommand();
            command.CommandText = $"USE ticketSystem SELECT MAX(order_id) FROM Order";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                max_id = (int)dataReader.GetValue(0) + 1;
            dataReader.Close();

            command = connection.CreateCommand();
            command.CommandText = $"USE ticketSystem INSERT INTO Order VALUES ({max_id}, {ticket_id}, {discount}, {cost}, '{date}', '{time}')";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                max_id = (int)dataReader.GetValue(0);
            dataReader.Close();
            connection.Close();
        }
    }
}
