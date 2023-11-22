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
using TravellingSalesmanProblemLibrary.Algorithms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravellingSalesmanProblemWF
{
    public partial class PopupSettingsForSAForm : Form
    {
        private MainForm parent;
        private SimulatedAnnealing algorithm;

        public BranchAndBound.SearchType babSearchType = BranchAndBound.SearchType.LOW_COST;


        public PopupSettingsForSAForm(MainForm parent, SimulatedAnnealing algorithm)
        {
            this.parent = parent;
            this.algorithm = algorithm;


            InitializeComponent();

            this.Text = algorithm.AlgorithmName;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
