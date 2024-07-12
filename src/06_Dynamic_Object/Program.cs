#region Activator sınıfı ile nesne oluşturma

using System.Dynamic;

Type type = typeof(MyClass);
var obj = Activator.CreateInstance(type); // object tipinde olacaktır, çünkü conversion yapmadık.
var obj2 = (MyClass)Activator.CreateInstance(type); // MyClass tipinde olacaktır.

#endregion

#region DynamicObject sınıfı ile nesne oluşturma

dynamic dynamicObj = new MyDynamicClass();
dynamicObj.Foo = "im a dynamic object and i can contain any type of value";
dynamicObj.Bar = 37.7;
dynamicObj.Qux = true;
dynamicObj.Quux = new int[] { 1, 2, 3 };

// dynamicObj.WriteProps(); // bu obje henüz dinamik, yani herhangi bir metodunu kullanamayız. öncelikle bunu instance olarak çevirmeliyiz.
var castedObj = (MyDynamicClass)dynamicObj;
castedObj.WriteProps();

#endregion

#region ExpandoObject sınıfı ile nesne oluşturma

dynamic expandoObj = new ExpandoObject(); // hazır ExpandoObj sınıfını kullanarak yeni class oluşturup kalıtım verme zahmetinden kurtulabiliriz
expandoObj.Foo2 = "im an expando object and i act like dynamic object";
expandoObj.Bar2 = 22.2;
expandoObj.Qux2 = true;
expandoObj.Quux2 = new int[] { 5,6,7 };

Console.WriteLine($"{expandoObj.Foo2} - {expandoObj.Qux2}");

#endregion

class MyClass
{
    public MyClass()
    {
        Console.WriteLine($"{nameof(MyClass)} instance created.");
    }
}

class MyDynamicClass : DynamicObject
{
    private readonly Dictionary<string, object> _props = new();
    public MyDynamicClass()
    {
        Console.WriteLine($"{nameof(MyDynamicClass)} instance created.");
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        _props[binder.Name] = value;
        return true;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        return _props.TryGetValue(binder.Name, out result);
    }

    public void WriteProps()
    {
        _props.ToList().ForEach(x => Console.WriteLine($"{x.Key} - {x.Value}"));
    }
}