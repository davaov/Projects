using System.Data.SqlClient;

namespace ticketSystem
{
    public class Admin
    {
        private int user_id;
        SqlDataReader dataReader;
        SqlConnection connection = new SqlConnection(connectionStaticStrings.connectionstr);
        SqlCommand command;
        public void addNewUser(string log, string pas, int role_id) //Добавление нового пользователя
        {
            int max_id = 0;
            command = connection.CreateCommand();
            command.CommandText = $"USE ticketSystem SELECT MAX(user_id) FROM Users";
            connection.Open();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                max_id = (int)dataReader.GetValue(0);
            }
            dataReader.Close();
            command.CommandText = $"USE ticketSystem INSERT INTO Users VALUES ({max_id + 1}, '{log}', '{pas}', {role_id})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }

        public void updateUserInfo(int user_id, string log, string pas, int role_id) //Изменение данных существующего пользователя
        {
            command = connection.CreateCommand();
            connection.Open();
            command.CommandText = $"USE ticketSystem UPDATE Users SET login = {log}, password = {pas}, role_id = {role_id}  WHERE user_id = {user_id}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }

        public void getUserInfo(int user_id) //Получение данных существующего пользователя
        {
            command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Users WHERE user_id = {user_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void deleteUser(int user_id) //Удаление существующего пользователя
        {
            command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Users WHERE user_id = {user_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
            //
        }
        public void addNewRole(string role_name) //Добавление новой роли
        {
            int max_id = 0;
            command = connection.CreateCommand();
            command.CommandText = $"USE ticketSystem SELECT MAX(role_id) FROM Roles";
            connection.Open();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                max_id = (int)dataReader.GetValue(0);
            }
            dataReader.Close();
            command.CommandText = $"USE ticketSystem INSERT INTO Roles VALUES ({max_id + 1}, '{role_name}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void updateRoleInfo(int role_id, string role_name) //Изменение данных существующей роли
        {
            command = connection.CreateCommand();
            connection.Open();
            command.CommandText = $"USE ticketSystem UPDATE Roles SET role_name = {role_name} WHERE role_id = {role_id}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void getRoleInfo(int role_id) //Изменение данных существующей роли
        {
            command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Roles WHERE role_id = {role_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
        public void deleteRole(int role_id) //Удаление существующей роли
        {
            command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Roles WHERE role_id = {role_id}";
            connection.Open();
            dataReader = command.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }
    }
}
