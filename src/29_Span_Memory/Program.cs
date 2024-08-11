#region Span

/*

   * Span: Bellekteki herhangi bir alanı temsil edebilmemizi sağlayan bir REF STRUCT'tır.
      * Dizinin dışındaki türlerde de çalışma sergileyebilir.
      * Stack'te ya da Heap'te fark etmeksizin, tanımlanmış olan tüm Array'lerin tümünü yahut bir bölümünü refere edebilir.
      * Array ve String'ler gibi kapasitesi yüksek olan verilerde, performans açısından son derece verimli işlemler yapabilmemizi sağlar.
      * Bu tür, REF STRUCT olmasından dolayı, heap'te hiçbir şekilde tanımlanamaz. Yani bir class, interface, dynamic vb. türlerinde referans edilemez. Property, field vs. olarak kullanılamaz.

*/

int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

Span<int> span1 = numbers.AsSpan();
Span<int> span2 = span1.Slice(3, 7); // Slice metodu sayesinde span'ları belirlediğimiz aralıkta bölebiliriz. Slice işlemi O(1) karmaşıklığına sahip olduğu için kullanımı performans açısından önemlidir

// problem: Öyle bir metot tanımla ki bir diziyi alsın ve bu dizinin ortasından başlayarak elemanlarının 1/4'ünü içerecek bir dizi döndürsün
int size = 1000;
int[] _myArray = new int[size];

for(int i=0;i<size; i++)
{
    _myArray[i] = i;
}

// Yöntem 1
int[] a1 = _myArray.Skip(size / 2).Take(size / 4).ToArray();

// Yöntem 2
int[] a2 = new int[size / 4];
Array.Copy(_myArray, size / 2, a2, 0, size / 4);

// Yöntem 3
int[] a3 = _myArray.AsSpan().Slice(size/2, size/4).ToArray();

// Performans açısından Yöntem 3 > Yöntem 2 > Yöntem 1

#endregion

#region Memory

/*

   * Memory: Span'ın, "ref struct" olmasından ötürü yaşadığı kısıtlamaları kendisinde barındırmayan halidir. STRUCT bir yapıdır.

*/

async Task SomethingAsync(Memory<byte> data) // Span kullanımı compilation error oluştururdu
{
    Memory<byte> slicedData = data.Slice(50, 100);
    // Span<byte> spanData = data.Span.Slice(50, 100); // compilation error. çünkü bir span, asenkron metotta tanımlanamaz
    SomethingNotAsync(data.Span); // senkron bir metoda span gönderdiğimiz için bu kod hata fırlatmaz
    await Task.Delay(1000);
}

Task SomethingNotAsync(Span<byte> data)
{
    return Task.CompletedTask;
}

#endregion

class SpanHolder
{
    private int[] myArr = { 1, 2, 3 };

    // public Span<int> _span0 { get; set; } // hata verir çünkü span, operasyonlar arası aynı kalır ve zaman içerisinde değiştirilmesine olaank verilir. bu da ref struct yapısına uymaz
    public Span<int> _span1 => myArr.AsSpan(); // hata vermez çünkü bu property'e her ulaştığımızda yeni bir span üretilir
    public Span<int> _span2 // hata vermez çünkü bu property'e her ulaştığımızda yeni bir span üretilir
    {
        get
        {
            return myArr.AsSpan();
        }
    }

    // private Span<int> _span3; // field kullanımında hata verir çünkü uzun süreli değişiklik durumlarında span bozulmaya uğrar
}