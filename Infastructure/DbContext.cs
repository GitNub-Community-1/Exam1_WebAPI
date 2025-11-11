namespace Infastructure;
using Npgsql;
public class DbContext
{
     readonly string connectionString =
        "Host = localhost; Port = 5432; Database = Exam_NpgSql_Connect; Username = postgres; Password = maradona@$$34";
    public NpgsqlConnection GetConnect()    
}
