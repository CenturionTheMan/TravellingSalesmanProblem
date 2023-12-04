using TravellingSalesmanProblemLibrary.Algorithms;

namespace TravellingSalesmanProblemWF
{
    public partial class PopupSettingsForSAForm : Form
    {
        private MainForm parent;

        private double initialTemperature;
        private double alpha;
        private int maxRepPerNeighbourSearch;
        private int repAmountPerTemperature;
        private int initCostAmountRepUntilBreak;
        private SimulatedAnnealing.CoolingFunction coolingFunction;

        public PopupSettingsForSAForm(MainForm parent, SimulatedAnnealing algorithm)
        {
            this.parent = parent;

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

            CoolingTypeComboBox.DataSource = Enum.GetValues(typeof(SimulatedAnnealing.CoolingFunction));
            CoolingTypeComboBox.SelectedItem = algorithm.ChoosenCoolingFunction;
            coolingFunction = algorithm.ChoosenCoolingFunction;

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
            var simulatedAnnealing = new SimulatedAnnealing(initialTemperature, alpha, repAmountPerTemperature, maxRepPerNeighbourSearch, initCostAmountRepUntilBreak, coolingFunction);
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

        private void CoolingTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            coolingFunction = (SimulatedAnnealing.CoolingFunction)CoolingTypeComboBox.SelectedItem;

            TemperatureNumericUpDown.Enabled = true;

            switch (coolingFunction)
            {
                case SimulatedAnnealing.CoolingFunction.LINEAR:
                    AlphaNumericUpDown.DecimalPlaces = 2;
                    AlphaNumericUpDown.Maximum = 1000000;
                    AlphaNumericUpDown.Minimum = (decimal)0.01;
                    AlphaNumericUpDown.Increment = (decimal)0.01;
                    break;
                case SimulatedAnnealing.CoolingFunction.LOGARITHMIC:
                    TemperatureNumericUpDown.Enabled = false;
                    AlphaNumericUpDown.DecimalPlaces = 1;
                    AlphaNumericUpDown.Maximum = 1000000;
                    AlphaNumericUpDown.Minimum = (decimal)0.1;
                    AlphaNumericUpDown.Increment = (decimal)0.1;
                    break;
                case SimulatedAnnealing.CoolingFunction.GEOMETRIC:
                    AlphaNumericUpDown.DecimalPlaces = 4;
                    AlphaNumericUpDown.Maximum = (decimal)0.9999;
                    AlphaNumericUpDown.Minimum = (decimal)0.0001;
                    AlphaNumericUpDown.Increment = (decimal)0.0001;

                    break;
                default:
                    break;
            }
        }
    }
}
