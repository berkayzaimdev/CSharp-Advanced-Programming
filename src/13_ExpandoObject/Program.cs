using System.Dynamic;
using System.Text.Json;

dynamic person1 = new ExpandoObject(); // expandoObject IDictionary<string, object> interface'ini implemente eder, bu sayede sahip olduğu property'leri key-value ikilisi olarak saklayabilir. (propName - propValue)

person1.Name = "Berkay";
person1.Surname = "Zaim";
person1.Age = 23;
//person1.YearOfBirth = new Func<int>(() => DateTime.Now.Year - person1.Age);

dynamic person2 = new ExpandoObject();
person1.Name = "Ahmet";
person1.Surname = "Mehmet";
person1.Age = 30;

dynamic person3 = new ExpandoObject();
person1.Name = "Mustafa";
person1.Surname = "Ali";
person1.Age = 35;

List<ExpandoObject> list = new()
{
    person1,
    person2,
    person3
};

var jsonData = JsonSerializer.Serialize(list); // hepsi aynı property'lere sahip expandoobject'ler olmalıdır

dynamic data = JsonSerializer.Deserialize<List<ExpandoObject>>(jsonData); // dynamic keyword ile işaretleme yapılır

var test = true;