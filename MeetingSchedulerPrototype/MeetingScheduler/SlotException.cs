using System;

namespace MeetingScheduler
{
    internal class SlotException : Exception
    {
        public Participants participant;

        public SlotException(string errorMessage, Participants participant)
            : base(errorMessage)
            => this.participant = participant;
    }
}
