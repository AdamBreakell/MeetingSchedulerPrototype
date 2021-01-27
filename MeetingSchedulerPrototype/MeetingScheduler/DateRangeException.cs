using System;

namespace MeetingScheduler
{
internal class DateRangeException : Exception
    {

        public DateRangeException(string message)
            : base (message)
        {

        }
    }
}
