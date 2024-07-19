using System.Reflection;


Assembly assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes()
    .Where(t => t.GetCustomAttribute<MyAttribute>() is not null) // bu attribute'a sahip tüm type'lar
    .ToList();

foreach(var t in types)
{
    var myAttribute = t.GetCustomAttribute<MyAttribute>();
    Console.WriteLine($"{t.Name} --> {myAttribute.MyProperty1}");
}


// [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor)] // hangi yapılara uygulanabiliri seçiyoruz. compile sürecinde belirlenmiş olur
public class MyAttribute : Attribute
{
    public MyAttribute(string s, bool b)
    {

    }

    public int MyProperty1 { get; set; }
    public int MyProperty2 { get; set; }
    public int MyProperty3 { get; set; }

    public int i;
    public void Method()
    {

    }
}
public class My2Attribute : Attribute
{

}

public class My3Attribute : Attribute
{

}
public class My4Attribute : Attribute
{
    public int MyProperty5 { get; set; }
}

public class My5Attribute<T> : Attribute
{
    public T MyGenericProperty { get; set; }
}


// [MyAttribute]
// [My2] // nameAttribute sınıfını seçmek için name yazmamız yeterli
// [My3] alt alta kullanım
// [My2, My3] yan yana kullanım
[My("asdsdad", true, i = 3, MyProperty1 = 4, MyProperty2 = 5, MyProperty3 = 6)] // constructor'daki parametreleri muhakkak vermeliyiz. diğer property ve fieldlar isteğe bağlı
[My4(MyProperty5 = x)]
class MyClass
{
    const int x = 37; // bu kullanım önemli bir detaydır. const tanımlama yaptığımız takdirde, property'e değişken gönderebiliriz

    [My("", true, MyProperty1 = 123)]
    public MyClass()
    {

    }

    [My("", true, MyProperty1 = 456)]
    public void X()
    { }

    [My5<bool>(MyGenericProperty = true)]
    public int MyProperty { get; set; }
}