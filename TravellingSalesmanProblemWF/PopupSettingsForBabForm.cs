using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravellingSalesmanProblemLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravellingSalesmanProblemWF
{
    public partial class PopupSettingsForBabForm : Form
    {
        private Form1 parent;

        public PopupSettingsForBabForm(Form1 parent, string algorithmName)
        {
            this.parent = parent;
            var initSearchType = parent.babSearchType;

            InitializeComponent();

            searchTypeComboBox.DataSource = Enum.GetValues(typeof(BranchAndBound.SearchType));
            searchTypeComboBox.SelectedItem = initSearchType;

            this.Text = algorithmName;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            bool wasNull = searchTypeComboBox.SelectedItem == null; 
        
        }

        private void searchTypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            parent.babSearchType = (BranchAndBound.SearchType)searchTypeComboBox.SelectedItem;
            parent.AddTextToMessageLog("Selected search type for B&B: " + parent.babSearchType.ToString() + "\n");
        }
    }
}
