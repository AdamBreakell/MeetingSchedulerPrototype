using System;

namespace MeetingScheduler
{
    internal class SlotBooking
    {
        //Attributes

        public DateTime date;
        public int SlotNumber;

        //Constructor
        public SlotBooking(int year, int month, int day,int SlotNumber)
        {
            this.date = new DateTime(year, month, day);
            this.SlotNumber = SlotNumber;
        }

        public SlotBooking(DateTime date, int SlotNumber)
        {
            this.date = date;
            this.SlotNumber = SlotNumber;
        }
        //Operations

        public override string ToString() => this.date.ToShortDateString() + " Slot " + (object)this.SlotNumber;

        public override bool Equals(object obj) => this.ToString().Equals(obj.ToString());

        public override int GetHashCode() => this.ToString().GetHashCode();


    }
}
