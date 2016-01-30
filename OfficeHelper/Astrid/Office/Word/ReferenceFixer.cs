using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Astrid.Office.Word {
    class ReferenceFixer:WordBase {
        protected static string DEFAULT_REFERENCE_PREFIX = "文献";

        public void Fix(string fileName) {
            StartApp();
            
            OpenDoc(fileName);



            CloseDoc();

            QuitApp();
        }
    }
}
