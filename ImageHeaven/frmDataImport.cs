using System;
using System.Drawing;
using System.Windows.Forms;
using NovaNet.Utils;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace ImageHeaven
{
    public partial class frmDataImport : Form
    {
        MemoryStream stateLog;
        byte[] tmpWrite;
        NovaNet.Utils.dbCon dbcon;
        int pos = 0;
        int posAdd = 0;
        OdbcConnection sqlCon = null;
        DataSet ds = null;
        private double ZOOMFACTOR = 1.10;   // = 25% smaller or larger
        private int MINMAX = 5;
        Point mouseDown = new Point();
        private Size ImageSize = new Size(100, 200);
        Credentials crd = new Credentials();
        //OdbcTransaction sqlTrans = null;
        private Dictionary<string, ListViewItem> ListViewItems = new Dictionary<string, ListViewItem>();
        private Dictionary<string, ListViewItem> ListViewItems1 = new Dictionary<string, ListViewItem>();
        public frmDataImport()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabPage3);
        }
        private void KeyEvent(object sender, KeyEventArgs e) //Keyup Event 
        {
            if (tabControl1.SelectedIndex == 0 && lstPolicy.SelectedItems.Count > 0 && e.KeyCode == Keys.Add)
            {
                cmdAdd_Click(this, e);
            }
            if (tabControl1.SelectedIndex == 0 && (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown))
            {
                tabControl1.SelectedIndex = 0;
            }
            if (tabControl1.SelectedIndex == 1 && (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown))
            {
                tabControl1.SelectedIndex = 0;
            }
            if (tabControl1.SelectedIndex == 0 && lstSelImg.Items.Count > 0 && lstSelImg.SelectedItems.Count > 0 && e.KeyCode == Keys.Subtract)
            {
                cmdRemove_Click(this, e);
            }
            if (tabControl1.SelectedIndex == 0 && e.KeyCode == Keys.F5)
            {
                cmdImport_Click(this, e);
            }
            if (tabControl1.SelectedIndex == 1 && lstCheckDeed.SelectedItems.Count > 0 && e.KeyCode == Keys.Add)
            {
                cmdadd1_Click(this, e);
            }
            if (tabControl1.SelectedIndex == 1 && lstSelectedImg.Items.Count > 0 && lstSelectedImg.SelectedItems.Count > 0 && e.KeyCode == Keys.Subtract)
            {
                cmdremove1_Click(this, e);
            }
            if (tabControl1.SelectedIndex == 1 && lstCheckDeed.SelectedItems.Count > 0 && e.KeyCode == Keys.F5)
            {
                CmdFinalSave_Click(this, e);
            }
        }
        private void frmDataImport_Load(object sender, EventArgs e)
        {
           this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);
           // PopulateProjectCombo();
           // cmdBrowse.Enabled = false;
        }

        private void frmDataImport_KeyUp(object sender, KeyEventArgs e)
        {

        }
        void picMain_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (e.Delta < 0)
            //{
            //    ZoomIn();
            //}
            //else
            //{
            //    ZoomOut();
            //}

        }
        public void ResizeImg(string path, Image img, int size)
        {
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, size);
            ImageCodecInfo encoderInfo = GetEncoderInfo(ImageFormat.Jpeg);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, encoderInfo, encoderParams);
            //img.Save(txtPath.Text,ImageCodecInfo.;
        }
        public ImageCodecInfo GetEncoderInfo(ImageFormat imageFormat)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == imageFormat.Guid)
                    return codec;
            }

            // Find the correct image codec 
            //for (int i = 0; i < codecs.Length; i++)
            //    if (codecs[i].MimeType == mimeType)
            //        return codecs[i];

            return null;
        }
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                lblinfo.Text = "";
                List<string> fileNames = new List<string>();
                List<string> tempPath = new System.Collections.Generic.List<string>(1000);


                lstPolicy.Items.Clear();
                lstCheckDeed.Items.Clear();
                lstAddlPages.Items.Clear();

                fbdPath.ShowDialog();
                txtPath.Text = fbdPath.SelectedPath;
                DirectoryInfo selectedPath = new DirectoryInfo(txtPath.Text);


                //if (Path.GetFileName(txtPath.Text) == cmbBatch.Text.Trim())
                //{
                //    cmdImport.Enabled = true;
                //    CmdFinalSave.Enabled = true;
                //}
                //else
                //{

                //    cmdImport.Enabled = false;
                //    CmdFinalSave.Enabled = false;
                //    MessageBox.Show(this, "Please select proper image folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                lstPolicy.Items.Add("KYC");
                lstPolicy.Items.Add("Income");
                lstPolicy.Items.Add("TVR");
                lstPolicy.Items.Add("Property");
                lstPolicy.Items.Add("Executed_loan");
                lstPolicy.Items.Add("PSS_reports");
                lstPolicy.Items.Add("Others");

                lstCheckDeed.Items.Add("KYC");
                lstCheckDeed.Items.Add("Income");
                lstCheckDeed.Items.Add("TVR");
                lstCheckDeed.Items.Add("Property");
                lstCheckDeed.Items.Add("Executed_loan");
                lstCheckDeed.Items.Add("PSS_reports");
                lstCheckDeed.Items.Add("Others");


                //if (Directory.Exists(txtPath.Text + "\\Backup"))
                //{
                //    Directory.Delete(txtPath.Text + "\\Backup", true);
                //    Directory.CreateDirectory(txtPath.Text + "\\Backup");
                //    DirectoryInfo selectedPath1 = new DirectoryInfo(txtPath.Text);
                //    foreach (FileInfo file in selectedPath.GetFiles())
                //    {
                //        if (file.Extension == ".TIF" || file.Extension == ".tif")
                //        {

                //            file.CopyTo(txtPath.Text + "\\Backup\\" + file.Name);

                //        }
                //    }
                //}
                //else
                //{
                //    Directory.CreateDirectory(txtPath.Text + "\\Backup");
                //    DirectoryInfo selectedPath1 = new DirectoryInfo(txtPath.Text);
                //    foreach (FileInfo file in selectedPath.GetFiles())
                //    {
                //        if (file.Extension == ".TIF" || file.Extension == ".tif")
                //        {


                //            file.CopyTo(txtPath.Text + "\\Backup\\" + file.Name);

                //        }
                //    }
                //}
                if (Directory.Exists(txtPath.Text + "\\Backup"))
                {
                    Directory.Delete(txtPath.Text + "\\Backup", true);
                    Directory.CreateDirectory(txtPath.Text + "\\Backup");
                    txtPath.Text = txtPath.Text + "\\Backup";
                    DirectoryInfo selectedPath1 = new DirectoryInfo(txtPath.Text);
                    foreach (FileInfo file in selectedPath.GetFiles())
                    {
                        if (file.Extension == ".TIF" || file.Extension == ".tif")
                        {
                            file.CopyTo(txtPath.Text + "\\" + file.Name);
                        }
                        else if (file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == "jpeg")
                        {
                            Image img = Image.FromFile(file.FullName);

                            string filename = Path.GetFileNameWithoutExtension(file.FullName) + ".TIF";
                            try
                            {
                                ResizeImg(txtPath.Text + "\\" + filename, img, 10);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this, "Error!! Filename - " + file.FullName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(txtPath.Text + "\\Backup");
                    txtPath.Text = txtPath.Text + "\\Backup";
                    DirectoryInfo selectedPath1 = new DirectoryInfo(txtPath.Text);
                    foreach (FileInfo file in selectedPath.GetFiles())
                    {
                        if (file.Extension == ".TIF" || file.Extension == ".tif")
                        {
                            file.CopyTo(txtPath.Text + "\\" + file.Name);
                        }
                        else if (file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".jpeg")
                        {
                            Image img = Image.FromFile(file.FullName);

                            string filename = Path.GetFileNameWithoutExtension(file.FullName) + ".TIF";
                            try
                            {
                                ResizeImg(txtPath.Text+"\\"+filename, img, 10);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this, "Error!! Filename - " + file.FullName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                        }
                    }
                }

                //textbox name change
                //txtPath.Text = fbdPath.SelectedPath;
                //selectedpath change
                selectedPath = new DirectoryInfo(txtPath.Text);

                if (selectedPath.GetFiles().Length > 0)

                    foreach (FileInfo file in selectedPath.GetFiles())
                    {
                        if (file.Extension.Equals(".tif") || file.Extension.Equals(".TIF"))
                        {
                            fileNames.Add(file.FullName);
                            tempPath.Add(txtPath.Text + "\\" + file.ToString());
                        }
                    }
                //lvwItem.SubItems.Add(CLAIMS.ToString());
                //lvwItem.SubItems.Add("0");
                ListViewItems.Clear();
                ListViewItems1.Clear();
                lstImage.Items.Clear();

                //lstTotalImage.Items.Clear();
                lstImage.BeginUpdate();
                //lstTotalImage.BeginUpdate();

                foreach (string fileName in fileNames)
                {

                    ListViewItem lvi = lstImage.Items.Add(System.IO.Path.GetFileNameWithoutExtension(fileName));
                    //ListViewItem lvi1 = lstTotalImage.Items.Add(System.IO.Path.GetFileNameWithoutExtension(fileName));
                    lvi.Tag = fileName;
                    //lvi1.Tag = fileName;
                    ListViewItems.Add(fileName, lvi);
                    lstTotalImage.Rows.Add();
                    lstTotalImage.Rows[pos].Cells[0].Value = System.IO.Path.GetFileNameWithoutExtension(fileName);

                    pos = pos + 1;
                    //ListViewItems1.Add(fileName, lvi1);
                }
                //foreach (string fileName in fileNames)
                //{
                //    ListViewItem lvi1 = lstTotalImage.Items.Add(System.IO.Path.GetFileNameWithoutExtension(fileName));
                //    lvi1.Tag = fileName;
                //    ListViewItems.Add(fileName, lvi1);
                //}
                lstImage.EndUpdate();
                // lstTotalImage.EndUpdate();
                if (lstPolicy.Items.Count > 0)
                {
                    lstPolicy.Items[0].Selected = true;
                }
                groupBox2.Enabled = false;

                if (lstImage.Items.Count > 0)
                {

                    lstImage.Items[0].Focused = true;
                    lstImage.Items[0].Selected = true;
                    picMain.Height = 647;
                    picMain.Width = 625;
                    picMain.Refresh();
                    picMain.ImageLocation = null;
                    string imgPath = txtPath.Text + "\\" + lstImage.Items[0].Text + ".TIF";
                    picMain.ImageLocation = imgPath;


                    Image newImage = Image.FromFile(imgPath);
                    picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                    picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                    picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                    //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                    picMain.Refresh();
                    newImage.Dispose();
                    // GC.Collect();
                    picMain.MouseWheel += new MouseEventHandler(picMain_MouseWheel);
                    //picMain.MouseHover += new EventHandler(picMain_MouseHover);
                    lstImage.Select();
                }
                else
                {
                    picMain.ImageLocation = null;
                    lstImage.Select();
                }
                //lstImage.Select();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            picMain.Image = null;

            try
            {
                for (int i = 0; i < lstImage.Items.Count; i++)
                {
                    if (lstImage.Items[i].Selected == true)
                    {
                        lstSelImg.Items.Add(lstImage.Items[i].Text.ToString());
                    }
                }
                foreach (ListViewItem eachItem in lstImage.SelectedItems)
                {
                    lstImage.Items.Remove(eachItem);
                }
                if (lstImage.Items.Count > 0)
                {

                    lstImage.Items[0].Focused = true;
                    lstImage.Items[0].Selected = true;
                    picMain.Height = 647;
                    picMain.Width = 625;
                    picMain.Refresh();
                    picMain.ImageLocation = null;
                    string imgPath = txtPath.Text + "\\" + lstImage.Items[0].Text + ".TIF";
                    picMain.ImageLocation = imgPath;


                    Image newImage = Image.FromFile(imgPath);
                    picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                    picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                    picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                    //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                    picMain.Refresh();
                    newImage.Dispose();
                    // GC.Collect();
                    picMain.MouseWheel += new MouseEventHandler(picMain_MouseWheel);
                   // picMain.MouseHover += new EventHandler(picMain_MouseHover);
                    lstImage.Select();
                }
                else
                {
                    picMain.ImageLocation = null;
                    lstImage.Select();
                }
                lstImage.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lstSelImg.Items.Count; i++)
                {
                    if (lstSelImg.Items[i].Selected == true)
                    {
                        lstImage.Items.Add(lstSelImg.Items[i].Text.ToString());
                    }
                }
                foreach (ListViewItem eachItem in lstSelImg.SelectedItems)
                {
                    lstSelImg.Items.Remove(eachItem);
                }
                //if (lstImage.Items.Count > 0)
                //{

                //    lstImage.Items[0].Focused = true;
                //    lstImage.Items[0].Selected = true;
                //    picMain.Height = 647;
                //    picMain.Width = 625;
                //    picMain.Refresh();
                //    picMain.ImageLocation = null;
                //    string imgPath = txtPath.Text + "\\" + lstImage.Items[0].Text + ".TIF";
                //    picMain.ImageLocation = imgPath;


                //    Image newImage = Image.FromFile(imgPath);
                //    //picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                //    //picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                //    picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                //    //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                //    //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                //    picMain.Refresh();
                //    newImage.Dispose();
                //    // GC.Collect();
                //    //picMain.MouseWheel += new MouseEventHandler(picMain_MouseWheel);
                //    //picMain.MouseHover += new EventHandler(picMain_MouseHover);
                //    //lstImage.Select();
                //}
                //else
                //{
                //    picMain.ImageLocation = null;
                //    //lstImage.Select();
                //}
                if (lstImage.Items.Count > 0)
                {
                    lstImage.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void lstImage_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lstImage.Items.Count > 0)
                {

                    if (lstImage.SelectedItems.Count > 0)
                    {

                        //lstImage.SelectedItems[0].Focused = true;
                        //lstImage.SelectedItems[0].Selected = true;
                        picMain.Height = 647;
                        picMain.Width = 625;
                        picMain.Refresh();
                        picMain.ImageLocation = null;
                        string imgPath = txtPath.Text + "\\" + lstImage.SelectedItems[0].Text + ".TIF";
                        
                        picMain.ImageLocation = imgPath;


                        Image newImage = Image.FromFile(imgPath);
                        //picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                        //picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                        picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                        //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                        //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                        picMain.Refresh();
                        newImage.Dispose();
                        // GC.Collect();
                        //picMain.MouseWheel += new MouseEventHandler(picMain_MouseWheel);
                        //picMain.MouseHover += new EventHandler(picMain_MouseHover);
                        //lstImage.Select();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                GC.Collect();
            }
        }

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstImage_MouseClick(sender, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        }

        private void lstSelImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSelImg_MouseClick(sender, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        }

        private void cmdadd1_Click(object sender, EventArgs e)
        {
            int indexRow = 0;
            try
            {
                for (int j = 0; j < lstTotalImage.Rows.Count - 1; j++)
                {
                    if (lstCheckDeed.SelectedItems[0].Selected == true)
                    {
                        if (lstTotalImage.CurrentRow.Cells[1].Value == null)
                        {
                            lstTotalImage.CurrentRow.Cells[1].Value = lstCheckDeed.SelectedItems[0].Text;
                            lstTotalImage.SelectedRows[j].DefaultCellStyle.BackColor = Color.GreenYellow;
                            lstSelectedImg.Items.Add(lstTotalImage.CurrentRow.Cells[0].Value.ToString());
                        }

                    }
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdremove1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lstSelectedImg.Items.Count; i++)
                {
                    if (lstSelectedImg.Items[i].Selected == true)
                    {
                        for (int j = 0; j < lstTotalImage.Rows.Count - 1; j++)
                        {
                            if (lstTotalImage.Rows[j].Cells[0].Value != null)
                            {
                                if (lstTotalImage.Rows[j].Cells[0].Value.ToString() == lstSelectedImg.Items[i].Text)
                                {
                                    lstTotalImage.Rows[j].Cells[1].Value = null;
                                    lstTotalImage.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                                }
                            }
                        }
                    }
                }
                foreach (ListViewItem eachItem in lstSelectedImg.SelectedItems)
                {
                    lstSelectedImg.Items.Remove(eachItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
           // OdbcTransaction sqlTrans = null;

            if (cmdImport.Enabled == true)
            {
                try
                {
                    if (lstPolicy.Items.Count > 0)
                    {
                        if (lstSelImg.Items.Count == 0)
                        {
                            DialogResult dr = MessageBox.Show(this, "No Images selected for this Document type... Are you sure to continue?", "Selected no Image", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.Yes)
                            {
                                if (lstPolicy.Items.Count > 0)
                                {
                                    lstPolicy.Items[0].Selected = true;

                                    if (lstPolicy.SelectedItems.Count > 0)
                                    {
                                        for (int i = 0; i < lstSelImg.Items.Count; i++)
                                        {
                                            //lstSelImg.Items[i].Text
                                            for (int j = 0; j < lstTotalImage.Rows.Count; j++)
                                            {
                                                if (lstTotalImage.Rows[j].Cells[0].Value != null)
                                                {
                                                    if (lstSelImg.Items[i].Text == lstTotalImage.Rows[j].Cells[0].Value.ToString())
                                                    {
                                                        lstTotalImage.Rows[j].Cells[1].Value = lstPolicy.Items[0].Text;
                                                    }
                                                }
                                            }

                                        }

                                    }
                                    lstSelImg.Items.Clear();
                                    lstPolicy.SelectedItems[0].Remove();
                                    if (lstPolicy.Items.Count > 0)
                                    {
                                        lstPolicy.Items[0].Selected = true;

                                    }
                                }
                            }

                            else
                            {
                                return;
                            }
                        }
                        ////
                        else
                        {
                            if (lstPolicy.Items.Count > 0)
                            {
                                lstPolicy.Items[0].Selected = true;

                                if (lstPolicy.SelectedItems.Count > 0)
                                {
                                    for (int i = 0; i < lstSelImg.Items.Count; i++)
                                    {
                                        for (int j = 0; j < lstTotalImage.Rows.Count; j++)
                                        {
                                            if (lstTotalImage.Rows[j].Cells[0].Value != null)
                                            {
                                                if (lstSelImg.Items[i].Text == lstTotalImage.Rows[j].Cells[0].Value.ToString())
                                                {
                                                    lstTotalImage.Rows[j].Cells[1].Value = lstPolicy.Items[0].Text;
                                                }
                                            }
                                        }

                                    }

                                }
                                lstSelImg.Items.Clear();
                                lstPolicy.SelectedItems[0].Remove();
                                if (lstPolicy.Items.Count > 0)
                                {
                                    lstPolicy.Items[0].Selected = true;

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "There's no doc type present in Import Tab...", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (lstPolicy.Items.Count > 0)
                    {
                        lstPolicy.Items[0].Selected = true;
                        //GetIndexDetails(lstPolicy.SelectedItems[0].Text, cmbProject.SelectedValue.ToString(), cmbBatch.SelectedValue.ToString());
                        //GetDeedVolume(lstPolicy.SelectedItems[0].Text);
                    }
                    if (lstImage.Items.Count > 0)
                    {

                        lstImage.Items[0].Focused = true;
                        lstImage.Items[0].Selected = true;
                        picMain.Height = 647;
                        picMain.Width = 625;
                        picMain.Refresh();
                        picMain.ImageLocation = null;
                        string imgPath = txtPath.Text + "\\" + lstImage.Items[0].Text + ".TIF";
                        picMain.ImageLocation = imgPath;


                        Image newImage = Image.FromFile(imgPath);
                        picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                        picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                        picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                        //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                        //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                        picMain.Refresh();
                        newImage.Dispose();
                        // GC.Collect();
                        picMain.MouseWheel += new MouseEventHandler(picMain_MouseWheel);
                       // picMain.MouseHover += new EventHandler(picMain_MouseHover);
                        lstImage.Select();
                    }
                    else
                    {
                        picMain.ImageLocation = null;
                        lstImage.Select();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    lblinfo.Text = "Error...";
                    //sqlTrans.Rollback();
                }
            }
        }

        private void lstSelImg_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstSelImg.Items.Count > 0)
            {
                if (lstSelImg.SelectedItems.Count > 0)
                {



                    string imgPath = txtPath.Text + "\\" + lstSelImg.SelectedItems[0].Text + ".TIF";
                    picMain.Height = 647;
                    picMain.Width = 625;
                    picMain.Refresh();
                    picMain.ImageLocation = null;

                    picMain.ImageLocation = imgPath;


                    Image newImage = Image.FromFile(imgPath);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                    //picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                    picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                    //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                    picMain.Refresh();
                    newImage.Dispose();

                    lstSelImg.SelectedItems[0].Focused = true;
                }
            }
        }

        private void lstTotalImage_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lstTotalImage.Rows.Count > 0)
                {

                    string imgPath = txtPath.Text + "\\" + lstTotalImage.CurrentRow.Cells[0].Value.ToString() + ".TIF";
                    picMain.Height = 647;
                    picMain.Width = 625;
                    picMain.Refresh();
                    picMain.ImageLocation = null;

                    picMain.ImageLocation = imgPath;


                    Image newImage = Image.FromFile(imgPath);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                    //picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                    picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                    //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                    //picMain.Refresh();
                    newImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                GC.Collect();
            }
        }

        private void lstTotalImage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (lstTotalImage.Rows.Count > 0)
                {

                    string imgPath = txtPath.Text + "\\" + lstTotalImage.CurrentRow.Cells[0].Value.ToString() + ".TIF";
                    picMain.Height = 647;
                    picMain.Width = 625;
                    picMain.Refresh();
                    picMain.ImageLocation = null;

                    picMain.ImageLocation = imgPath;


                    Image newImage = Image.FromFile(imgPath);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                    //picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                    picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                    //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                    //picMain.Refresh();
                    newImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                GC.Collect();
            }
        }

        private void CmdFinalSave_Click(object sender, EventArgs e)
        {
            if (CmdFinalSave.Enabled == true)
            {
                //OdbcTransaction sqlTrans = null;
                string path = string.Empty;
                string oldFilename = string.Empty;
                string newFilename = string.Empty;
               // wfeProject wfep = new wfeProject(sqlCon);
                DirectoryInfo selectedPath = new DirectoryInfo(txtPath.Text);
                try
                {
                    int filecou = lstPolicy.Items.Count;
                    int totImgcou = lstImage.Items.Count;
                    if (filecou > 0)
                    {
                        MessageBox.Show("You have one or more doc type there... ", "Check Again !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tabControl1.SelectedIndex = 0;
                        lstPolicy.Select();
                        return;
                    }
                    //if (totImgcou > 0)
                    //{
                    //    DialogResult del = MessageBox.Show("There's one or more images left...Want to Delete?", "Check Again !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    //    if (del == DialogResult.Yes)
                    //    {
                    //        path = wfep.GetPath(Convert.ToInt32(cmbProject.SelectedValue.ToString())).Tables[0].Rows[0][0].ToString();

                    //        string delFolder = path + "\\" + cmbBatch.Text + "\\" + "Delete";
                    //        if (!Directory.Exists(delFolder))
                    //        {
                    //            Directory.CreateDirectory(delFolder);
                    //        }
                    //        else
                    //        {
                    //            Directory.Delete(delFolder);
                    //            Directory.CreateDirectory(delFolder);
                    //        }

                    //        List<string> fileNames1 = new List<string>();


                    //        for (int i = 0; i < lstImage.Items.Count - 1; i++)
                    //        {
                    //            string f = lstImage.Items[i].Text;
                    //            string newFilename1 = delFolder + "\\" + cmbBatch.Text + "_" + (i+1).ToString().PadLeft(3, '0') + ".TIF";
                    //            string imageName1 = cmbBatch.Text + "_" + (i+1).ToString().PadLeft(3, '0') + ".TIF";
                    //            File.Copy(txtPath.Text + "\\" + f + ".TIF",newFilename1,true);
                    //        }
                    //        foreach (ListViewItem eachItem in lstImage.Items)
                    //        {
                    //            lstImage.Items.Remove(eachItem);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        return;
                    //    }

                    //}
                    DialogResult dr = MessageBox.Show(this, "Images are Ready to Import.Transaction Cannot be Rollback.Continue ?", "Importing Images", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {
                        lstTotalImage.Enabled = false;
                        lstSelectedImg.Enabled = false;
                        lstCheckDeed.Enabled = false;
                        cmdadd1.Enabled = false;
                        cmdremove1.Enabled = false;
                        CmdFinalSave.Enabled = false;
                        //path = wfep.GetPath(Convert.ToInt32(cmbProject.SelectedValue.ToString()), sqlTrans).Tables[0].Rows[0][0].ToString();
                        path = txtPath.Text;
                        //sqlTrans = sqlCon.BeginTransaction();
                        if (lstCheckDeed.Items.Count > 0)
                        {


                            for (int i = 0; i < lstCheckDeed.Items.Count; i++)
                            {


                                string scanFolder = path + "\\" + lstCheckDeed.Items[i].Text ;
                                if (!Directory.Exists(scanFolder))
                                {
                                    Directory.CreateDirectory(scanFolder);
                                }


                                List<string> fileNames = new List<string>();
                                int sequence = 1;

                                for (int j = 0; j < lstTotalImage.Rows.Count; j++)
                                {
                                    if (lstTotalImage.Rows[j].Cells[1].Value != null)
                                    {
                                        if (lstCheckDeed.Items[i].Text == lstTotalImage.Rows[j].Cells[1].Value.ToString())
                                        {
                                            fileNames.Add(lstTotalImage.Rows[j].Cells[0].Value.ToString() + ".TIF");
                                            newFilename = scanFolder + "\\" + lstCheckDeed.Items[i].Text + "_" + sequence.ToString().PadLeft(5, '0') + ".TIF";
                                            string imageName = lstCheckDeed.Items[i].Text + "_" + sequence.ToString().PadLeft(5, '0') + ".TIF";
                                            File.Move(txtPath.Text + "\\" + lstTotalImage.Rows[j].Cells[0].Value.ToString() + ".TIF", newFilename);
                                            //insertIntoDB(imageName, sequence, sqlTrans, lstCheckDeed.Items[i].Text);
                                            sequence = sequence + 1;

                                        }
                                    }

                                }
                                //if (UpdateCaseFile(sqlTrans, lstCheckDeed.Items[i].Text))
                                //{

                                //}
                                //wfePolicy wfe = new wfePolicy(sqlCon, new CtrlPolicy(Convert.ToInt32(cmbProject.SelectedValue.ToString()), Convert.ToInt32(cmbBatch.SelectedValue.ToString()), "1", lstCheckDeed.Items[i].Text));
                                //wfe.UpdateTransactionLog(eSTATES.POLICY_SCANNED, crd, sqlTrans);
                            }
                        }

                        //sqlTrans.Commit();
                        //bool updatebatch = updateBatch();
                        //bool updatemeta = updateMeta();
                        MessageBox.Show(this, "Images Successfully Imported", "Import Images", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    //sqlTrans.Rollback();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void lstPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPolicy_Click(sender, e);
        }

        private void lstPolicy_Click(object sender, EventArgs e)
        {
            if (lstPolicy.SelectedItems.Count > 0)
            {
                //lstPolicy.Items[0].Selected = true;
               // GetIndexDetails(lstPolicy.SelectedItems[0].Text, cmbProject.SelectedValue.ToString(), cmbBatch.SelectedValue.ToString());
                //GetDeedVolume(lstPolicy.SelectedItems[0].Text);
            }
        }

        private void lstCheckDeed_MouseClick(object sender, MouseEventArgs e)
        {
            lstSelectedImg.Items.Clear();
            for (int i = 0; i < lstTotalImage.Rows.Count; i++)
            {
                if (lstTotalImage.Rows[i].Cells[1].Value != null)
                {
                    if (lstTotalImage.Rows[i].Cells[1].Value.ToString() == lstCheckDeed.SelectedItems[0].Text)
                    {
                        lstSelectedImg.Items.Add(lstTotalImage.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
        }

        private void lstCheckDeed_Click(object sender, EventArgs e)
        {
            if (lstCheckDeed.SelectedItems.Count > 0)
            {
                //lstPolicy.Items[0].Selected = true;
               // GetIndexDetails(lstCheckDeed.SelectedItems[0].Text, cmbProject.SelectedValue.ToString(), cmbBatch.SelectedValue.ToString());
                //GetDeedVolume(lstCheckDeed.SelectedItems[0].Text);
            }
        }

        private void lstCheckDeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCheckDeed_Click(sender, e);
        }

        private void picMain_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;

            //if (mouse.Button == MouseButtons.Left)
            //{
            //    Point mousePosNow = mouse.Location;

            //    int deltaX = mousePosNow.X - mouseDown.X;
            //    int deltaY = mousePosNow.Y - mouseDown.Y;

            //    int newX = picMain.Location.X + deltaX;
            //    int newY = picMain.Location.Y + deltaY;

            //    picMain.Location = new Point(newX, newY);
            //}
            //lstImage.Select();
        }
        
        protected override void OnMouseWheel(MouseEventArgs mea)
        {

            //if (picMain.Image != null)
            //{
            //    if (mea.Delta > 0)
            //    {
            //        if ((picMain.Width < (15 * this.Width)) && (picMain.Height < (15 * this.Height)))
            //        {
            //            picMain.Width = (int)(picMain.Width * 1.25);
            //            picMain.Height = (int)(picMain.Height * 1.25);
            //        }
            //    }

            //    else
            //    {
            //        // Check if the pictureBox dimensions are in range (15 is the minimum and maximum zoom level)
            //        if ((picMain.Width > (this.Width / 15)) && (picMain.Height > (this.Height / 15)))
            //        {
            //            // Change the size of the picturebox, divide it by the ZOOM FACTOR
            //            picMain.Width = (int)(picMain.Width / 1.25);
            //            picMain.Height = (int)(picMain.Height / 1.25);
            //        }
            //    }
            //}
            //picMain.Refresh();
        }
        private void picMain_MouseEnter(object sender, EventArgs e)
        {
            if (picMain.Focused == false)
            {
                //picMain.Focus();
            }
        }
        private void ZoomOut()
        {
            if (picMain.Height > (panel1.Height))
            {
                panel1.Width = picMain.Width;
                picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                picMain.Width = Convert.ToInt32(picMain.Width / ZOOMFACTOR);
                picMain.Height = Convert.ToInt32(picMain.Height / ZOOMFACTOR);
                picMain.Refresh();
            }
        }
        private void ZoomIn()
        {
            if ((picMain.Width < (MINMAX * panel1.Width)) &&
                (picMain.Height < (MINMAX * panel1.Height)))
            {
                picMain.Width = Convert.ToInt32(picMain.Width * ZOOMFACTOR);
                picMain.Height = Convert.ToInt32(picMain.Height * ZOOMFACTOR);
                picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                picMain.Refresh();
            }
        }
        private void picMain_MouseHover(object sender, EventArgs e)
        {

        }

        private void lstSelectedImg_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstSelectedImg.Items.Count > 0)
            {
                if (lstSelectedImg.SelectedItems.Count > 0)
                {



                    string imgPath = txtPath.Text + "\\" + lstSelectedImg.SelectedItems[0].Text + ".TIF";
                    picMain.Height = 647;
                    picMain.Width = 625;
                    picMain.Refresh();
                    picMain.ImageLocation = null;

                    picMain.ImageLocation = imgPath;


                    Image newImage = Image.FromFile(imgPath);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1.1);
                    //picMain.Width = Convert.ToInt32(picMain.Height * newImage.Width / newImage.Height);

                    picMain.SizeMode = PictureBoxSizeMode.StretchImage;
                    //picMain.Width = Convert.ToInt32(picMain.Width * 1);
                    //picMain.Height = Convert.ToInt32(picMain.Height * 1);
                    picMain.Refresh();
                    newImage.Dispose();

                    lstSelectedImg.SelectedItems[0].Focused = true;
                }
            }
        }
    }
}
