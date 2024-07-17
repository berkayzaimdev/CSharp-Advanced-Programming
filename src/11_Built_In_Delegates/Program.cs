#region Action

// Action<T1,T2,...,Tn> ---> dönüş değeri yok
Action action1 = () => Console.WriteLine("I'm an action!");
Action<string> action2 = (s) => Console.WriteLine("I'm an generic action 1!");
Action<bool, string> action3 = (b, s) => Console.WriteLine("I'm an generic action 2!");

#endregion

#region Func

// Func<T1,T2,...,Tn> ---> parametreler (T1,T2,...Tn-1), dönüş değeri Tn
Func<string> func1 = () => "I'm a function!";
Func<bool, string, bool> func2 = (b, s) => true;

#endregion

#region Predicate

Predicate<int> predicate1 = i => i > 0; // pozitif mi
Predicate<string> predicate2 = s => s.Contains(" "); // space var mı

Console.WriteLine("Result without space: "+ predicate2("asdasd"));
Console.WriteLine("Result with space: "+ predicate2("   "));

#endregion