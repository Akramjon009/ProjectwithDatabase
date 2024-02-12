using Npgsql;
using System.Dynamic;
using System.Globalization;
internal class Program
{
    public static void Main(string[] args)
    {
        bool Check = true;
        string pgConnector = "Host=localhost;Port=5432;Database=TestDB;username=postgres;Password=Akramjon_09;";


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
                Console.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2]);
            }


        }
    }
    public static void GetByName(string connectionString)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {

            Console.WriteLine("Enter table name");
            string nametable = Console.ReadLine();

            Console.WriteLine("Enter  name");
            string name = Console.ReadLine();
            string query = $"select * from {nametable} where name = '{name}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine("Id\tName\tSurname");
            while (result.Read())
            {
                Console.WriteLine(result[0] + "\t " + result[1] + "\t " + result[2]);
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


    public static void GetLike(string connectionString)
    {

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Enter table name");
        string Tablename = Console.ReadLine();
        Console.WriteLine("Enter  Like");
        string like = Console.ReadLine();
        string qre = $"   query = $\"select * from users where name like '{like}';";
        using NpgsqlCommand cmd = new NpgsqlCommand(qre, connection);
        var data = cmd.ExecuteReader();

        while (data.Read())
        {
            Console.WriteLine($"id = {data["id"]}\nname = {data["name"]}\nage = {data["age"]}\n");
        }


        connection.Close();
    }
    //10.yangi column qo'shish
    public void AddColumn(string )
    {
        Open();
        query = $"alter table {tableName} add column {columnNameWithType}";
        command = new NpgsqlCommand(query, connection);
        Console.WriteLine(command.ExecuteNonQuery());
        Close();
    }
    //11.yangi colummni default qiymati bilan qo'shish
    public void AddColumnDefault(string tableName, string columnName, string type, string defaultValue)
    {
        Open();
        query = $"alter table {tableName} add column {columnName} {type} default {defaultValue}";
        command = new NpgsqlCommand(query, connection);
        Console.WriteLine(command.ExecuteNonQuery());
        Close();
    }
    //12.columnni nomini update qilish
    public void UpdateColumn(string tableName, string columnName, string newColumnName)
    {
        Open();
        query = $"alter table {tableName} rename column {columnName} to {newColumnName}";
        command = new NpgsqlCommand(query, connection);
        Console.WriteLine(command.ExecuteNonQuery());
        Close();
    }
    //13.Tableni nomini update qilish.
    public void UpdateTable(string tableName, string newTableName)
    {
        Open();
        query = $"alter table {tableName} rename to {newTableName}";
        command = new NpgsqlCommand(query, connection);
        Console.WriteLine(command.ExecuteNonQuery());
        Close();
    }
    //14.Yo'g' database bor silar shu yangitdan yaratishilar kerak va uni ichiga 3 dona table yaratamiz.
    public void CreateDatabase(string databaseName, params string[] tableNames)
    {
        Open();
        query = $"create database if not exists {databaseName}\nuse {databaseName}\ncreate table if not exists ";
        foreach (var item in tableNames)
        {
            query += $"{item} (id serial primary key, name varchar(50), age int),";
        }
        command = new NpgsqlCommand(query, connection);
        Console.WriteLine(command.ExecuteNonQuery());
        Close();
    }
    //15.Truncate qilish.
    public void Truncate(string tableName)
    {
        Open();
        query = $"truncate {tableName}";
        command = new NpgsqlCommand(query, connection);
        Console.WriteLine(command.ExecuteNonQuery());
        Close();
    }
    //16.Join qilib ko'rish. 2 ta tableni join qilib ko'rish.
    public void Join(string tableName, string secondTableName, string column1, string column2)
    {
        Open();
        query = $"select * from {tableName} join {secondTableName} on {tableName}.{column1} = {secondTableName}.{column2}";
        command = new NpgsqlCommand(query, connection);
        var data = command.ExecuteReader();
        while (data.Read())
        {
            Console.WriteLine($"id = {data["id"]}\nname = {data["name"]}\nage = {data["age"]}\n");
        }
        Close();
    }
    //17.Index qo'shamiz.
    public void Index(string tableName, params string[] columns)
    {
        Open();
        query = $"create index on {tableName} (";
        foreach (var item in columns)
        {
            query += $"{item},";
        }
        query += query.Remove(query.Length - 1) + ")";
        command = new NpgsqlCommand(query, connection);
        Console.WriteLine(command.ExecuteNonQuery());
        Close();
    }
}
