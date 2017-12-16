using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehousePortal.View
{
    class ChangePricePrompt
    {

        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 130,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 100, Top = 10, Text = text };
            TextBox textBox = new TextBox() { Left = 100, Top = 30, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 240, Width = 60, Top = 50, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            textBox.KeyPress += new KeyPressEventHandler(Int_KeyPress);

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private static void Int_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
