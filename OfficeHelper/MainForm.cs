using System;
using Astrid.Office.Visio;
using Astrid.Clipboard;
using System.Windows.Forms;

namespace Astrid.OfficeHelper {
    public partial class MainForm : Form {




        public MainForm() {
            InitializeComponent();

            mergerBackgroundWorker.DoWork += MergerBackgroundWorker_DoWork;
            counterBackgroundWorker.DoWork += counterBackgroundWorker_DoWork;
            


        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void MainForm_Load(object sender, EventArgs e) {
            VisioBase.ExitVisio();
            VisioBase.StartVisio();
            VisioBase.Directory = "f:\\test\\faulttree";
        }

        private void visioMergerToolStripMenuItem_Click(object sender, EventArgs e) {
            mergerBackgroundWorker.RunWorkerAsync();
        }

        private void MergerBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {

            MergerSetting settings = new MergerSetting();
            DialogResult r = settings.ShowDialog(this);
            if (r == DialogResult.OK) {
                Trace("选择文件:");
                Trace(settings.FileNames);
                Merger merger = new Merger("merge2006-2013.vsdx");
                merger.TextInfo = txtInfo;
                merger.TextError = txtError;
                merger.TextDebug = txtDebug;
                merger.Add(settings.FileNames);
                merger.Close();
                Trace("完成");
            }
            else {
                Trace("取消了操作");
            }
        }

        private void mergerBackgroundWorker_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e) {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            counterBackgroundWorker.CancelAsync();
            mergerBackgroundWorker.CancelAsync();
            VisioBase.ExitVisio();
        }

        private void visioSearcherToolStripMenuItem_Click(object sender, EventArgs e) {
            counterBackgroundWorker.RunWorkerAsync();
        }

        private void counterBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            Counter counter = new Counter();
            counter.TextInfo = txtInfo;
            counter.TextDebug = txtDebug;
            counter.TextError = txtError;
            counter.Open("2006.vsdx");
            counter.CountInAllShapesEx("keywords.txt");
        }

        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void txtError_TextChanged(object sender, EventArgs e) {

        }

        private void txtOutput_TextChanged(object sender, EventArgs e) {

        }

        private void Trace(string str) {
            txtOutput.AppendLine(str);
            txtOutput.ForeColor = System.Drawing.Color.Blue;
            txtOutput.BackColor = System.Drawing.Color.Black;
        }
        private void Trace(string[] strs) {
            foreach (string str in strs) {
                Trace(str);
            }
        }

        ClipboardWatcher cbWatcher = new ClipboardWatcher();
        private void monitorToolStripMenuItem_Click(object sender, EventArgs e) {
            cbWatcher.TextDisplay = this.txtDebug;
        }

        private void unmonitorToolStripMenuItem_Click(object sender, EventArgs e) {
            cbWatcher.TextDisplay = null;
        }
    }
}
