using System;
using System.Collections.Generic;

namespace MeetingScheduler
{
    internal class WeakConflict: Exception
    {
        public IEnumerable<SlotBooking> notInExclusionSets;
        public WeakConflict(string message, IEnumerable<SlotBooking> notInExclusionSets)
            : base(message)
            => this.notInExclusionSets = notInExclusionSets;
    }
}
