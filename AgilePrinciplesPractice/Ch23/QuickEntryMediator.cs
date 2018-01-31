using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AgilePrinciplesPractice.Ch23
{
    public class QuickEntryMediator
    {
        private TextBox itsTextBox;
        private ListBox itsListBox;

        public QuickEntryMediator(TextBox itsTextBox, ListBox itsListBox)
        {
            this.itsTextBox = itsTextBox;
            this.itsListBox = itsListBox;
            itsTextBox.TextChanged += new EventHandler(TextFieldChanged);
        }

        private void TextFieldChanged(object source, EventArgs args)
        {
            string prefix = itsTextBox.Text;
            if (prefix.Length == 0)
            {
                itsListBox.ClearSelection();
                return;
            }

            ListItemCollection listItems = itsListBox.Items;
            bool found = false;
            for (int i = 0; found == false && i < listItems.Count; i++)
            {
                object o = listItems[i];
                string s = o.ToString();
                if (s.StartsWith(prefix))
                {
                    itsListBox.Items[i].Selected = true;
                    found = true;
                }
            }

            if (!found)
            {
                itsListBox.ClearSelection();
            }
        }
    }
}