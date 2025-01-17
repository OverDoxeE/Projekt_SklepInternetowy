namespace Projekt_SklepInternetowy
{
    partial class FormEditProduct
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtGameTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPlatform;
        private System.Windows.Forms.Button btnSave;

        /// <summary>
        /// Cleanup resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtGameTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPlatform = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtGameTitle
            this.txtGameTitle.Location = new System.Drawing.Point(50, 50);
            this.txtGameTitle.Name = "txtGameTitle";
            this.txtGameTitle.Size = new System.Drawing.Size(300, 31);
            this.txtGameTitle.TabIndex = 0;

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(50, 100);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 31);
            this.txtDescription.TabIndex = 1;

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(50, 150);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(300, 31);
            this.txtPrice.TabIndex = 2;

            // txtPlatform
            this.txtPlatform.Location = new System.Drawing.Point(50, 200);
            this.txtPlatform.Name = "txtPlatform";
            this.txtPlatform.Size = new System.Drawing.Size(300, 31);
            this.txtPlatform.TabIndex = 3;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(50, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // FormEditProduct
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.txtGameTitle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtPlatform);
            this.Controls.Add(this.btnSave);
            this.Name = "FormEditProduct";
            this.Text = "Edytuj produkt";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
