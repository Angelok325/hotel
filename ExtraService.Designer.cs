
namespace Project_HMS
{
    partial class ExtraService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraService));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.SId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPackageCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSCost = new System.Windows.Forms.TextBox();
            this.lblSCost = new System.Windows.Forms.Label();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtSId = new System.Windows.Forms.TextBox();
            this.lblSName = new System.Windows.Forms.Label();
            this.lblSId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.dgvService);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtSCost);
            this.panel1.Controls.Add(this.lblSCost);
            this.panel1.Controls.Add(this.txtSName);
            this.panel1.Controls.Add(this.txtSId);
            this.panel1.Controls.Add(this.lblSName);
            this.panel1.Controls.Add(this.lblSId);
            this.panel1.Location = new System.Drawing.Point(38, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 495);
            this.panel1.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1090, 22);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(148, 58);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvService
            // 
            this.dgvService.AllowUserToAddRows = false;
            this.dgvService.AllowUserToDeleteRows = false;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SId,
            this.SName,
            this.SPackageCost});
            this.dgvService.Location = new System.Drawing.Point(564, 103);
            this.dgvService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvService.Name = "dgvService";
            this.dgvService.ReadOnly = true;
            this.dgvService.RowHeadersWidth = 51;
            this.dgvService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvService.Size = new System.Drawing.Size(675, 359);
            this.dgvService.TabIndex = 23;
            this.dgvService.DoubleClick += new System.EventHandler(this.dgvService_DoubleClick);
            // 
            // SId
            // 
            this.SId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SId.DataPropertyName = "SId";
            this.SId.HeaderText = "Сервис ID";
            this.SId.MinimumWidth = 6;
            this.SId.Name = "SId";
            this.SId.ReadOnly = true;
            // 
            // SName
            // 
            this.SName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SName.DataPropertyName = "SName";
            this.SName.HeaderText = "Наименование услуг";
            this.SName.MinimumWidth = 6;
            this.SName.Name = "SName";
            this.SName.ReadOnly = true;
            // 
            // SPackageCost
            // 
            this.SPackageCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SPackageCost.DataPropertyName = "SPackageCost";
            this.SPackageCost.HeaderText = "Стоимость";
            this.SPackageCost.MinimumWidth = 6;
            this.SPackageCost.Name = "SPackageCost";
            this.SPackageCost.ReadOnly = true;
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(386, 345);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 117);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(208, 345);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 117);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(52, 345);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 117);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSCost
            // 
            this.txtSCost.Location = new System.Drawing.Point(294, 255);
            this.txtSCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSCost.Name = "txtSCost";
            this.txtSCost.Size = new System.Drawing.Size(148, 31);
            this.txtSCost.TabIndex = 19;
            // 
            // lblSCost
            // 
            this.lblSCost.AutoSize = true;
            this.lblSCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSCost.Location = new System.Drawing.Point(70, 262);
            this.lblSCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSCost.Name = "lblSCost";
            this.lblSCost.Size = new System.Drawing.Size(129, 25);
            this.lblSCost.TabIndex = 18;
            this.lblSCost.Text = "Стоимость";
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(294, 180);
            this.txtSName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(148, 31);
            this.txtSName.TabIndex = 15;
            // 
            // txtSId
            // 
            this.txtSId.Location = new System.Drawing.Point(294, 103);
            this.txtSId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSId.Name = "txtSId";
            this.txtSId.Size = new System.Drawing.Size(148, 31);
            this.txtSId.TabIndex = 14;
            // 
            // lblSName
            // 
            this.lblSName.AutoSize = true;
            this.lblSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSName.Location = new System.Drawing.Point(70, 184);
            this.lblSName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(251, 25);
            this.lblSName.TabIndex = 13;
            this.lblSName.Text = "Наименование услуги";
            // 
            // lblSId
            // 
            this.lblSId.AutoSize = true;
            this.lblSId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSId.Location = new System.Drawing.Point(70, 103);
            this.lblSId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSId.Name = "lblSId";
            this.lblSId.Size = new System.Drawing.Size(117, 25);
            this.lblSId.TabIndex = 12;
            this.lblSId.Text = "Сервис Id";
            // 
            // ExtraService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1334, 586);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ExtraService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExtraService";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExtraService_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSCost;
        private System.Windows.Forms.Label lblSCost;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtSId;
        private System.Windows.Forms.Label lblSName;
        private System.Windows.Forms.Label lblSId;
        private System.Windows.Forms.DataGridView dgvService;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn SId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPackageCost;
    }
}