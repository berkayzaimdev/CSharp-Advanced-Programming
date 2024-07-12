var a = Array.CreateInstance(typeof(int), 2); // Array türünde, int type tutan bir dizi
// int[] b = Array.CreateInstance(typeof(int), 2); // hata verecektir, tip uyuşmazlığı
int[] c = (int[])Array.CreateInstance(typeof(int), 2); // casting işlemi ile int[] türüne çeviriyoruz. polymorphism ile Array türü olarak da kullanabiliriz

int[,,] d = (int[,,])Array.CreateInstance(typeof(int), 2, 3, 5); // birden fazla length verdiğimiz durumlarda, dizinin boyutunu da ona uygun olarak modifiye etmemiz lazım


(string s, uint u, double d)[] newArray = new (string s, uint u, double d)[]
{
    ("sbsdbsdb",10,27.5),
    ("sbsdbsdb",10,27.5),
    ("sbsdbsdb",10,27.5),
    ("sbsdbsdb",10,27.5),
    ("sbsdbsdb",10,27.5),
    ("sbsdbsdb",10,27.5)
}; // tuple dizi


Console.ReadLine();