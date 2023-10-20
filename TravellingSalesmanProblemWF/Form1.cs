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

    /// <summary>
    /// Hides settings panels for different algorithms.
    /// </summary>
    private void HideAllSettings()
    {
        DynamicProgrammingPanel.Visible = false;
        BruteForcepanel.Visible = false;
    }

    /// <summary>
    /// Loads an adjacency matrix from a file.
    /// </summary>
    /// <param name="filePath"></param>
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

    /// <summary>
    /// Method will be used for settings params for different algh
    /// </summary>
    private void SetupAlgorithmParams()
    {

    }

    /// <summary>
    /// Function will write given message in message log (GUI)
    /// </summary>
    /// <param name="message">Message to write</param>
    private void AddTextToMessageLog(string message)
    {
        // little workover for adding text from different thread
        this.Invoke(new MethodInvoker(() =>
        {
            messageLogTextBox.AppendText(message);
            messageLogTextBox.AppendText(Environment.NewLine);
        }));
    }

    /// <summary>
    /// Handles the Brute Force algorithm selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BruteForceRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        HideAllSettings();
        algorithm = new BruteForce();
        BruteForcepanel.Visible = true;
    }

    /// <summary>
    /// Handles the Dynamic Programming algorithm selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DynamicProgrammingRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        HideAllSettings();
        algorithm = new DynamicProgramming();
        DynamicProgrammingPanel.Visible = true;
    }

    /// <summary>
    /// Opens a file dialog to select a matrix file.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SelectFileFromDiscButton_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
        var fileName = openFileDialog1.FileName;
        fileNameTextBox.Text = fileName;
        LoadMatrixFromFile(fileName);
    }

    /// <summary>
    /// Loads the matrix from the specified file.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void loadFileButton_Click(object sender, EventArgs e)
    {
        var fileName = fileNameTextBox.Text;
        LoadMatrixFromFile(fileName);
    }

    /// <summary>
    /// Solves the TSP problem using the selected algorithm.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

            AddTextToMessageLog("Solving example...");

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

    /// <summary>
    /// Scrolls to the end of the message log when it becomes visible.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void messageLogTextBox_VisibleChanged(object sender, EventArgs e)
    {
        messageLogTextBox.SelectionStart = messageLogTextBox.TextLength;
        messageLogTextBox.ScrollToCaret();
    }

    /// <summary>
    /// Displays the matrix in the message log.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void showMatrixButton_Click(object sender, EventArgs e)
    {
        if (matrix == null) return;

        string tmp = matrix.ToString();
        var lines = tmp.Split("\n");
        foreach (var line in lines)
        {
            AddTextToMessageLog(line);
        }
    }

    private void generateRandomMatrixButton_Click(object sender, EventArgs e)
    {
        int vertexAmount = (int)vertexAmountNumeric.Value;
        int minDis = (int)minDistanceNumeric.Value;
        int maxDis = (int)maxDistanceNumeric.Value;

        if(vertexAmount < 2)
        {
            AddTextToMessageLog($"Matrix must have two or more vertices. Was given: {vertexAmount}");
            return;
        }

        if (minDis < 0)
        {
            AddTextToMessageLog($"Min distance must have positive value. Was given: {minDis}");
            return;
        }

        if (minDis < 0)
        {
            AddTextToMessageLog($"Max distance must have positive value. Was given: {maxDis}");
            return;
        }

        if(minDis >= maxDis)
        {
            AddTextToMessageLog($"Min distance must be lesser than max distance");
            return;
        }

        matrix = new AdjMatrix(vertexAmount, minDis, maxDis);
        AddTextToMessageLog($"Matrix {vertexAmount}x{vertexAmount} generated.");

    }
}