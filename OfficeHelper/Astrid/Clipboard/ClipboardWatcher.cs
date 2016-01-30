using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Astrid.Common.UI;
using System.ComponentModel;

namespace Astrid.Clipboard {
    class ClipboardWatcher: Form {
        private TextDisplay text;
        public TextDisplay TextDisplay {
            set {


                text = value;
            }
        }
        protected void TextShow(string str) {
            TextShow(str, System.Drawing.Color.Green);
        }
        protected void TextShow(string str, System.Drawing.Color color) {
            if (text != null) {
                text.AppendLine(str);
                text.BackColor = System.Drawing.Color.Black;
                text.ForeColor = color;
            }
            
        }

        public ClipboardWatcher() {
            try {
                AddClipboardFormatListener(this.Handle);
            }
            catch (Win32Exception e) {
                MessageBox.Show(e.Message);
            }


        }
        ~ClipboardWatcher() {
            try {
                RemoveClipboardFormatListener(this.Handle);
            }
            catch (Exception e) {
            }
        }

        /****************引入系统相关API******************/
        [DllImport("user32.dll")]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
        private static int WM_CLIPBOARDUPDATE = 0x031D;

        private bool noNeedToMonitor = false;
        protected override void DefWndProc(ref Message m) {
            if (m.Msg == WM_CLIPBOARDUPDATE) {
                try {
                    //根据.net自带Clipboard类，获取裁切板中的数据
                    if (!noNeedToMonitor) {
                        if (System.Windows.Forms.Clipboard.ContainsText()) {
                            string org = System.Windows.Forms.Clipboard.GetText();
                            string trans = Common.Utils.String.RemoveSpacesOfHead(org);
                            trans = trans.Substring(0, 1).ToUpper() + trans.Substring(1).ToLower();
                            TextShow("---------------------------------->");
                            TextShow("原始:", System.Drawing.Color.Red);
                            TextShow(org);
                            TextShow("转换【已设置到剪切板】:", System.Drawing.Color.Red);
                            TextShow(trans);
                            TextShow("<----------------------------------");

                            noNeedToMonitor = true;
                            //System.Windows.Forms.Clipboard.SetText(trans);


                        }
                    }
                    else {
                        noNeedToMonitor = false;
                    }
                }
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
            else {
                base.DefWndProc(ref m);
            }
        }


        
    }
}
