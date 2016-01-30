using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astrid.OfficeHelper {
    public partial class MergerSetting : Form {
        public MergerSetting() {
            InitializeComponent();
        }

        private void cmdSelectFiles_Click(object sender, EventArgs e) {
            DialogResult r = openFileDialog.ShowDialog();
            if (r == DialogResult.OK) {
                FileNames = openFileDialog.FileNames;
                txtFiles.Clear();
                foreach (string file in FileNames) {
                    txtFiles.AppendText(file + "\r\n");
                }
            }
            
        }


        public string[] FileNames;

        private void MergerSetting_Load(object sender, EventArgs e) {

        }

        private void cmdExcute_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
