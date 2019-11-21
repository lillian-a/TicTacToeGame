using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class Program
    {
        /// Main
        /// <summary>Main starting class of the program</summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
        
        /// Testing
        /// <summary>Funcion used in testing Calculation class</summary>
        static void Testing()
        {
            // original lines for testing Calculations Class when on its' own
            //Console.WriteLine("Hello World!");
            //Calculations.Testing();
            //Console.ReadKey();
        }
    }
    
}
