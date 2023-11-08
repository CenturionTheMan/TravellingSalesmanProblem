using System.Diagnostics;
using System.Windows.Forms;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemWF;

public partial class Form1 : Form
{
    private const string BREAK_LINE = "================================================";
    private readonly Color WARNING = Color.Red;
    private readonly Color DEFAULT = Color.Black;
    private readonly Color HIGHLIGHT = Color.BlueViolet;
    private readonly Color RESULT = Color.MediumSeaGreen;


    AlgorithmKind? algorithmKind = null;
    AdjMatrix? matrix;
    Stopwatch stopwatch = new();
    CancellationTokenSource? algorithmTaskCTS = null;


    #region ALGH SETTINGS
    // B&B
    BranchAndBound.SearchType babSearchType = BranchAndBound.SearchType.LOW_COST;

    #endregion


    public Form1()
    {
        matrix = null;

        InitializeComponent();

        BruteForceRadioButton.Checked = true;
    }

    /// <summary>
    /// Method will stop currently working algorithm task
    /// </summary>
    private void FreeCancellationToken()
    {
        if(algorithmTaskCTS != null)
        {
            algorithmTaskCTS.Cancel();
            AddTextToMessageLog("Currently working algorithm is being stopped...\n");
            AddTextToMessageLog(BREAK_LINE + "\n");
        }
        algorithmTaskCTS = null;
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
            AddTextToMessageLog("Matrix loaded...\n");
        }
        else
        {
            AddTextToMessageLog("Can not load matrix from given file path!\n");
        }
    }

    /// <summary>
    /// Method will be used for settings params for different algh
    /// </summary>
    /// <returns>New tsp algorithm</returns>
    /// <exception cref="Exception"></exception>
    private TSPAlgorithm CreateAlgorithm()
    {
        TSPAlgorithm alg;
        FreeCancellationToken();
        algorithmTaskCTS = new CancellationTokenSource();
        CancellationToken token = algorithmTaskCTS.Token;
        switch (algorithmKind)
        {
            case AlgorithmKind.BRUTE_FORCE:
                alg = new BruteForce(ref token);
                break;

            case AlgorithmKind.DYNAMIC_PROGRAMMING:
                alg = new DynamicProgramming(ref token);
                break;

            case AlgorithmKind.BRANCH_AND_BOUND:
                alg = new BranchAndBound(ref token, babSearchType);
                break;

            default:
                throw new Exception("Algorithm was not choosen!");
        }
        return alg;
    }


    /// <summary>
    /// Little workover for adding text from different thread
    /// </summary>
    /// <param name="action"></param>
    private void RunMethodOnCurrentThread(Action action)
    {
        this.Invoke(new MethodInvoker(() =>
        {
            action();
        }));
    }


    /// <summary>
    /// Function will write given message in message log (GUI)
    /// </summary>
    /// <param name="message">Message to write</param>
    private void AddTextToMessageLog(string message, Color? textColor = null)
    {
        Color col = (textColor.HasValue) ? textColor.Value : DEFAULT;
        message = message.Replace("\n", Environment.NewLine);

        RunMethodOnCurrentThread(() => {
            messageLogTextBox.SelectionColor = col;
            messageLogTextBox.AppendText(message);
        });
    }

    /// <summary>
    /// Handles the Brute Force algorithm selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BruteForceRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        algorithmKind = AlgorithmKind.BRUTE_FORCE;
        algorithmSettingsButton.Enabled = false;
    }

    /// <summary>
    /// Handles the Dynamic Programming algorithm selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DynamicProgrammingRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        algorithmKind = AlgorithmKind.DYNAMIC_PROGRAMMING;
        algorithmSettingsButton.Enabled = false;

    }

    /// <summary>
    /// Handles the BranchAndBound algorithm selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BranchAndBoundradioButton_CheckedChanged(object sender, EventArgs e)
    {
        algorithmKind = AlgorithmKind.BRANCH_AND_BOUND;
        algorithmSettingsButton.Enabled = true;

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
        if (algorithmKind == null)
        {
            AddTextToMessageLog("Can not solve example without choosen algorithm\n", WARNING);
        }
        else if(matrix == null)
        {
            AddTextToMessageLog("Can not solve example without choosen matrix\n", WARNING);
        }
        else
        {
            var algorithm = CreateAlgorithm();

            AddTextToMessageLog("\n" + BREAK_LINE + "\n");
            AddTextToMessageLog($"Solving example using ");
            AddTextToMessageLog($"{algorithm.AlgorithmName}...\n", HIGHLIGHT);

            SolvaButton.Enabled = false;
            stopButton.Enabled = true;

            Task.Factory.StartNew(() => {
                stopwatch.Restart();
                var res = algorithm.CalculateBestPath(matrix);
                stopwatch.Stop();

                if(algorithm.CancellationToken.IsCancellationRequested)
                {
                    algorithm = null;
                    GC.Collect();

                    AddTextToMessageLog("Algorithm has stopped.\n");
                    AddTextToMessageLog(BREAK_LINE + "\n");
                    RunMethodOnCurrentThread(() => {
                        SolvaButton.Enabled = true;
                        stopButton.Enabled = false;
                    });
                    return;
                }

                algorithmTaskCTS = null;

                if (res == null)
                {
                    AddTextToMessageLog($"Solution could not be found!\n", WARNING);
                }
                else
                {
                    AddTextToMessageLog($"Solution found!\n");

                    AddTextToMessageLog("Best Cost: ");
                    AddTextToMessageLog($"{res.Value.cost}\n", RESULT);
                    
                    AddTextToMessageLog("Best Path: ");
                    AddTextToMessageLog($"{res.Value.path.ArrayToPathString()}\n", RESULT);
                    
                    AddTextToMessageLog("Time taken: ");
                    AddTextToMessageLog($"{stopwatch.Elapsed.TotalSeconds.ToString("0.###")} [s]\n", RESULT);
                }
                AddTextToMessageLog(BREAK_LINE + "\n");

                algorithm = null;
                GC.Collect();

                RunMethodOnCurrentThread(() => {
                    SolvaButton.Enabled = true;
                    stopButton.Enabled = false;
                });
            });
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
        AddTextToMessageLog("\n" + BREAK_LINE + "\n");
        AddTextToMessageLog("Loaded Matrix:\n", HIGHLIGHT);
        AddTextToMessageLog(tmp + BREAK_LINE + "\n");
    }

    private void generateRandomMatrixButton_Click(object sender, EventArgs e)
    {
        int vertexAmount = (int)vertexAmountNumeric.Value;
        int minDis = (int)minDistanceNumeric.Value;
        int maxDis = (int)maxDistanceNumeric.Value;

        if(vertexAmount < 2)
        {
            AddTextToMessageLog($"Matrix must have two or more vertices. Was given: {vertexAmount}\n", WARNING);
            return;
        }

        if (minDis < 0)
        {
            AddTextToMessageLog($"Min distance must have positive value. Was given: {minDis}\n", WARNING);
            return;
        }

        if (minDis < 0)
        {
            AddTextToMessageLog($"Max distance must have positive value. Was given: {maxDis}\n", WARNING);
            return;
        }

        if(minDis >= maxDis)
        {
            AddTextToMessageLog($"Min distance must be lesser than max distance\n", WARNING);
            return;
        }

        matrix = new AdjMatrix(vertexAmount, minDis, maxDis);
        AddTextToMessageLog($"Matrix {vertexAmount}x{vertexAmount} generated.\n");

    }

    private void stopButton_Click(object sender, EventArgs e)
    {
        if(algorithmTaskCTS != null)
        {
            algorithmTaskCTS.Cancel();
            algorithmTaskCTS = null;
            AddTextToMessageLog("Currently working algorithm is being stopped...\n");
        }
    }

    private void algorithmSettingsButton_Click(object sender, EventArgs e)
    {
        if (algorithmKind == null) return;

        string alghName = algorithmKind.ToString().Replace("_", " ");

        switch (algorithmKind.Value)
        {
            case AlgorithmKind.BRUTE_FORCE:
                break;
            case AlgorithmKind.DYNAMIC_PROGRAMMING:
                break;
            case AlgorithmKind.BRANCH_AND_BOUND:
                {
                    var bab = new PopupSettingsForBabForm(alghName, ref babSearchType);
                    bab.ShowDialog();
                    break;
                }
            default:
                break;
        }
    }
}