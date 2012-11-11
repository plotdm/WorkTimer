using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkTimer.UI
{
    /// <summary>
    /// Formats time string to show to the user.
    /// </summary>
    /// <author>Dmitry Plotnikov, plotdm@gmail.com</author>
    class TimeFormatter
    {
        /// <summary>
        /// Returns a time string formatted to show to the user.
        /// </summary>
        /// <param name="time">A time value.</param>
        /// <returns>A time string formatted.</returns>
        public string Format(DateTime time)
        {
            return time.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Returns a time string formatted to show to the user.
        /// </summary>
        /// <param name="time">A time value.</param>
        /// <returns>A time string formatted.</returns>
        public string Format(TimeSpan time)
        {
            return time.ToString("hh\\:mm\\:ss");
        }
    }
}
