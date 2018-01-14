using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehousePortal.View
{
    public static class ConfirmationPrompt
    {
        public static bool ShowDialog(string text, string caption, string okButton, string cancelButton)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,

            };
            Label textLabel = new Label() { Left = 30, Top = 20, Width = 200, Text = text };
            Button yes = new Button() { Text = okButton, Left = 30, Width = 100, Top = 70, DialogResult = DialogResult.Yes };
            Button no = new Button() { Text = cancelButton, Left = 130, Width = 100, Top = 70, DialogResult = DialogResult.No };
            yes.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(yes);
            prompt.Controls.Add(no);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = yes;
            prompt.CancelButton = no;

            return prompt.ShowDialog() == DialogResult.Yes;
        }
    }
}
