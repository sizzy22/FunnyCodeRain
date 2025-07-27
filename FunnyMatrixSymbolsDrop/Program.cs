namespace FunnyMatrixSymbolsDrop
{
    class Program
    {
        static char[] symbsArr = "QWERTYUIOP[]ASDFGHJKL;'ZXCVBNM,.1234567890".ToCharArray();
        static CodeRain codeRain = new CodeRain(237, 63, symbsArr);
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                
                codeRain.OnFrame();
            }
        }
    }
}
