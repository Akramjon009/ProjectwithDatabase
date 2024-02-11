using Npgsql;
using System.Dynamic;
using System.Globalization;
internal class Program 
{
    public static void Main(string[] args) 
    {
        bool Check = true;
        string pgConnector ="Host=localhost;Port=5432;Database=TestDB;username=postgres;Password=Akramjon_09;";

        while (Check)
        {
            Console.WriteLine("1.Create\n2.Read\n3.Update\n4.Delete\n5.End");
            string num = Console.ReadLine() ;
            if (num == "1")
            {
                Insert(pgConnector);


            }
            else if (num == "2")
            {
                Console.WriteLine("1.Read all\n2.Read by name\n3.Read by surname\n4.Read by id");
                if (num == "1")
                {
                    GetAll(pgConnector);
                }
                else if (num == "2")
                {
                    GetByName(pgConnector);
                }
                else if (num == "3")
                {
                    GetBySurname(pgConnector);
                }
                else if (num == "4")
                {
                    GetById(pgConnector);
                }
                else
                {
                    Console.WriteLine("Folse enter correct number");
                }

            }
            else if (num == "3")
            {
                Console.WriteLine("1.Update by name\n2.Update by surname\n3.Update by id");
                if (num == "1")
                {
                    UpdateByName(pgConnector);
                }
                else if (num == "2")
                {
                    UpdateBySurname(pgConnector);
                }
                else if (num == "3")
                {
                    UpdateById(pgConnector);
                }
                else
                {
                    Console.WriteLine("Folse enter correct number");
                }
            }
            else if (num == "4")
            {
                Console.WriteLine("1.Delete by name\n2.Delete by surname\n3.Delete by id");
                if (num == "1")
                {
                    DeleteByName(pgConnector);
                }
                else if (num == "2")
                {
                    DeleteBySurname(pgConnector);
                }
                else if (num == "3")
                {
                    DeleteById(pgConnector);
                }
                else
                {
                    Console.WriteLine("Folse enter correct number");
                }
            }
            else if (num == "5") 
            {
                Check = false;
            }
            else
            {
                Console.WriteLine("Folse enter correct number");
            }
            Console.WriteLine("Wait ...");
            Thread.Sleep(5000);
            Console.Clear();
        }

    }

    #region Create table

    public static void CreateTable(string connectionString)
    {

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter name");
        string name = Console.ReadLine();

        string query = $"CREATE TABLE {name}( id SERIAL PRIMARY KEY,name varchar,surname varchar);";
        NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli yaratildi");
        connection.Close();

    }
    #endregion


    #region Insert one info 
    public static void Insert(string connectionString)
    {
    
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Enter table name");
        string tablename = Console.ReadLine();
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();

        string query = $"insert into {tablename}(Name,Surname) values('{name}','{surname}');";
        NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli yaratildi");
        
    }
    #endregion


    #region Insert many info
    public static void Insertmany(string connectionString)
    {

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Enter table name");
        string tablename = Console.ReadLine();
        Console.WriteLine("how row do you want to add ");
        int count = int.Parse(Console.ReadLine());
        string query = $"insert into {tablename}(Name,Surname) values";
        while (count > 0)
        {

            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname");
            string surname = Console.ReadLine();

            count--;
            query += $"({name},{surname}),";

        }
        query.Remove(query.Length - 1);
        NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli yaratildi");

    }
    #endregion


    #region Update
    public static void UpdateByName(string connectionString) 
    {
        using NpgsqlConnection conn = new NpgsqlConnection(connectionString);
        conn.Open();

        Console.WriteLine("Enter table name");
        string Tablename = Console.ReadLine();
        Console.WriteLine("Enter Old name");
        string oldname = Console.ReadLine();
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();
      
        string query = $"Update {Tablename} set name = '{name}',surname='{surname}' where name = '{oldname}";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
        conn.Close();
       
    }
    public static void UpdateBySurname(string connectionString)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(connectionString);
        conn.Open();
        Console.WriteLine("Enter table name");
        string Tablename = Console.ReadLine();
        Console.WriteLine("Enter Old surname");
        string oldsurname = Console.ReadLine();
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();
        
        string query = $"Update {Tablename} set name = '{name}',surname='{surname}' where surname = '{oldsurname}";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
        conn.Close();

    }
    public static void UpdateById(string connectionString)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(connectionString);
        conn.Open();
        Console.WriteLine("Enter table name");
        string Tablename = Console.ReadLine();
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();
        Console.WriteLine("Enter old Id");
        int id = int.Parse(Console.ReadLine());
        string query = $"Update  {Tablename}  set name = '{name}',surname='{surname}' where id = '{id}";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");

        conn.Close();
    }
    #endregion


    #region Read  function
    public static void GetAll(string connectionString)
    {       

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            

            Console.WriteLine("Enter table name");
            string name = Console.ReadLine();
            string query = $"select * from {name};";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0]+"\t" + result[1]+"\t" + result[2]);
            }

 
        }
    }
    public static void GetByName(string connectionString)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {

            Console.WriteLine("Enter table name");
            string nametable = Console.ReadLine();
           
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            string query = $"select * from {nametable} where name = '{name}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0]+"\t " + result[1]+"\t " + result[2]);
            }

          
        }
    }

    public static void GetBySurname(string connectionString)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            
            Console.WriteLine("Enter table name");
            string nametable = Console.ReadLine();
            
            Console.WriteLine("Enter surname");
            string surname = Console.ReadLine();
            string query = $"select * from {nametable} where surname = '{surname}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2]);
            }

         
        }
    }

    public static void GetById(string connectionString)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {

            Console.WriteLine("Enter table name");
            string nametable = Console.ReadLine();
           
            Console.WriteLine("Enter Id");
            int Id = int.Parse(Console.ReadLine());

            string query = $"select * from {nametable} where Id = {Id};";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2]);
            }

          
        }
    }
    #endregion


    #region Deleate function 
    public static void DeleteByName(string connectionString) 
    {
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Enter table name");
        string Tablename = Console.ReadLine();
        Console.WriteLine("Enter name");
        string Name = Console.ReadLine();
        string qre = $"Delete table form {Tablename} where name = '{Name}';";
        using NpgsqlCommand cmd = new NpgsqlCommand(qre, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
        connection.Close(); 

    }
    public static void DeleteById(string connectionString)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter table name");
        string Tablename = Console.ReadLine();
        Console.WriteLine("Enter Id");
        int Id = int.Parse(Console.ReadLine());
        string qre = $"Delete table form {Tablename} where id = {Id};";
        using NpgsqlCommand cmd = new NpgsqlCommand(qre, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
        connection.Close();
    }
    public static void DeleteBySurname(string connectionString)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Enter table name");
        string Tablename = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();
        string qre = $"Delete table form {Tablename} where  surname = '{surname}';";
        using NpgsqlCommand cmd = new NpgsqlCommand(qre, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
        connection.Close();
    }
    #endregion
}
