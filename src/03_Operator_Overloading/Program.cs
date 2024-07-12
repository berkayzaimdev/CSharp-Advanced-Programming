Student student = new()
{
    Name = "Berkay"
};

Book book = new()
{
    Name = "Darth Vader - İmparatorluk Makinesi",
    Author = "Star Wars"
};

var s = student + book;
s = student + book;
s = student - book;

var database = new Database();
database = database + ServerType.SqlServer;
database = database + ServerType.Oracle;
database = database + ServerType.Mongo;

Console.ReadLine();

class Student
{
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = [];

    // neden bu sınıfa yazdığımızı anlamamakla birlikte, scope dışında işlem sırasınca solda s sağda b olması bu syntaxı geçerli kılar
    // sebebini anlayıp Book classında belirttim
    public static Student operator +(Student s, Book b) // Kural 1: public static T operator x(type t1, type t2). Kural 2: override ettiğimiz bu metodu kullanırken sağ-sol eşitliği önemli. Kural 3: mutlaka ama mutlaka override ettiğimiz type, parametrelerden EN AZ BİRİ nde yer almalıdır.
    {
        s.Books.Add(b);
        return s;
    }
}
class Book
{
    public string Name { get; set; }
    public string Author { get; set; }

    // solda s, sağda b var. Bu ikisinin bağıntısını sağlamak için metodu hangi classta tanımladığımız önemli değil. yeter ki bu ikisi arasında bir bağ olsun ve işlemde doğru sırada yer alsınlar. Dönüş değeri de önemsiz.
    public static Student operator -(Student s, Book b)
    {
        s.Books.Remove(b);
        return s;
    }
}
class Database
{ 
    public static Database operator +(Database db, ServerType serverType)
    {
        string connectionString = serverType switch
        {
            ServerType.SqlServer => "connection string for sql server",
            ServerType.Oracle => "connection string for oracle",
            ServerType.Mongo => "connection string for mongo"
        };

        Connect(connectionString);

        return db;
    }

    public static void Connect(string connectionString)
    {
        //...
    }
}

enum ServerType
{
    SqlServer, Oracle, Mongo
}

#region overloadables
/*
 
+, -, *, /, %, ++, -- (aritmetik)

true, false (bool)

==, !=, <, >, <=, >= (mantıksal)

explicit, implicit (buna ileride değineceğiz)

&, |, ^, <<, >>, >>> (bitwise)

*/
#endregion

#region unoverloadables
/*
 
&&, || (mantıksal baglac)
indexer[] 
Cast()
+=, -=, *=, /=, &=, ^=, <<=, >>=, >>>=

as, await, checked, unchecked, default, delegate, is, nameof, new, sizeof, stackalloc, switch, typeof, with

 */
#endregion

#region properties
/*
 
   * Daha Doğal ve Sezgisel Kullanım: örneğin + ve - operatörlerini overload ederek davranışlarına uygun şekilde hareket etmelerini sağlayabiliriz.
   * Okunabilirlik ve Anlaşılabilirlik: bize daha pratik bir yapı sunan operator overloading, fazla koddan bizi kurtarır
   * Dildeki Metotlarla Tutarlılık: zaten özünde bir metot olan operator overloading, bu metotları "." syntaxı yerine kendine has sembolleriyle gerçekleştirmemizi sağlar

 */
#endregion

#region dikkat edilmesi gerekenler
/*
 
   * Mantıklı ve anlamlı bir davranış sağlamak için, operatorlerin gerçek karşılıklarıyla uyumlu bir dizayn oluşturmalıyız
   * kodu geliştirilebilir ve bakımı kolay bir şekilde yazılmalıdır.
   * performans göz önüne alınmalıdır, aşırı karmaşık senaryolarda tercih etmememiz gerekir.
   * asenkron işlemlerde tercih edilmemelidir.

 */
#endregion

#region çift kullanılan operatörler
/*
 
      * == ve !=
      * > ve <
      * >= ve <=
      * true ve false
      
   * bu ikililerin birini tanımlayıp diğerini tanımlamamak compailer hatasına yol açacaktır.

 */
#endregion

#region tekil tanımlı operatörler
/*
 
      * ++
      * --
      
   * bu operatörler, gerçek kullanımına uygun şekilde tek bir parametre alırlar
   
     public static int operator ++(Book b)
     {
        return 3;
     }


      * true
      * false
      
   * bu operatörler, gerçek kullanımına uygun şekilde BOOL döndürmek zorundadır.
   
     public static bool operator true(MyClass A)
     {
        return true;
     }

 */
#endregion

#region örnek
#endregion