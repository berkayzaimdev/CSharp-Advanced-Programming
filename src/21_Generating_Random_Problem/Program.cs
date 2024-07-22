// ilk random değer üretimi için seed seçilir
// seed data, default olarak tarihsel veri kullanır. milisaniye her vakit değiştiği için rastgelelik sağlanır.
// aynı değeri üretme ihtimali de vardır fakat yüksek ihtimalle, bu random veri değişecektir.
// eğer ki seed'i kendimiz belirlerken her çağrımda aynı veri üzerinden aritmatik çağrımlar yapılacağı için aynı sayı dizileri elde edilecektir.

//Random random = new Random(); 
using System.Security.Cryptography;

Random random = new Random(DateTime.UtcNow.Microsecond); // bu şekilde default değer yerine sürekli değişecek bir parametre göndermek faydalı olacaktır

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(random.Next());
}

// RNGCryptoServiceProvider sınıfı ile de random sayı üretimi sağlanır. Fakat bu yöntem normal üretime kıyasla çok daha yavaş olmaktadır.
using var rng = RandomNumberGenerator.Create();
byte[] randomBytes = new byte[4];
rng.GetBytes(randomBytes);
int randomNumber = BitConverter.ToInt32(randomBytes, 0);
Console.WriteLine(randomNumber);