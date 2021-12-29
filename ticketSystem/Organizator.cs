using System.Data.SqlClient;

namespace ticketSystem
{
    class Organizator
    {
        private int user_id;
        SqlDataReader dataReader;
        SqlConnection connection = new SqlConnection(connectionStaticStrings.connectionstr);
        SqlCommand command;
        public void addNewEvent(int category_id, string event_name, int place_id, string date, string time, int tickets_count, bool event_status) //Добавление нового события
        {
            int max_id = 0;
            command = connection.CreateCommand();
            command.CommandText = $"USE ticketSystem SELECT MAX(event_id) FROM Event";
            connection.Open();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                max_id = (int)dataReader.GetValue(0);
            }
            if (max_id == null)
                max_id = 0;
            dataReader.Close();
            command.CommandText = $"USE ticketSystem INSERT INTO Event VALUES ({max_id + 1}, {category_id}, '{event_name}', {place_id}, '{date}', '{time}', {tickets_count}, {event_status})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void updateEventInfo(int event_id, int category_id, string event_name, int place_id, string date, string time, int tickets_count, bool event_status) //Изменение данных существующего события
        {
            command = connection.CreateCommand();
            connection.Open();
            command.CommandText = $"USE ticketSystem UPDATE Event SET category_id = {category_id}, event_name = {event_name}, place_id = {place_id}, date = {date}, time = {time}, tickets_count = {tickets_count}, event_status = {event_status},  WHERE event_id = {event_id}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void getEventInfo(int event_id) //Получение данных существующего события
        {
            command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Event WHERE event_id = {event_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void deleteEvent(int event_id) //Удаление существующего события
        {
            command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Event WHERE event_id = {event_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
            //
        }
        public void createTicketsForEvent(int event_id, string ticket_category) //Сгененерировать билеты для события
        {
            int max_id = 0, ticketsCount = 0;
            command = connection.CreateCommand();
            command.CommandText = $"SELECT tickets_count FROM Event WHERE event_id = {event_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                ticketsCount = (int)dataReader.GetValue(0);
            dataReader.Close();


            command = connection.CreateCommand();
            command.CommandText = $"USE ticketSystem SELECT MAX(ticket_id) FROM Tickets";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                max_id = (int)dataReader.GetValue(0) + 1;
            dataReader.Close();



            for (int i = max_id; i < ticketsCount + max_id; i++)
            {
                command = connection.CreateCommand();
                command.CommandText = $"USE ticketSystem INSERT INTO Tickets VALUES ({i}, {event_id}, null, null, {ticket_category})";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    max_id = (int)dataReader.GetValue(0);
                dataReader.Close();
            }
            connection.Close();
        }
        public void updateTicketInfo(int ticket_id, int event_id, int row, int seat, string ticket_category) //Изменение данных существующем билете
        {
            command = connection.CreateCommand();
            connection.Open();
            command.CommandText = $"USE ticketSystem UPDATE Tickets SET event_id = {event_id}, row = {row}, seat = {seat}, ticket_category = {ticket_category} WHERE ticket_id = {ticket_id}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void getTicketInfo(int ticket_id) //Изменение данных существующей роли
        {
            command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Tickets WHERE ticket_id = {ticket_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void deleteTicket(int ticket_id) //Удаление существующей роли
        {
            command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Tickets WHERE role_id = {ticket_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
    }
}
