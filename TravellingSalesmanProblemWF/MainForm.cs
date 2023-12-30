using System.Diagnostics;
using System.Windows.Forms;
using TravellingSalesmanProblemLibrary;
    
namespace TravellingSalesmanProblemWF;

public partial class MainForm : Form
{
    public const string BREAK_LINE = "===============================================";
    public readonly Color WARNING = Color.Red;
    public readonly Color DEFAULT = Color.Black;
    public readonly Color HIGHLIGHT = Color.BlueViolet;
    public readonly Color RESULT = Color.MediumSeaGreen;


    public ITSPAlgorithm? Algorithm = null;
    private AdjMatrix? matrix = null;
    private Stopwatch stopwatch = new();
    private CancellationTokenSource? algorithmTaskCTS = null;

    private Form? popupSettingsForm = null;


    public MainForm()
    {
        InitializeComponent();
        BruteForceRadioButton.Enabled = true;
    }

    private CancellationToken CreateCancellationToken()
    {
        if (algorithmTaskCTS != null)
        {
            algorithmTaskCTS.Cancel();
            //AddTextToMessageLog("Currently working Algorithm is being stopped...\n");
            //AddTextToMessageLog(BREAK_LINE + "\n");
        }
        algorithmTaskCTS = new CancellationTokenSource();
        return algorithmTaskCTS.Token;
    }


    public void PrintAlgorithMessage(string message)
    {
        AddTextToMessageLog(message);
    }


    /// <summary>
    /// Loads an adjacency matrix from a file.
    /// </summary>
    /// <param name="filePath"></param>
    private void LoadMatrixFromFile(string filePath)
    {
        matrix = FilesHandler.LoadAdjMatrixFromFile(filePath);
        if (matrix != null)
        {
            AddTextToMessageLog("Matrix loaded...\n");
        }
        else
        {
            AddTextToMessageLog("Can not load matrix from given file path!\n");
        }
    }


    /// <summary>
    /// Little workover for adding text from different thread
    /// </summary>
    /// <param name="action"></param>
    private void RunMethodOnCurrentThread(Action action)
    {
        try
        {
            this.Invoke(new MethodInvoker(() =>
            {
                action();
            }));
        }
        catch
        {

        }
    }


    /// <summary>
    /// Function will write given message in message log (GUI)
    /// </summary>
    /// <param name="message">Message to write</param>
    public void AddTextToMessageLog(string message, Color? textColor = null)
    {
        Color col = (textColor.HasValue) ? textColor.Value : DEFAULT;
        message = message.Replace("\n", Environment.NewLine);

        RunMethodOnCurrentThread(() =>
        {
            messageLogTextBox.SelectionColor = col;
            messageLogTextBox.AppendText(message);
        });
    }

    /// <summary>
    /// Handles the Brute Force Algorithm selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BruteForceRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        this.Algorithm = new BruteForce();
        popupSettingsForm = null;
        algorithmSettingsButton.Enabled = false;
    }

    /// <summary>
    /// Handles the Dynamic Programming Algorithm selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DynamicProgrammingRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        this.Algorithm = new DynamicProgramming();
        popupSettingsForm = null;
        algorithmSettingsButton.Enabled = false;
    }

    /// <summary>
    /// Handles the BranchAndBound Algorithm selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BranchAndBoundradioButton_CheckedChanged(object sender, EventArgs e)
    {
        this.Algorithm = new BranchAndBound();
        popupSettingsForm = new PopupSettingsForBabForm(this, (BranchAndBound)Algorithm);
        algorithmSettingsButton.Enabled = true;
    }

    private void SimulatedAnnealingRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        var tmp = new SimulatedAnnealing(500, 0.99, 1000, 10, 1000000);
        this.Algorithm = tmp;
        popupSettingsForm = new PopupSettingsForSAForm(this, (SimulatedAnnealing)Algorithm);
        tmp.OnAlgorithmShowInfo += PrintAlgorithMessage;

        algorithmSettingsButton.Enabled = true;
    }

    private void GeneticAlgorithmRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        var tmp = new GeneticAlgorithm(100, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.1, 100000);
        this.Algorithm = tmp;
        popupSettingsForm = new PopupSettingsForGAForm(this, (GeneticAlgorithm)Algorithm);
        tmp.OnAlgorithmShowInfo += PrintAlgorithMessage;

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
    /// Solves the TSP problem using the selected Algorithm.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SolvaButton_Click(object sender, EventArgs e)
    {
        if (Algorithm == null)
        {
            AddTextToMessageLog("Can not solve example without choosen Algorithm\n", WARNING);
        }
        else if (matrix == null)
        {
            AddTextToMessageLog("Can not solve example without choosen matrix\n", WARNING);
        }
        else
        {
            AddTextToMessageLog("\n" + BREAK_LINE + "\n");
            AddTextToMessageLog($"Solving example using ");
            AddTextToMessageLog($"{Algorithm.AlgorithmDetailedName}...\n", HIGHLIGHT);

            SolvaButton.Enabled = false;
            stopButton.Enabled = true;

            var cancelToken = CreateCancellationToken();

            Task.Factory.StartNew(() =>
            {
                stopwatch.Restart();
                var res = Algorithm.CalculateBestPath(matrix, cancelToken);
                stopwatch.Stop();

                if (cancelToken.IsCancellationRequested && res.HasValue == false)
                {
                    GC.Collect();

                    AddTextToMessageLog("Algorithm has stopped.\n");
                    AddTextToMessageLog(BREAK_LINE + "\n");
                    RunMethodOnCurrentThread(() =>
                    {
                        SolvaButton.Enabled = true;
                        stopButton.Enabled = false;
                    });
                    return;
                }

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

                GC.Collect();

                RunMethodOnCurrentThread(() =>
                {
                    SolvaButton.Enabled = true;
                    stopButton.Enabled = false;
                });
            }, cancelToken);
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

        if (vertexAmount < 2)
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

        if (minDis >= maxDis)
        {
            AddTextToMessageLog($"Min distance must be lesser than max distance\n", WARNING);
            return;
        }

        matrix = new AdjMatrix(vertexAmount, minDis, maxDis);
        AddTextToMessageLog($"Matrix {vertexAmount}x{vertexAmount} generated.\n");

    }

    private void stopButton_Click(object sender, EventArgs e)
    {
        if (algorithmTaskCTS != null)
        {
            algorithmTaskCTS.Cancel();
            algorithmTaskCTS = null;
            AddTextToMessageLog("Currently working Algorithm is being stopped...\n");
        }
    }

    private void algorithmSettingsButton_Click(object sender, EventArgs e)
    {
        if (Algorithm == null || popupSettingsForm == null) return;

        popupSettingsForm.ShowDialog();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }
}