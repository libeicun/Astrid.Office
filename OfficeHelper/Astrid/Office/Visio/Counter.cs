using Microsoft.Office.Interop.Visio;
using System.IO;
namespace Astrid.Office.Visio {
    public class Counter: VisioBase {
        public void Open(string path) {
            path = BuildFilePath(path);
            Trace("Opening " + path, true);
            Document doc = visio.Documents.Open(path);
            currentDoc = doc;
        }
        public Document OpenEx(string path) {
            Open(path);
            return currentDoc;
        }
        public void Close() {
            currentDoc.Close();
        }
        public void CloseEx(Document doc) {
            doc.Close();
        }


        public int CountInAllShapes(Document doc, string keyword) {
            return CountInAllShapes(doc, keyword, true);
        }
        public int CountInAllShapes(Document doc, string keyword, bool equals) {
            if (keyword.EndsWith("\r")) {
                keyword = keyword.Replace("\r","");
            }
            Trace(keyword + ",", false);
            int count = 0;
            foreach (Page page in doc.Pages) {
                foreach (Shape shape in page.Shapes) {
                    string text = shape.Text;
                    if (equals? text.Equals(keyword):text.Contains(keyword)) {
                        count++;
                    }
                }
            }
            Trace(count.ToString(), true);
            Info(keyword + "," + count.ToString());
            Debug("完成:" + doc.Path + doc.Name + " - 关键词:" + keyword);
            if (count == 0) {
                Error(doc.Path + doc.Name + " 未找到 " + keyword);
            }
            return count;
        }
        public int[] CountInAllShapes(Document doc, string[] keywords, bool equals) {
            int size = keywords.Length;
            int[] count = new int[size];
            for (int i = 0; i < size; i++) {
                count[i] = CountInAllShapes(doc, keywords[i], equals);
            }
            return count;
        }
        public int[] CountInAllShapes(Document doc, string[] keywords) {
            return CountInAllShapes(doc, keywords, true);
        }
        public int CountInAllShapes(string keyword) {
            return CountInAllShapes(currentDoc, keyword);
        }
        public int CountInAllShapes(string keyword, bool equals) {
            return CountInAllShapes(currentDoc, keyword, equals);
        }
        public int[] CountInAllShapes(string[] keywords, bool equals) {
            return CountInAllShapes(currentDoc,keywords, equals);
        }
        public int[] CountInAllShapes(string[] keywords) {
            return CountInAllShapes(currentDoc, keywords);
        }
        public int[] CountInAllShapesEx(string keywordFile) {
            string path = BuildFilePath(keywordFile);
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            TextReader reader = new StreamReader(file, System.Text.Encoding.Default);
            string[] keywords = reader.ReadToEnd().Replace(',','\n').Split('\n');
            Debug("指定关键词文件:" + path);
            Debug("读取关键词 ...");
            foreach (string kw in keywords) {
                Debug(kw);
            }
            int [] counts = CountInAllShapes(keywords);
            Debug("完成");
            return counts;
        }


    }
}
