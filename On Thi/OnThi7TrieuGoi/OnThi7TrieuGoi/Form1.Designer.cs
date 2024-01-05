namespace OnThi7TrieuGoi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtMa = new TextBox();
            txtTen = new TextBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnFind = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 38);
            label1.Name = "label1";
            label1.Size = new Size(30, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 83);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 128);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 2;
            label3.Text = "Đơn Giá";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 173);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 3;
            label4.Text = "Số Lượng";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(183, 37);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(230, 27);
            txtMa.TabIndex = 4;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(183, 82);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(230, 27);
            txtTen.TabIndex = 5;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(183, 127);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(230, 27);
            txtDonGia.TabIndex = 6;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(183, 172);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(230, 27);
            txtSoLuong.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(486, 39);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(486, 83);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(486, 127);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(486, 171);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(94, 29);
            btnFind.TabIndex = 11;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 235);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(667, 200);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellClick += GetASP;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnFind);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtSoLuong);
            Controls.Add(txtDonGia);
            Controls.Add(txtTen);
            Controls.Add(txtMa);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtMa;
        private TextBox txtTen;
        private TextBox txtDonGia;
        private TextBox txtSoLuong;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnFind;
        private DataGridView dataGridView1;
    }
}