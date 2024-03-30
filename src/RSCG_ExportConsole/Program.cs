using RSCG_Export_Objects_Console;


Person person = new Person("Andrei", "Ignat");
//Console.WriteLine(person.FullName());
DisplayData(person);

static void DisplayData(Person person)
{
    Console.WriteLine(person.FullName());

}