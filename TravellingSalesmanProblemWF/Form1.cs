using System.Diagnostics;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemWF;

public partial class Form1 : Form
{
    ITSPAlgorithm? algorithm;
    AdjMatrix? matrix;
    Stopwatch stopwatch = new();

    public Form1()
    {
        algorithm = null;
        matrix = null;

        InitializeComponent();

        BruteForceRadioButton.Checked = true;
    }


    private void HideAllSettings()
    {
        DynamicProgrammingPanel.Visible = false;
        BruteForcepanel.Visible = false;
    }

    private void LoadMatrixFromFile(string filePath)
    {
        matrix = FilesHandler.LoadAdjMatrixFromFile(filePath);
        if(matrix != null)
        {
            AddTextToMessageLog("Matrix loaded...");
        }
        else
        {
            AddTextToMessageLog("Can not load matrix from given file path!");
        }
    }


    private void SetupAlgorithmParams()
    {

    }

    /// <summary>
    /// Function will write given message in message log (GUI)
    /// </summary>
    /// <param name="message">Message to write</param>
    private void AddTextToMessageLog(string message)
    {
        //this.Invoke(new MethodInvoker(() =>
        //{
            messageLogTextBox.AppendText(message);
            messageLogTextBox.AppendText(Environment.NewLine);
        //}));
    }

    private void BruteForceRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        HideAllSettings();
        algorithm = new BruteForce();
        BruteForcepanel.Visible = true;
    }

    private void DynamicProgrammingRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        HideAllSettings();
        algorithm = new DynamicProgramming();
        DynamicProgrammingPanel.Visible = true;
    }

    private void SelectFileFromDiscButton_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
        var fileName = openFileDialog1.FileName;
        fileNameTextBox.Text = fileName;
        LoadMatrixFromFile(fileName);
    }

    private void loadFileButton_Click(object sender, EventArgs e)
    {
        var fileName = fileNameTextBox.Text;
        LoadMatrixFromFile(fileName);
    }

    private void SolvaButton_Click(object sender, EventArgs e)
    {
        if (algorithm == null)
        {
            AddTextToMessageLog("Can not solve example without choosen algorithm");
        }
        else if(matrix == null)
        {
            AddTextToMessageLog("Can not solve example without choosen matrix");
        }
        else
        {
            SetupAlgorithmParams();

            stopwatch.Start();
            var res = algorithm.CalculateBestPathCost(matrix);
            stopwatch.Stop();

            if(res == null)
            {
                AddTextToMessageLog($"Solution could not be found!");
            }
            else
            {
                AddTextToMessageLog($"Solution found!");
                AddTextToMessageLog($"Best Cost: {res.Value} || Time taken: {stopwatch.Elapsed} [s]");
            }
        }

    }

    private void messageLogTextBox_VisibleChanged(object sender, EventArgs e)
    {
        messageLogTextBox.SelectionStart = messageLogTextBox.TextLength;
        messageLogTextBox.ScrollToCaret();
    }
}