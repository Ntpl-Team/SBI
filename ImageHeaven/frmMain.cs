using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageHeaven
{
    public partial class frmMain : Form
    {
        //static wItem wi;
        //NovaNet.Utils.dbCon dbcon;
        frmMain mainForm;
        //OdbcConnection sqlCon = null;
        //public Credentials crd;
        static int colorMode;
        //dbCon dbcon;

        //
        NovaNet.Utils.GetProfile pData;
        NovaNet.Utils.ChangePassword pCPwd;
        NovaNet.Utils.Profile p;
        public static NovaNet.Utils.IntrRBAC rbc;
        private short logincounter;
        //
        //OdbcTransaction txn;

        public static string projKey;
        public static string bundleKey;
        public static string projectName = null;
        public static string batchName = null;
        public static string boxNumber = null;
        public static string projectVal = null;
        public static string batchVal = null;

        public static string name;

        public static int height;
        public static int width;

        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            height = pictureBox1.Height;
            width = pictureBox1.Width;

            int k;
            //dbcon = new NovaNet.Utils.dbCon();
            try
            {
                string dllPaths = string.Empty;

                menuStrip1.Visible = true;
                //toolStrip1.Visible = false;



                AssemblyName assemName = Assembly.GetExecutingAssembly().GetName();
                this.Text = "B'Zer - SBI" + "           Version: " + assemName.Version.ToString();




            }
            catch (Exception dbex)
            {
                //MessageBox.Show(dbex.Message, "Image Heaven", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string err = dbex.Message;
                this.Close();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.nevaehtech.com/");
        }

        private void imageImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataImport frm = new frmDataImport();
            frm.ShowDialog(this);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExport frmExport = new frmExport();
            frmExport.ShowDialog(this);
        }

        private void batchExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatchExport frm = new frmBatchExport();
            frm.ShowDialog(this);
        }
    }
}
