using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehousePortal.Entity;
using WarehousePortal.Service;

namespace WarehousePortal
{
    public partial class Warehouse : Form
    {

        private ArticleService ArticleService = new ArticleService();
        private List<Article> articles = new List<Article>();

        public Warehouse()
        {
            InitializeComponent();
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            this.LoadArticles();


        }

        void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var ArtNo = Int32.Parse(ArtNoTextBox.Text);
                var Name = NameTextBox.Text;
                var Description = DescriptionTextBox.Text;
                var Price = Decimal.Parse(PriceTextBox.Text);
                var Quant = Int32.Parse(QuantTextBox.Text);

                var article = ArticleService.Add(ArtNo, Name, Description, Price, Quant);

                MessageBox.Show(article.GetName() + " erfolgreich hinzugefügt");
                ResetFields();
                LoadArticles();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Ungültige Eingabe");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ungültige Eingabe");
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        void resetButton_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {

            var selectedIndex = dataGridView1.CurrentCell.RowIndex;

            ArtNoTextBox.Text = "";
            NameTextBox.Text = "";
            DescriptionTextBox.Text = "";
            PriceTextBox.Text = "";
            QuantTextBox.Text = "";

        }

        private void LoadArticles()
        {
            articles = ArticleService.GetAll();

            dataGridView1.Rows.Clear();

            foreach (var article in articles)
            {
                dataGridView1.Rows.Add(article.ToTableRowValues());
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
