#region IComparer

using System;
using System.Collections;
using System.ComponentModel;

//Person p1 = new()
//{
//Name = "Ahmet",
//Age = 30
//};

//Person p2 = new()
//{
//Name = "Mehmet",
//Age = 40
//};

//Person p3 = new()
//{
//Name = "Mustafa",
//Age = 35
//};

//Person p4 = new()
//{
//Name = "Ali",
//Age = 45
//};

//var persons = new List<Person>() { p1, p2, p3, p4 };

//AgeComparer ageComparer = new();

//var result = ageComparer.Compare(p1, p2);

//Console.WriteLine(result);
//Console.WriteLine("***************");

//// persons.Sort(); // primitive tip olsaydı, düzgün çalışacaktı fakat içerisine nesne tanımlaması yapmamız lazım
//persons.Sort(ageComparer); // IComparer'i implemente eden AgeComparer sınıfının instance'ını verdik ve küçükten büyüğe sıraladık

//persons.ForEach(x => Console.Write($"{x.Name} {x.Age} yasindadir.\n"));

//class AgeComparer : IComparer, IComparer<Person>
//{
//    public int Compare(Person? x, Person? y)
//    {
//        // return x.Age > x.Age ? 1 : x.Age == y.Age ? 0 : -1;
//        return x.Age.CompareTo(y.Age);
//    }

//    public int Compare(object? x, object? y)
//    {
//        throw new NotImplementedException();
//    }
//}

#endregion

#region IComparable

//var result2 = p1.CompareTo(p3); // p1, p3'ten yaşça büyük ise 1, eşit ise 0, küçük ise -1
//Console.WriteLine(result2);

#endregion

#region ICloneable

//var p1Clone = p1.Clone();

#endregion

#region INotifyPropertyChanged

Person p = new() { Name = "Berkay" };

p.PropertyChanged += (sender, e) =>
{
    var person = (Person)sender as Person;
    Console.WriteLine($"{person.Name} adlı kisinin {e.PropertyName} degeri, {person.Age} olarak guncellenmistir.");
};

p.Age = 24;

#endregion

#region IEquatable

//Person p1 = new()
//{
//    Name = "Ahmet",
//    Age = 30
//};

//Person p2 = new()
//{
//    Name = "Mehmet",
//    Age = 40
//};

//Console.WriteLine(p1.Equals(p2));

#endregion

#region IEnumerable

// bir nesnenin üzerinde foreach ile gezmeyi sağlayan interface'tir.
var depo = new Depo();
foreach(var item in depo)
{
    Console.WriteLine(item);
}

var result = depo.Where(d => d.Contains('a'));
foreach (var item in result)
{
    Console.WriteLine(item);
}

#endregion

#region IDisposable

using (Depo dDispose = new())
{
    Console.WriteLine("before dispose");
}

#endregion



class Person : IComparable<Person>, ICloneable, INotifyPropertyChanged, IEquatable<Person>
{
    public string Name { get; set; }
    private int _age;
    public int Age {
        get 
        {
            return _age;
        }

        set 
        {
            _age = value;
            PropertyChanged(this, new(nameof(Age)));
        } 
    }

    public int CompareTo(Person? other) // java'daki comparable gibi
    {
        return this.Age.CompareTo((int)other.Age);
    }

    public object Clone()
    {
        return this.MemberwiseClone(); // farklı referanslı bir kopyasını döndürür. object metodudur
        //return new Person()
        //{
        //    Age = this.Age,
        //    Name = this.Name
        //};
    }

    public event PropertyChangedEventHandler? PropertyChanged; // property'si değişirse

    public bool Equals(Person? other) // object.Equals() yerine daha güvenli bir yaklaşım. eşitlik durumunu döndürür
    {
        return this.Age == this._age;
    }
}

class Depo : IEnumerable, IEnumerable<string>, IDisposable
{
    List<string> list = new List<string>(){"kalem", "silgi", "defter"};
    public IEnumerator GetEnumerator() // foreach kullanımı için bu metot olması şarttır. interface'i implemente etmeye gerek yok esasında
    {
        return list.GetEnumerator(); // list'in metodunu çağırarak enumerator döndürebiliriz.
    }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        return list.GetEnumerator();
    }

    public void Dispose()
    {
        // kaynakları serbest bırakmak için kullanılır. "using" keyword kullanımını sağlar.
        Console.WriteLine("disposing..");
    }
}