using System;
using System.Windows.Forms;
using WindowsFormsApp;

namespace Main
{
    public class Program
    {
        
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Window w = new Window();
            Application.Run(w);
            
        }
        
    } 
}