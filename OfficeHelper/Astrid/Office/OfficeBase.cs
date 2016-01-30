using System;
using System.IO;
using System.Windows.Forms;
using Astrid.Common.UI;

namespace Astrid.Office {
    public abstract class OfficeBase {
        /// <summary>
        /// 主要文本输出文件。
        /// </summary>
        private FileStream file;
        /// <summary>
        /// 对应主要文本输出文件的文本输出器。
        /// </summary>
        private TextWriter fileWriter;
        private TextDisplay error, info, debug;

        /// <summary>
        /// 当前工作目录。
        /// </summary>
        protected static string workdingDirectory = Environment.CurrentDirectory;

        public static string Directory {
            set {
                if (workdingDirectory.EndsWith("\\")) {
                    throw new ApplicationException("Invalid path. A path should not include '\\'.");
                }
                if (!workdingDirectory.Contains(":")) {
                    throw new ApplicationException("Invalid path. A path should include its volume label.");
                }
                workdingDirectory = value;
            }
        }
        protected string BuildFilePath(string fileName) {
            if (fileName.Contains(":") && fileName.Contains("\\")) {
                return fileName;
            }
            return workdingDirectory + "\\" + fileName;
        }
        public string TraceFile {
            set {
                if (!value.Contains(".")) {
                    throw new ApplicationException("You'd better not create a file without an extension.");
                }
                file = new FileStream(workdingDirectory + "\\" + value, FileMode.Create, FileAccess.Write);
                fileWriter = new StreamWriter(file);
                ((StreamWriter)fileWriter).AutoFlush = true;
            }
        }
        public TextDisplay TextDebug {
            set {
                debug = value;
            }
        }
        public TextDisplay TextInfo {
            set {
                info = value;
            }
        }
        public TextDisplay TextError {
            set {
                error = value;
            }
        }
        protected void Trace(string str, bool crlf) {
            string s = "";
            if (crlf) {
                s = str + "\n";
            }
            else {
                s = str;
            }
            if (fileWriter != null) {
                fileWriter.Write(s);
            }
        }
        private void fuck(TextDisplay text, string str) {
            text.AppendLine(str);
        }
        protected void Debug(string str) {
            if (debug != null) {
                if (!debug.InvokeRequired) {

                }
                fuck(debug, str);
                debug.ForeColor = System.Drawing.Color.White;
                debug.BackColor = System.Drawing.Color.Black;
            }
        }
        protected void Info(string str) {
            if (info != null) {
                if (!info.InvokeRequired) {

                }
                fuck(info, str);
                info.ForeColor = System.Drawing.Color.Green;
                info.BackColor = System.Drawing.Color.Black;
            }
        }
        protected void Error(string str) {
            if (error != null) {
                if (error.InvokeRequired) {
                }
                else {

                }
                fuck(error, str);
                error.ForeColor = System.Drawing.Color.Red;
                error.BackColor = System.Drawing.Color.Black;
            }
        }
        
               
    }
}
