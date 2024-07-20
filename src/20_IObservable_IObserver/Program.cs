MyObservable observable = new();

using var sub1 = observable.Subscribe(new MyObserver("a"));
using var sub2 = observable.Subscribe(new MyObserver("b"));
using var sub3 = observable.Subscribe(new MyObserver("c"));

observable.NotifyObservers(5);
observable.NotifyObservers(15);
observable.NotifyObservers(25);

class MyObservable : IObservable<int>
{
    private List<IObserver<int>> _observers = [];
    public IDisposable Subscribe(IObserver<int> observer)
    {
        if(!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }

        return new UnSubscription(() =>
        {
            _observers.Remove(observer);
            observer.OnCompleted();
        });
    }

    public void NotifyObservers(int value) => _observers.ForEach(observer => observer.OnNext(value));
}

class UnSubscription(Action unSubscription): IDisposable // (props) = constructor kısa tanımlaması 
{
    public void Dispose()
    {
        unSubscription?.Invoke(); // dispose edilince ilgili metodu çağır
        unSubscription = null; // bellek optimizasyonu için önemli
    }
}

class MyObserver(string observerName) : IObserver<int>
{
    public void OnCompleted() => Console.WriteLine($"Observer {observerName} takibi tamamlandı");

    public void OnError(Exception error) => Console.WriteLine($"{observerName} hata");

    public void OnNext(int value) => Console.WriteLine($"Observer {observerName} => {value}");
}
