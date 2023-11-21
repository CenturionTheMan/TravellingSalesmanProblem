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
        private BranchAndBound branchAndBound;

        public BranchAndBound.SearchType babSearchType = BranchAndBound.SearchType.LOW_COST;


        public PopupSettingsForBabForm(Form1 parent, BranchAndBound branchAndBound)
        {
            this.parent = parent;
            this.branchAndBound = branchAndBound;

            var initSearchType = branchAndBound.SelectedSearchType;

            InitializeComponent();

            searchTypeComboBox.DataSource = Enum.GetValues(typeof(BranchAndBound.SearchType));
            searchTypeComboBox.SelectedItem = initSearchType;

            this.Text = branchAndBound.AlgorithmName;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void searchTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    bool wasNull = searchTypeComboBox.SelectedItem == null;

        //}

        private void searchTypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            branchAndBound.SelectedSearchType = (BranchAndBound.SearchType)searchTypeComboBox.SelectedItem;
            parent.AddTextToMessageLog("Selected search type for B&B: " + branchAndBound.SelectedSearchType.ToString() + "\n");
        }

        //private void PopupSettingsForBabForm_FormClosing(object sender, FormClosingEventArgs e)
        //{

        //}
    }
}
