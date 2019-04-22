using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Diplom_1
{
    class SQL
    {
        int status_cod;
        public string Name { get; set; }
        public string Roly { get; set; }
        string Sql = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
        public int go_in(string Login, string Password)
        {
            SqlConnection conn = new SqlConnection(Sql);
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from Users", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while(reader.Read())
            {
                if(Login == reader["Логин"].ToString() && Password == reader["Пароль"].ToString())
                {
                    Name = reader["Имя"].ToString();
                    Roly = reader["Роль"].ToString();
                    status_cod = 1;
                    break;
                }
                else
                {
                    status_cod = 01;
                }
            }

            return status_cod;
        }
        public void cookie_(string Login, string Password, string Roly_, string Name_)
        {
            SqlConnection conn = new SqlConnection(Sql);
            conn.Open();
            SqlCommand comm = new SqlCommand("insert into Cookie(ПК, Пользователь_ПК, Логин, Пароль, Имя, Роль) values ('" + Environment.MachineName + "', '" + Environment.UserName + "', '" + Login + "', '" + Password + "', '" + Name_ + "', '" + Roly_ + "')", conn);
            int num = comm.ExecuteNonQuery();
        }

        public int Register_user(string[] Data)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                SqlCommand comm = new SqlCommand("insert into Users(Логин, Пароль, Имя, Роль) values('" + Data[0] + "','" + Data[2] + "','" + Data[1] + "','" + Data[3] + "')", conn);
                int num = comm.ExecuteNonQuery();
                return num;
            }
            catch(SqlException)
            {
                int num = 0;
                return num;
            }
        }

    }
}