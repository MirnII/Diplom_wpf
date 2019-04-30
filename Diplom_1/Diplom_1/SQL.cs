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
                SqlCommand comm = new SqlCommand("Insert into repair(Категория, Программа, Картридж, ПК, Логин, Дата, Кабинет, Уч_зп, Статус, Техник) " +
                    "values ('" + kat + "', '-', '-', '" + Environment.MachineName + "', '" + log + "', '" + DateTime.Now + "', '" + kab+ "', " +
                    "'" + Environment.UserName + "', 'Новая', '-')", conn);
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
                SqlCommand comm = new SqlCommand("insert into Users(Логин, Пароль, Имя, Роль) " +
                    "values('" + Data[0] + "','" + Data[2] + "','" + Data[1] + "','" + Data[3] + "')", conn);
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
                SqlCommand comm = new SqlCommand("insert into repair(Категория, Программа, Картридж, ПК, " +
                    "Уч_зп, Кабинет, Логин, Статус, Дата)" +
                    " values('Замена картриджа', '-', '" + Cart + "', '" + Environment.MachineName + "', " +
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
                SqlCommand comm = new SqlCommand("insert into repair(Категория, Программа, Картридж, ПК, " +
                    "Уч_зп, Кабинет, Логин, Статус, Дата, Техник)" +
                    "values('Установка программы', '" + Name + "', '-', '" + Environment.MachineName + "', " +
                    "'" + Environment.UserName + "', '" + kab + "', '" + Login + "', 'Новая', '" + DateTime.Now + "', '-')", conn);
                return comm.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public int Mer(string name, string Login, string sv, string date, string Name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                SqlCommand comm = new SqlCommand("insert into mer(Логин, Имя, Описание, Дата_пров, Ответственный, Статус, Техник)" +
                    " values('"+Login+"','" + name + "', '" + sv + "', '" + date + "', '" + Name + "', 'Новое', '-')", conn);
                return comm.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }

        }
        public void sp_ZAV(string Login, MainWindow main)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                SqlCommand comm = new SqlCommand("select id, Категория, Программа, Картридж, ПК, Дата, Кабинет, " +
                    "Техник, Статус from repair where Логин = '" + Login + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds, "repair");
                DataView data = new DataView(ds.Tables[0]);
                main.datagrid_rzi.ItemsSource = data;
            }
            catch
            {

            }
        }

        public void sp_ZAV(string Login, string Kat, MainWindow main)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                SqlCommand comm = new SqlCommand("select id, Категория, Программа, Картридж, ПК, Дата, Кабинет," +
                    " Техник, Статус from repair where Логин = '" + Login + "' and Категория = '" + Kat + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds, "repair");
                DataView data = new DataView(ds.Tables[0]);
                main.datagrid_rzi.ItemsSource = data;
            }
            catch
            {

            }
        }
        public void sp_ZAV(string Login, string Prog, string Cart, string Kab, string Kat, MainWindow main)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                if (Prog != "Программа" && Kab != "Кабинет" && Kat == "Установка программы")
                {
                    SqlCommand comm = new SqlCommand("select Категория, Программа, Картридж, ПК, Дата, Кабинет," +
                    " Техник, Статус from repair where Логин = '" + Login + "' and Категория = '" + Kat + "' and Программа like '%" + Prog + "%' and Кабинет like '%" + Kab + "%'", conn);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "repair");
                    DataView data = new DataView(ds.Tables[0]);
                    main.datagrid_rzi.ItemsSource = data;
                }
                if (Prog != "Программа" && Kab == "Кабинет" && Kat == "Установка программы")
                {
                    SqlCommand comm = new SqlCommand("select id, Категория, Программа, Картридж, ПК, Дата, Кабинет," +
                    " Техник, Статус from repair where Логин = '" + Login + "' and Категория = '" + Kat + "' and Программа like '%" + Prog + "%'", conn);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "repair");
                    DataView data = new DataView(ds.Tables[0]);
                    main.datagrid_rzi.ItemsSource = data;
                }
                if (Prog == "Программа" && Kab != "Кабинет" && Cart == "Картридж")
                {
                    SqlCommand comm = new SqlCommand("select id, Категория, Программа, Картридж, ПК, Дата, Кабинет," +
                    " Техник, Статус from repair where Логин = '" + Login + "' and Кабинет like '" + Kab + "%'", conn);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "repair");
                    DataView data = new DataView(ds.Tables[0]);
                    main.datagrid_rzi.ItemsSource = data;
                }
                if (Cart != "Картридж" && Kab != "Кабинет" && Kat == "Замена картриджа")
                {
                    SqlCommand comm = new SqlCommand("select  id, Категория, Программа, Картридж, ПК, Дата, Кабинет," +
                    " Техник, Статус from repair where Логин = '" + Login + "' and Категория = '" + Kat + "' and Картридж like '" + Cart + "%' and Кабинет like '%" + Kab + "%'", conn);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "repair");
                    DataView data = new DataView(ds.Tables[0]);
                    main.datagrid_rzi.ItemsSource = data;
                }
                if (Cart != "Картридж" && Kab == "Кабинет" && Kat == "Замена картриджа")
                {
                    SqlCommand comm = new SqlCommand("select id, Категория, Программа, Картридж, ПК, Дата, Кабинет," +
                    " Техник, Статус from repair where Логин = '" + Login + "' and Категория = '" + Kat + "' and Картридж like '" + Cart + "%'", conn);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "repair");
                    DataView data = new DataView(ds.Tables[0]);
                    main.datagrid_rzi.ItemsSource = data;
                }
            }
            catch
            {

            }
        }
        public int cansel_z(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                SqlCommand comm = new SqlCommand("delete from repair where id = '" + id + "'", conn);
                return comm.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }
        public int Close_z(int id, int ass, string engineer)
        {
            int z_o = 0, z_c= 0, _5 = 0, _4 = 0, _3 = 0, _2 = 0;
            int num = 0;
            try
            {
                SqlCommand comm;
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
                comm = new SqlCommand("select * from engineer", conn);
                SqlDataReader reader = comm.ExecuteReader();
                while(reader.Read())
                {
                    if(engineer == reader["ФИ"].ToString())
                    {
                        z_o = Convert.ToInt16(reader["Заявок_открыто"]);
                        z_c = Convert.ToInt16(reader["Заявок_закрыто"]);
                        _5 = Convert.ToInt16(reader["_5"]);
                        _4 = Convert.ToInt16(reader["_4"]);
                        _3 = Convert.ToInt16(reader["_3"]);
                        _2 = Convert.ToInt16(reader["_2"]);
                        reader.Close();
                        break;
                    }
                }
                if(ass == 5)
                {
                    z_o--;
                    z_c++;
                    _5++;
                    comm = new SqlCommand("update engineer Set Заявок_открыто = '" + z_o + "', Заявок_закрыто = '" + z_c + "', _5 = '" + _5 + "' where ФИ = '" + engineer + "'", conn);
                    num = comm.ExecuteNonQuery();
                }
                if (ass == 4)
                {
                    z_o--;
                    z_c++;
                    _4++;
                    comm = new SqlCommand("update engineer Set Заявок_открыто = '" + z_o + "', Заявок_закрыто = '" + z_c + "', _4 = '" + _4 + "' where ФИ = '" + engineer + "'", conn);
                    num = comm.ExecuteNonQuery();
                }
                if (ass == 3)
                {
                    z_o--;
                    z_c++;
                    _3++;
                    comm = new SqlCommand("update engineer Set Заявок_открыто = '" + z_o + "', Заявок_закрыто = '" + z_c + "', _3 = '" + _3 + "' where ФИ = '" + engineer + "'", conn);
                    num = comm.ExecuteNonQuery();
                }
                if (ass == 2)
                {
                    z_o--;
                    z_c++;
                    _2++;
                    comm = new SqlCommand("update engineer Set Заявок_открыто = '" + z_o + "', Заявок_закрыто = '" + z_c + "', _2 = '" + _2 + "' where ФИ = '" + engineer + "'", conn);
                    num =  comm.ExecuteNonQuery();
                }
                if(num == 1)
                {
                    comm = new SqlCommand("delete from repair where id = '" + id + "'", conn);
                    comm.ExecuteNonQuery();
                    num = 2;
                }
                return num;

            }
            catch
            {
                return 0;
            }
        }
        public void sp_Mer(string Login, MainWindow main)
        {
            SqlConnection conn = new SqlConnection(Sql);
            conn.Open();
            SqlCommand comm = new SqlCommand("select Имя, Описание, Дата_пров, Ответственный, Техник, Статус from mer where Логин = '"+Login+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds, "mer");
            DataView data = new DataView(ds.Tables[0]);
            main.datagrid_mer.ItemsSource = data;
                 
        }
    }
}