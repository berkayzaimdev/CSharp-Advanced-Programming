using System.Diagnostics;

Person p = new Person
{
    Name = "Berkay",
    Country = "Turkey"
};

Console.WriteLine();

[DebuggerDisplay("Name: {Name}, Age: {Age}, City: {City}, Country: {Country}")] // bu attribute sayesinde property/field'ları dahil ederek formatlı bir şekilde instance'ın debug'taki gösterimini değiştirebiliriz
class Person
{
    public string Name { get; set; }
    private int Age  = 23; // access modifier farketmeksizin erişebiliriz
    protected string City { private get; set; } = "İstanbul"; // access modifier farketmeksizin erişebiliriz
    public string Country { get; set; }
}