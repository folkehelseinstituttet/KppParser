using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dhhr.KppParser.Service;

namespace Dhhr.KppParser
{
    public partial class MainForm : Form
    {
        private readonly string _version;

        public MainForm()
        {
            InitializeComponent();

            var assembly = Assembly.GetExecutingAssembly();
            _version = AssemblyName.GetAssemblyName(assembly.Location).Version.ToString();

            VersionLabel.Text = $@"Versjon: {_version}";
        }

        private void EpisodeButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "csv",
                Filter = @"CSV filer|*.csv",
                Multiselect = false,
                Title = @"Velg fil med episoder"
            };

            openFileDialog.ShowDialog();
            EpisodePathBox.Text = openFileDialog.FileName;
        }

        private void TjenesteButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "csv",
                Filter = @"CSV filer|*.csv",
                Multiselect = false,
                Title = @"Velg fil med tjenester"
            };

            openFileDialog.ShowDialog();
            TjenestePathBox.Text = openFileDialog.FileName;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            var args = new Args
            {
                EpisodePath = EpisodePathBox.Text,
                TjenestePath = TjenestePathBox.Text,
                FraDato = FromDatePicker.Value,
                TilDato = ToDatePicker.Value,
                OrganizationName = OrgNameBox.Text,
                OrganizationHerId = OrgHerIdBox.Text,
                HDirHerId = RadioTrial.Checked
                    ? Properties.Settings.Default.HdirQa
                    : Properties.Settings.Default.HdirProd,
                Leverandor = Properties.Settings.Default.Leverandor,
                NavnEpj = Properties.Settings.Default.NavnEpj,
                VersjonEpj = Properties.Settings.Default.VersjonEpj,
                ProgramVersion = _version,
            };

            if (!KppService.IsValid(args, out var errorMessage))
            {
                MessageBox.Show($"Kan ikke lage melding. Årsak:\n\n{errorMessage}", @"Ugyldig input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fileDialog = new SaveFileDialog
            {
                OverwritePrompt = true,
                Filter = @"XML filer|*.xml",
                AddExtension = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                Title = @"Velg hvor filen skal lagres",
                ValidateNames = true
            };

            if (fileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            args.OutputPath = fileDialog.FileName;

            var progressForm = new ProgressForm(args);
            progressForm.ShowDialog();
        }
    }
}
