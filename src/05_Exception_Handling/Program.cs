try
{
    while(true)
    {
        var key = Console.ReadKey();
        if(key.Key is ConsoleKey.A)
        {
            throw new CustomException("test");
        }
        else
        {

        }
    }
    int a = 1, b = 0;
    int c = a / b;
}

catch (Exception ex)
{

}

class CustomException : Exception
{
    public CustomException() : base("I'm a custom exception")
    {
    }

    public CustomException(string message) : base(message)
    {
    }
}