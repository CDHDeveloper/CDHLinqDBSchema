using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using CDH.LinqDBSchema;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using SandBox.Generators;
using SandBox.Properties;
using Column = CDH.LinqDBSchema.Column;

namespace SandBox
{
    public partial class Form1 : Form
    {
        private SchemaFactory _schemaFactory;
        private Solution.Solution Solution { get; set; }

        public Form1()
        {
            InitializeComponent();
            if (Solution == null)
                Solution = new Solution.Solution();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You need to supply a connection string");
                return;
            }
            _schemaFactory = SchemaFactory.CreateSchemaFactory(textBox1.Text);
            foreach (var tbl in _schemaFactory.DataBase.Tables)
            {
                tbl.GetPrimaryKeys();
                tbl.GetForeignKeys();
            }
            MessageBox.Show("Database has been loaded");
        }

        private void Button2Click(object sender, EventArgs e)
        {
            // Validate that the info needed is there
            if (_schemaFactory == null)
            {
                MessageBox.Show("You need to click Load to load the database before you can generate the source files");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("You need to fill in the Source Directory");
                return;
            }
            if (!Directory.Exists(textBox2.Text))
            {
                MessageBox.Show("The Source Directory must be a valid existent directory");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("You need to fill in the Namespace");
                return;
            }

            // Init Solution info
            Solution.Solution solution = new Solution.Solution();
            Solution.BaseDirectory = textBox2.Text;
            Solution.Namespace = textBox3.Text;
            if (Solution.Settings == null)
                Solution.Settings = new Solution.SolutionSettings();
            if (Solution.Settings.LinqSettings == null)
                Solution.Settings.LinqSettings = new Solution.LinqSettings();
            Solution.Settings.LinqSettings.Generate = true;
            Solution.Settings.LinqSettings.MakeDataContextCSFile = chkGenerateDataContextClass.Checked;
            
            // Generate the Linq files
            var linqGenerator = new LinqGenerator(Solution, _schemaFactory);
            linqGenerator.Generate();

            // Generate the FNH Files
            var FNHGenerator = new FluentNHGenerator(Solution, _schemaFactory);
            FNHGenerator.Generate();

            // Generate the HBM files
            var hbmGenerator = new HBMGenerator(Solution, _schemaFactory);
            hbmGenerator.Generate();

            MessageBox.Show(string.Format("All Source files have been written to: {0}", textBox2.Text));
        }

    }
}
