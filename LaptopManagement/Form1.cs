using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace LaptopManagement
{
    public partial class frmLaptopManagement : Form
    {
        public List<Laptop> LaptopList = new List<Laptop>();
        //loadData = 0 (no data)
        //loadData = 1 (data from Excel)
        //loadData = 2 (data from SQL)
        public int loadData = 0;
        static string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string excelFilePath = ProjectPath + "\\Data\\LaptopList.xlsx";
        string connectionString = "Data Source = HaTran; Initial Catalog = LaptopDB;Integrated Security=SSPI";
        int CurrentLaptopIndex = -1;
        DataTable datatable;
        BindingSource binding = new BindingSource();
        public frmLaptopManagement()
        {
            InitializeComponent();
        }
        //Load data from Excel file
        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            loadData = 1;
            datatable = new DataTable();
            LaptopList.Clear();
            int colCount = 9;
            int NumDataRow = ReadDataFromFile(LaptopList, excelFilePath, colCount);
            //Create a sublist filtering data from Laptop list
            //This sublist store data showing on DataGridView
            var sublist = LaptopList.Select(x => new
            {
                LaptopID = x.LaptopID,
                LaptopName = x.LaptopName,
                LaptopType = x.LaptopType,
                ProductDate = x.ProductDate.ToString("dd/MM/yyyy"),
                Processor = x.Processor,
                HDD = x.HDD,
                RAM = x.RAM,
                Price = x.Price.ToString() + " USD",
                Avatar = x.Avatar,
            }).ToList();
            //Add columns from the sublist to datatable variable
            datatable.Columns.Add("LaptopID");
            datatable.Columns.Add("LaptopName");
            datatable.Columns.Add("LaptopType");
            datatable.Columns.Add("ProductDate");
            datatable.Columns.Add("Processor");
            datatable.Columns.Add("HDD");
            datatable.Columns.Add("RAM");
            datatable.Columns.Add("Price");
            datatable.Columns.Add("ImageName");
            //Add rows from the sublist to datatable variable
            DataRow newrow;
            foreach (var bi in sublist)
            {
                newrow = datatable.NewRow();
                newrow["LaptopID"] = bi.LaptopID;
                newrow["LaptopName"] = bi.LaptopName;
                newrow["LaptopType"] = bi.LaptopType;
                newrow["ProductDate"] = bi.ProductDate;
                newrow["Processor"] = bi.Processor;
                newrow["HDD"] = bi.HDD;
                newrow["RAM"] = bi.RAM;
                newrow["Price"] = bi.Price;
                newrow["ImageName"] = bi.Avatar;
                datatable.Rows.Add(newrow);
                datatable.AcceptChanges();
            }
            //Attach datatable to BindingSource, attach BindingSource to DataGridView
            //BindingSource is a medium that communicate between DataGridView and datatable,
            //When any changes happen to DataGridView or datatable, data will be updated automatically
            binding.AllowNew = true;
            binding.DataSource = datatable;
            dgwLaptopList.AutoGenerateColumns = false;
            dgwLaptopList.DataSource = binding;
        }

        private int ReadDataFromFile(List<Laptop> dataList, string filePath, int colCount)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            xlWorksheet.Columns.ClearFormats();
            xlWorksheet.Rows.ClearFormats();
            int rowCount = xlWorksheet.UsedRange.Rows.Count;
            int numLaptop = 0;
            string LaptopID = "";
            string LaptopName = "";
            string LaptopType = "";
            DateTime ProductDate = DateTime.Now;
            string Processor = "";
            string HDD = "";
            string RAM = "";
            int Price = 0;
            string Avatar = "";
            for (int i = 2; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    switch (j)
                    {
                        case 1: //column LaptopID
                            LaptopID = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 2: //column LaptopName
                            LaptopName = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 3: //column LaptopType
                            LaptopType = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 4: //column ProductDate
                            ProductDate = DateTime.ParseExact(xlRange.Cells[i, j].Value2.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            break;
                        case 5: //column Processor
                            Processor = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 6: //column HDD
                            HDD = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 7: //column RAM
                            RAM = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 8: //column Price
                            Price = Convert.ToInt32(xlRange.Cells[i, j].Value2.ToString());
                            break;
                        case 9: //column Avatar
                            Avatar = xlRange.Cells[i, j].Value2.ToString();
                            break;
                    }
                }
                dataList.Add(new Laptop());
                dataList[numLaptop].LaptopID = LaptopID;
                dataList[numLaptop].LaptopName = LaptopName;
                dataList[numLaptop].LaptopType = LaptopType;
                dataList[numLaptop].ProductDate = ProductDate;
                dataList[numLaptop].Processor = Processor;
                dataList[numLaptop].HDD = HDD;
                dataList[numLaptop].RAM = RAM;
                dataList[numLaptop].Price = Price;
                dataList[numLaptop].Avatar = Avatar;
                numLaptop = numLaptop + 1;
            }
            MessageBox.Show("Loading data from Excel finished: " + (rowCount - 1).ToString() + " records");
            xlApp.Quit();
            return (rowCount - 1);//not count header
        }

        //When user selects a row on the DataGridView, the corresponding image of that laptop will be displayed
        private void dgwLaptopList_SelectionChanged(object sender, EventArgs e)
        {
            if ((LaptopList.Count == 0) || datatable.Rows.Count == 0)
                return;
            CurrentLaptopIndex = dgwLaptopList.CurrentRow.Index;
            if (CurrentLaptopIndex > -1 && CurrentLaptopIndex < LaptopList.Count)
                picLaptopImage.Image = Image.FromFile(ProjectPath + "\\Data\\" + LaptopList[CurrentLaptopIndex].Avatar);
        }
        //Load data from SQL database
        private void btnLoadSQL_Click(object sender, EventArgs e)
        {
            loadData = 2;
            datatable = new DataTable();
            LaptopList.Clear();
            int NumRowData = ReadDataFromSQLServer(LaptopList, connectionString);
            //Create a sublist filtering data from Laptop list
            //This sublist store data showing on DataGridView
            var sublist = LaptopList.Select(x => new
            {
                LaptopID = x.LaptopID,
                LaptopName = x.LaptopName,
                LaptopType = x.LaptopType,
                ProductDate = x.ProductDate.ToString("dd/MM/yyyy"),
                Processor = x.Processor,
                HDD = x.HDD,
                RAM = x.RAM,
                Price = x.Price.ToString() + " USD",
                Avatar = x.Avatar,
            }).ToList();
            //Add columns from the sublist to datatable variable
            datatable.Columns.Add("LaptopID");
            datatable.Columns.Add("LaptopName");
            datatable.Columns.Add("LaptopType");
            datatable.Columns.Add("ProductDate");
            datatable.Columns.Add("Processor");
            datatable.Columns.Add("HDD");
            datatable.Columns.Add("RAM");
            datatable.Columns.Add("Price");
            datatable.Columns.Add("ImageName");
            //Add rows from sublist to datatable variable
            DataRow newrow;
            foreach (var bi in sublist)
            {
                newrow = datatable.NewRow();
                newrow["LaptopID"] = bi.LaptopID;
                newrow["LaptopName"] = bi.LaptopName;
                newrow["LaptopType"] = bi.LaptopType;
                newrow["ProductDate"] = bi.ProductDate;
                newrow["Processor"] = bi.Processor;
                newrow["HDD"] = bi.HDD;
                newrow["RAM"] = bi.RAM;
                newrow["Price"] = bi.Price;
                newrow["ImageName"] = bi.Avatar;
                datatable.Rows.Add(newrow);
                datatable.AcceptChanges();
            }
            binding.AllowNew = true;
            binding.DataSource = datatable;
            dgwLaptopList.AutoGenerateColumns = false;
            dgwLaptopList.DataSource = binding;
        }

        public int ReadDataFromSQLServer(List<Laptop> dataList, string connectionString)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            int iRow = 0;
            int NumRecords = 0;
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open!");
                string SqlString = @"SELECT
                                    LaptopID,
                                    LaptopName,
                                    LaptopType,
                                    ProductDate = Convert(varchar(10), CONVERT(date, ProductDate, 106),103),
                                    Processor,
                                    HDD,
                                    RAM,
                                    Price,
                                    ImageName
                                    FROM dbo.Laptop";
                using (var command = new SqlCommand(SqlString, cnn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LaptopList.Add(new Laptop());
                            LaptopList[iRow].LaptopID = reader.GetString(0);
                            LaptopList[iRow].LaptopName = reader.GetString(1);
                            LaptopList[iRow].LaptopType = reader.GetString(2);
                            LaptopList[iRow].ProductDate = DateTime.ParseExact(reader.GetString(3), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            LaptopList[iRow].Processor = reader.GetString(4);
                            LaptopList[iRow].HDD = reader.GetString(5);
                            LaptopList[iRow].RAM = reader.GetString(6);
                            LaptopList[iRow].Price = reader.GetInt32(7);
                            LaptopList[iRow].Avatar = reader.GetString(8);
                            iRow = iRow + 1;
                        }
                    }
                }
                SqlCommand cmd = new SqlCommand("select count(*) from Laptop", cnn);
                object result = cmd.ExecuteScalar();
                NumRecords = int.Parse(result.ToString());
                MessageBox.Show("Loading data from SQL finished: " + NumRecords.ToString() + " records");
                cnn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot open connection! : " + ex.Message);
            }
            return NumRecords;
        }
        //User can edit data on the DataGridView
        //For Price column, data must be digits
        private void dgwLaptopList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnPrice_KeyPress);
            if (dgwLaptopList.CurrentCell.ColumnIndex == 7) //column Price
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnPrice_KeyPress);
                }
            }
        }
        private void ColumnPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CurrentLaptopIndex < 0)
            {
                MessageBox.Show("Please add new laptops after loading data!");
            }
            else
            {
                Laptop sp = new Laptop();
                sp.LaptopID = "Not Assigned";
                sp.LaptopName = "Not Assigned";
                sp.LaptopType = "Not Assigned";
                sp.ProductDate = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                sp.Processor = "Not Assigned";
                sp.HDD = "Not Assigned";
                sp.RAM = "Not Assigned";
                sp.Price = 0;
                sp.Avatar = "Laptop.jpg";
                LaptopList.Add(sp);

                DataRow newrow;
                newrow = datatable.NewRow();
                newrow["LaptopID"] = sp.LaptopID;
                newrow["LaptopName"] = sp.LaptopName;
                newrow["LaptopType"] = sp.LaptopType;
                newrow["ProductDate"] = sp.ProductDate.ToString("dd/MM/yyyy");
                newrow["Processor"] = sp.Processor;
                newrow["HDD"] = sp.HDD;
                newrow["RAM"] = sp.RAM;
                newrow["Price"] = sp.Price.ToString() + " USD";
                newrow["ImageName"] = sp.Avatar;
                datatable.Rows.Add(newrow);
                datatable.AcceptChanges();

                MessageBox.Show("Finish adding a laptop to the grid view.");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Laptop sp;
            if ((CurrentLaptopIndex >= 0) && (CurrentLaptopIndex < LaptopList.Count))
                sp = LaptopList[CurrentLaptopIndex];
            else
            {
                MessageBox.Show("No laptop is selected.");
                return;
            }
            string question = "Do you want to delete this laptop: " + sp.LaptopID + "?";
            DialogResult result = MessageBox.Show(question, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LaptopList.RemoveAt(CurrentLaptopIndex);
                binding.RemoveAt(CurrentLaptopIndex);
                MessageBox.Show("Finish deleting the laptop from the grid view. ");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CurrentLaptopIndex < 0)
                MessageBox.Show("No laptop is selected.");
            else
            {
                DataRow row;
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    row = datatable.Rows[i];
                    LaptopList[i].LaptopID = row["LaptopID"].ToString();
                    LaptopList[i].LaptopName = row["LaptopName"].ToString();
                    LaptopList[i].LaptopType = row["LaptopType"].ToString();
                    LaptopList[i].ProductDate = DateTime.ParseExact(row["ProductDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    LaptopList[i].Processor = row["Processor"].ToString();
                    LaptopList[i].HDD = row["HDD"].ToString();
                    LaptopList[i].RAM = row["RAM"].ToString();
                    string sPrice = row["Price"].ToString();
                    LaptopList[i].Price = Convert.ToInt32(sPrice.Substring(0, sPrice.IndexOf(" ")));
                    LaptopList[i].Avatar = row["ImageName"].ToString();
                }
                MessageBox.Show("Finish updating the laptop on the grid view.");
            }
        }
        public void btnUpdateSource_Click(object sender, EventArgs e)
        {
            if (loadData == 1)
                WriteDataToExcelFile(LaptopList, excelFilePath);
            else if (loadData == 2)
                WriteDataToSQLServer(LaptopList, connectionString);
            else
                MessageBox.Show("There is no data on the grid view.");
        }
        private void WriteDataToSQLServer(List<Laptop> LaptopList, string connectionString)
        {
            SqlConnection cnn;
            SqlCommand myCommand = new SqlCommand();
            String query;
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open!");

                query = "TRUNCATE TABLE Laptop";
                myCommand.CommandText = query;
                myCommand.Connection = cnn;
                myCommand.ExecuteNonQuery();

                query = @"INSERT INTO Laptop(LaptopID, LaptopName, LaptopType,
                                                ProductDate, Processor, HDD, RAM, Price, ImageName)";
                query += @"VALUES (@LaptopID, @LaptopName, @LaptopType, @ProductDate, @Processor,
                                                @HDD, @RAM, @Price, @ImageName)";

                myCommand.CommandText = query;
                myCommand.Connection = cnn;

                myCommand.Parameters.Add(new SqlParameter("@LaptopID", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@LaptopName", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@LaptopType", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@ProductDate", SqlDbType.DateTime));
                myCommand.Parameters.Add(new SqlParameter("@Processor", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@HDD", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@RAM", SqlDbType.NVarChar));
                myCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int));
                myCommand.Parameters.Add(new SqlParameter("@ImageName", SqlDbType.NVarChar));

                foreach (Laptop sp in LaptopList)
                {
                    myCommand.Parameters[0].Value = sp.LaptopID;
                    myCommand.Parameters[1].Value = sp.LaptopName;
                    myCommand.Parameters[2].Value = sp.LaptopType;
                    myCommand.Parameters[3].Value = sp.ProductDate;
                    myCommand.Parameters[4].Value = sp.Processor;
                    myCommand.Parameters[5].Value = sp.HDD;
                    myCommand.Parameters[6].Value = sp.RAM;
                    myCommand.Parameters[7].Value = sp.Price;
                    myCommand.Parameters[8].Value = sp.Avatar;

                    myCommand.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot open connection! : " + ex.Message);
            }
            MessageBox.Show("Finish update to datasource SQLServer.");
        }
        private void WriteDataToExcelFile(List<Laptop> LaptopList, string excelFilePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange;
            string[,] Data = new string[1, 9];
            int idxRow = 2;
            foreach (Laptop sp in LaptopList)
            {
                Data[0, 0] = sp.LaptopID;
                Data[0, 1] = sp.LaptopName;
                Data[0, 2] = sp.LaptopType;
                Data[0, 3] = sp.ProductDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                Data[0, 4] = sp.Processor;
                Data[0, 5] = sp.HDD;
                Data[0, 6] = sp.RAM;
                Data[0, 7] = sp.Price.ToString();
                Data[0, 8] = sp.Avatar;

                xlRange = xlWorksheet.get_Range("A" + idxRow.ToString(), "J" + idxRow.ToString());
                xlRange.Value2 = Data;
                idxRow = idxRow + 1;
            }
            xlWorkbook.Save();
            xlWorkbook.Close();
            xlApp.Quit();

            MessageBox.Show("Finish update to datasource Excel.");
        }
    }
}
