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
        private MainForm parent;

        public SearchType babSearchType = SearchType.LOW_COST;


        public PopupSettingsForBabForm(MainForm parent, BranchAndBound branchAndBound)
        {
            this.parent = parent;

            var initSearchType = branchAndBound.SelectedSearchType;

            InitializeComponent();

            searchTypeComboBox.DataSource = Enum.GetValues(typeof(SearchType));
            searchTypeComboBox.SelectedItem = initSearchType;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void searchTypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            babSearchType = (SearchType)searchTypeComboBox.SelectedItem;
            //parent.AddTextToMessageLog("Selected search type for B&B: " + branchAndBound.SelectedSearchType.ToString() + "\n");
        }

        private void PopupSettingsForBabForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parent.Algorithm = new BranchAndBound(babSearchType);
            parent.AddTextToMessageLog("Changes saved!\n");
        }

    }
}
