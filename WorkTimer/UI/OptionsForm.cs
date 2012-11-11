using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WorkTimer.Properties;

namespace WorkTimer.UI
{
    public partial class OptionsForm : Form
    {
        private string m_formatErrorMessageText = "{0} parameter must be in the following format: hh:mm:ss";

        public OptionsForm()
        {
            InitializeComponent();
            workTimerIntervalTextBox.Text = Settings.Default.WorkInterval.ToString();
            restTimerIntervalTextBox.Text = Settings.Default.RestInterval.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            TimeSpan workInterval;
            if (TimeSpan.TryParse(workTimerIntervalTextBox.Text, out workInterval))
            {
                Settings.Default.WorkInterval = workInterval;
            }
            else
            {
                MessageBox.Show(string.Format(m_formatErrorMessageText, "Work Interval"));
            }

            TimeSpan restInterval;
            if (TimeSpan.TryParse(restTimerIntervalTextBox.Text, out restInterval))
            {
                Settings.Default.RestInterval = restInterval;
            }
            else
            {
                MessageBox.Show(string.Format(m_formatErrorMessageText, "Rest Interval"));
            }

            Settings.Default.Save();
            
            Close();
        }
    }
}
