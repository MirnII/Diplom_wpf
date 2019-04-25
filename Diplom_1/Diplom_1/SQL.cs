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
                    status_cod = 11;
                }
            }

            return status_cod;
        }

        public bool connect_status()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int repair_(string kat, string log, string kab)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                SqlCommand comm = new SqlCommand("Insert into repair(Категория, ПК, Логин, Дата, Кабинет, Уч_зп, Статус) values ('" + kat + "', '" + Environment.MachineName + "', '" + log + "', '" + DateTime.Now + "', '" + kab+ "', '" + Environment.UserName + "', 'Новая')", conn);
                int status = comm.ExecuteNonQuery();
                return status;
            }
            catch
            {
                int status = 0;
                return status;
            }
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

        public int zamena(string Cart, string Login, string kab)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                SqlCommand comm = new SqlCommand("insert into repair(Категория, Картридж, ПК, " +
                    "Уч_зп, Кабинет, Логин, Статус, Дата)" +
                    " values('Замена картриджа', '" + Cart + "', '" + Environment.MachineName + "', " +
                    "'" + Environment.UserName + "', '" + kab + "', '" + Login + "', 'Новая', '" + DateTime.Now + "')", conn);
                return comm.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }
        public int install(string Login, string Name, string kab)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                SqlCommand comm = new SqlCommand("insert into repair(Категория, Программа, ПК, " +
                    "Уч_зп, Кабинет, Логин, Статус, Дата)" +
                    "values('Установка программы', '" + Name + "', '" + Environment.MachineName + "', " +
                    "'" + Environment.UserName + "', '" + kab + "', '" + Login + "', 'Новая', '" + DateTime.Now + "')", conn);
                return comm.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

    }
}