using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace password
{
    class Program
    {
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            Microsoft.Win32.RegistryKey Key =
            Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
            @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\", true);
            Key.SetValue("password", "F:\\MyProgramm\\password\\password\\bin\\Release\\password.exe");
            Key.Close();
            for (long i = -9223372036854775808; i < 9223372036854775807; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Привет!");
            }
        }
    }
}
