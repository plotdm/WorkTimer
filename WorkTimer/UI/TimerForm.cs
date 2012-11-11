using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WorkTimer.Data;
using WorkTimer.Properties;
using WorkTimer.Timers;
using WorkTimer.UI;

namespace WorkTimer.UI
{
    public partial class TimerForm : Form
    {
        private enum TimerType
        {
            Work,
            Rest
        }

        private TimeCounter m_totalTimeCounter = new TimeCounter("timer.total");

        private Dictionary<TimerType, TimerViewInfo> m_timerInfo = new Dictionary<TimerType, TimerViewInfo>
            {
                {
                    TimerType.Work, new TimerViewInfo
                    {
                        TimeCounter = new TimeCounter("timer.work"),
                        TimerInterval = new TimeSpan(0, 1, 0),
                        TriggeredMessageText = "It’s time to have a rest"
                    }
                },
                {
                    TimerType.Rest, new TimerViewInfo
                    {
                        TimeCounter = new TimeCounter("timer.rest"),
                        TimerInterval = new TimeSpan(0, 0, 3),
                        TriggeredMessageText = "Now it’s time to work"
                    }
                }
            };

        private Dictionary<TimerType, string> m_startButtonText = new Dictionary<TimerType, string>
            {
                { TimerType.Work, "Pause" },
                { TimerType.Rest, "Start" }
            };

        private Dictionary<TimerType, string> m_startMenuItemText = new Dictionary<TimerType, string>
            {
                { TimerType.Work, "P&ause" },
                { TimerType.Rest, "St&art" }
            };

        private Dictionary<TimerType, string> m_statusText = new Dictionary<TimerType, string>
            {
                { TimerType.Work, "Work" },
                { TimerType.Rest, "Rest" }
            };

        private List<TimerType> m_timersSequence = new List<TimerType> { TimerType.Rest, TimerType.Work };
        private List<TimerType>.Enumerator m_currentTimer;
        private TimeFormatter m_timeFormatter = new TimeFormatter();

        private TimerType CurrentTimerType { get { return m_currentTimer.Current; } }
        private TimeCounter CurrentTimer { get { return m_timerInfo[CurrentTimerType].TimeCounter; } }
        private string CurrentStartButtonText { get { return m_startButtonText[CurrentTimerType]; } }
        private string CurrentStartMenuItemText { get { return m_startMenuItemText[CurrentTimerType]; } }
        private string CurrentStatusText { get { return m_statusText[CurrentTimerType]; } }

        public TimerForm()
        {
            InitializeComponent();

            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);
            LoadSettings();

            timer.Tick += new EventHandler(m_totalTimeCounter.OnTick);
            foreach (var timerInfo in m_timerInfo)
            {
                var timerType = timerInfo.Key;
                var timeCounter = timerInfo.Value.TimeCounter;
                var timerInterval = timerInfo.Value.TimerInterval;

                timer.Tick += new EventHandler(timeCounter.OnTick);
                var trigger = new TimeIntervalTrigger(timerInterval, timeCounter);
                trigger.Triggered += () => TimerTriggered(timerType);
            }

            SelectFirstTimer();
            UpdateDisplay();
            timer.Start();
        }

        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            m_timerInfo[TimerType.Work].TimerInterval = Settings.Default.WorkInterval;
            m_timerInfo[TimerType.Rest].TimerInterval = Settings.Default.RestInterval;
        }

        private void SelectFirstTimer()
        {
            m_currentTimer = m_timersSequence.GetEnumerator();
            SelectNextTimer();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopTimer();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopTimer();
        }

        private void StartTimer()
        {
            if (!m_totalTimeCounter.IsRunning)
            {
                m_totalTimeCounter.Reset();
                m_totalTimeCounter.Start();
            }

            CurrentTimer.Stop();
            SelectNextTimer();
            CurrentTimer.Reset();
            CurrentTimer.Start();

            runButton.Text = CurrentStartButtonText;
            startToolStripMenuItem.Text = CurrentStartMenuItemText;
        }

        private void SelectNextTimer()
        {
            if (!m_currentTimer.MoveNext())
            {
                m_currentTimer = m_timersSequence.GetEnumerator();
                m_currentTimer.MoveNext();
            }
        }

        private void StopTimer()
        {
            m_totalTimeCounter.Stop();
            foreach (var timer in m_timerInfo)
            {
                timer.Value.TimeCounter.Reset();
            }
            SelectFirstTimer();
        }

        private void UpdateDisplay()
        {
            timeCountDisplay.Text = m_timeFormatter.Format(CurrentTimer.Time);
            totalTimeDisplay.Text = m_timeFormatter.Format(m_totalTimeCounter.Time);
            statusLabel.Text = CurrentStatusText;
        }

        private void TimerTriggered(TimerType timerType)
        {
            MessageBox.Show(m_timerInfo[timerType].TriggeredMessageText);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
        }
    }
}
