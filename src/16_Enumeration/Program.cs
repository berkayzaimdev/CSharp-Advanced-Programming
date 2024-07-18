using System.Collections;

var numbers = Enumerable.Range(0, 15).ToList();
foreach(var number in numbers)
{
    //numbers.Remove(number); // iterasyonel bir mekanizmada çalışırken, kaynak o an için değişmez olmalıdır. bu kod satırı hata fırlatacaktır
}

Stock s = new Stock();
foreach (var element in s)
{
    //numbers.Remove(number); // iterasyonel bir mekanizmada çalışırken, kaynak o an için değişmez olmalıdır. bu kod satırı hata fırlatacaktır
}

class Stock
{
    List<string> materials = new List<string>()
    {
        "kalem",
        "defter",
        "silgi"
    };

    public IEnumerator GetEnumerator()
    {
        return null;
    }
}