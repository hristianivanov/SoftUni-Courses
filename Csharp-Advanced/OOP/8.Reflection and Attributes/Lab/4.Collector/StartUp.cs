namespace Stealer
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(   spy.GetMethodType("Stealer.Hacker", "DownloadAllBankAccountsInTheWorld"));
            string result = spy.CollectGetterAndSetter("Stealer.Hacker");
            Console.WriteLine(result);

        }
    }
}
