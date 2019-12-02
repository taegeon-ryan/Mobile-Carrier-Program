namespace WinFormTest_Telecom
{
    partial class Form4
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMdlClear = new System.Windows.Forms.Button();
            this.btnMdlSearch = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSubsidy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbStorage = new System.Windows.Forms.ComboBox();
            this.cbModelname = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNetwork = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPetname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMdlUpdate = new System.Windows.Forms.Button();
            this.btnMdlDelete = new System.Windows.Forms.Button();
            this.btnMdlCancel = new System.Windows.Forms.Button();
            this.btnMdlApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔스퀘어 Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(28, 26);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(655, 352);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMdlClear);
            this.groupBox1.Controls.Add(this.btnMdlSearch);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbSubsidy);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbPrice);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbColor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbStorage);
            this.groupBox1.Controls.Add(this.cbModelname);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbNetwork);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbPetname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbManufacturer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 395);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(655, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnMdlClear
            // 
            this.btnMdlClear.Font = new System.Drawing.Font("나눔스퀘어 Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMdlClear.Location = new System.Drawing.Point(512, 87);
            this.btnMdlClear.Name = "btnMdlClear";
            this.btnMdlClear.Size = new System.Drawing.Size(52, 52);
            this.btnMdlClear.TabIndex = 22;
            this.btnMdlClear.Text = "지우기";
            this.btnMdlClear.UseVisualStyleBackColor = true;
            this.btnMdlClear.Click += new System.EventHandler(this.btnMdlClear_Click);
            // 
            // btnMdlSearch
            // 
            this.btnMdlSearch.Font = new System.Drawing.Font("나눔스퀘어 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMdlSearch.Location = new System.Drawing.Point(569, 87);
            this.btnMdlSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnMdlSearch.Name = "btnMdlSearch";
            this.btnMdlSearch.Size = new System.Drawing.Size(68, 52);
            this.btnMdlSearch.TabIndex = 21;
            this.btnMdlSearch.Text = "검색";
            this.btnMdlSearch.UseVisualStyleBackColor = true;
            this.btnMdlSearch.Click += new System.EventHandler(this.btnMdlSearch_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔스퀘어", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(444, 117);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "원";
            // 
            // tbSubsidy
            // 
            this.tbSubsidy.BackColor = System.Drawing.SystemColors.Window;
            this.tbSubsidy.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSubsidy.Location = new System.Drawing.Point(329, 114);
            this.tbSubsidy.Margin = new System.Windows.Forms.Padding(2);
            this.tbSubsidy.Name = "tbSubsidy";
            this.tbSubsidy.Size = new System.Drawing.Size(114, 24);
            this.tbSubsidy.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(263, 115);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 18;
            this.label11.Text = "지원금";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔스퀘어", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(196, 117);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "원";
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPrice.Location = new System.Drawing.Point(81, 115);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(113, 24);
            this.tbPrice.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔스퀘어", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(158, 87);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "GB";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(16, 115);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "출고가";
            // 
            // cbColor
            // 
            this.cbColor.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(329, 84);
            this.cbColor.Margin = new System.Windows.Forms.Padding(2);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(136, 24);
            this.cbColor.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(263, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "색상";
            // 
            // cbStorage
            // 
            this.cbStorage.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbStorage.FormattingEnabled = true;
            this.cbStorage.Location = new System.Drawing.Point(81, 84);
            this.cbStorage.Margin = new System.Windows.Forms.Padding(2);
            this.cbStorage.Name = "cbStorage";
            this.cbStorage.Size = new System.Drawing.Size(76, 24);
            this.cbStorage.TabIndex = 11;
            this.cbStorage.SelectedIndexChanged += new System.EventHandler(this.cbStorage_SelectedIndexChanged);
            // 
            // cbModelname
            // 
            this.cbModelname.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbModelname.FormattingEnabled = true;
            this.cbModelname.Location = new System.Drawing.Point(330, 52);
            this.cbModelname.Margin = new System.Windows.Forms.Padding(2);
            this.cbModelname.Name = "cbModelname";
            this.cbModelname.Size = new System.Drawing.Size(156, 24);
            this.cbModelname.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(264, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "모델명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(16, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "용량";
            // 
            // cbNetwork
            // 
            this.cbNetwork.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbNetwork.FormattingEnabled = true;
            this.cbNetwork.Location = new System.Drawing.Point(330, 19);
            this.cbNetwork.Margin = new System.Windows.Forms.Padding(2);
            this.cbNetwork.Name = "cbNetwork";
            this.cbNetwork.Size = new System.Drawing.Size(53, 24);
            this.cbNetwork.TabIndex = 7;
            this.cbNetwork.SelectedIndexChanged += new System.EventHandler(this.cbNetwork_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(264, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "통신망";
            // 
            // cbPetname
            // 
            this.cbPetname.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPetname.FormattingEnabled = true;
            this.cbPetname.Location = new System.Drawing.Point(82, 52);
            this.cbPetname.Margin = new System.Windows.Forms.Padding(2);
            this.cbPetname.Name = "cbPetname";
            this.cbPetname.Size = new System.Drawing.Size(157, 24);
            this.cbPetname.TabIndex = 3;
            this.cbPetname.SelectedIndexChanged += new System.EventHandler(this.cbPetname_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "기종명";
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.Location = new System.Drawing.Point(82, 20);
            this.cbManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(104, 24);
            this.cbManufacturer.TabIndex = 1;
            this.cbManufacturer.SelectedIndexChanged += new System.EventHandler(this.cbManufacturer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "제조사";
            // 
            // btnMdlUpdate
            // 
            this.btnMdlUpdate.Font = new System.Drawing.Font("나눔스퀘어 Bold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMdlUpdate.Location = new System.Drawing.Point(37, 563);
            this.btnMdlUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnMdlUpdate.Name = "btnMdlUpdate";
            this.btnMdlUpdate.Size = new System.Drawing.Size(64, 24);
            this.btnMdlUpdate.TabIndex = 3;
            this.btnMdlUpdate.Text = "수정";
            this.btnMdlUpdate.UseVisualStyleBackColor = true;
            this.btnMdlUpdate.Visible = false;
            this.btnMdlUpdate.Click += new System.EventHandler(this.btnMdlUpdate_Click);
            // 
            // btnMdlDelete
            // 
            this.btnMdlDelete.Font = new System.Drawing.Font("나눔스퀘어 Bold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMdlDelete.Location = new System.Drawing.Point(109, 563);
            this.btnMdlDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnMdlDelete.Name = "btnMdlDelete";
            this.btnMdlDelete.Size = new System.Drawing.Size(64, 24);
            this.btnMdlDelete.TabIndex = 4;
            this.btnMdlDelete.Text = "삭제";
            this.btnMdlDelete.UseVisualStyleBackColor = true;
            this.btnMdlDelete.Visible = false;
            this.btnMdlDelete.Click += new System.EventHandler(this.btnMdlDelete_Click);
            // 
            // btnMdlCancel
            // 
            this.btnMdlCancel.Font = new System.Drawing.Font("나눔스퀘어 Bold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMdlCancel.Location = new System.Drawing.Point(444, 563);
            this.btnMdlCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnMdlCancel.Name = "btnMdlCancel";
            this.btnMdlCancel.Size = new System.Drawing.Size(107, 24);
            this.btnMdlCancel.TabIndex = 5;
            this.btnMdlCancel.Text = "취소";
            this.btnMdlCancel.UseVisualStyleBackColor = true;
            this.btnMdlCancel.Visible = false;
            this.btnMdlCancel.Click += new System.EventHandler(this.btnMdlCancel_Click);
            // 
            // btnMdlApply
            // 
            this.btnMdlApply.Font = new System.Drawing.Font("나눔스퀘어 Bold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMdlApply.Location = new System.Drawing.Point(567, 563);
            this.btnMdlApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnMdlApply.Name = "btnMdlApply";
            this.btnMdlApply.Size = new System.Drawing.Size(107, 24);
            this.btnMdlApply.TabIndex = 6;
            this.btnMdlApply.Text = "선택";
            this.btnMdlApply.UseVisualStyleBackColor = true;
            this.btnMdlApply.Visible = false;
            this.btnMdlApply.Click += new System.EventHandler(this.btnMdlApply_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(713, 604);
            this.Controls.Add(this.btnMdlApply);
            this.Controls.Add(this.btnMdlCancel);
            this.Controls.Add(this.btnMdlDelete);
            this.Controls.Add(this.btnMdlUpdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.Text = "기종 조회";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.ComboBox cbPetname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbStorage;
        private System.Windows.Forms.ComboBox cbModelname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbSubsidy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnMdlSearch;
        private System.Windows.Forms.Button btnMdlUpdate;
        private System.Windows.Forms.Button btnMdlDelete;
        private System.Windows.Forms.Button btnMdlCancel;
        private System.Windows.Forms.Button btnMdlApply;
        private System.Windows.Forms.ComboBox cbNetwork;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMdlClear;
    }
}