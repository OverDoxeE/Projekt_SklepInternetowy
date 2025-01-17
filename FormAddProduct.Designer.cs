namespace Projekt_SklepInternetowy
{
    partial class FormAddProduct
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtGameTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPlatform;
        private System.Windows.Forms.Button btnSave;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddProduct));
            txtGameTitle = new TextBox();
            txtDescription = new TextBox();
            txtPrice = new TextBox();
            txtPlatform = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtGameTitle
            // 
            txtGameTitle.Location = new Point(50, 50);
            txtGameTitle.Name = "txtGameTitle";
            txtGameTitle.Size = new Size(300, 31);
            txtGameTitle.TabIndex = 0;
            txtGameTitle.Text = "Wpisz tytuł";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(50, 100);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(300, 31);
            txtDescription.TabIndex = 1;
            txtDescription.Text = "Opis";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(50, 150);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(300, 31);
            txtPrice.TabIndex = 2;
            txtPrice.Text = "Cena";
            // 
            // txtPlatform
            // 
            txtPlatform.Location = new Point(50, 200);
            txtPlatform.Name = "txtPlatform";
            txtPlatform.Size = new Size(300, 31);
            txtPlatform.TabIndex = 3;
            txtPlatform.Text = "Platforma";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(145, 259);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 4;
            btnSave.Text = "Zapisz";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FormAddProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 350);
            Controls.Add(txtGameTitle);
            Controls.Add(txtDescription);
            Controls.Add(txtPrice);
            Controls.Add(txtPlatform);
            Controls.Add(btnSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAddProduct";
            Text = "Dodaj Produkt";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
