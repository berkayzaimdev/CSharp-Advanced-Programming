/*
   * Lambda function'larla ilgili bir özelliktir.
   * Yapısal olarak bir delegate tarafından işaretlenmesi gereken metodun, basmakalıp olarak imzasının ve gövdesinin tanımlanmasından biz developer'ı kurtaran ve hızlı bir şekilde ilgili fonksiyonu oluşturarak daha düzgün ve estetik bir şekilde kodun geliştirilebilmesini sağlayan yapıdır
   
   * Fakat bu yapı, bellek optimizasyonu açısından istenmeyen bir duruma yol açmaktadır.
   * Bu maliyet, derleme neticesinde ortaya çıkan "Closure" sınıfının yol açtığı bir durumdur. Bu sınıf, tanımlamış olduğumuz lambda expression'ları normal birer metot olarak tanımlar. DisplayClass ön eki ile metotların bulunduğu sınıflar dahil edilir.
   * Lambda'nın kullanıldığı sınıftan yeni bir instance oluşturulup metot çağrısı yapılır. Bu durum bir allocation problemine yol açar
   * Döngüsel durumlar gibi senaryolarda tetiklenme sayısı kadar nesne oluşturulacağından dolayı GC açısından pek iç açıcı bir durum teşkil edilmez.
*/

int a = 5; // değişkenlerin dışarıda tanımlanması instance üretimine sebebiyet vereceği için belleği bir hayli yorar 
Action action = () =>
{
    int a = 5; // değişkenlerin içeride tanımlanması, dışarıda tanımlanmasından daha az maliyetlidir. static field olarak bir tanımlamaya oluşturur, a'yı bu field'dan çağrımak da bellek yönetimini daha optimize hale getirir.
    a *= 5;
};

action();

static int b = 10;
const int c = 10; // const değişkenler, arkaplanda statik birer yapılanmadır
Action optimisedAction = static () => { // static anonymous function tanımlayarak bu bellek maliyetinden kurtulabiliriz. dikkat etmemiz gereken şu ki; statik yapılanmalarda ancak ve ancak statik bileşenler yer alabilir. Değişkenlerimizi buna göre ayarlamamız önemli
    b = 20;
    c = 30;
};