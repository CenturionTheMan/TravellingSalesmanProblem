using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemWF
{
    public partial class PopupSettingsForGAForm : Form
    {
        private MainForm parent;

        private int populationSize;
        private CrossoverType crossoverType;
        private double crossoverChance;
        private MutationType mutationType;
        private double mutationChance;
        private int costAmountRepUntilBreak;

        public PopupSettingsForGAForm(MainForm parent, GeneticAlgorithm algorithm)
        {
            this.parent = parent;

            populationSize = algorithm.PopulationSize;
            crossoverType = algorithm.CrossoverType;
            crossoverChance = algorithm.CrossoverChance;
            mutationType = algorithm.MutationType;
            mutationChance = algorithm.MutationChance;
            costAmountRepUntilBreak = algorithm.CostRepAmountWithoutImprovementUntilBreak!.Value;

            InitializeComponent();

            PopulationNumericUpDown.Value = (decimal)populationSize;
            CrossChanceUpDown.Value = (decimal)crossoverChance;
            CostRepAmountNumericUpDown.Value = (decimal)costAmountRepUntilBreak;
            MutationChanceUpDown.Value = (decimal)mutationChance;


            CrossoverComboBox.DataSource = Enum.GetValues(typeof(CrossoverType));
            CrossoverComboBox.SelectedItem = algorithm.CrossoverType;
            crossoverType = algorithm.CrossoverType;

            MutationTypeComboBox.DataSource = Enum.GetValues(typeof(MutationType));
            MutationTypeComboBox.SelectedItem = algorithm.MutationType;
            mutationType = algorithm.MutationType;
        }

        private void PopupSettingsForSAForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var algh = new GeneticAlgorithm(populationSize, crossoverType, crossoverChance, mutationType, mutationChance, costAmountRepUntilBreak);
            parent.Algorithm = algh;
            algh.OnAlgorithmShowInfo += parent.PrintAlgorithMessage;
            parent.AddTextToMessageLog("Changes saved!\n");
        }


        private void closeButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            populationSize = (int)PopulationNumericUpDown.Value;
        }

        private void CrossoverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            crossoverType = (CrossoverType)CrossoverComboBox.SelectedItem;

        }

        private void CrossChanceUpDown_ValueChanged(object sender, EventArgs e)
        {
            crossoverChance = (double)CrossChanceUpDown.Value;
        }

        private void MutationTypeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mutationType = (MutationType)MutationTypeComboBox.SelectedItem;
        }

        private void CostRepAmountNumericUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            costAmountRepUntilBreak = (int)CostRepAmountNumericUpDown.Value;
        }

        private void MutationChanceUpDown_ValueChanged(object sender, EventArgs e)
        {
            mutationChance = (double)MutationChanceUpDown.Value;
        }
    }
}
