using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehousePortal.Core;
using WarehousePortal.Entity;
using WarehousePortal.Service;
using WarehousePortal.View;

namespace WarehousePortal
{
    public partial class Warehouse : Form
    {

        private ArticleService ArticleService = new ArticleService();
        private List<Article> articles = new List<Article>();

        private Logger _logger = Logger.getInstance();

        public Warehouse()
        {
            InitializeComponent();
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            LoadArticles();
        }

        void addButton_Click(object sender, EventArgs e)
        {
            try
            {

                String ArtNo = ArtNoTextBox.Text;
                String Name = NameTextBox.Text;
                String Description = DescriptionTextBox.Text;
                Decimal Price = Decimal.Parse(PriceTextBox.Text, Thread.CurrentThread.CurrentCulture.NumberFormat);
                int Quant = Int32.Parse(QuantTextBox.Text);

                _logger.Debug("addButton_Click -> begin");
                _logger.Debug("addButton_Click -> ArtNo=" + ArtNo);
                _logger.Debug("addButton_Click -> Name=" + Name);
                _logger.Debug("addButton_Click -> Description=" + Description);
                _logger.Debug("addButton_Click -> Price=" + Price);
                _logger.Debug("addButton_Click -> Quant=" + Quant);

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
            ArtNoTextBox.Text = "";
            NameTextBox.Text = "";
            DescriptionTextBox.Text = "";
            PriceTextBox.Text = "";
            QuantTextBox.Text = "";

        }

        private void LoadArticles()
        {

            try
            {
                articles = ArticleService.GetAll();

                LoadArticles(articles);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadArticles(List<Article> articles)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }

            foreach (var article in articles)
            {
                dataGridView1.Rows.Add(article.ToTableRowValues());
            }
        }

        private void OnSearchInput(object sender, EventArgs e)
        {
            String input = this.SearchTextBox.Text.Trim();
            if (String.IsNullOrEmpty(input))
            {
                LoadArticles();
            }
            else
            {
                articles = ArticleService.GetAllLikeArtNo(input);

                LoadArticles(articles);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex > (articles.Count - 1) || e.RowIndex < 0)
            {
                return;
            }

            var senderGrid = (DataGridView)sender;
            var column = senderGrid.Columns[e.ColumnIndex];

            if (column.Tag == null)
            {
                return;
            }

            if (column.Tag.ToString() != ADD_QUANT_COLUMN_NAME
                && column.Tag.ToString() != SUB_QUANT_COLUMN_NAME
                && column.Tag.ToString() != UPDATE_PRICE_NAME
                && column.Tag.ToString() != DELETE_NAME
                )
            {
                return;
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                String input = "";
                int quant = 0;

                try
                {
                    var article = articles[e.RowIndex];

                    if (column.Tag.ToString() == ADD_QUANT_COLUMN_NAME)
                    {
                        input = ChangeQuantPrompt.ShowDialog("Menge: ", "Menge hinzufügen fur " + article.GetArtNo());
                        if (String.IsNullOrEmpty(input))
                        {
                            return;
                        }
                        quant = Int32.Parse(input);
                        ArticleService.AddQuant(article, quant);

                    }
                    else if (column.Tag.ToString() == SUB_QUANT_COLUMN_NAME)
                    {
                        input = ChangeQuantPrompt.ShowDialog("Menge: ", "Menge subtrahieren fur " + article.GetArtNo());
                        if (String.IsNullOrEmpty(input))
                        {
                            return;
                        }
                        quant = Int32.Parse(input);
                        ArticleService.SubQuant(article, quant);
                    }
                    else if (column.Tag.ToString() == UPDATE_PRICE_NAME)
                    {
                        input = ChangePricePrompt.ShowDialog("Preis :", "Preis ändern fur " + article.GetArtNo());
                        if (String.IsNullOrEmpty(input))
                        {
                            return;
                        }
                        var price = Decimal.Parse(input, Thread.CurrentThread.CurrentCulture.NumberFormat);
                        ArticleService.UpdatePrice(article, price);
                    }
                    else if (column.Tag.ToString() == DELETE_NAME)
                    {

                        var result = ConfirmationPrompt.ShowDialog("Möchten Sie es wirklich löschen?", "Löschen", "Ja", "Nein");
                        if (result)
                        {
                            ArticleService.Delete(article);
                        }
                        
                    }

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
        }
    }
}
