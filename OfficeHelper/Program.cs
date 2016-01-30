using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Astrid.Office.Visio;

namespace Astrid.OfficeHelper {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {


            //Facade visio = new Facade();
            //visio.TraceEnabled = true;
            //visio.TraceFile = "x.csv";
            //visio.AddTrace(System.Console.Out);
            //visio.AddTrace(System.Console.Error);
            //visio.Open("2006.vsdx");
            //int count = visio.CountInAllShapes("管理因素");
            //visio.Close();
            //Facade.Finished();

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
