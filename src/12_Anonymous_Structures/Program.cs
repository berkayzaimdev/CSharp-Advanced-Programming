#region Anonymous Objects

var anonymousObject1 = new
{
    A = "asdfsaf",
    B = (short)1231
};

// anonymousObject1.A = "gjfkjfgk"; // readonly olduğu için değiştirilemez

#endregion

#region Anonymous Methods

//Topla a1 = new Topla((s1, s2) => s1 + s2); // tüm lambda ifadeleri birer anonymous metottur
//Topla a2 = (s1, s2) => s1 + s2;
//Topla a3 = delegate (int s1, int s2) // eski tip tanımlama
//{
//    return s1 + s2;
//};

//var a4 = () => Console.Write("Hello world"); // var kullanımı neticesinde compiler, bu değişkeni uygun bir delegate'e atar

//delegate int Topla(int sayi1, int sayi2);

#endregion

#region Anonymous Collection

// Array
var arr1 = new[] { 3, 7 }; //int[]
var arr2 = new[] { 1, 2, 3, 2.2 }; // double[]

// List
//var col1 = new Collection()
//{
//    new {A = 2},
//    new {B = 3}
//};

#endregion