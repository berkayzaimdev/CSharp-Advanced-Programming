#region Normal Kullanım

//!!! IX.StaticAbstractA1(); // abstract olduğu için kullanılamaz. implementasyonu concrete class'ta yapılacak çünkü
//!!! IX.StaticAbstractA2(); // abstract olduğu için kullanılamaz. implementasyonu concrete class'ta yapılacak çünkü
IX.C();

X.StaticAbstractA1();
X.StaticAbstractA2();
//!!! X.C(); // interface'e ait bir static metot olduğu için kullanılamaz

#endregion

#region Generic Kullanım

XX<X> myObj = new(); // mantığı; X sınıfı, interface'ten kalıtım alır. kalıtım aldığı kontratlar olan static abstract member'ları uygular. XX sınıfı ise bu uygulanan metotları kendi constructor'ında tabii tutar

#endregion

#region Static members VS. Static Abstract members

/*
                                     STATİC MEMBERS                                                                      STATİC ABSRTACT MEMBERS
       Tanımlandığı interface'leri uygulayan sınıfa implemente edilmesini zorunlu kılmaz       Tanımlandığı interface'leri uygulayan sınıfa implemente edilmesini zorunlu kılar
                        Generic parametre üzerinden ERİŞİLEMEZ                                                  Generic parametre üzerinden ERİŞİLEBİLİR  
                     Interface üzerinden static olarak ERİŞİLEBİLİR                                          Interface üzerinden static olarak ERİŞİLEMEZ 
*/

#endregion

class XX<T> where T : IX, new()
{
    public XX()
    {
        T.StaticAbstractA1();
        T.StaticAbstractA2(); // sadece static abstract member'lar gelir

        T t1 = new();
        T t2 = new();

        _ = t1 + t2;
        _ = +t1;
    }
}

interface IX
{
    abstract void A(); // normal olarak metot imzası; abstract keyword ile işaretlenir
    // static void StaticA(); // static ile işaretlenemez
    abstract static void StaticAbstractA1();
    static abstract void StaticAbstractA2(); // yer değiştirebilir

    int Value { get; }
    static abstract int operator +(IX x1); // operatör imzaları mutlaka static abstract olmalıdır. keywordsüz, abstract ya da static olarak tanımlanamaz
    static abstract int operator +(IX x1, IX x2);



    virtual void B() // normal olarak default implementation; virtual keyword ile işaretlenir
    {
        Console.WriteLine("B");
    }

    //sealed void B() // virtual davranış sergilemesini istemiyorsak, virtual keyword'ü kaldırıp sealed ile işaretleyebiliriz.
    //{
    //    Console.WriteLine("B");
    //}

    //abstract void B() // abstract KULLANILAMAZ, static abstract da kullanılamaz
    //{
    //    Console.WriteLine("B");
    //}

    static void C() // static tanımlamada, default olarak default implementation uygulanmalıdır. bu tip metotlar özleri itibariyle ne abstract, ne de virtual davranış sergilerler. Bu sebeple sealed olarak işaretlenemez.
    {

    }

}

class X : IX
{
    public void A()
    {
        Console.WriteLine("A");
    }

    public static void StaticAbstractA1()
    {
        Console.WriteLine("StaticAbstractA1");
    }

    public static void StaticAbstractA2()
    {
        Console.WriteLine("StaticAbstractA2");
    }

    public int Value => 5;

    void IX.A()
    {
        Console.WriteLine("Explicit A");
    }

    static void IX.StaticAbstractA1()
    {
        Console.WriteLine("Explicit StaticAbstractA1");
    }

    static void IX.StaticAbstractA2()
    {
        Console.WriteLine("Explicit StaticAbstractA2");
    }

    int IX.Value => 1;

    static int IX.operator +(IX x1)
    {
        return 5;
    }

    static int IX.operator +(IX x1, IX x2)
    {
        return 10;
    }
}