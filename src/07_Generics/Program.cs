// X<int>(3); //kullanım esnasında sharp parantez ile tipini belirtebiliriz
// X("asdasgasdg"); // yahut tip belirtmeyip kendi algılaması için compilera bırakabiliriz.
// List<T> generic yapı iken, List<int> bu generic yapının constructed type'ı olarak karşımıza çıkar
X<Flower>(new());


void X<T>(T t)
    // where T : struct // int, char, long gibi built-in veri tipleri için condition
    // where T : class // referans tipli tüm objeler. string buna dahildir. static class, abstract class, record, interface buna dahildir.
    // where T : new() // NESNE OLUŞTURULABİLİRLİĞİN garantisini sağlar! bu sefer abstract class ve interface'i dahil edemeyiz. Sınıfın "public ve parametresiz" bir constructor'ı olmalıdır.
    // where T : Animal // Nesnenin türediği base class constraint
    // where T : IMyInterface // Nesnenin implement ettiği interface constraint
    // where T : Enum
    // where T : unmanaged // sbyte, byte, short, ushort, int, uint, long, ulong, nint, nuint, char, float, double, decimal, bool, Enum, fielded struct of unmanaged types
    // where T : notnull // nullable olmayan bir tür olması gerekir
    // where T : default // yalnızca override metotlarda ve explicit implemente edilmiş interface metotları için kullanılabilir.(?)
{
    Console.WriteLine(t);
}

class MyClass; // class, new
record MyRecord // class, new
{

};

abstract class MyAbstractClass; // class
static class MyStaticClass; // class
interface IMyInterface; // class


struct MyStruct; // struct, new
enum MyEnum;


class MyPrivateCtorClass // class
{
    private MyPrivateCtorClass() { }
}

class Cat : Animal
{

}

class Animal
{

}

class Flower
{

}