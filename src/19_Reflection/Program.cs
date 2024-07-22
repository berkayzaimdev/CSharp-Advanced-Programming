using System.Reflection;
using System.Reflection.Emit;

#region Reflection Nedir?

// Reflection; runtime'da proje içerisindeki class, interface, delegate, struct, enum gibi tüm türlerin bilgilerine erişme ve bu bilgileri manipüle etmeye yarayan bir özelliktir.
// yani bir programın kendi yapıtaşlarını inceleme ve değiştirmeyi sağlayan bir özelliktir.

#endregion

#region Reflection'ın Amaçları
/*

   * Tip Bilgisi İnceleme: bir türün ismi, propertyleri, metotları, field'ları gibi bilgilerine erişmemizi sağlar. Böylece reflection, runtime'da tip hakkında dinamik kararlar almak veya tipin özelliklerine dinamik olarak erişmek için kullanılabilmektedir.
   * Yeni Bir Tip Oluşturma ve Yükleme: reflection, runtimeda yeni bir tür oluşturulmasına yahut var olan bir .dll dosyaındaki türün yüklenmesine olanak tanımaktadır. Bu sayede programın çalışma sürecinde ihtiyaç duyduğu türleri oluşturmak ve paket program yaklaşımı sergilemek için imkan kılmaktadır.
   * Member'ları Dinamik Çalıştırma: reflection ile runtime'da metot ya da property gibi member'ları çalıştırabilmekteyiz. Bu özellik sayesinde member'ları dinamik oalrak seçebilmekte ve operasyonlarımızı daha manevratik bir şekilde gerçekleştirebilmekteyiz
   
*/
#endregion

#region Reflection'ın Kullanım Senaryoları
/*

   * Yazılım Analizi ve Araç Geliştirme
   * Plugin ve Modül Sistemi: Reflection, dinamik olarak yüklenebilen ve kullanılan eklentileri veya modülleri yönetmek için kullanılabilir. Böylece belirli kontratları uyguladığı takdirde, runtime'da dinamik davranış sergileyebilen plugin(eklenti) tabanlı sistemler geliştirilebilir.
   * Data Serialize & Deserialize
   * Konfigürasyon Yönetimi: Reflection, özellikle yapılandırma dosyalarındaki bilgileri okuma ve bu bilgileri uygun nesnelere dönüştürme amacıyla kullanılabilir. Bu, yapılandıırma dosyalarındaki değişikliklere daha esnek bir şekilde yanıt verebilmeyi sağlar.
   * Unit Test framework'ları
   * Data Binding süreçleri
   * Dependency Injection: IoC oluşturmak için kullanılabilir.
   
*/
#endregion

#region Assembly nedir?

/*

   * Uygulamaya karşılık gelen ya da uygulamanın derlenmiş ve neticesinde .dll oluşturulmul halidir.
      * Compile-Time Assembly: Kaynak kodun derlenmesi sonucu oluşan .dll yahut .exe uzantılı dosyalardır.
      * Run-Time Assembly: Dinamik olarak oluşturulabilen ve yüklenebilen assembly'lerdir. Reflection ile hedefimiz burasıdır.

*/

#endregion

#region Assembly

/*
 
    * Assembly, uygulamaya karşılık gelen ya da uygulamanın derlenmiş ve neticesinde .dll olarak oluşturulmuş hali olarak nitelendirilebilir
       * Compile-Time Assembly: kaynak kodların derlenmesi sonucu elde edilen .dll yahut .exe dosyasıdır
       * Run-Time Assembly: dinamik olarak oluşturulabilen ve yüklenebilen assembly'lerdir. Reflection kütüphanesi yardımıyla biz bu tür Assembly'lerle ilgili olacağız.
    

    * Assembly sınıfı sayesinde;
       * uygulamadaki tüm meta datalara
       * modüllere (assembly'e eklediğimiz proje referansı)
       * türlere erişim sağlayabilir ve dinamik bir şekilde bunları yönetebiliriz
      
*/


