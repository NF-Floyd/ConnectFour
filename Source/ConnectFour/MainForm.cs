#define KI_DEBUG_NO

using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ConnectFour.Intelligence;

namespace ConnectFour
{
    internal partial class MainForm : Form
    {
        static int[] _points = new int[2];
        static int _round;
        static int _player = 1;
        static int _endingPlayer;
        static bool _autoRun;
        static int _loops = 1;

        static PlayerIntelligence p1;
        static PlayerIntelligence p2;

        public MainForm()
        {
            InitializeComponent();

            loopsCb.Text = "100";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisplayState();

            p1 = LadeSpieler(@"Player1.dll");
            if (p1 == null)
            {
                MessageBox.Show("Player1.dll could not be loaded.", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            p2 = LadeSpieler(@"Player2.dll");
            if (p2 == null)
            {
                MessageBox.Show("Player2.dll could not be loaded.", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFile")]
        private static PlayerIntelligence LadeSpieler(string dateiname)
        {
            if (!File.Exists(dateiname))
                return null;

            Assembly bibliothek;

            // try to load library
            try
            {
                bibliothek = Assembly.LoadFile(Path.GetFullPath(dateiname));
            }
            catch (Exception)
            {
                return null;
            }

            foreach (Type typ in bibliothek.GetExportedTypes())
            {
                if (typ.IsSubclassOf(typeof(PlayerIntelligence)))
                    return (PlayerIntelligence)Activator.CreateInstance(typ);
            }
            return null;
        }

        private void gameStepBtn_Click(object sender, EventArgs e)
        {
            if (_endingPlayer != 0) return;

            _autoRun = false;

            PlayStep();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void PlayStep()
        {
            try
            {
                PlayForActivePlayer();
            }
            catch (Exception ex)
            {
                _round++;
                _endingPlayer = _player;
                AddScore(_player, true);
                if (_autoRun)
                    ResetGame();
                else
                {
                    string message = string.Format("Player {0} made a mistake:\n{1}", _player, ex.ToString());
                    MessageBox.Show(message, "Internal error on setting field.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (++_player > 2) _player = 1;
                return;
            }

            if (++_player > 2) _player = 1;
        }

        private int GetFieldCount(int player)
        {
            int count = 0;
            foreach (int field in playground1.Fields)
            {
                if (field == player)
                    count++;
            }
            return count;
        }

        static MyIntelligence me = new MyIntelligence();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void PlayForActivePlayer()
        {
            int x = 0;
            bool canSet = false;

            if (GetFieldCount(0) == 0)
            {
                _round++;
                _endingPlayer = _player;
                if (_autoRun)
                    ResetGame();
                else
                {
                    string message = string.Format("The game ended in a draw.");
                    MessageBox.Show(message, "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

#if KI_DEBUG
            if (_player == 2)
                x = me.MakeMove(spielfeld1.Fields, 2);
#endif
            try
            {
                if (_player == 1)
                    x = p1.MakeMove(playground1.Fields, 1);
#if !KI_DEBUG
                if (_player == 2)
                    x = p2.MakeMove(playground1.Fields, 2);
#endif
            }
            catch (Exception ex)
            {
                _round++;
                _endingPlayer = _player;
                AddScore(_player, true);
                if (_autoRun)
                    ResetGame();
                else
                {
                    string message = string.Format("Player {0} made a mistake:\n{1}", _player, ex.ToString());
                    MessageBox.Show(message, "Internal error on setting field.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }

            if (x < 0 || x > Settings.WIDTH_UNITS)
            {
                _round++;
                _endingPlayer = _player;
                AddScore(_player, true);
                if (_autoRun)
                    ResetGame();
                else
                {
                    string message = string.Format("Column {0} is not valid. Player {1} made a mistake.", x + 1, _player);
                    MessageBox.Show(message, "Internal error on setting field.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }

            for (int i = 0; i < Settings.HEIGHT_UNITS; i++)
            {
                if (playground1.Fields[x, i] == 0)
                {
                    playground1.SetField(x, i, _player);
                    playground1.Invalidate();
                    canSet = true;
                    break;
                }
            }
            if (!canSet)
            {
                _round++;
                _endingPlayer = _player;
                AddScore(_player, true);
                if (_autoRun)
                    ResetGame();
                else
                {
                    string message = string.Format("Column {0} is full. Player {1} made a mistake.", x + 1, _player);
                    MessageBox.Show(message, "Internal error on setting field.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }

            MyField f = new MyField(playground1.Fields);
            _endingPlayer = f.Winner;

            if (_endingPlayer != 0)
            {
                foreach (FieldInfo fi in f.FieldInfos)
                    playground1.Fields[fi.X, fi.Y] = fi.Player;

                _round++;
                AddScore(_player);
                if (_autoRun)
                    ResetGame();
                else
                {
                    string message = string.Format("Player {0} wins.", _endingPlayer);
                    MessageBox.Show(message, "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                playground1.Invalidate();
            }
        }

        private void AddScore(int player)
        {
            AddScore(player, false);
        }

        private void AddScore(int player, bool otherPlayer)
        {
            if (otherPlayer)
            {
                if (player == 1)
                    _points[1]++; // player 2
                else
                    _points[0]++; // player 1
            }
            else
            {
                if (player == 1)
                    _points[0]++; // player 1
                else
                    _points[1]++; // player 2
            }

            if (!this.InvokeRequired)
                DisplayState();
        }

        private void gameClearBtn_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            _endingPlayer = 0;
            _player = (_round % 2) + 1;

            for (int i = 0; i < Settings.WIDTH_UNITS; i++)
            {
                for (int j = 0; j < Settings.HEIGHT_UNITS; j++)
                    playground1.SetField(i, j, 0);
            }

            playground1.Invalidate();
        }

        private void DisplayState()
        {
            player1Lbl.Text = _points[0].ToString(CultureInfo.CurrentUICulture);
            player2Lbl.Text = _points[1].ToString(CultureInfo.CurrentUICulture);
        }

        private void runBtn_ButtonClick(object sender, EventArgs e)
        {
            if (playWorker.IsBusy) return;

            _autoRun = true;
            _round = 0;
            _points[0] = 0;
            _points[1] = 0;

            gameStepBtn.Enabled = false;
            gameClearBtn.Enabled = false;
            runBtn.Enabled = false;
            stopBtn.Enabled = true;

            playWorker.RunWorkerAsync();
        }

        private void loopsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _loops = int.Parse(loopsCb.Text);
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (playWorker.WorkerSupportsCancellation)
                playWorker.CancelAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (playWorker.WorkerSupportsCancellation)
                playWorker.CancelAsync();
        }

        private void playWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (_round < _loops)
            {
                if (playWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                PlayStep();
                playWorker.ReportProgress((int)(_round / (float)_loops * 100));
            }
        }

        private void playWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Internal error on calculating.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            gameStepBtn.Enabled = true;
            gameClearBtn.Enabled = true;
            runBtn.Enabled = true;
            stopBtn.Enabled = false;
        }

        private void playWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            roundProgress.Value = e.ProgressPercentage;
            DisplayState();
        }
    }
}
