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

    #region Creat
    public static void Insert(string connectionString)
    {
    
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();

        string query = $"insert into TestTable1(Name,Surname) values('{name}','{surname}');";
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
        Console.WriteLine("Enter Old name");
        string oldname = Console.ReadLine();
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();
      
        string query = $"Update TestTable1 set name = '{name}',surname='{surname}' where name = '{oldname}";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");

        conn.Close();
    }
    public static void UpdateBySurname(string connectionString)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(connectionString);
        conn.Open();
        Console.WriteLine("Enter Old surname");
        string oldsurname = Console.ReadLine();
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();
        
        string query = $"Update TestTable1 set name = '{name}',surname='{surname}' where surname = '{oldsurname}";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");


    }
    public static void UpdateById(string connectionString)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(connectionString);
        conn.Open();
      
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();
        Console.WriteLine("Enter old Id");
        int id = int.Parse(Console.ReadLine());
        string query = $"Update TestTable1 set name = '{name}',surname='{surname}' where id = '{id}";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
    }
    #endregion


    #region Read  function
    public static void GetAll(string connectionString)
    {       

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = "select * from TestTable1;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0]+"\t" + result[1]+"\t" + result[2]);
            }

            connection.Close();
        }
    }
    public static void GetByName(string connectionString)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            string query = $"select * from TestTable1 where name = '{name}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0]+"\t " + result[1]+"\t " + result[2]);
            }

            connection.Close();
        }
    }

    public static void GetBySurname(string connectionString)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Enter surname");
            string surname = Console.ReadLine();
            string query = $"select * from TestTable1 where surname = '{surname}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2]);
            }

            connection.Close();
        }
    }

    public static void GetById(string connectionString)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Enter Id");
            int Id = int.Parse(Console.ReadLine());

            string query = $"select * from TestTable1 where Id = {Id};";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2]);
            }

            connection.Close();
        }
    }
    #endregion


    #region Deleate function 
    public static void DeleteByName(string connectionString) 
    {
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Enter name");
        string Name = Console.ReadLine();
        string qre = $"Delete table form TestTable1 where name = '{Name}';";
        using NpgsqlCommand cmd = new NpgsqlCommand(qre, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");


    }
    public static void DeleteById(string connectionString)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter Id");
        int Id = int.Parse(Console.ReadLine());
        string qre = $"Delete table form TestTable1 where id = {Id};";
        using NpgsqlCommand cmd = new NpgsqlCommand(qre, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");

    }
    public static void DeleteBySurname(string connectionString)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();
        string qre = $"Delete table form TestTable1 where  surname = '{surname}';";
        using NpgsqlCommand cmd = new NpgsqlCommand(qre, connection);
        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");

    }
    #endregion
}
