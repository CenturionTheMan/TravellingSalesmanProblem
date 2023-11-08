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

namespace TravellingSalesmanProblemWF
{
    public partial class PopupSettingsForBabForm : Form
    {
        public PopupSettingsForBabForm(string algorithmName, ref BranchAndBound.SearchType searchType)
        {
            InitializeComponent();
            searchTypeComboBox.DataSource = Enum.GetValues(typeof(BranchAndBound.SearchType));
            this.Text = algorithmName;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
