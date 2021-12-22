﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticketSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection();

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.ConnectionString = connectionStaticStrings.connectionstr;
            try
            {
                connection.Open();
                MessageBox.Show("Связь с сервером установлена");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 17: MessageBox.Show("Ошибка", "Неверное имя сервера!", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    case 4060: MessageBox.Show("Ошибка", "Неверное имя БД!", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    case 18456: MessageBox.Show("Ошибка", "Неверное имя пользователя или пароль!", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                }
                MessageBox.Show(ex.Message + " Уровень ошибки " + ex.Class); return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