Assembly startupAssembly = Assembly.GetEntryAssembly(); // startup project
Assembly assembly = Assembly.GetExecutingAssembly(); // şuan çalışmakta olan assembly
// Assembly assembly2 = Assembly.Load(assembly.Name); // load ile ismini verdiğimiz assembly'e erişebiliriz

#endregion

#region Type

var types = assembly.GetTypes(); 
var modules = assembly.GetModules(); // tekil olarak name vererek tek bir module alabiliriz

MyClass myObject = new();
var type1 = myObject.GetType();
var type2 = typeof(MyClass);
var type3 = assembly.GetType(nameof(MyClass));
// type1 == type2 == type3

#endregion

#region Bir class'ın member'larına erişme

Type type = typeof(MyClass);

// dizi olarak yahut tekil olarak member bilgisi alabiliriz. tekil alırken istediğimiz member'ın ismini nameof ile vermemiz gerekli
MemberInfo[] xMember = type.GetMember(nameof(MyClass.X));

MethodInfo xMethodd = type.GetMethod(nameof(MyClass.X));

PropertyInfo[] allProps = type.GetProperties();

FieldInfo[] allFields = type.GetFields();

FieldInfo bField = type.GetField(nameof(MyClass.b)); // sadece public olana erişebiliyoruz access modifier önemli

MemberInfo myProperty3 = type.GetField("MyProperty3", BindingFlags.NonPublic | BindingFlags.Instance); // nameof yerine metinsel olarak private member adını yazarsak ve bindingflag ile public olmayanları getir dersek bu mermber'a erişebilir, get ve set metotlarını uygulayabiliriz. bu yöntem büyük bir güvenlik açığı teşkil eder

#endregion

#region Bir property'nin değerini okuma ve değiştirme

Type myObjectType = myObject.GetType(); // type'ı alırken object sınıfının metodunu uygulayabiliriz

PropertyInfo prop = myObjectType.GetProperty(nameof(MyClass.MyProperty1));
prop.SetValue(myObject, 123); // öncelikle instance'ın GetType metodundan yararlanıyoruz. ardından aldığımız bu type'ı, property i almada kullanıyoruz. artık get-set metotlarını uygulayabiliriz fakat instance adını metot içerisinde belirtmemiz lazım

var value = prop.GetValue(myObject);

#endregion

#region Metot çalıştırma

MethodInfo xMethod = myObjectType.GetMethod(nameof(MyClass.X));
MethodInfo zMethod = myObjectType.GetMethod(nameof(MyClass.Z));

xMethod.Invoke(myObject, null); // parametreleri bir dizi olarak veriyoruz
zMethod.Invoke(myObject, ["asdasd",true]);

#endregion

#region DynamicMethod

// run-time'da metot oluşturmaya yarayan bir class'tır çok çok nadir kullanılır
DynamicMethod dynamicMethod = new(
    name: "MyDynamicMethod",
    returnType: typeof(bool),
    parameterTypes: [typeof(string), typeof(bool)],
    m: typeof(Program).Module
);

ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
ilGenerator.Emit(OpCodes.Ldarg_0);
ilGenerator.Emit(OpCodes.Ldarg_1);
ilGenerator.Emit(OpCodes.Add);
ilGenerator.Emit(OpCodes.Ret); // assembly dilinde olduğu gibi instruction yönetimi yaptık. dönüş değeri var/yok, parametre sayısı gibi

Func<string, bool, bool> methodDelegate = (Func<string, bool, bool>) dynamicMethod.CreateDelegate(typeof(Func<string, bool, bool>));

bool result = methodDelegate("asdasd",true);

#endregion

#region Private member'lara erişim

Type myClassType = typeof(MyClass);
var members = type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance); // private property'ler ve get-set metotları, private fieldlar, private metotlar ve private override'lar (memberwiseClone ve finalize gibi)

#endregion

Console.ReadLine();

class MyClass
{
    private string s;
    public bool b;

    public void X() => Console.WriteLine("X metodu");
    private void Y() => Console.WriteLine("Y metodu");
    public void Z(string s, bool b) => Console.WriteLine($"Z metodu -> {s} {b}");

    public int MyProperty1 { get; set; }
    protected int MyProperty2 { get; set; }
    int MyProperty3 { get; set; }   
}