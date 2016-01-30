using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
namespace Astrid.Office.Word {
    class WordBase:OfficeBase {
        protected Document currentDoc;
        /// <summary>
        /// 
        /// </summary>
        protected static Application word;

        public static void StartApp() {
            word = new Application();
            word.Visible = false;
        }

        public static void QuitApp() {
            if (word != null) {
                word.Quit();
            }
        }

        public void CloseDoc(Document doc) {
            doc.Close();
        }
        public void CloseDoc() {
            CloseDoc(currentDoc);
        }
        public Document OpenDocEx(string fileName) {
            OpenDoc(fileName);
            return currentDoc;
        }
        public void OpenDoc(string fileName) {
            fileName = BuildFilePath(fileName);
            currentDoc = word.Documents.Open(fileName);
        }
        
    }
}
