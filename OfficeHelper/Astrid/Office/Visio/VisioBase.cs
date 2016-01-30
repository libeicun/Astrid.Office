
using System;
using Microsoft.Office.Interop.Visio;





namespace Astrid.Office.Visio {
    public class VisioBase:OfficeBase {

        protected Document currentDoc;
        /// <summary>
        /// 
        /// </summary>
        protected static Application visio;
        
        public static  void StartVisio() {
            visio = new Application();
            visio.Visible = false;
        }

        public static  void ExitVisio() {
            if (visio != null) {
                visio.Quit();
            }
        }
    }
}
