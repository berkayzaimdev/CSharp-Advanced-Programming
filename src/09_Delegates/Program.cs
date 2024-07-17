/*
    * Delegate'ler metotları temsil eden yapılardır.
    * delege, temsilci ve vekil gibi ifadeler kapsamında düşünebiliriz.
    
    * Bir sınıfın metotlarına ancak ve ancak; o sınıftan üretilmiş bir instance'dan, o sınıfın içerisinden ya da sınıf türü üzerinden erişim sağlayabiliyoruz. Delegate'ler sayesinde metotları farklı noktalarda referans ederek kullanabiliriz.
    
    * Kullanım Amaçları;
       * Callback İşlevleri; Bir metodun işlevinin tamamlanması neticesinde opsiyonel olarak tasarlanmış başka bir işlevi parametrik bir şekilde callback olarak çağırmak için kullanılmaktadırlar.
       * Event-Based Programming; Kodlama sürecinde olay tabanlı yaklaşımlar delegate'ler sayesinde gerçekleştirilmektedir.
       * Fonksiyon Parametreleri; Delegate'ler; metotların, başka metotlar tarafından parametre olarak geçirilmesini ve çağrılmasını sağlarlar.
       * Dinamik Metot Atamaları; Delegate'ler, metotları referans eden yapılar oldukları için programın çalışma zamanında tercihen metotların değiştirilmesini sağlarlar.

    * Delegate'ler ekseriyetle sonuna Handler eklenerek isimlendirilir.
     
    * Delegate'ler, özünde birer CLASS'tır ve referans türlülerdir. Bu duruma istinaden delegate'i kullanabilmek için bir instance üretmemiz gerekecektir.
    
    * += operatörü kullanımı ile delegate'ler birleştirilebilir.
    * -= operatörü kullanımı ile delegate eksiltilebilir.


    * Kullanımı:
       * Önce Handler yapısında bir delegate oluştur.
       * Sonra o delegate'e, temsil edeceği bir fonksiyon ver.
       * Invoke ile delegate'in temsil ettiği fonksiyonu çağır.
*/

#region Defining Delegates

XHandler xDelegate = new XHandler(XMethod);
XHandler x2Delegate = XMethod; // compiler sayesinde new keyword gerekmeksizin bu tanınlamayı yapabiliriz.
XHandler x3Delegate = (b) => { }; // parameter(burada ismin bir önemi yok) type => return type

YHandler yDelegate = new YHandler(YMethod);
YHandler y2Delegate = YMethod;
YHandler y3Delegate = (x, y) => (123, 'a'); // scope'suz direkt type eşleşimi yolu ile tanımlama
YHandler y4Delegate = (x, y) => // scope ile tanımlama
{
    var b = x.GetHashCode();
    return (b, 'b'); 
};

YHandler y5Delegate = delegate (A aObject, (string, int) pTuple) // delegate keyword ile tanımlama
{
    var b = aObject.GetHashCode();
    return (b, (char)pTuple.Item2);
};

#endregion

#region Invoking Delegates

var x1 = y4Delegate.Invoke(new(), ("asdasd", 123));  // sync çalışır metot
var x2 = y4Delegate(new(), ("asdasd", 123)); // bir fonksiyon gibi kullanım sağlayabiliriz
var x3 = YMethod(new(), ("asdasd", 123));

#endregion

#region Multicast Delegates

XHandler xDelegateList = (s) => Console.WriteLine("Delegate 1");
xDelegateList += (s) => Console.WriteLine("Delegate 2");
xDelegateList += (s) => Console.WriteLine("Delegate 3");
xDelegateList += (s) => Console.WriteLine("Delegate 4");
xDelegateList += (s) => Console.WriteLine("Delegate 5");

xDelegateList.Invoke("fsdfgsd");

var methods = xDelegateList.GetInvocationList(); // Delegate array döner

#endregion

#region Generic Delegates

ZHandler<string, int, bool> zDelegate = (x, y) => true; // tanımı itibariyle x ve y = T1 ve T2'dir. yani string ve int dir. true ise dönüş değeri T3'tür.

Console.Write(zDelegate.Invoke("sadasd",12313)); // Output => True

#endregion

#region Asynchronic Delegates

// TODO: eklenecek

#endregion

void XMethod(string s)
{
    Console.WriteLine("Hello world!");
}

(int, char) YMethod(A a, (string,int) p)
{
    Console.WriteLine("Hello world 2!");
    return (2, 'a');
}

public delegate void XHandler(string s); // string tipinde parametre alan ve geriye değer döndürmeyen fonksiyonları temsil edebilen bir delegate

public delegate (int, char) YHandler(A a, (string, int) p);

public delegate T3 ZHandler<T1, T2, T3>(T1 param1, T2 param2);

public class A { }