using PowerPlannerAppDataLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.DateTimeFormatting;

namespace PowerPlannerUWPLibrary.Extensions
{
    public class UWPDateTimeFormatterExtension : DateTimeFormatterExtension
    {
        private Dictionary<TimeSpan, string> _cache = new Dictionary<TimeSpan, string>();

        public override string FormatAsShortTime(DateTime time)
        {
            // We have to cache answers since it literally takes 5 milliseconds for DateTimeFormatter to format, which ends up
            // being 2.5 seconds if formatting 1,440 times.
            if (_cache.TryGetValue(time.TimeOfDay, out string answer))
            {
                return answer;
            }

            // Remove the hidden BOM character
            var str = DateTimeFormatter.ShortTime.Format(time).Replace("\u200E", "");
            _cache[time.TimeOfDay] = str;
            return str;
        }

        public override string FormatAsShortTimeWithoutAmPm(DateTime time)
        {
            return FormatAsShortTime(time).TrimEnd('A', 'P', 'M', 'a', 'p', 'm', ' ');
        }

        private static Task _initializeAllShortTimesTask;
        public static Task InitializeAllShortTimesAsync()
        {
            if (_initializeAllShortTimesTask == null)
            {
                _initializeAllShortTimesTask = Task.Run(delegate
                {
                    UWPDateTimeFormatterExtension formatter = (UWPDateTimeFormatterExtension)DateTimeFormatterExtension.Current;

                    DateTime time = new DateTime(2000, 1, 1);

                    while (time.Day == 1)
                    {
                        formatter.FormatAsShortTime(time);
                        time = time.AddMinutes(1);
                    }
                });
            }

            return _initializeAllShortTimesTask;
        }
    }
}
