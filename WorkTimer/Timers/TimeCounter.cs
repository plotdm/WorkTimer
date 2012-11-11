using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkTimer.Timers
{
    /// <summary>
    /// Manages the time counting for the specific task.
    /// </summary>
    /// <author>Dmitry Plotnikov, plotdm@gmail.com</author>
    class TimeCounter
    {

        /// <summary>
        /// The time counter tick delegate.
        /// </summary>
        /// <param name="counter">The event source.</param>
        public delegate void TickDelegate(TimeCounter counter);

        private string m_id;
        private bool m_isCounting;
        private TimeSpan m_time = new TimeSpan();
        private DateTime m_lastTimestamp = new DateTime();

        /// <summary>
        /// Time counter identificator.
        /// </summary>
        public string Id { get { return m_id; } }

        /// <summary>
        /// Time counted.
        /// </summary>
        public TimeSpan Time { get { return m_time; } }

        /// <summary>
        /// True if the timer is currently running.
        /// </summary>
        public bool IsRunning { get { return m_isCounting; } }

        /// <summary>
        /// The Tick Handled event.
        /// </summary>
        public TickDelegate Tick { get; set; }

        /// <summary>
        /// Constructs the time counter.
        /// </summary>
        /// <param name="id">A time counter indentificator.</param>
        public TimeCounter(string id)
        {
            m_id = id;
        }

        /// <summary>
        /// Starts time counting.
        /// </summary>
        public void Start()
        {
            m_isCounting = true;
            m_lastTimestamp = DateTime.Now;
        }

        /// <summary>
        /// Stops time counting.
        /// </summary>
        public void Stop()
        {
            m_isCounting = false;
        }

        /// <summary>
        /// Resets the time counted.
        /// </summary>
        public void Reset()
        {
            Stop();
            m_time = new TimeSpan();
        }

        /// <summary>
        /// Handles the timer tick.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event parameters.</param>
        public void OnTick(object sender, EventArgs e)
        {
            var currentTime = DateTime.Now;
            if (m_isCounting)
            {
                m_time += currentTime - m_lastTimestamp;
            }
            m_lastTimestamp = currentTime;
            if (Tick != null)
            {
                Tick(this);
            }
        }
    }
}
