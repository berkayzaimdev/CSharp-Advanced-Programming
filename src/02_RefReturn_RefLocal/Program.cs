int b = 5;
X(ref b); // b'nin referansını, yani adresini gönderiyoruz.
Console.Write(b);

int c = 20;
ref var d = ref Y(ref c); 
Console.Write(d); // c ve d; bellekte AYNI yeri paylaşan, iki FARKLI değişkendir.

void X(ref int a)
{
    a = 37;
}

ref int Y(ref int a)
{
    a = 37;
    return ref a;
}

char bb = 's';
ref char cc = ref bb; // ref local; aynı yerde kullanabildiğimiz bir özellik metot ile döndürmek yerine initialize gibi kullanabiliriz


/*
    
int b = 5;
X(&b);
printf("%d",b);

void X(int* a)
{
   *a = 37;
}

C'deki pointer mantığı ile hemen hemen aynı işlem. çok bir farkı yok.
Sadece syntaxta ikinci yıldızı almıyor, kendisi bir adres değil çünkü bir değişken

 */


// ref return özelliği; performans gerektiren durumlarda kodu optimize etmek ve değişken tekrarlarını engellemek için kullanılır