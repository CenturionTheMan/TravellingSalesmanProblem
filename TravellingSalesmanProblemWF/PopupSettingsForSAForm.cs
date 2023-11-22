using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TravellingSalesmanProblemLibrary;
using TravellingSalesmanProblemLibrary.Algorithms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravellingSalesmanProblemWF
{
    public partial class PopupSettingsForSAForm : Form
    {
        private MainForm parent;
        private SimulatedAnnealing algorithm;

        private double initialTemperature;
        private double alpha;
        private int maxRepPerNeighbourSearch;
        private int repAmountPerTemperature;
        private int initCostAmountRepUntilBreak;


        public PopupSettingsForSAForm(MainForm parent, SimulatedAnnealing algorithm)
        {
            this.parent = parent;
            this.algorithm = algorithm;

            initialTemperature = algorithm.InitialTemperature;
            alpha = algorithm.Alpha;
            maxRepPerNeighbourSearch = algorithm.MaxRepPerNeighbourSearch;
            repAmountPerTemperature = algorithm.RepAmountPerTemperature;
            initCostAmountRepUntilBreak = algorithm.InitCostAmountRepUntilBreak;

            InitializeComponent();

            TemperatureNumericUpDown.Value = (decimal)initialTemperature;
            AlphaNumericUpDown.Value = (decimal)alpha;
            RepInNeighbourhoodNumericUpDown.Value = (decimal)maxRepPerNeighbourSearch;
            RepAmountPerTempNumericUpDown.Value = (decimal)repAmountPerTemperature;
            CostRepAmountNumericUpDown.Value = (decimal)initCostAmountRepUntilBreak;

            this.Text = algorithm.AlgorithmName;
        }

        private void AlphaNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            alpha = (double)AlphaNumericUpDown.Value;
        }

        private void TemperatureNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            initialTemperature = (double)TemperatureNumericUpDown.Value;
        }

        private void RepAmountPerTempNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            repAmountPerTemperature = (int)RepAmountPerTempNumericUpDown.Value;
        }

        private void CostRepAmountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            initCostAmountRepUntilBreak = (int)CostRepAmountNumericUpDown.Value;
        }

        private void PopupSettingsForSAForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var simulatedAnnealing = new SimulatedAnnealing(initialTemperature, alpha, repAmountPerTemperature, maxRepPerNeighbourSearch, initCostAmountRepUntilBreak);
            parent.Algorithm = simulatedAnnealing;
            simulatedAnnealing.OnAlgorithmShowInfo += parent.PrintAlgorithMessage;
        }

        private void RepInNeighbourhoodNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            maxRepPerNeighbourSearch = (int)RepInNeighbourhoodNumericUpDown.Value;
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
