using System.Collections;

MyClass myClass = new() { 
    1, 2, 3,
    { 123, "sbsbsbsb" },
    { 456, "sbsbsbsb" },
    (1,"asdasd",1.1)
};

class MyClass : IEnumerable<int> // 1.adım;
{
    List<int> numbers = new();

    public void Add(int i) // 2.adım; collection initializer özelliğini sağlayan metot. parametre aynı tip olmalıdır
    {
        numbers.Add(i); 
    }

    public void Add(int i, string j) // overload
    {
        numbers.Add(i);
    }

    public void Add((int i, string j, double d) t) // overload
    {
        numbers.Add(t.i);
    }

    public IEnumerator<int> GetEnumerator()
    {
        return numbers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return numbers.GetEnumerator();
    }
}