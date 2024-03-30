namespace RSCG_Export_Objects_Console;

public record Person(string FirstName,string LastName)
{
    public string FullName() => FirstName + " " + LastName;
}
