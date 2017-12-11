using System;
using System.Drawing;
using System.Windows.Forms;

namespace WarehousePortal
{
    partial class Warehouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;

        private TextBox ArtNoTextBox;
        private TextBox NameTextBox;
        private TextBox DescriptionTextBox;
        private TextBox PriceTextBox;
        private TextBox QuantTextBox;

        private Label ArtNoLabel;
        private Label NameLabel;
        private Label DescriptionLabel;
        private Label PriceLabel;
        private Label QuantLabel;

        private Button ResetButton;
        private Button AddButton;


        private ToolTip toolTip1;

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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView1.MultiSelect = false;

            var ArtNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ArtNo.HeaderText = "Artikel Nu.";

            var Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Name.HeaderText = "Name";

            var Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Description.HeaderText = "Beschreibung";

            var Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Price.HeaderText = "Preis";

            var Quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Quant.HeaderText = "Menge";

            this.ArtNoLabel = new System.Windows.Forms.Label();
            this.ArtNoLabel.Text = "Artikel Nu.";
            this.ArtNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.NameLabel = new System.Windows.Forms.Label();
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel.Text = "Beschreibung";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.PriceLabel = new System.Windows.Forms.Label();
            this.PriceLabel.Text = "Preis";
            this.PriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.QuantLabel = new System.Windows.Forms.Label();
            this.QuantLabel.Text = "Menge";
            this.QuantLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.ArtNoTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.QuantTextBox = new System.Windows.Forms.TextBox();


            this.ResetButton = new System.Windows.Forms.Button();
            this.ResetButton.Text = "Neu fassen";
            this.ResetButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.AddButton = new System.Windows.Forms.Button();
            this.AddButton.Text = "Speichern";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.ArtNoTextBox);
            this.panel1.Controls.Add(this.NameTextBox);
            this.panel1.Controls.Add(this.DescriptionTextBox);
            this.panel1.Controls.Add(this.PriceTextBox);
            this.panel1.Controls.Add(this.QuantTextBox);

            this.panel1.Controls.Add(this.ArtNoLabel);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Controls.Add(this.DescriptionLabel);
            this.panel1.Controls.Add(this.PriceLabel);
            this.panel1.Controls.Add(this.QuantLabel);

            this.panel1.Controls.Add(this.ResetButton);
            this.panel1.Controls.Add(this.AddButton);

            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "Neuer Artikel";
            this.panel1.Size = new System.Drawing.Size(300, 737);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(287, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 737);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                 ArtNo,
                 Name,
                 Description ,
                 Price ,
                 Quant
            });
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(685, 737);
            this.dataGridView1.TabIndex = 0;

            // 
            // NameLabel
            // 
            this.ArtNoLabel.AutoSize = true;
            this.ArtNoLabel.Location = new System.Drawing.Point(5, 20);
            this.ArtNoLabel.Name = "ArtNoLabel";
            this.ArtNoLabel.Size = new System.Drawing.Size(35, 13);
            this.ArtNoLabel.TabIndex = 0;

            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(5, 50);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 1;

            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(5, 80);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(35, 13);
            this.DescriptionLabel.TabIndex = 2;


            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(5, 110);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(35, 13);
            this.PriceLabel.TabIndex = 1;

            // 
            // QuantLabel
            // 
            this.QuantLabel.AutoSize = true;
            this.QuantLabel.Location = new System.Drawing.Point(5, 140);
            this.QuantLabel.Name = "QuantLabel";
            this.QuantLabel.Size = new System.Drawing.Size(35, 13);
            this.QuantLabel.TabIndex = 2;


            // 
            // ArtNoTextBox
            // 
            this.ArtNoTextBox.Location = new System.Drawing.Point(80, 20);
            this.ArtNoTextBox.Name = "ArtNoTextBox";
            this.ArtNoTextBox.Size = new System.Drawing.Size(180, 20);
            this.ArtNoTextBox.TabIndex = 3;
            this.ArtNoTextBox.KeyPress += new KeyPressEventHandler(Int_KeyPress);

            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(80, 50);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(180, 20);
            this.NameTextBox.TabIndex = 4;
           
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(80, 80);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(180, 20);
            this.DescriptionTextBox.TabIndex = 5;

            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(80, 110);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(180, 20);
            this.PriceTextBox.TabIndex = 5;
            this.PriceTextBox.KeyPress += new KeyPressEventHandler(Number_KeyPress);

            // 
            // QuantTextBox
            // 
            this.QuantTextBox.Location = new System.Drawing.Point(80, 140);
            this.QuantTextBox.Name = "QuantTextBox";
            this.QuantTextBox.Size = new System.Drawing.Size(180, 20);
            this.QuantTextBox.TabIndex = 5;
            this.QuantTextBox.KeyPress += new KeyPressEventHandler(Number_KeyPress);

            this.ResetButton.Location = new System.Drawing.Point(5, 180);
            this.ResetButton.Size = new System.Drawing.Size(105, 30);
            this.ResetButton.Click += new System.EventHandler(this.resetButton_Click);
            

            this.AddButton.Location = new System.Drawing.Point(110, 180);
            this.AddButton.Size = new System.Drawing.Size(105, 30);
            this.AddButton.Font = AddButton.Font = new Font(AddButton.Font.Name, AddButton.Font.Size, FontStyle.Bold);
            this.AddButton.Click += new System.EventHandler(this.addButton_Click);

            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.Name = "Warehouse";
            this.Text = "Warehouse";
            this.Load += new System.EventHandler(this.Warehouse_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Int_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }


    }
}

