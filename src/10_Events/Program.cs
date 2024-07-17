MyEventPublisher m = new();
// x.XHandler = ...; public keyword olsa dahi, bir sınıfın instance'ından o delegate'i DEĞİŞTİREMEYİZ.
MyEventPublisher.XHandler xHandler = new MyEventPublisher.XHandler(() => Console.Write("test"));
m.MyEvent += () => Console.WriteLine("Event tetiklendi..");

class MyEventPublisher
{
    public delegate void XHandler();

    XHandler xDelegate; // field, add ve remove kullanılırsa gerek olmaz

    public event XHandler MyEvent // property
    // add ve remove blokları isteğe bağlı tanımlanabilir
    // add => += sonucu ne olacak?
    // remove => -= sonucu ne olacak?
    {
        add // property-field mantığı
        {
            Console.WriteLine("Event'e metot bağlandı.");
            xDelegate += value;
        }

        remove
        {
            Console.WriteLine("Event'ten metot koparıldı.");
            xDelegate -= value;
        }
    }

    public void RaiseEvent()
    {
        // MyEvent.Invoke(); // add ve remove kullanılırsa hata verir

        xDelegate.Invoke(); // add ve remove kullanılırsa gerek olmaz
    }
}