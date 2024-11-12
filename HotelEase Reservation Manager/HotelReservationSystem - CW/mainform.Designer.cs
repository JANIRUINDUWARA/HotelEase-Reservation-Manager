namespace HotelReservationSystem___CW
{
    partial class mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.addnew = new System.Windows.Forms.Button();
            this.database = new System.Windows.Forms.Button();
            this.billsection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addnew
            // 
            this.addnew.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addnew.Location = new System.Drawing.Point(71, 251);
            this.addnew.Name = "addnew";
            this.addnew.Size = new System.Drawing.Size(216, 52);
            this.addnew.TabIndex = 0;
            this.addnew.Text = "Add New Customer";
            this.addnew.UseVisualStyleBackColor = true;
            this.addnew.Click += new System.EventHandler(this.button1_Click);
            // 
            // database
            // 
            this.database.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.database.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.database.Location = new System.Drawing.Point(71, 336);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(216, 52);
            this.database.TabIndex = 0;
            this.database.Text = "Customer DataBase";
            this.database.UseVisualStyleBackColor = true;
            this.database.Click += new System.EventHandler(this.database_Click);
            // 
            // billsection
            // 
            this.billsection.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billsection.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.billsection.Location = new System.Drawing.Point(71, 419);
            this.billsection.Name = "billsection";
            this.billsection.Size = new System.Drawing.Size(216, 52);
            this.billsection.TabIndex = 0;
            this.billsection.Text = "Bill Section";
            this.billsection.UseVisualStyleBackColor = true;
            this.billsection.Click += new System.EventHandler(this.billsection_Click);
            // 
            // mainform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.billsection);
            this.Controls.Add(this.database);
            this.Controls.Add(this.addnew);
            this.Name = "mainform";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addnew;
        private System.Windows.Forms.Button database;
        private System.Windows.Forms.Button billsection;
    }
}