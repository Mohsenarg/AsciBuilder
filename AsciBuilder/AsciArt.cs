using System.Runtime.InteropServices;
using Figgle;

namespace AsciBuilder
{
    //Befor use install figgle package from nuget : Install-Package Figgle
    /// <summary>
    /// Gui For Console
    /// </summary>
    internal static class AsciArt
    {
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_CLOSE = 0xF060;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private static int textMargin;
        /// <summary>
        /// insert margin before asci text
        /// </summary>
        public static int TextMargin
        {
            get { return textMargin; }
            set 
            {
                if (value>0 && value<=50)
                {
                    textMargin = value;
                }
                else
                {
                    throw new Exception("Text Size Only can be set between 1 t0 10");
                }
               
            }   
        }
        public static Dictionary<string,char> CustomShape { get; set; }

        private static int textWidth { get; set; }
        /// <summary>
        /// baner text that changed to asci
        /// </summary>
        public static string BanerText { get; set; }
        /// <summary>
        /// Disable the menu customize
        /// </summary>
        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        /// <summary>
        /// Disable the menu customize
        /// </summary>
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        /// <summary>
        /// Disable the menu customize
        /// </summary>
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        /// <summary>
        /// Create baner
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="txt"></param>
        internal static void PrintBaner(FiggleFont fi, string txt)
        {
            BanerText = txt;
            string figgle = fi.Render(BanerText);
            string[] t = figgle.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            System.Text.StringBuilder sp = new System.Text.StringBuilder();
            for (int i = 0; i <=TextMargin; i++)
                sp.Append(" ");
            List<string> listT = new List<string>(10);
            listT = t.ToList();
            for (int i=0; i<listT.Count;i++)
            {
                if(i == 0)
                {
                    listT[i]= "██" + sp.ToString() + listT[i] + sp.ToString() + "██";
                    textWidth = listT[i].Length;
                    System.Text.StringBuilder spt = new System.Text.StringBuilder();

                    for (int x = 0; x < listT[i].Length/2; x++)
                    {
                        spt.Append("██");
                    }
                    listT.Insert(0, spt.ToString());
                    i++;
                }
                else if (i+2 == listT.Count)
                {
                    listT[i] = "██" + sp.ToString() + listT[i] + sp.ToString() + "██";
                    System.Text.StringBuilder spt = new System.Text.StringBuilder();
                    for (int x = 0; x < listT[i].Length/2; x++)
                    {
                        spt.Append("██");
                    }
                    listT.Insert(i+1, spt.ToString());
                    
                    i=i+2;
                }
                else
                {
                    listT[i] = "██" + (sp.ToString() + listT[i].ToString() + sp.ToString()) + "██";
                }
            }
            string[] rA = listT.ToArray();
            string Baner = string.Join("\r\n", rA);


            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            Console.WriteLine(Baner);
        }
        /// <summary>
        /// Create baner
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="txt"></param>
        internal static void PrintBaner(FiggleFont fi)
        {

            string figgle = fi.Render(BanerText);
            string[] t = figgle.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            System.Text.StringBuilder sp = new System.Text.StringBuilder();
            for (int i = 0; i <= TextMargin; i++)
                sp.Append(" ");
            List<string> listT = new List<string>(10);
            listT = t.ToList();
            for (int i = 0; i < listT.Count; i++)
            {
                if (i == 0)
                {
                    listT[i] = "██" + sp.ToString() + listT[i] + sp.ToString() + "██";
                    textWidth = listT[i].Length;
                    System.Text.StringBuilder spt = new System.Text.StringBuilder();

                    for (int x = 0; x < listT[i].Length / 2; x++)
                    {
                        spt.Append("██");
                    }
                    listT.Insert(0, spt.ToString());
                    i++;
                }
                else if (i + 2 == listT.Count)
                {
                    listT[i] = "██" + sp.ToString() + listT[i] + sp.ToString() + "██";
                    System.Text.StringBuilder spt = new System.Text.StringBuilder();
                    for (int x = 0; x < listT[i].Length / 2; x++)
                    {
                        spt.Append("██");
                    }
                    listT.Insert(i + 1, spt.ToString());

                    i = i + 2;
                }
                else
                {
                    listT[i] = "██" + (sp.ToString() + listT[i].ToString() + sp.ToString()) + "██";
                }
            }
            string[] rA = listT.ToArray();
            string Baner = string.Join("\r\n", rA);


            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            Console.WriteLine(Baner);
        }
        /// <summary>
        /// Print Line Space
        /// </summary>
        internal static void PrintLineSpace()
        {
            System.Text.StringBuilder sbl = new System.Text.StringBuilder();
            for (int i = 0; i < textWidth/2; i++)
                sbl.Append("██");


            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            Console.Write('\n'+ sbl.ToString() + '\n');
        }
        /// <summary>
        /// Print When you Have Text 
        /// </summary>
        /// <param name="txt"></param>
        internal static void PrintLine(string txt)
        {
            System.Text.StringBuilder sbs = new System.Text.StringBuilder();
            for (int i = 0; i < (textWidth - txt.Length) - 7; i++)
                sbs.Append(" ");
            System.Text.StringBuilder sbl = new System.Text.StringBuilder();
            for (int i = 0; i < textWidth - 4; i++)
                sbl.Append(" ");
            Console.Write("██" + sbl.ToString() + "██" + '\n');
            Console.Write("██" + "   " + txt + sbs.ToString() + "██");
            Console.Write('\n' + "██" + sbl.ToString() + "██");
            PrintLineSpace();
        }
        /// <summary>
        /// Print When you Have Text & Not Have Line in First 
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="WithoutFSpace"></param>
        internal static void PrintLine(string txt, bool WithoutFSpace)
        {
            if (WithoutFSpace)
            {
                System.Text.StringBuilder sbs = new System.Text.StringBuilder();
                for (int i = 0; i < (textWidth - txt.Length) - 7; i++)
                    sbs.Append(" ");
                System.Text.StringBuilder sbl = new System.Text.StringBuilder();
                for (int i = 0; i < textWidth - 4; i++)
                    sbl.Append(" ");


                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
                Console.Write("██" + sbl.ToString() + "██" + '\n');
                Console.Write("██" + "   " + txt + sbs.ToString() + "██");
                Console.Write('\n' + "██" + sbl.ToString() + "██");
                PrintLineSpace();
            }
            else
            {
                PrintLineSpace();
                System.Text.StringBuilder sbs = new System.Text.StringBuilder();
                for (int i = 0; i < (textWidth - txt.Length) -7; i++)
                    sbs.Append(" ");
                System.Text.StringBuilder sbl = new System.Text.StringBuilder();
                for (int i = 0; i < textWidth-4; i++)
                    sbl.Append(" ");


                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
                Console.Write("██"+sbl.ToString()+"██" + '\n');
                Console.Write("██" + "   " + txt + sbs.ToString() + "██");
                Console.Write('\n' + "██" + sbl.ToString() + "██");
                PrintLineSpace();
            }
        }
    }
}
