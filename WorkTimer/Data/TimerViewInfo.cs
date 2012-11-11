using System;

using WorkTimer.Timers;

namespace WorkTimer.Data
{
    /// <summary>
    /// Contains info for displaying the timer.
    /// </summary>
    /// <author>Dmitry Plotnikov, plotdm@gmail.com</author>
    class TimerViewInfo
    {
        /// <summary>
        /// Counts the time.
        /// </summary>
        public TimeCounter TimeCounter { set; get; }

        /// <summary>
        /// The time interval beyond which the timer triggers.
        /// </summary>
        public TimeSpan TimerInterval { set; get; }

        /// <summary>
        /// The message to show after the timer has triggered.
        /// </summary>
        public string TriggeredMessageText { set; get; }
    }
}
