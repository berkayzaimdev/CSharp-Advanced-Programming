using System.Collections;

#region yield keyword

var settings = GetSettings();

foreach (var setting in settings)
{
    Console.WriteLine($"{setting.key} -> {setting.value}");
}

IEnumerable<(string key, string value)> GetSettings()
{
    //List<(string, string)> settings = new()
    //{
    //    ("mssqlConn",".."),
    //    ("redisConn","..."),
    //    ("mongodbConn","....")
    //};

    //return settings; // normal yaklaşım


    // eleman sayımız kısıtlı ise yield'den faydalanabiliriz. performans açısından önem taşır
    // yield keyword; bir iterasyon sürecinde kullanılan metodun her çağrısında nerede olduğunu hatırlar ve oradan devam eder.
    // compiler, yield'i gördüğü zaman burada bir iterasyonel yapı olduğunu algılamaktadır.
    // yield, adım adım yükleme yaptığı için deferred/lazy execution uygulayan bir yapıdır. çağrıldığı noktada değil de itere edildiği noktada aktif olur.

    Console.WriteLine("sql veritabanları aşağıdadır");
    yield return ("mssqlConn", "..");
    Console.WriteLine("nosql veritabanları aşağıdadır");
    yield return ("redisConn", "...");
    yield return ("mongodbConn", "....");
    Console.WriteLine("bağlantı sonu");
    yield break; // döngüyü burada keseceği için alt satırdaki kod çalışmayacaktır (switch case'deki break mantığı)
    Console.WriteLine("program sonu");
}

IEnumerable<string> GetDays()
{

    List<string> days = new() { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };

    foreach (var day in days)
        yield return day;
}

#endregion

#region IEnumerable

var numbers = Enumerable.Range(0, 15).ToList();
foreach (var number in numbers)
{
    //numbers.Remove(number); // iterasyonel bir mekanizmada çalışırken, kaynak o an için değişmez olmalıdır. bu kod satırı hata fırlatacaktır
}

Stock s = new Stock();
foreach (var element in s)
{
    Console.Write(element);
}

class Stock : IEnumerable<string>
{
    List<string> materials = new List<string>()
    {
        "kalem",
        "defter",
        "silgi"
    };

    //public IEnumerator<string> GetEnumerator()
    //{
    //    return materials.GetEnumerator();
    //}

    //IEnumerator IEnumerable.GetEnumerator() // bunu implemente ettirmesinin sebebi foreach döngüsünde object'i kullanabilmek.
    //{
    //    throw new NotImplementedException();
    //}

    public IEnumerator<string> GetEnumerator() // yazdığımız özel enumerator yapısını döndürdük
    {
        return new StockEnumerator(materials);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new StockEnumerator(materials);
    }
}

#endregion

#region IEnumerator

class StockEnumerator : IEnumerator<string> // generic string çünkü string türde kaynak üzerinde çalışma yapacağız
{
    List<string> _source; // dönülecek kaynak
    int _currentIndex = -1; // ilk başta iterasyon başlar başlamaz 1 adım gidecek, yani 0.elemanı alacağız.

    public StockEnumerator(List<string> source)
    {
        _source = source;
    }

    public string Current => _source[_currentIndex]; // o adımda o anki veriyi getirecek
    object IEnumerator.Current => _source[_currentIndex]; // burada object üzerinde çalışma yapabilmemizi sağlayan non-generic implementasyonu kullanmayı şart kılar

    public bool MoveNext() => ++_currentIndex < _source.Count; // doğruysa bir sonraki adıma geç. değilse iterasyonun sonuna gelmişiz demektir

    public void Reset() => _currentIndex = -1; // başlangıca geri döndük

    public void Dispose() => _source = null;// dispose edilebilir. bellek yönetimini sağlamak için built-in olarak eklenmiş  
}

#endregion
