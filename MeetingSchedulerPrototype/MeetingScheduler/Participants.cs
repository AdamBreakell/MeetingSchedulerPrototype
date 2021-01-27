using System.Collections.Generic;

namespace MeetingScheduler
{
    internal class Participants
    {
        public string name;
        public HashSet<SlotBooking> preferenceSet;
        public HashSet<SlotBooking> exclusionSet;

        // Constructor
        public Participants(string name) 
        {
            this.name = name;
            this.preferenceSet = new HashSet<SlotBooking>();
            this.exclusionSet = new HashSet<SlotBooking>();
        }

        public void addToPreferenceSet(SlotBooking slot)
        {
            if (this.exclusionSet.Contains(slot))
                throw new SlotException("Slot already in exclusion set: " + (object)slot, this);
            this.preferenceSet.Add(slot);
        }

        public void addToExclusionSet(SlotBooking slot)
        {
            if (this.preferenceSet.Contains(slot))
                throw new SlotException("Slot already in preference set: " + (object)slot, this);
            this.exclusionSet.Add(slot);
        }

        public bool isSlotInPrefSet(SlotBooking slot) => this.preferenceSet.Contains(slot);

        public bool isSlotInExcSet(SlotBooking slot) => this.exclusionSet.Contains(slot);
    }
}