namespace WinFormTest_Telecom
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbMinSpeed = new System.Windows.Forms.ComboBox();
            this.cbData = new System.Windows.Forms.ComboBox();
            this.cbCallText = new System.Windows.Forms.ComboBox();
            this.cbPrice = new System.Windows.Forms.ComboBox();
            this.cbPlanName = new System.Windows.Forms.ComboBox();
            this.tbFeature = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbPlanClass = new System.Windows.Forms.ComboBox();
            this.cbNetwork = new System.Windows.Forms.ComboBox();
            this.cbTelecom = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlanApply = new System.Windows.Forms.Button();
            this.btnPlanCancel = new System.Windows.Forms.Button();
            this.btnPlanUpdate = new System.Windows.Forms.Button();
            this.btnPlanDelete = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.cbMinSpeed);
            this.groupBox1.Controls.Add(this.cbData);
            this.groupBox1.Controls.Add(this.cbCallText);
            this.groupBox1.Controls.Add(this.cbPrice);
            this.groupBox1.Controls.Add(this.cbPlanName);
            this.groupBox1.Controls.Add(this.tbFeature);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbPlanClass);
            this.groupBox1.Controls.Add(this.cbNetwork);
            this.groupBox1.Controls.Add(this.cbTelecom);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 395);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(655, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("나눔스퀘어 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(562, 111);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 53);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("나눔스퀘어 Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClear.Location = new System.Drawing.Point(501, 111);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 53);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbMinSpeed
            // 
            this.cbMinSpeed.Font = new System.Drawing.Font("나눔스퀘어", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbMinSpeed.FormattingEnabled = true;
            this.cbMinSpeed.Location = new System.Drawing.Point(501, 79);
            this.cbMinSpeed.Name = "cbMinSpeed";
            this.cbMinSpeed.Size = new System.Drawing.Size(121, 25);
            this.cbMinSpeed.TabIndex = 24;
            // 
            // cbData
            // 
            this.cbData.Font = new System.Drawing.Font("나눔스퀘어", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbData.FormattingEnabled = true;
            this.cbData.Location = new System.Drawing.Point(288, 79);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(121, 25);
            this.cbData.TabIndex = 23;
            // 
            // cbCallText
            // 
            this.cbCallText.Font = new System.Drawing.Font("나눔스퀘어", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCallText.FormattingEnabled = true;
            this.cbCallText.Location = new System.Drawing.Point(100, 79);
            this.cbCallText.Name = "cbCallText";
            this.cbCallText.Size = new System.Drawing.Size(108, 25);
            this.cbCallText.TabIndex = 22;
            // 
            // cbPrice
            // 
            this.cbPrice.Font = new System.Drawing.Font("나눔스퀘어", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPrice.FormattingEnabled = true;
            this.cbPrice.Location = new System.Drawing.Point(418, 47);
            this.cbPrice.Name = "cbPrice";
            this.cbPrice.Size = new System.Drawing.Size(121, 25);
            this.cbPrice.TabIndex = 21;
            // 
            // cbPlanName
            // 
            this.cbPlanName.Font = new System.Drawing.Font("나눔스퀘어", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPlanName.FormattingEnabled = true;
            this.cbPlanName.Location = new System.Drawing.Point(260, 49);
            this.cbPlanName.Name = "cbPlanName";
            this.cbPlanName.Size = new System.Drawing.Size(99, 25);
            this.cbPlanName.TabIndex = 20;
            this.cbPlanName.SelectedIndexChanged += new System.EventHandler(this.cbPlanName_SelectedIndexChanged);
            // 
            // tbFeature
            // 
            this.tbFeature.Font = new System.Drawing.Font("나눔스퀘어", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbFeature.Location = new System.Drawing.Point(100, 111);
            this.tbFeature.Margin = new System.Windows.Forms.Padding(2);
            this.tbFeature.Multiline = true;
            this.tbFeature.Name = "tbFeature";
            this.tbFeature.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFeature.Size = new System.Drawing.Size(333, 53);
            this.tbFeature.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(17, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "특징";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔스퀘어", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(542, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "원(월)";
            // 
            // cbPlanClass
            // 
            this.cbPlanClass.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPlanClass.FormattingEnabled = true;
            this.cbPlanClass.Location = new System.Drawing.Point(100, 49);
            this.cbPlanClass.Margin = new System.Windows.Forms.Padding(2);
            this.cbPlanClass.Name = "cbPlanClass";
            this.cbPlanClass.Size = new System.Drawing.Size(155, 24);
            this.cbPlanClass.TabIndex = 10;
            this.cbPlanClass.SelectedIndexChanged += new System.EventHandler(this.cbPlanClass_SelectedIndexChanged);
            // 
            // cbNetwork
            // 
            this.cbNetwork.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbNetwork.FormattingEnabled = true;
            this.cbNetwork.Location = new System.Drawing.Point(271, 17);
            this.cbNetwork.Margin = new System.Windows.Forms.Padding(2);
            this.cbNetwork.Name = "cbNetwork";
            this.cbNetwork.Size = new System.Drawing.Size(60, 24);
            this.cbNetwork.TabIndex = 9;
            this.cbNetwork.SelectedIndexChanged += new System.EventHandler(this.cbNetwork_SelectedIndexChanged);
            // 
            // cbTelecom
            // 
            this.cbTelecom.Font = new System.Drawing.Font("나눔스퀘어", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbTelecom.FormattingEnabled = true;
            this.cbTelecom.Location = new System.Drawing.Point(100, 18);
            this.cbTelecom.Margin = new System.Windows.Forms.Padding(2);
            this.cbTelecom.Name = "cbTelecom";
            this.cbTelecom.Size = new System.Drawing.Size(72, 24);
            this.cbTelecom.TabIndex = 8;
            this.cbTelecom.SelectedIndexChanged += new System.EventHandler(this.cbTelecom_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(17, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "통신사";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(204, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "통신망";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(428, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "속도제한";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(230, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "데이터";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(17, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "음성/문자";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(375, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "요금";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "요금제명";
            // 
            // btnPlanApply
            // 
            this.btnPlanApply.Font = new System.Drawing.Font("나눔스퀘어 Bold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlanApply.Location = new System.Drawing.Point(576, 585);
            this.btnPlanApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlanApply.Name = "btnPlanApply";
            this.btnPlanApply.Size = new System.Drawing.Size(107, 24);
            this.btnPlanApply.TabIndex = 2;
            this.btnPlanApply.Text = "선택";
            this.btnPlanApply.UseVisualStyleBackColor = true;
            this.btnPlanApply.Visible = false;
            this.btnPlanApply.Click += new System.EventHandler(this.btnPlanApply_Click);
            // 
            // btnPlanCancel
            // 
            this.btnPlanCancel.Font = new System.Drawing.Font("나눔스퀘어 Bold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlanCancel.Location = new System.Drawing.Point(452, 585);
            this.btnPlanCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlanCancel.Name = "btnPlanCancel";
            this.btnPlanCancel.Size = new System.Drawing.Size(107, 24);
            this.btnPlanCancel.TabIndex = 3;
            this.btnPlanCancel.Text = "취소";
            this.btnPlanCancel.UseVisualStyleBackColor = true;
            this.btnPlanCancel.Visible = false;
            this.btnPlanCancel.Click += new System.EventHandler(this.btnPlanCancel_Click);
            // 
            // btnPlanUpdate
            // 
            this.btnPlanUpdate.Font = new System.Drawing.Font("나눔스퀘어 Bold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlanUpdate.Location = new System.Drawing.Point(27, 585);
            this.btnPlanUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlanUpdate.Name = "btnPlanUpdate";
            this.btnPlanUpdate.Size = new System.Drawing.Size(64, 24);
            this.btnPlanUpdate.TabIndex = 5;
            this.btnPlanUpdate.Text = "수정";
            this.btnPlanUpdate.UseVisualStyleBackColor = true;
            this.btnPlanUpdate.Visible = false;
            this.btnPlanUpdate.Click += new System.EventHandler(this.btnPlanUpdate_Click);
            // 
            // btnPlanDelete
            // 
            this.btnPlanDelete.Font = new System.Drawing.Font("나눔스퀘어 Bold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlanDelete.Location = new System.Drawing.Point(100, 585);
            this.btnPlanDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlanDelete.Name = "btnPlanDelete";
            this.btnPlanDelete.Size = new System.Drawing.Size(64, 24);
            this.btnPlanDelete.TabIndex = 6;
            this.btnPlanDelete.Text = "삭제";
            this.btnPlanDelete.UseVisualStyleBackColor = true;
            this.btnPlanDelete.Visible = false;
            this.btnPlanDelete.Click += new System.EventHandler(this.btnPlanDelete_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(713, 629);
            this.Controls.Add(this.btnPlanDelete);
            this.Controls.Add(this.btnPlanUpdate);
            this.Controls.Add(this.btnPlanCancel);
            this.Controls.Add(this.btnPlanApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3";
            this.Text = "요금제 조회";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTelecom;
        private System.Windows.Forms.ComboBox cbPlanClass;
        private System.Windows.Forms.ComboBox cbNetwork;
        private System.Windows.Forms.Button btnPlanApply;
        private System.Windows.Forms.Button btnPlanCancel;
        private System.Windows.Forms.Button btnPlanUpdate;
        private System.Windows.Forms.Button btnPlanDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFeature;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbPlanName;
        private System.Windows.Forms.ComboBox cbMinSpeed;
        private System.Windows.Forms.ComboBox cbData;
        private System.Windows.Forms.ComboBox cbCallText;
        private System.Windows.Forms.ComboBox cbPrice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
    }
}