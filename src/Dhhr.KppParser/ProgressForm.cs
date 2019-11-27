using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dhhr.KppParser.Service;

namespace Dhhr.KppParser
{
    public partial class ProgressForm : Form
    {
        private readonly BackgroundWorker _worker;

        public ProgressForm(Args args)
        {
            InitializeComponent();

            CloseButton.Enabled = false;

            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = 100;

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += OnDoWork(args);
            _worker.ProgressChanged += OnProgressChanged;
        }

        private DoWorkEventHandler OnDoWork(Args args)
        {
            return (o, e) =>
            {
                _worker.ReportProgress(ProgressBar.Minimum);
                try
                {
                    KppService.Run(args, _worker.ReportProgress);
                }
                catch (Exception ex)
                {
                    _worker.ReportProgress(ProgressBar.Value, "Noe gikk galt :(");
                    var message = $"Noe gikk galt under opprettelse av meldingen.\n\nFeilmelding: {ex.Message}\n\n{ex.GetType()}\n\nVersjon: {args.ProgramVersion}";
                    MessageBox.Show(message, @"Noe gikk galt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _worker.ReportProgress(ProgressBar.Maximum);
                }
            };
        }

        private void OnProgressChanged(object o, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;

            if (e.ProgressPercentage == ProgressBar.Maximum)
            {
                CloseButton.Enabled = true;
            }

            if (e.UserState is string status)
            {
                StatusLabel.Text = status;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            _worker.RunWorkerAsync();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
