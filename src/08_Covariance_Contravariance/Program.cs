#region Covariance
// Her veri türü object'ten türer; object in türevidir. Bu sebeple bu sağ-sol dengesizliği solun lehine olduğu zaman, Covariance kuralı devreye girer.
// Covariance ve Contravariance durumlarında derleyici bir problem çıkarmaz bize.

object[] isimler = new string[5] { "Ahmet", "Mehmet", "Ali", "Mustafa", "Hilmi" };

#region Array Types

object[] x = new string[5];
x[0] = "wadsd";
x[1] = 123; // covariance durumlarında tehlike arz eder. runtime'da hata fırlatacaktır. string dizisine int verilemez çünkü

IEnumerable<object> arabalar = new List<string> { "Tesla", "Volvo", "TOGG" };

IEnumerable<A> asd = new List<B> { new(), new() };

#endregion

#region Delegete Types

Func<A> funcA = GetB; // covariance için uygun bir delegate
B GetB() => new(); // B türünden değer döndüren fonksiyon

#endregion

#region Return Types

//class Animal
//{
//    public virtual Animal X() => new();
//}
//class Cat : Animal
//{
//    public override Cat X() => new(); // override keyword ile üst sınıftaki metot ile eşleşti
//}

#endregion

#region Generic Types

//IAnimal<object> objectAnimals = new Animal<string>();
//IAnimal<A> aAnimals = new Animal<B>();

//interface IAnimal<out T> { } // out keyword burada covariance davranışın gerçekleşmesini sağlar. kullanmadığımız durumda compiler error verir
//// out sadece interface ve delegate türlerde kullanılabilir
//class Animal<T> : IAnimal<T> { }

#endregion


#endregion

#region Contravariance
// sağ-sol dengesizliği sağın lehine ise bu durum Contravariance'a işaret eder

#region Delegete Types

Action<string> xDelegate = XMethod;
void XMethod(object o) { }

Action<B> bDelegate = AMethod;
void AMethod(A a) { }

#endregion

#region Generic Types

IAnimal<string> stringAnimals = new Animal<object>();
IAnimal<B> aAnimals = new Animal<A>();

interface IAnimal<in T> { } // in keyword burada contravariance davranışın gerçekleşmesini sağlar. kullanmadığımız durumda compiler error verir
// B ile B'yi karşılıyoruz, A'yı da karşılıyoruz
class Animal<T> : IAnimal<T> { }

#endregion

#endregion

#region Özet

/*
    * Covariance ve Contravariance terimleri; array, delegate, return ve generic typelar için implicit referans dönüşümlerini ifade eder. Polymorphism' e benzer bir yapıdır.
    
    * out keyword output davranışlarda kullanılırken, in keyword ise input davranışlarda kullanılır.
    
    * delegate Covariancer<in T>(T t);
    * delegate T Contravariancer<out T>();
*/

#endregion

class A 
{
    public virtual A X() => new();
}
class B : A {
    public override B X() => new(); // override keyword ile üst sınıftaki metot ile eşleşti
}