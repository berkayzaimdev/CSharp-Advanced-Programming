// Bir sınıf ya da interface'e, kendi içerisindeki herhangi bir metot tanımının dışında, farklı bir yerde tanımlanmış olan bir metot eklemek istediğimizde kalıtım/extension metot yöntemlerini kullanıyoruz

// Hazır sınıflara müdahale etmek için extension metot yöntemini kullanırız. Yazılmış olan ya da kütüphane yardımıyla uygulamamıza eklenen sınıflara yeni metotlar kazandırabiliyoruz

/*

   * Mevcut bir sınıfın işlevselliğini genişletmek,
   * 3rd Party kütüphanelerle uyum sağlamak,
   * Daha okunabilir kod sağlamak,
   * Kod tekrarını azaltmak; extension metodun işlevleri olarak sayılabilir.
   
*/

string s = "www google com";

s = s.JoinWithDots();
Console.WriteLine(s);

static class StringExtensions // class mutlaka static olmalı
{
    public static string JoinWithDots(this string instance) // metot mutlaka static olmalı ve this keyword'ünü içermeli
    {
        return instance.Replace(' ', '.');
    }
}