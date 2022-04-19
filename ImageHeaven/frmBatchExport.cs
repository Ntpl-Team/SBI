﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageHeaven
{
    public partial class frmBatchExport : Form
    {
        public static string temp;
        MemoryStream stateLog;
        byte[] tmpWrite;
        
        DataSet ds = null;
        DataTable dsexport = new DataTable();
        string batchCount;
        

        public static string batchKey = null;
        public static string projKey = null;

        public string err = null;
        //wfeBox box = null;
        string sqlFileName = null;
        
        StreamWriter sw;
        StreamWriter expLog;
        
        string error = null;
        string sqlIp = null;
        string exportPath = null;
        string globalPath = string.Empty;
        string[] imageName;
        string[] imageWithDocName;
        string[] imageNameWithoutDoc;
        
        private long expImageCount = 0;
        private long expPolicyCount = 0;
        

        public frmBatchExport()
        {
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            this.Text = "Batch Export ";
        }
        
        private void frmExport_Load(object sender, EventArgs e)
        {
            //populateProject();
            //chkReExport.Checked = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            btnExport.Enabled = false;
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                //lblinfo.Text = "";
                List<string> fileNames = new List<string>();
                List<string> tempPath = new System.Collections.Generic.List<string>(1000);


                dgvbatch.DataSource = null;
                dgvexport.DataSource = null;

                fbdPath.ShowDialog();
                txtPath.Text = fbdPath.SelectedPath;
                DirectoryInfo selectedPath = new DirectoryInfo(txtPath.Text);
                DataTable dt = new DataTable();
                //dt.Columns.Add("Document Types");
                dt.Columns.Add("Account Numbers");
                foreach (var info in Directory.GetDirectories(txtPath.Text))
                {
                    string dir = Path.GetFileName(info);
                    dt.Rows.Add(dir);
                    
                }

                //dgvbatch.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dgvbatch.DataSource = dt;
                    dgvbatch.Columns[0].Width = 25;
                    dgvbatch.Columns[1].Width = 160;
                    dgvbatch.Columns[1].ReadOnly = true;
                    dgvbatch.Columns[0].Visible = false;
                    //dgvbatch.Columns[2].Visible = false;
                    //dgvbatch.Columns[3].Visible = false;

                    label3.Visible = true;
                    lbldeedCount.Visible = true;
                    lbldeedCount.Text = dt.Rows.Count.ToString();
                    btnExport.Enabled = true;
                }
                else
                {
                    dgvbatch.DataSource = null;
                    dgvexport.DataSource = null;
                    label3.Visible = false;
                    lbldeedCount.Visible = false;
                }
                


                //textbox name change
                txtPath.Text = fbdPath.SelectedPath;
                //selectedpath change
                selectedPath = new DirectoryInfo(txtPath.Text);

               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgvbatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            populateDeeds(dgvbatch.CurrentRow.Cells[1].Value.ToString());
        }

        private void dgvbatch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvbatch.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvbatch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                PopulateSelectedBatchCount();
        }
        private void PopulateSelectedBatchCount()
        {
            int StatusStep = 0;
            try
            {
                if (dgvbatch.Rows.Count > 0)
                {
                    for (int x = 0; x < dgvbatch.Rows.Count; x++)
                    {
                        if (Convert.ToBoolean(dgvbatch.Rows[x].Cells[0].Value))
                        {
                            StatusStep = StatusStep + 1;
                        }

                    }
                    lblBatchSelected.Text = StatusStep.ToString();
                }
            }
            catch (Exception ex)
            {
                lblBatchSelected.Text = "0";
            }
        }
        public void cleargrid()
        {
            dgvexport.DataSource = null;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dgvPlot.DataSource = null;
            dgvKhatian.DataSource = null;
            if (dgvexport.Columns.Contains("Status"))
            {
                dgvexport.Columns.Remove("Status");
            }
            lbl.Text = "";
            progressBar1.Value = 0;
            txtMsg.Text = "";
            tblExp.SelectedTab = tabPage1;
        }
        private void populateDeeds(string file)
        {
            cleargrid();

            int holdDeed = 0;
            
            dsexport = GetExportableDeed(file);

            if (dsexport.Rows.Count > 0)
            {
                dgvexport.DataSource = dsexport;
                dgvexport.Columns[0].Width = 220;
               
            }

            label6.Visible = true;
            lblBatchSelected.Visible = true;
            lblBatchSelected.Text = dsexport.Rows.Count.ToString();

            
        }
        public DataTable GetExportableDeed(string file)
        {
            string sqlStr = null;
            DataTable dsBox = new DataTable();
            
            //image_master merge
            string filePath = txtPath.Text + "\\" + file;
            dsBox.Columns.Add("Doc Type");
            try
            {

                
                foreach (var info in Directory.GetDirectories(filePath))
                {
                    string dir = Path.GetFileName(info);
                    
                    if (dir == "KYC" || dir == "Income" || dir == "TVR" || dir == "Property" || dir == "Executed_loan" || dir == "PSS_reports" || dir == "Others")
                    {
                        dsBox.Rows.Add(dir);
                    }
                }
                
            }
            catch (Exception ex)
            {
                stateLog = new System.IO.MemoryStream();
                tmpWrite = new System.Text.ASCIIEncoding().GetBytes(sqlStr + "\n");
                stateLog.Write(tmpWrite, 0, tmpWrite.Length);
            }
            return dsBox;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdValidatefiles_Click(object sender, EventArgs e)
        {
            try
            {

                btnExport.Enabled = false;
                string batchPath = string.Empty;
                string batchName = string.Empty;
                string resultMsg = "Hold Deeds" + "\r\n";
                DataTable deedEx = new DataTable();
                DataTable NameEx = new DataTable();
                DataTable PropEx = new DataTable();
                DataTable CSVPropEx = new DataTable();
                DataTable PlotEx = new DataTable();
                DataTable KhatianEx = new DataTable();
                string expFolder = string.Empty;
                bool isDeleted = false;
                int MaxExportCount = 0;
                int StatusStep = 0;
                //config = new ImageConfig(ihConstants.CONFIG_FILE_PATH);
                //expFolder = config.GetValue(ihConstants.EXPORT_FOLDER_SECTION, ihConstants.EXPORT_FOLDER_KEY).Trim();
                //int len = expFolder.IndexOf('\0');
                //expFolder = expFolder.Substring(0, len);
                //List<DeedImageDetails> dList = new List<DeedImageDetails>();


                lblFinalStatus.Text = "Please wait while Validating....  ";
                Application.DoEvents();
                if (dgvbatch.Rows.Count > 0)
                {
                    //for (int x = 0; x < dgvbatch.Rows.Count; x++)
                    //{
                    //    //if (dgvbatch.Rows[x].Cells[0].Value))
                    //    //{
                    //    //    StatusStep = StatusStep + 1;
                    //    //    dgvbatch.Rows[x].Selected = false; 
                    //    //}
                    //}
                    StatusStep = dgvbatch.Rows.Count;

                    int step = 100 / StatusStep;
                    progressBar2.Step = step;
                    for (int z = 0; z < dgvbatch.Rows.Count; z++)
                    {

                        dgvexport.DataSource = null;
                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        dataGridView3.DataSource = null;
                        dgvKhatian.DataSource = null;
                        dgvPlot.DataSource = null;
                        deedEx.Clear();
                        NameEx.Clear();
                        CSVPropEx.Clear();
                        PlotEx.Clear();
                        KhatianEx.Clear();
                        //populateDeeds(dgvbatch.Rows[z].Cells[2].Value.ToString(), dgvbatch.Rows[z].Cells[3].Value.ToString());
                        //string file = dgvbatch.Rows[z].Cells[1].Value.ToString();
                        populateDeeds(dgvbatch.Rows[z].Cells[1].Value.ToString());
                        //MaxExportCount = wPolicy.getMaxExportCount(cmbProject.SelectedValue.ToString(), dgvbatch.Rows[z].Cells[2].Value.ToString());
                        //if (dgvexport.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < dgvexport.Rows.Count; i++)
                        //    {
                        //        if (Convert.ToInt32(dgvexport.Rows[i].Cells["status"].Value.ToString()) == 30 || Convert.ToInt32(dgvexport.Rows[i].Cells["status"].Value.ToString()) == 21)
                        //        {
                        //            dgvexport.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        //            MessageBox.Show("There is some Problem in one or more files, Please Check and Retry..., Export Failed");
                        //            btnExport.Enabled = true;
                        //            return;
                        //        }
                        //    }
                        //}

                        if (dgvexport.Rows.Count > 0)
                        {
                            Application.DoEvents();
                            dgvbatch.Rows[z].DefaultCellStyle.BackColor = Color.GreenYellow;
                            int i1 = 100 / dsexport.Rows.Count;
                            progressBar1.Step = i1;
                            progressBar1.Increment(i1);
                            Application.DoEvents();
                            batchPath = txtPath.Text + "\\" + dgvbatch.Rows[z].Cells[1].Value.ToString(); //GetPath(Convert.ToInt32(cmbProject.SelectedValue.ToString()), Convert.ToInt32(dgvbatch.Rows[z].Cells[3].Value.ToString()));
                            //batchPath = batchPath + "\\1\\Nevaeh";

                            for (int x = 0; x < dsexport.Rows.Count; x++)
                            {
                                dgvexport.Rows[x].DefaultCellStyle.BackColor = Color.GreenYellow;
                                
                                DataTable dsimage = new DataTable();
                                Application.DoEvents();
                                lbl.Text = "Validating :" + dgvbatch.Rows[z].Cells[1].Value.ToString();
                                Application.DoEvents();
                                string aa = txtPath.Text + "\\" + dgvbatch.Rows[z].Cells[1].Value.ToString() + "\\" + dsexport.Rows[x][0].ToString(); //GetPath(Convert.ToInt32(cmbProject.SelectedValue.ToString()), Convert.ToInt32(dgvbatch.Rows[z].Cells[3].Value.ToString()));
                                sqlFileName = dgvbatch.Rows[z].Cells[1].Value.ToString()+"_"+dsexport.Rows[x][0].ToString();
                                sqlFileName = sqlFileName + ".mdf";
                                //dsimage = GetAllExportedImage(dsexport.Tables[0].Rows[x][1].ToString(), dsexport.Tables[0].Rows[x][2].ToString(), dsexport.Tables[0].Rows[x][3].ToString(), dsexport.Tables[0].Rows[x][0].ToString());
                                dsimage = GetAllExportedImage(dgvbatch.Rows[z].Cells[1].Value.ToString(),dsexport.Rows[x][0].ToString());
                                imageName = new string[dsimage.Rows.Count];
                                string IMGName = dsexport.Rows[x][0].ToString();
                                //string IMGName1 = IMGName.Split(new char[] { '[', ']' })[1];
                                //IMGName = IMGName.Replace("[", "");
                                //IMGName = IMGName.Replace("]", "");
                                string fileName = dsexport.Rows[x][0].ToString();
                                lbl.Text = "Validating :" + dgvbatch.Rows[z].Cells[1].Value.ToString()+"_"+ dsexport.Rows[x][0].ToString();
                                if (dsimage.Rows.Count > 0)
                                {
                                    for (int a = 0; a < dsimage.Rows.Count; a++)
                                    {
                                        //                                        imageName[a] = dsexport.Tables[0].Rows[x][4].ToString() + "\\QC" + "\\" + dsimage.Tables[0].Rows[a]["page_name"].ToString();
                                        imageName[a] = aa + "\\" + dsimage.Rows[a][0].ToString();
                                    }

                                    if (imageName.Length != 0)
                                    {

                                        //sumit for export problem
                                        for (int i = 0; i < imageName.Length; i++)
                                        {
                                            if (File.Exists(imageName[i]))
                                            {

                                            }
                                            else
                                            {
                                                MessageBox.Show("Doc Type not found or may be corrupted... " + imageName[i]);
                                                return;
                                            }

                                        }

                                    }

                                }
                                else
                                {
                                    MessageBox.Show(this, "No Image found for doc type: " + fileName + ",Export aborted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "No such doc type found : " + dgvbatch.Rows[z].Cells[1].Value.ToString() + ",Export aborted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                lbl.Text = "Folder Validated successfully...";
                lblFinalStatus.Text = "Data Validated successfully...";
                btnExport.Enabled = true;
                progressBar2.Increment(100);
                progressBar1.Increment(100);
                //dgvexport.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                //for (int i = 0; i < dgvbatch.Rows.Count; i++)
                //{
                //    dgvbatch.Rows[i].DefaultCellStyle.BackColor = Color.White;
                //}
            }


            catch (Exception ex)
            {

            }
        }
        public DataTable GetAllExportedImage(string acc,string filename)
        {
            DataTable dsImage = new DataTable();
            string indexPageName = string.Empty;

            

            
            string filePath = txtPath.Text + "\\" + acc+"\\"+ filename;
            dsImage.Columns.Add("Images");
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
                foreach (FileInfo info in directoryInfo.GetFiles())
                {
                    if(info.Extension.ToLower() == ".tiff" || info.Extension.ToLower() == ".tif" || info.Extension.ToLower() == ".jpg"
                        || info.Extension.ToLower() == ".jpeg")
                    {
                        string dir = info.Name;

                        dsImage.Rows.Add(dir);
                    }
                    

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dsImage;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                btnExport.Enabled = false;




                string expFolder = "C:\\";
                bool isDeleted = false;
                string DirName1 = Path.GetFileName(txtPath.Text/*.Substring(0, txtPath.Text.Length - 7)*/);
                string DirName = DirName1;//Path.GetFileName(txtPath.Text);
                if (Directory.Exists(expFolder + "\\Nevaeh\\" + DirName) && isDeleted == false)
                {
                    Directory.Delete(expFolder + "\\Nevaeh\\" + DirName, true);
                }

                string batchPath = string.Empty;
                string batchName = string.Empty;
                string resultMsg = "Hold Files" + "\r\n";
                DataTable deedEx = new DataTable();
                DataTable NameEx = new DataTable();
                DataTable PropEx = new DataTable();
                DataTable CSVPropEx = new DataTable();
                DataTable CSVPropEx1 = new DataTable();
                DataTable PlotEx = new DataTable();
                DataTable KhatianEx = new DataTable();
                //string expFolder = "C:\\";
                //bool isDeleted = false;
                int MaxExportCount = 0;
                int StatusStep = 0;
                //config = new ImageConfig(ihConstants.CONFIG_FILE_PATH);
                //expFolder = config.GetValue(ihConstants.EXPORT_FOLDER_SECTION, ihConstants.EXPORT_FOLDER_KEY).Trim();

                System.Text.StringBuilder Builder1 = new System.Text.StringBuilder();
                Builder1.Append(PropEx.Rows.Count.ToString());
                Builder1.Append(",");

                

                lblFinalStatus.Text = "Please wait while Exporting....  ";
                Application.DoEvents();


                if (dgvbatch.Rows.Count > 0)
                {
                    StatusStep = dgvbatch.Rows.Count;
                    progressBar2.Value = 0;
                    progressBar1.Value = 0;
                    int step = 100 / StatusStep;
                    progressBar2.Step = step;

                    for (int z = 0; z < dgvbatch.Rows.Count; z++)
                    {
                        dgvexport.DataSource = null;
                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        dataGridView3.DataSource = null;
                        dgvKhatian.DataSource = null;
                        dgvPlot.DataSource = null;
                        deedEx.Clear();
                        NameEx.Clear();
                        CSVPropEx.Clear();
                        CSVPropEx1.Clear();
                        PlotEx.Clear();
                        KhatianEx.Clear();
                        string file = dgvbatch.Rows[z].Cells[1].Value.ToString();
                        populateDeeds(dgvbatch.Rows[z].Cells[1].Value.ToString());


                        if (dgvexport.Rows.Count > 0)
                        {
                            Application.DoEvents();
                            dgvbatch.Rows[z].DefaultCellStyle.BackColor = Color.GreenYellow;
                            int i1 = 100 / dsexport.Rows.Count;
                            progressBar1.Step = i1;
                            progressBar1.Increment(i1);
                            Application.DoEvents();
                            batchPath = txtPath.Text + "\\" + dgvbatch.Rows[z].Cells[1].Value.ToString();
                            //batchPath = batchPath + "\\1\\Nevaeh";


                            if (!Directory.Exists(expFolder + "\\Nevaeh\\" + DirName))
                            {
                                Directory.CreateDirectory(expFolder + "\\Nevaeh\\" + DirName);
                            }

                            for (int x = 0; x < dsexport.Rows.Count; x++)
                            {
                                dgvexport.Rows[x].DefaultCellStyle.BackColor = Color.GreenYellow;
                                DataTable dsimage = new DataTable();
                                DataTable dsimageDoc = new DataTable();
                                DataTable dsimageWithoutDoc = new DataTable();
                                Application.DoEvents();
                                lbl.Text = "Exporting :" + dgvbatch.Rows[z].Cells[1].Value.ToString();
                                Application.DoEvents();
                                string aa = txtPath.Text + "\\" + dgvbatch.Rows[z].Cells[1].Value.ToString()+"\\"+ dsexport.Rows[x][0].ToString();// GetPath(Convert.ToInt32(cmbProject.SelectedValue.ToString()), Convert.ToInt32(dgvbatch.Rows[z].Cells[3].Value.ToString()));
                                sqlFileName = dsexport.Rows[x][0].ToString();
                                //int index = sqlFileName.IndexOf('[');
                                sqlFileName = sqlFileName.ToString();
                                batchName = sqlFileName.ToString();
                                batchName = dsexport.Rows[x][0].ToString();
                                sqlFileName = sqlFileName + ".mdf";
                                dsimage = GetAllExportedImage(dgvbatch.Rows[z].Cells[1].Value.ToString(),dsexport.Rows[x][0].ToString());
                                imageName = new string[dsimage.Rows.Count];

                                dsimageWithoutDoc = GetAllExportedImage(dgvbatch.Rows[z].Cells[1].Value.ToString(),dsexport.Rows[x][0].ToString());
                                imageNameWithoutDoc = new string[dsimageWithoutDoc.Rows.Count];

                                string IMGName = dsexport.Rows[x][0].ToString();
                                //string IMGName1 = IMGName.Split(new char[] { '[', ']' })[1];
                                //IMGName = IMGName.Replace("[", "");
                                //IMGName = IMGName.Replace("]", "");
                                string fileName = dsexport.Rows[x][0].ToString();
                                if (dsimageWithoutDoc.Rows.Count > 0)
                                {
                                    //if (Directory.Exists(expFolder + "\\Nevaeh\\" + DirName) && isDeleted == false)
                                    //{
                                    //    //Directory.Delete(expFolder + "\\Export\\" + cmbBatch.Text + "\\" + fileName,true);
                                    //    Directory.Delete(expFolder + "\\Nevaeh\\" + DirName, true);
                                        
                                    //}
                                    if (!Directory.Exists(expFolder + "\\Nevaeh\\" + DirName))
                                    {
                                        Directory.CreateDirectory(expFolder + "\\Nevaeh\\" + DirName);
                                        Directory.CreateDirectory(expFolder + "\\Nevaeh\\" + DirName + "\\" + dgvbatch.Rows[z].Cells[1].Value.ToString());
                                        isDeleted = true;
                                    }
                                    if (!Directory.Exists(expFolder + "\\Nevaeh\\" + DirName + "\\" + dgvbatch.Rows[z].Cells[1].Value.ToString()))
                                    {
                                        //Directory.CreateDirectory(expFolder + "\\Export\\" + cmbBatch.Text);
                                        Directory.CreateDirectory(expFolder + "\\Nevaeh\\" + DirName + "\\" + dgvbatch.Rows[z].Cells[1].Value.ToString());
                                        isDeleted = true;
                                    }

                                    //doctype


                                    dsimageDoc = GetAllExportedImage(dgvbatch.Rows[z].Cells[1].Value.ToString(),dsexport.Rows[x][0].ToString());
                                    imageWithDocName = new string[dsimageDoc.Rows.Count];
                                    string IMGNameDoc = dsexport.Rows[x][0].ToString();

                                    for (int b = 0; b < dsimageDoc.Rows.Count; b++)
                                    {

                                        //imageName[a] = dsexport.Tables[0].Rows[x][4].ToString() + "\\QC" + "\\" + dsimage.Tables[0].Rows[a]["page_name"].ToString();
                                        imageWithDocName[b] = aa + "\\" + dsimageDoc.Rows[b][0].ToString();


                                    }

                                    lbl.Text = "Exporting :" + dgvbatch.Rows[z].Cells[1].Value.ToString() + "_" + dsexport.Rows[x][0].ToString();
                                    string acc_name = dgvbatch.Rows[z].Cells[1].Value.ToString();
                                    string doc_type_name = dsexport.Rows[x][0].ToString();
                                    if (imageWithDocName.Length != 0)
                                    {

                                        
                                        //itextsharp combo pdf sandhi

                                        iTextSharp.text.Document doc = new iTextSharp.text.Document();
                                        PdfWriter writer1 = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(expFolder + "\\Nevaeh\\" + DirName + "\\" + acc_name + "\\" + acc_name + "_" + doc_type_name + ".pdf", FileMode.Create));

                                        doc.Open();
                                        for (int i = 0; i < imageWithDocName.Length; i++)
                                        {
                                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageWithDocName[i].ToString());
                                            //image.Alignment = Image.ALIGN_LEFT;
                                            image.SetAbsolutePosition(0, 0);
                                            image.ScaleAbsolute(iTextSharp.text.PageSize.A4.Width, iTextSharp.text.PageSize.A4.Height);
                                            
                                            doc.Add(image);
                                            doc.NewPage();
                                            //htmlparser.Parse(sr);
                                        }
                                        doc.Close();
                                        writer1.Close();

                                        string pdf_path = expFolder + "\\Nevaeh\\" + DirName + "\\" + acc_name + "\\" + acc_name + "_" + doc_type_name + ".pdf";
                                        file = doc_type_name + ".pdf";
                                        string dirname = Path.GetDirectoryName(pdf_path);
                                        //PdfDocument document = new PdfDocument(PdfPage.PAGE.ToPdf,PdfImage.BEST_COMPRESSION);
                                        PdfReader pdfReader = new PdfReader(pdf_path);
                                        int noofpages = pdfReader.NumberOfPages;

                                        List<string> fileNames = new List<string>();

                                        iTextSharp.text.Document document = new iTextSharp.text.Document();

                                        //ocr directory create
                                        string dirEx = dirname + "\\OCR";
                                        if (!Directory.Exists(dirEx))
                                        {
                                            Directory.CreateDirectory(dirEx);
                                        }

                                        //split pdf
                                        for (int i = 0; i < noofpages; i++)
                                        {
                                            using (MemoryStream ms = new MemoryStream())
                                            {
                                                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(pdf_path);
                                                Syncfusion.Pdf.PdfDocument documentPage = new Syncfusion.Pdf.PdfDocument();
                                                documentPage.ImportPage(loadedDocument, i);
                                                documentPage.Save(dirEx + "\\OCR_" + i + ".pdf");
                                                string filenameNew = dirEx + "\\OCR_" + i + ".pdf";
                                                //documentPage.Close();
                                                documentPage.Close(true);
                                                //documentPage.Dispose();
                                                //loadedDocument.Close();
                                                loadedDocument.Close(true);
                                                //loadedDocument.Dispose();
                                                documentPage.EnableMemoryOptimization = true;
                                                loadedDocument.EnableMemoryOptimization = true;
                                                fileNames.Add(filenameNew);
                                                //lstImage.Items.Add(filenameNew);

                                                ms.Close();

                                                GC.Collect();
                                                GC.WaitForPendingFinalizers();
                                                GC.Collect();

                                                Application.DoEvents();
                                            }
                                            Application.DoEvents();
                                        }

                                        string expath = Path.GetDirectoryName(Application.ExecutablePath);
                                        //ocr
                                        try
                                        {
                                            System.IO.DirectoryInfo di3 = new DirectoryInfo(dirEx);
                                            foreach (string filename in fileNames)
                                            {
                                                Application.DoEvents();
                                                string xyz = filename;
                                                //PdfLoadedDocument loadedDocument = new PdfLoadedDocument(pdf_path);
                                                //Syncfusion.Pdf.PdfDocument documentPage = new Syncfusion.Pdf.PdfDocument();
                                                //documentPage.ImportPage(loadedDocument, i);
                                                using (OCRProcessor oCR = new OCRProcessor(expath + "\\TesseractBinaries\\3.02\\"))
                                                {
                                                    try
                                                    {

                                                        PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(xyz);
                                                        oCR.Settings.Language = Syncfusion.OCRProcessor.Languages.English;
                                                        oCR.Settings.Performance = Syncfusion.OCRProcessor.Performance.Rapid;
                                                        oCR.Settings.IsCompressionEnabled = true;
                                                        oCR.PerformOCR(pdfLoadedDocument, expath + "\\tessdata\\", true);

                                                        pdfLoadedDocument.EnableMemoryOptimization = true;

                                                        pdfLoadedDocument.Save(xyz);

                                                        pdfLoadedDocument.Close(true);

                                                        oCR.Dispose();

                                                        GC.Collect();
                                                        GC.WaitForPendingFinalizers();
                                                        GC.Collect();
                                                    }
                                                    catch (Exception)
                                                    { continue; }
                                                }

                                            }
                                            string outFile = expFolder + "\\Nevaeh\\" + DirName + "\\" + acc_name + "\\" + acc_name + "_" + doc_type_name + ".pdf";
                                            try
                                            {
                                                //create newFileStream object which will be disposed at the end
                                                using (FileStream newFileStream = new FileStream(outFile, FileMode.Create))
                                                {
                                                    Application.DoEvents();
                                                    // step 2: we create a writer that listens to the document
                                                    PdfCopy writer = new PdfCopy(document, newFileStream);
                                                    if (writer == null)
                                                    {
                                                        return;
                                                    }

                                                    // step 3: open the document
                                                    document.Open();

                                                    foreach (string filename in fileNames)
                                                    {
                                                        Application.DoEvents();
                                                        string xyz = filename;
                                                        // create a reader for a certain document
                                                        PdfReader reader = new PdfReader(xyz);
                                                        reader.ConsolidateNamedDestinations();

                                                        // step 4: add content
                                                        for (int i = 1; i <= reader.NumberOfPages; i++)
                                                        {
                                                            PdfImportedPage page = writer.GetImportedPage(reader, i);
                                                            writer.AddPage(page);
                                                        }

                                                        PRAcroForm form = reader.AcroForm;
                                                        if (form != null)
                                                        {
                                                            writer.CopyAcroForm(reader);
                                                        }

                                                        reader.Close();
                                                    }

                                                    // step 5: close the document and writer
                                                    writer.Close();
                                                    document.Close();

                                                    GC.Collect();
                                                    GC.WaitForPendingFinalizers();
                                                    GC.Collect();
                                                }//disposes the newFileStream object

                                                try
                                                {
                                                    PdfLoadedDocument loadeddoc = new PdfLoadedDocument(outFile);
                                                    Syncfusion.Pdf.Graphics.PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11f);
                                                    PdfPageNumberField pageNumber = new PdfPageNumberField(font, PdfBrushes.Black);
                                                    PdfPageCountField count = new PdfPageCountField(font, PdfBrushes.Black);
                                                    PdfCompositeField compositeField = new PdfCompositeField(font, PdfBrushes.Black, "Page {0} of {1}", pageNumber, count);
                                                    for (int c = 0; c < loadeddoc.Pages.Count; c++)
                                                    {
                                                        compositeField.Draw(loadeddoc.Pages[c].Graphics,
                                                            new PointF(loadeddoc.Pages[c].Size.Width / 2 - 20,
                                                            loadeddoc.Pages[c].Size.Height - 20));
                                                    }
                                                    loadeddoc.Save(outFile);
                                                    loadeddoc.Close(true);
                                                }
                                                catch (Exception)
                                                { continue; }

                                                Directory.Delete(dirEx, true);

                                                //MessageBox.Show("OCR Completed Successfully ...");
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.ToString());
                                            }
                                        }
                                        catch (Exception ex1)
                                        { MessageBox.Show(ex1.ToString()); }

                                    }




                                    

                                }

                                dgvexport.Rows[x].DefaultCellStyle.BackColor = Color.GreenYellow;

                                Application.DoEvents();
                                
                               
                                sqlFileName = string.Empty;
                                txtMsg.Text = resultMsg;

                            }

                        }

                        
                        progressBar2.PerformStep();
                        Application.DoEvents();
                        
                    }
                    //progressBar2.Increment(100);
                    progressBar2.Value=100;
                   
                    progressBar1.Value = 100;
                    lblFinalStatus.Text = "Finished....";
                    lbl.Text = "Finished....";
                    btnExport.Enabled = true;
                }



            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
