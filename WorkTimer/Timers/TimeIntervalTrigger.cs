using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkTimer.Timers
{
    /// <summary>
    /// Triggers an event when time interval has expired.
    /// </summary>
    /// <author>Dmitry Plotnikov, plotdm@gmail.com</author>
    class TimeIntervalTrigger
    {
        public delegate void TriggeredDelegate();

        private TimeSpan m_interval;
        private TimeCounter m_timer;
        private bool m_triggered = false;

        /// <summary>
        /// A Triggered event handler.
        /// </summary>
        public TriggeredDelegate Triggered { set; get; }

        /// <summary>
        /// A timer attached to the trigger.
        /// </summary>
        public TimeCounter Timer
        {
            get
            {
                return m_timer;
            }

            set
            {
                if (m_timer != null)
                {
                    DetachTimer(m_timer);
                }
                m_timer = value;
                if (m_timer != null)
                {
                    AttachTimer(m_timer);
                }
            }
        }

        /// <summary>
        /// Constructs the trigger.
        /// </summary>
        /// <param name="interval">A time interval</param>
        public TimeIntervalTrigger(TimeSpan interval)
        {
            m_interval = interval;
        }

        /// <summary>
        /// Constructs the trigger.
        /// </summary>
        /// <param name="interval">A time interval</param>
        /// <param name="timer">A timer to be attached.</param>
        public TimeIntervalTrigger(TimeSpan interval, TimeCounter timer)
            : this(interval)
        {
            Timer = timer;
        }

        private void AttachTimer(TimeCounter timer)
        {
            timer.Tick += OnTick;
        }

        private void DetachTimer(TimeCounter timer)
        {
            timer.Tick -= OnTick;
        }

        private void OnTick(TimeCounter timer)
        {
            if (!m_triggered)
            {
                if (m_interval < timer.Time)
                {
                    m_triggered = true;
                    Triggered();
                }
            }
            else
            {
                if (m_interval > timer.Time)
                {
                    m_triggered = false;
                }
            }
        }
    }
}
