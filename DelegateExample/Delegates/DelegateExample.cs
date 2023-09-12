namespace DelegateExample.Delegates
{
    public class DelegateExamples
    {
        //Declare delegate
        delegate void LogDel(string text);

        public void Main()
        {
            Log log = new Log();

            LogDel LogTextToScreen, LogTextToFile;

            LogTextToScreen = new LogDel(log.LogTextToScreen);
            LogTextToFile = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogTextToScreen + LogTextToFile;

            Console.WriteLine("Please enter your name:");

            var name = Console.ReadLine()!;

            LogText(multiLogDel, name);
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }

    }
}
