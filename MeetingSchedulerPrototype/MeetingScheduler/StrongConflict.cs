using System;

namespace MeetingScheduler
{
    internal class StrongConflict : Exception
    {

        public StrongConflict(string message)
            : base(message)
        {
        }
    }
}
