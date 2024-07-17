#region Implicit Conversion

// temel programlamada sıklıkla kullandığımız bir dönüşüm. veri kaybının olası olmadığı durumlarda sıklıkla başvurduğumuz
// büyük type = küçük type dönüşümüdür

int x = 135;
long y = x;
#endregion

#region Explicit Conversation

// küçük type = (küçük)büyük type dönüşümüdür

long q = 1000;
int z = (int)q;
#endregion

#region Overloading Implicit & Explicit

A a1 = new B();
A a2 = (A)new B();

B b = (B)new A();

class A
{    // sen sağ tarafta A'dan bir instance oluşturuyorsun ve bu oluşturduğun instance'ı, B tipindeki bir değişkene atamak istiyorsun. Bu normal koşulda gerçekleşmez explicit ile (B) gibi belirtmemiz gerekir.
    public static explicit operator B(A i) // A type'ına sahip olan i; (B) kullanımı ile B type'ına dönüşecek
    {
        return new B { };
    }
}

class B
{
    // sen sağ tarafta B'den bir instance oluşturuyorsun ve bu oluşturduğun instance'ı, A tipindeki bir değişkene atamak istiyorsun. Implicit ile bu dönüşüm otomatik olarak gerçekleşecektir.
    public static implicit operator A(B i) // B type'ına sahip olan i; A type'ına dönüşecek
    {
        return new A { };
    }
}

// overload'ların hangi sınıfta tanımlandığının hiçbir önemi yoktur. tek dikkat etmemiz gereken doğru tanımlamadır

#endregion