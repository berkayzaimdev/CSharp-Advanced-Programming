#region String'lerin hafızadaki durumu

/*
   * 2. ya da 3.şahıslar, memory'e erişip tüm verileri alıp farklı işlemlere tabii tutabilir.
   * Eğer bu erişim sağlanırsa veri şifreleme bu noktada faydalı olacaktır çünkü ham veri yerine şifrelenmiş veri çok daha güvenlidir.
      * örn: Herhangi bir kredi kartı bilgisini şifreleyip memory'e öyle ekleyebiliriz.
   
   * String'ler normalde immutable yapılardır.
   * String bir ifadede yapılan değişiklik, o ifadenin klonlanmasıyla hafızaya kaydedilir. GC devreye girene kadar da kayıtlı olarak kalır.
   
   * Bu durumda SecureString sınıfı bize fayda sağlamaktadır. Bu sınıfın temel amacı, bellekteki string verilerin güvenilirliğini arttırmaktadır.
   * SecureString ile müdahale edilen değişkenler bellek üzerinde DPAPI(Data Protection API) yardımıyla şifreli bir şekilde tutulmaktadır. Ayrıca değişken değerinde yapılan herhangi bir değişiklik, bu değişkenin kopyalanması yerine direkt olarak değişkenin memory alanında uygulanır.
      * Bu sınıf; API key'lerin, kimlik doğrulama bilgilerinin yahut şifrelerin güvenliğini sağlamak amacıyla kullanılabilir.
      * Kullanıcı Kimlik Bilgilerini Saklama, Network API istekleri, Güvenli Parola Yönetimi, Secret Key Yöntemi, Hassas Veri İşleme gibi alanlarda kullanılabilir.
*/

#endregion

#region SecureString kullanımı

using System.Runtime.InteropServices;
using System.Security;

string cardNo = "1234 5678 9012 3456";
SecureString secureString = new();
cardNo.ToList().ForEach(c => secureString.AppendChar(c));
secureString.MakeReadOnly(); // SecureString nesnesini read-only ve immutable hale getirerek değişikliklere karşı koruma altına alırız.

#endregion

#region Veriye Erişim


#region 1. Yöntem

IntPtr bStr = Marshal.SecureStringToBSTR(secureString);
var value = Marshal.PtrToStringUni(bStr);

Console.WriteLine(value);

#endregion

#region 2. Yöntem

IntPtr bStr2 = Marshal.SecureStringToBSTR(secureString);
var value2 = Marshal.PtrToStringAuto(bStr2);

Console.WriteLine(value2);

#endregion

#region 3. Yöntem

IntPtr bStr3 = Marshal.SecureStringToBSTR(secureString);
char[] characters = new char[secureString.Length];
Marshal.Copy(bStr3, characters, 0, secureString.Length);
var value3 = string.Join(string.Empty, characters);
Marshal.ZeroFreeBSTR(bStr3);

Console.WriteLine(value3);

#endregion


#endregion