using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Visio;

namespace Astrid.Office.Visio {
    public class Merger:VisioBase {
        public Merger():this("default.asdx") {
        }
        public Merger(string targetPath) {
            TargetFileName = targetPath;
        }


        ~Merger() {
        }



        private string filePath;
        public string TargetFileName {
            set {
                filePath = BuildFilePath(value);
            }
            get {
                return filePath;
            }
        }
        
        private string GetAnAvailablePageName(string name) {
            foreach (Page p in currentDoc.Pages) {
                if (p.Name.Equals(name)){
                    name += "-R";
                }
            }
            return name;
        }
        public void Add(string path) {
            InitDocumentIfNeeded();
            path = BuildFilePath(path);
            Document doc = null;

            try {
                doc = visio.Documents.Open(path);
                Debug("打开文档:" + path);
                foreach(Page src in doc.Pages) {
                    Page newPage = currentDoc.Pages.Add();
                    string newName = GetAnAvailablePageName(src.Name);
                    Info("开始复制页面:" + src.Name + " 到 " + newName);
                    CopyPage(src, newPage, newName);
                }
                doc.Close();
                Debug("关闭文档:" + path);
            }
            catch(Exception e) {
                Error(e.Message);
            }

        }
        public void Add(string[] paths) {
            foreach (string path in paths) {
                Add(path);
            }
        }
        public void Close() {
            currentDoc.SaveAs(TargetFileName);
            currentDoc.Close();
            Debug("成功地保存合并后的文件到:" + TargetFileName);
        }


        private void CopyPage(Page src, Page dest, string name) {
            foreach (Shape shape in src.Shapes) {
                //System.Threading.Thread.Sleep(500);
                string str = "[文本:" + shape.Text + "][类型:" + shape.Style + "][线型:" + shape.LineStyle + "]";
                try {

                    shape.Copy(VisCutCopyPasteCodes.visCopyPasteNoTranslate);
                    dest.Paste(VisCutCopyPasteCodes.visCopyPasteNoTranslate);
                    Info("成功地复制了形状 - " + str);
                } catch (Exception e) {
                    string error = "在 " + src.Document.Name + " - " + src.Name + " : 无法复制形状 - " + str;
                    Trace(error, true);
                    Error(error);
                    Error(e.Message);
                }
            }
            dest.AutoSize = true;
            dest.Name = name;
        }

        private void InitDocumentIfNeeded() {
            if (currentDoc == null) {
                currentDoc = visio.Documents.Add("");
            }
        }
    }
}
