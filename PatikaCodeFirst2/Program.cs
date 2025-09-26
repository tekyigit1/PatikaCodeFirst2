using PatikaCodeFirst2.Context;

using var db = new PatikaSecondDbContext();

try
{
    Console.WriteLine($"Users: {db.Users.Count()}, Posts: {db.Posts.Count()}");
}
catch
{
    Console.WriteLine("Önce migration ve Update-Database çalıştır:");
    Console.WriteLine("PM> Add-Migration InitialCreate -Context PatikaSecondDbContext");
    Console.WriteLine("PM> Update-Database -Verbose");
}
