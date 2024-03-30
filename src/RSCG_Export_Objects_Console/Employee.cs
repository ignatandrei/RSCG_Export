using System;

namespace RSCG_Export_Objects_Console;

public record Employee(string FirstName, string LastName, int salary):Person(FirstName,LastName)
{
    public string ShowInfo()
    {
        return this.FullName()+ " "+ this.salary;
    }
}
