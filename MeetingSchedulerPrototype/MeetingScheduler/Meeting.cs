using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MeetingScheduler
{
    internal class Meeting 
    {
      
        //Attributes
        private const int SLOTS_IN_A_DAY = 4;
        private MeetingInitiator initiator;
        private HashSet<Participants> participant;
        private DateTime fromDate;
        private DateTime toDate;
        private string status = "Not Planned";
        public string path = Directory.GetCurrentDirectory();
        
        //Constructor

        public Meeting(MeetingInitiator initiator, DateTime fromDate, DateTime toDate)
        {
            this.initiator = initiator;
            this.fromDate = DateTime.Compare(toDate, fromDate) >= 0 ? fromDate : throw new DateRangeException("To date cannot be before from date when arranging a meeting.");
            this.toDate = toDate;
            this.participant = new HashSet<Participants>();
        }
        //Operations

        public void setStatus(string status)
        {
            this.status = status;
        }

        public string getStatus() => this.status;
      

        public void addParticipant(Participants participant) => this.participant.Add(participant);

        public List<SlotBooking> getAvailableSlots() => new List<SlotBooking>();

        public DateTime getFromDate() => this.fromDate;

        public DateTime getToDate() => this.toDate;


        public SlotBooking findBestSlot()
        {
            DateTime t1 = this.fromDate;
            int slotNum = 1;
            HashSet<SlotBooking> first = new HashSet<SlotBooking>();
            HashSet<SlotBooking> source = new HashSet<SlotBooking>();
            HashSet<SlotBooking> slotSet = new HashSet<SlotBooking>();
            for (; DateTime.Compare(t1, this.toDate) <= 0; t1 = t1.AddDays(1.0))
            {
                for (; slotNum <= 4; ++slotNum)
                {
                    SlotBooking slot = new SlotBooking(t1.Year, t1.Month, t1.Day, slotNum);
                    first.Add(slot);
                    int num = 0;

                    foreach (Participants participant in this.participant)
                    {
                        bool ExcSet = participant.isSlotInExcSet(slot);
                        bool PrefSet = participant.isSlotInPrefSet(slot);
                        if (ExcSet)
                            slotSet.Add(slot);
                        else if (PrefSet)
                            ++num;
                    }
                    if (this.participant.Count == num)
                        source.Add(slot);
                }
                slotNum = 1;
            }
            string path1 = path +  "\\Meeting1.txt";
            string path2 = path +  "\\Meeting2.txt";
            string path3 = path +  "\\Meeting3.txt";
            string path4 = path +  "\\Meeting4.txt";
            string roomPath = path + "\\Room.txt";
            string meetingPath = path + "\\Meeting.txt";
            string SpecialPath = path + "\\SpecialEquip.txt";
            string[] SpecialEquips = File.ReadAllLines(SpecialPath);
            string[] SelectedRoom = File.ReadAllLines(roomPath);
            string[] meetingNum = File.ReadAllLines(meetingPath);
            if (System.IO.File.Exists(path1) == true && meetingNum[0] != "1")
            {
            string[] data1 =File.ReadAllLines(path1);
                if (data1[0] != "")
                {
                    string[] sep = { " (Disabled Access + Projector)"};
                    string[] sepProjector = { " (Projector)"};
                    string[] sepDisabled = {" (Disabled Access)"};
                    string room = data1[1];
                    string[] RoomTakenCheck1 = room.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);

                    string RoomCheck2 = RoomTakenCheck1[0];
                    string[] RoomTakenCheck2 = RoomCheck2.Split(sepProjector, System.StringSplitOptions.RemoveEmptyEntries);
                     
                    string RoomCheck3 = RoomTakenCheck2[0];
                    string[] RoomTaken = RoomCheck3.Split(sepDisabled, System.StringSplitOptions.RemoveEmptyEntries);
                        
                        

                    string otherRoom = SelectedRoom[0];
                    string[] CheckRoomCheck1 = otherRoom.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                        
                    string otherRoom2 = CheckRoomCheck1[0];
                    string[] CheckRoomCheck2 = otherRoom2.Split(sepProjector, System.StringSplitOptions.RemoveEmptyEntries);

                    string otherRoom3 = CheckRoomCheck2[0];
                    string[] CheckRoom = otherRoom3.Split(sepDisabled, System.StringSplitOptions.RemoveEmptyEntries);

                    bool EquipSame = false;


                    if (data1[33] == SpecialEquips[0]&&SpecialEquips[0]!="" || data1[33] == SpecialEquips[1]&&SpecialEquips[1]!="" || data1[33] == SpecialEquips[2]&&SpecialEquips[2]!="" || data1[33] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data1[34] == SpecialEquips[0]&&SpecialEquips[0]!="" || data1[34] == SpecialEquips[1]&&SpecialEquips[1]!=""|| data1[34] == SpecialEquips[2]&&SpecialEquips[2]!="" || data1[34] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data1[35] == SpecialEquips[0]&&SpecialEquips[0]!="" || data1[35] == SpecialEquips[1]&&SpecialEquips[1]!="" || data1[35] == SpecialEquips[2]&&SpecialEquips[2]!="" || data1[35] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data1[36] == SpecialEquips[0]&&SpecialEquips[0]!="" || data1[36] == SpecialEquips[1]&&SpecialEquips[1]!="" || data1[36] == SpecialEquips[2]&&SpecialEquips[2]!="" || data1[36] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    if (RoomTaken[0] == CheckRoom[0] || EquipSame == true )
                    {
                        string[] separator = { "Slot " };
                        string numberSlot = data1[3];
                        string[] slotNumber = numberSlot.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                      
                        slotNum = int.Parse(slotNumber[0]);
                        string date2 = data1[2];
                        string[] date = date2.Split('/');
                        DateTime m1 = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                        SlotBooking slot = new SlotBooking(m1.Year, m1.Month, m1.Day, slotNum);
                            source.Remove(slot);
                    }
                }

            }
            if (System.IO.File.Exists(path2) == true && meetingNum[0] != "2")
             {
                string[] data2 =File.ReadAllLines(path2);
                if (data2[0] != "")
                {
                    string[] sep = { " (Disabled Access + Projector)"};
                    string[] sepProjector = { " (Projector)"};
                    string[] sepDisabled = {" (Disabled Access)"};
                    string room = data2[1];
                    string[] RoomTakenCheck1 = room.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);

                    string RoomCheck2 = RoomTakenCheck1[0];
                    string[] RoomTakenCheck2 = RoomCheck2.Split(sepProjector, System.StringSplitOptions.RemoveEmptyEntries);
                      
                    string RoomCheck3 = RoomTakenCheck2[0];
                    string[] RoomTaken = RoomCheck3.Split(sepDisabled, System.StringSplitOptions.RemoveEmptyEntries);
                        
                        

                    string otherRoom = SelectedRoom[0];
                    string[] CheckRoomCheck1 = otherRoom.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                        
                    string otherRoom2 = CheckRoomCheck1[0];
                    string[] CheckRoomCheck2 = otherRoom2.Split(sepProjector, System.StringSplitOptions.RemoveEmptyEntries);

                    string otherRoom3 = CheckRoomCheck2[0];
                    string[] CheckRoom = otherRoom3.Split(sepDisabled, System.StringSplitOptions.RemoveEmptyEntries);
                    bool EquipSame = false;


                    if (data2[33] == SpecialEquips[0]&&SpecialEquips[0]!="" || data2[33] == SpecialEquips[1]&&SpecialEquips[1]!="" || data2[33] == SpecialEquips[2]&&SpecialEquips[2]!="" || data2[33] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data2[34] == SpecialEquips[0]&&SpecialEquips[0]!="" || data2[34] == SpecialEquips[1]&&SpecialEquips[1]!="" || data2[34] == SpecialEquips[2]&&SpecialEquips[2]!="" || data2[34] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data2[35] == SpecialEquips[0]&&SpecialEquips[0]!="" || data2[35] == SpecialEquips[1]&&SpecialEquips[1]!="" || data2[35] == SpecialEquips[2]&&SpecialEquips[2]!="" || data2[35] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data2[36] == SpecialEquips[0]&&SpecialEquips[0]!="" || data2[36] == SpecialEquips[1]&&SpecialEquips[1]!="" || data2[36] == SpecialEquips[2]&&SpecialEquips[2]!="" || data2[36] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }


                    if (RoomTaken[0] == CheckRoom[0]||EquipSame == true )
                    {
                       string numberSlot = data2[3];
                        string[] separator = { "Slot " };
                        
                        string[] slotNumber = numberSlot.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                        slotNum = int.Parse(slotNumber[0]);
                        string date2 = data2[2];
                        string[] date = date2.Split('/');
                        DateTime m1 = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                        SlotBooking slot = new SlotBooking(m1.Year, m1.Month, m1.Day, slotNum);
                            source.Remove(slot);
                          

                    }
                }
            }
             if (System.IO.File.Exists(path3) == true && meetingNum[0] != "3")
               {
               string[] data3 =File.ReadAllLines(path3);
                if (data3[0] != "")
                    {
                    string[] sep = { " (Disabled Access + Projector)"};
                    string[] sepProjector = { " (Projector)"};
                    string[] sepDisabled = {" (Disabled Access)"};
                        string room = data3[1];
                        string[] RoomTakenCheck1 = room.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);

                        string RoomCheck2 = RoomTakenCheck1[0];
                        string[] RoomTakenCheck2 = RoomCheck2.Split(sepProjector, System.StringSplitOptions.RemoveEmptyEntries);
                        
                        string RoomCheck3 = RoomTakenCheck2[0];
                        string[] RoomTaken = RoomCheck3.Split(sepDisabled, System.StringSplitOptions.RemoveEmptyEntries);
                        
                        

                        string otherRoom = SelectedRoom[0];
                        string[] CheckRoomCheck1 = otherRoom.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                        
                        string otherRoom2 = CheckRoomCheck1[0];
                        string[] CheckRoomCheck2 = otherRoom2.Split(sepProjector, System.StringSplitOptions.RemoveEmptyEntries);

                        string otherRoom3 = CheckRoomCheck2[0];
                        string[] CheckRoom = otherRoom3.Split(sepDisabled, System.StringSplitOptions.RemoveEmptyEntries);
                        bool EquipSame = false;
                        
                    if(data3[33] == SpecialEquips[0]&&SpecialEquips[0]!=""|| data3[33] == SpecialEquips[1]&&SpecialEquips[1]!=""|| data3[33] == SpecialEquips[2]&&SpecialEquips[2]!=""|| data3[33] == SpecialEquips[3]&&SpecialEquips[3]!="") 
                        {
                            EquipSame = true;
                        }

                    else if (data3[34] == SpecialEquips[0]&&SpecialEquips[0]!="" || data3[34] == SpecialEquips[1]&&SpecialEquips[1]!="" || data3[34] == SpecialEquips[2]&&SpecialEquips[2]!="" || data3[34] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data3[35] == SpecialEquips[0]&&SpecialEquips[0]!="" || data3[35] == SpecialEquips[1]&&SpecialEquips[1]!="" || data3[35] == SpecialEquips[2]&&SpecialEquips[2]!="" || data3[35] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data3[36] == SpecialEquips[0]&&SpecialEquips[0]!="" || data3[36] == SpecialEquips[1]&&SpecialEquips[1]!="" || data3[36] == SpecialEquips[2]&&SpecialEquips[2]!="" || data3[36] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }


                    if (RoomTaken[0] == CheckRoom[0]||EquipSame == true)
                    {
                       string numberSlot = data3[3];
                        string[] separator = { "Slot " };
                        
                        string[] slotNumber = numberSlot.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                        slotNum = int.Parse(slotNumber[0]);
                        string date3 = data3[2];
                        string[] date = date3.Split('/');
                        DateTime m1 = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                        SlotBooking slot = new SlotBooking(m1.Year, m1.Month, m1.Day, slotNum);
                            source.Remove(slot);
                    }
                }
            }
             if (System.IO.File.Exists(path4) == true && meetingNum[0] != "4")
                {
               string[] data4 =File.ReadAllLines(path4);
                if (data4[0] != "")
                    {
                    string[] sep = { " (Disabled Access + Projector)"};
                    string[] sepProjector = { " (Projector)"};
                    string[] sepDisabled = {" (Disabled Access)"};
                        string room = data4[1];
                        string[] RoomTakenCheck1 = room.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);

                        string RoomCheck2 = RoomTakenCheck1[0];
                        string[] RoomTakenCheck2 = RoomCheck2.Split(sepProjector, System.StringSplitOptions.RemoveEmptyEntries);
                        
                        string RoomCheck3 = RoomTakenCheck2[0];
                        string[] RoomTaken = RoomCheck3.Split(sepDisabled, System.StringSplitOptions.RemoveEmptyEntries);
                        
                        

                        string otherRoom = SelectedRoom[0];
                        string[] CheckRoomCheck1 = otherRoom.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                        
                        string otherRoom2 = CheckRoomCheck1[0];
                        string[] CheckRoomCheck2 = otherRoom2.Split(sepProjector, System.StringSplitOptions.RemoveEmptyEntries);

                        string otherRoom3 = CheckRoomCheck2[0];
                        string[] CheckRoom = otherRoom3.Split(sepDisabled, System.StringSplitOptions.RemoveEmptyEntries);

                    bool EquipSame = false;

                    if(data4[33] == SpecialEquips[0]&&SpecialEquips[0]!=""|| data4[33] == SpecialEquips[1]&&SpecialEquips[1]!=""|| data4[33] == SpecialEquips[2]|| data4[33] == SpecialEquips[3]&&SpecialEquips[3]!="") 
                        {
                            EquipSame = true;
                        }

                    else if (data4[34] == SpecialEquips[0] &&SpecialEquips[0]!=""|| data4[34] == SpecialEquips[1] &&SpecialEquips[1]!=""|| data4[34] == SpecialEquips[2]&&SpecialEquips[2]!="" || data4[34] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data4[35] == SpecialEquips[0]&&SpecialEquips[0]!="" || data4[35] == SpecialEquips[1]&&SpecialEquips[1]!="" || data4[35] == SpecialEquips[2]&&SpecialEquips[2]!="" || data4[35] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }

                    else if (data4[36] == SpecialEquips[0]&&SpecialEquips[0]!="" || data4[36] == SpecialEquips[1]&&SpecialEquips[1]!="" || data4[36] == SpecialEquips[2]&&SpecialEquips[2]!="" || data4[36] == SpecialEquips[3]&&SpecialEquips[3]!="")
                    {
                        EquipSame = true;
                    }


                    if (RoomTaken[0] == CheckRoom[0]||EquipSame == true)
                    {
                       string numberSlot = data4[3];
                     string[] separator = { "Slot " };
                        
                        string[] slotNumber = numberSlot.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                        slotNum = int.Parse(slotNumber[0]);
                        string date2 = data4[2];
                        string[] date = date2.Split('/');
                        DateTime m1 = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                        SlotBooking slot = new SlotBooking(m1.Year, m1.Month, m1.Day, slotNum);
                            source.Remove(slot);
                            
                    }
                }
            }
            if (source.Count > 0)
                return source.ElementAt<SlotBooking>(0);
            IEnumerable<SlotBooking> slots = first.Except<SlotBooking>((IEnumerable<SlotBooking>)slotSet);
            if (slots.Count<SlotBooking>() > 0)
                throw new WeakConflict("No slot in all preference slots which has the requested room and equipment available, there are " + (object)slots.Count<SlotBooking>() + " slots not in exclusion sets, within range.", slots);
            throw new StrongConflict("No slots found in preference sets or not in exclusion sets with the requested room and equipment available.");
        }
    }
}
