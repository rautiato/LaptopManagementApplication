namespace LaptopManagement
{
    partial class frmLaptopManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaptopManagement));
            this.dgwLaptopList = new System.Windows.Forms.DataGridView();
            this.colLaptopID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLaptopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLaptopType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLaptopImage = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateSource = new System.Windows.Forms.Button();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.btnLoadSQL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLaptopList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLaptopImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwLaptopList
            // 
            this.dgwLaptopList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwLaptopList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLaptopID,
            this.colLaptopName,
            this.colLaptopType,
            this.colProductDate,
            this.colProcessor,
            this.colHDD,
            this.colRAM,
            this.colPrice,
            this.colImageName});
            this.dgwLaptopList.Location = new System.Drawing.Point(1, 62);
            this.dgwLaptopList.MultiSelect = false;
            this.dgwLaptopList.Name = "dgwLaptopList";
            this.dgwLaptopList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgwLaptopList.Size = new System.Drawing.Size(576, 330);
            this.dgwLaptopList.TabIndex = 0;
            this.dgwLaptopList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgwLaptopList_EditingControlShowing);
            this.dgwLaptopList.SelectionChanged += new System.EventHandler(this.dgwLaptopList_SelectionChanged);
            // 
            // colLaptopID
            // 
            this.colLaptopID.DataPropertyName = "LaptopID";
            this.colLaptopID.HeaderText = "LaptopID";
            this.colLaptopID.Name = "colLaptopID";
            // 
            // colLaptopName
            // 
            this.colLaptopName.DataPropertyName = "LaptopName";
            this.colLaptopName.HeaderText = "LaptopName";
            this.colLaptopName.Name = "colLaptopName";
            // 
            // colLaptopType
            // 
            this.colLaptopType.DataPropertyName = "LaptopType";
            this.colLaptopType.HeaderText = "LaptopType";
            this.colLaptopType.Name = "colLaptopType";
            // 
            // colProductDate
            // 
            this.colProductDate.DataPropertyName = "ProductDate";
            this.colProductDate.HeaderText = "ProductDate";
            this.colProductDate.Name = "colProductDate";
            // 
            // colProcessor
            // 
            this.colProcessor.DataPropertyName = "Processor";
            this.colProcessor.HeaderText = "Processor";
            this.colProcessor.Name = "colProcessor";
            // 
            // colHDD
            // 
            this.colHDD.DataPropertyName = "HDD";
            this.colHDD.HeaderText = "HDD";
            this.colHDD.Name = "colHDD";
            // 
            // colRAM
            // 
            this.colRAM.DataPropertyName = "RAM";
            this.colRAM.HeaderText = "RAM";
            this.colRAM.Name = "colRAM";
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            // 
            // colImageName
            // 
            this.colImageName.DataPropertyName = "ImageName";
            this.colImageName.HeaderText = "ImageName";
            this.colImageName.Name = "colImageName";
            // 
            // picLaptopImage
            // 
            this.picLaptopImage.Image = ((System.Drawing.Image)(resources.GetObject("picLaptopImage.Image")));
            this.picLaptopImage.InitialImage = null;
            this.picLaptopImage.Location = new System.Drawing.Point(581, 62);
            this.picLaptopImage.Name = "picLaptopImage";
            this.picLaptopImage.Size = new System.Drawing.Size(346, 330);
            this.picLaptopImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLaptopImage.TabIndex = 1;
            this.picLaptopImage.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(13, 407);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 29);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(127, 407);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 29);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(240, 407);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 29);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdateSource
            // 
            this.btnUpdateSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSource.Location = new System.Drawing.Point(352, 407);
            this.btnUpdateSource.Name = "btnUpdateSource";
            this.btnUpdateSource.Size = new System.Drawing.Size(199, 29);
            this.btnUpdateSource.TabIndex = 2;
            this.btnUpdateSource.Text = "Update to DataSource";
            this.btnUpdateSource.UseVisualStyleBackColor = true;
            this.btnUpdateSource.Click += new System.EventHandler(this.btnUpdateSource_Click);
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadExcel.Location = new System.Drawing.Point(44, 17);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(199, 29);
            this.btnLoadExcel.TabIndex = 2;
            this.btnLoadExcel.Text = "Load Data from Excel";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // btnLoadSQL
            // 
            this.btnLoadSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadSQL.Location = new System.Drawing.Point(302, 17);
            this.btnLoadSQL.Name = "btnLoadSQL";
            this.btnLoadSQL.Size = new System.Drawing.Size(199, 29);
            this.btnLoadSQL.TabIndex = 2;
            this.btnLoadSQL.Text = "Load Data from SQL";
            this.btnLoadSQL.UseVisualStyleBackColor = true;
            this.btnLoadSQL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnLoadSQL_Click);
            // 
            // frmLaptopManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 450);
            this.Controls.Add(this.btnLoadSQL);
            this.Controls.Add(this.btnLoadExcel);
            this.Controls.Add(this.btnUpdateSource);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.picLaptopImage);
            this.Controls.Add(this.dgwLaptopList);
            this.Name = "frmLaptopManagement";
            this.Text = "Laptop Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgwLaptopList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLaptopImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwLaptopList;
        private System.Windows.Forms.PictureBox picLaptopImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdateSource;
        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.Button btnLoadSQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLaptopID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLaptopName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLaptopType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImageName;
    }
}

