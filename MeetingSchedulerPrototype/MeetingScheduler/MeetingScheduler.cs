using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MeetingScheduler
{
    public partial class MeetingScheduler : Form
    {
        private Meeting meeting;

        //In-build c# function for handling regular expressions 
        public Regex rx;
        
        public string Foundslot;
        public string path = Directory.GetCurrentDirectory();
        

        public MeetingScheduler()
        {
            InitializeComponent();
        }

        private void MeetingScheduler_Load(object sender, EventArgs e)
        {
            //Loads special equipment combobox content at run-time
            SpecialEquip1Content();
            SpecialEquip2Content();
            SpecialEquip3Content();
            SpecialEquip4Content();

            //Loads user importance combo box content at run-time
            ImportCombo1Content();
            ImportCombo2Content();
            ImportCombo3Content();
            ImportCombo4Content();

            //Loads room choice content combo box at run-time
            RoomChoiceContent1();
            RoomChoiceContent2();
            RoomChoiceContent3();
            RoomChoiceContent4();

            //Loads meeting select content combo box at run-time
            MeetingSelectContent();

            //Assigns default data box entries for the program when it is first launched, designed to be overwritten
            StatusTxt.Text = "Awaiting Status Update...";
            ErrorTxt.Text = "Awaiting Error Report...";
            MeetingDateTxt.Text = "TBC";
            MeetingSlotTxt.Text = "TBC";
            AdamResult.Text = "N/A";
            SebResult.Text = "N/A";
            NathanResult.Text = "N/A";
            MattResult.Text = "N/A";

            MeetingSelectCombo.Text = "1";

            SpecialEquipmentAccess();
            RoomSelectionAccess();
            MeetingChoiceTxt();
        }
        //Function that runs when the Confirm Button is pressed on the Windows Form interface by a user of the software prototype
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            string RoomChoice = "";
            MeetingRoomChoice(RoomChoice);


            //To and From date array declarations splitting text with the '/' giving the date format

            string[] FromDateArray = this.FromDateTxt.Text.Split('/');
            string[] ToDateArray = this.ToDateTxt.Text.Split('/');
            

            //Conversion of the string array into 32 bit integer equivalent with Parse in-built function 

            DateTime fromDate = new DateTime(int.Parse(FromDateArray[2]), int.Parse(FromDateArray[1]), int.Parse(FromDateArray[0]));
            DateTime toDate = new DateTime(int.Parse(ToDateArray[2]), int.Parse(ToDateArray[1]), int.Parse(ToDateArray[0]));
            try
            {
                this.meeting = new Meeting(new MeetingInitiator(this.InitiatorTxt.Text.Trim()), fromDate, toDate);
                foreach (Participants participant in this.GetParticipants())
                    this.meeting.addParticipant(participant);
                try
                {
                    string RoomDecision = MeetingRoomChoice(RoomChoice);
                    SpecialEquipTXT();
                    MeetingChoiceTxt();
                    SlotBooking bestSlot = this.meeting.findBestSlot();
                    this.ErrorTxt.Text = "No Errors";
                    this.meeting.setStatus("Planned");
                    this.MeetingDateTxt.Text = bestSlot.date.ToShortDateString();
                    this.MeetingSlotTxt.Text = "Slot " + bestSlot.SlotNumber.ToString();
                    int num = (int)MessageBox.Show("We found you a meeting date!\n" + bestSlot.ToString() + "\n" + " The meeting initiator is " + InitiatorTxt.Text + "\n" + "You are in: " + RoomDecision); 
                    SlotBooking bestslot = this.meeting.findBestSlot();
                    Foundslot = bestslot.date.ToShortDateString() +" Slot " + bestslot.SlotNumber.ToString();
               
            
            if (MeetingSelectCombo.Text == "1")
            {
                RoomDecision = MeetingRoomChoice(RoomChoice);
                string path1 = path +  "\\Meeting1.txt";
                string[] fileLines = {Foundslot, RoomDecision, MeetingDateTxt.Text, MeetingSlotTxt.Text, ErrorTxt.Text, StatusTxt.Text, InitiatorTxt.Text,FromDateTxt.Text,
                ToDateTxt.Text, AdamPrefBox.Text, AdamExcluBox.Text, SebPrefBox.Text, SebExcluBox.Text, NathanPrefBox.Text, NathanExcluBox.Text, MattPrefBox.Text, 
                MattExcluBox.Text, AdamResult.Text, SebResult.Text,NathanResult.Text, MattResult.Text, ImportCombo1.Text, ImportCombo2.Text, ImportCombo3.Text, ImportCombo4.Text,
                SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text, ChoiceBox1.Text, ChoiceBox2.Text, ChoiceBox3.Text, 
                ChoiceBox4.Text};
                System.IO.File.WriteAllLines(path1, fileLines);
  
            }
            else if (MeetingSelectCombo.Text == "2")
            {
                RoomDecision = MeetingRoomChoice(RoomChoice);
                string path2 = path +  "\\Meeting2.txt";
                string[] fileLines = {Foundslot, RoomDecision, MeetingDateTxt.Text, MeetingSlotTxt.Text, ErrorTxt.Text, StatusTxt.Text, InitiatorTxt.Text,FromDateTxt.Text,
                ToDateTxt.Text, AdamPrefBox.Text, AdamExcluBox.Text, SebPrefBox.Text, SebExcluBox.Text, NathanPrefBox.Text, NathanExcluBox.Text, MattPrefBox.Text, 
                MattExcluBox.Text, AdamResult.Text, SebResult.Text,NathanResult.Text, MattResult.Text, ImportCombo1.Text, ImportCombo2.Text, ImportCombo3.Text, ImportCombo4.Text, 
                SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text, ChoiceBox1.Text, ChoiceBox2.Text, ChoiceBox3.Text, 
                ChoiceBox4.Text};
                System.IO.File.WriteAllLines(path2, fileLines);
            }
            else if (MeetingSelectCombo.Text == "3")
            {
                RoomDecision = MeetingRoomChoice(RoomChoice);
                string path3= path +  "\\Meeting3.txt";
                string[] fileLines = {Foundslot, RoomDecision, MeetingDateTxt.Text, MeetingSlotTxt.Text, ErrorTxt.Text, StatusTxt.Text, InitiatorTxt.Text,FromDateTxt.Text,
                ToDateTxt.Text, AdamPrefBox.Text, AdamExcluBox.Text, SebPrefBox.Text, SebExcluBox.Text, NathanPrefBox.Text, NathanExcluBox.Text, MattPrefBox.Text, 
                MattExcluBox.Text, AdamResult.Text, SebResult.Text,NathanResult.Text, MattResult.Text, ImportCombo1.Text, ImportCombo2.Text, ImportCombo3.Text, ImportCombo4.Text,
                SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text, ChoiceBox1.Text, ChoiceBox2.Text, ChoiceBox3.Text, 
                ChoiceBox4.Text};
                System.IO.File.WriteAllLines(path3, fileLines);
            }
            else if (MeetingSelectCombo.Text == "4")
            {
                RoomDecision = MeetingRoomChoice(RoomChoice);
                string path4 = path +  "\\Meeting4.txt"; 
                string[] fileLines = {Foundslot, RoomDecision, MeetingDateTxt.Text, MeetingSlotTxt.Text, ErrorTxt.Text, StatusTxt.Text, InitiatorTxt.Text,FromDateTxt.Text,
                ToDateTxt.Text, AdamPrefBox.Text, AdamExcluBox.Text, SebPrefBox.Text, SebExcluBox.Text, NathanPrefBox.Text, NathanExcluBox.Text, MattPrefBox.Text, 
                MattExcluBox.Text, AdamResult.Text, SebResult.Text,NathanResult.Text, MattResult.Text, ImportCombo1.Text, ImportCombo2.Text, ImportCombo3.Text, ImportCombo4.Text,
                SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text, ChoiceBox1.Text, ChoiceBox2.Text, ChoiceBox3.Text, 
                ChoiceBox4.Text};
                System.IO.File.WriteAllLines(path4, fileLines);
            }

                }
                catch (WeakConflict ex)
                {
                    this.meeting.setStatus("Weak Conflict");
                    this.ErrorTxt.Text = "Weak Conflict: " + ex.Message;
                    int num = (int)MessageBox.Show(ex.Message, "Weak Conflict Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                }
                catch (StrongConflict ex)
                {
                    this.meeting.setStatus("Strong Conflict");
                    this.ErrorTxt.Text = "Strong Conflict: " + ex.Message;
                    int num = (int)MessageBox.Show(ex.Message, "Strong Conflict Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (DateRangeException ex)
            {
                this.ErrorTxt.Text = ex.Message;
                int num = (int)MessageBox.Show(ex.Message, "Date Range Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                this.StatusTxt.Text = "Initiator Error";
            }
            catch (Exception ex)
            {
                this.meeting.setStatus("Participant Error");
                this.ErrorTxt.Text = ex.Message;
                int num = (int)MessageBox.Show(ex.Message, "Participants Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
            }
            if (this.meeting == null || !(this.StatusTxt.Text != "Initiator Error"))
                return;
            this.StatusTxt.Text = this.meeting.getStatus();

            // Save meeting details

            //SlotBooking bestslot = this.meeting.findBestSlot();
          

        }

        private List<Participants> GetParticipants()
        {
            List<Participants> participantList = new List<Participants>();
            this.rx = new Regex("(\\d{1,2})/(\\d{1,2})/(\\d{4}) Slot (\\d)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            bool flag = true;
            Participants participant1 = new Participants("Adam");
            this.AdamResult.Text = "";
            try
            {
                this.fillParticipantSet(participant1, "Preference", this.AdamPrefBox.Text);
            }
            catch (SlotException ex)
            {
                flag = false;
                TextBox AdamResult = this.AdamResult;
                AdamResult.Text = AdamResult.Text + ex.Message + "\n";
            }
            try
            {
                this.fillParticipantSet(participant1, "Exclusion", this.AdamExcluBox.Text);

            }
            catch (SlotException ex)
            {
                flag = false;
                TextBox AdamResult = this.AdamResult;
                AdamResult.Text = AdamResult.Text + ex.Message + "\n";
            }
            if (this.AdamResult.Text == "")
                this.AdamResult.Text = "Success!";
            Participants participant2 = new Participants("Sebastian");
            this.SebResult.Text = "";
            try
            {
                this.fillParticipantSet(participant2, "Preference", this.SebPrefBox.Text);
            }
            catch (SlotException ex)
            {
                flag = false;
                TextBox SebResult = this.SebResult;
                SebResult.Text = SebResult.Text + ex.Message + "\n";
            }
            try
            {
                this.fillParticipantSet(participant2, "Exclusion", this.SebExcluBox.Text);
            }
            catch (SlotException ex)
            {
                flag = false;
                TextBox SebResult = this.SebResult;
                SebResult.Text = SebResult.Text + ex.Message + "\n";
            }
            if (this.SebResult.Text == "")
                this.SebResult.Text = "Success!";
            Participants participant3 = new Participants("Nathan");
            this.NathanResult.Text = "";
            try
            {
                this.fillParticipantSet(participant3, "Preference", this.NathanPrefBox.Text);
            }
            catch (SlotException ex)
            {
                flag = false;
                TextBox NathanResult = this.NathanResult;
                NathanResult.Text = NathanResult.Text + ex.Message + "\n";
            }
            try
            {
                this.fillParticipantSet(participant3, "Exclusion", this.NathanExcluBox.Text);
            }
            catch (SlotException ex)
            {
                flag = false;
                TextBox NathanResult = this.NathanResult;
                NathanResult.Text = NathanResult.Text + ex.Message + "\n";
            }
            if (this.NathanResult.Text == "")
                this.NathanResult.Text = "Success!";
            Participants participant4 = new Participants("Matt");
            this.MattResult.Text = "";
            try
            {
                this.fillParticipantSet(participant4, "Preference", this.MattPrefBox.Text);
            }
            catch (SlotException ex)
            {
                flag = false;
                TextBox MattResult = this.MattResult;
                MattResult.Text = MattResult.Text + ex.Message + "\n";
            }
            try
            {
                this.fillParticipantSet(participant4, "Exclusion", this.MattExcluBox.Text);
            }
            catch (SlotException ex)
            {
                flag = false;
                TextBox MattResult = this.MattResult;
                MattResult.Text = MattResult.Text + ex.Message + "\n";
            }
            if (this.MattResult.Text == "")
                this.MattResult.Text = "Success!";

            participantList.Add(participant1);
            participantList.Add(participant2);
            participantList.Add(participant3);
            participantList.Add(participant4);
            if (!flag)
                throw new Exception("Participant(s) error.");
            return participantList;

        }

        private void fillParticipantSet(Participants participant, string setType, string setText)
        {
            foreach (Match match in this.rx.Matches(setText))
            {
                GroupCollection groups = match.Groups;
                DateTime dateTime = new DateTime(int.Parse(groups[3].Value), int.Parse(groups[2].Value), int.Parse(groups[1].Value));
                if (DateTime.Compare(dateTime, this.meeting.getFromDate()) < 0)
                    throw new SlotException(match.ToString() + " (" + (setType == "Preference" ? "Preference Set" : "Exclusion Set") + ") is before the min date of the meeting.", participant);
                if (DateTime.Compare(dateTime, this.meeting.getToDate()) > 0)
                    throw new SlotException(match.ToString() + " (" + (setType == "Preference" ? "Preference Set" : "Exclusion Set") + ") is after the max date of the meeting.", participant);
                SlotBooking slot = new SlotBooking(dateTime, int.Parse(groups[4].Value));
                if (setType == "Preference")
                    participant.addToPreferenceSet(slot);
                else
                    participant.addToExclusionSet(slot);
            }
        }

        //Meeting member special equipment requests
        private void SpecialEquip1Content()
        {
            SpecialEquip1.Items.Add("Projector");
            SpecialEquip1.Items.Add("Laptop");
            SpecialEquip1.Items.Add("Printer");
            SpecialEquip1.Items.Add("Speech to Text Software");
            SpecialEquip1.Items.Add("Sign Language Specialist");
            SpecialEquip1.Items.Add("Scribe");
            SpecialEquip1.Items.Add("Interpretor");
            SpecialEquip1.Sorted = true;
        }
        //Meeting member special equipment requests
        private void SpecialEquip2Content()
        {
            SpecialEquip2.Items.Add("Projector");
            SpecialEquip2.Items.Add("Laptop");
            SpecialEquip2.Items.Add("Printer");
            SpecialEquip2.Items.Add("Speech to Text Software");
            SpecialEquip2.Items.Add("Sign Language Specialist");
            SpecialEquip2.Items.Add("Scribe");
            SpecialEquip2.Items.Add("Interpretor");
            SpecialEquip2.Sorted = true;
        }
        //Meeting member special equipment requests
        private void SpecialEquip3Content()
        {
            SpecialEquip3.Items.Add("Projector");
            SpecialEquip3.Items.Add("Laptop");
            SpecialEquip3.Items.Add("Printer");
            SpecialEquip3.Items.Add("Speech to Text Software");
            SpecialEquip3.Items.Add("Sign Language Specialist");
            SpecialEquip3.Items.Add("Scribe");
            SpecialEquip3.Items.Add("Interpretor");
            SpecialEquip3.Sorted = true;
        }
        //Meeting member special equipment requests
        private void SpecialEquip4Content()
        {
            SpecialEquip4.Items.Add("Projector");
            SpecialEquip4.Items.Add("Laptop");
            SpecialEquip4.Items.Add("Printer");
            SpecialEquip4.Items.Add("Speech to Text Software");
            SpecialEquip4.Items.Add("Sign Language Specialist");
            SpecialEquip4.Items.Add("Scribe");
            SpecialEquip4.Items.Add("Interpretor");
            SpecialEquip4.Sorted = true;
        }

        //Adds content to the room choice dropdown boxes 
        private void RoomChoiceContent1()
        {
            ChoiceBox1.Items.Add("Room 1");
            ChoiceBox1.Items.Add("Room 2");
            ChoiceBox1.Items.Add("Room 3");
            ChoiceBox1.Items.Add("Room 4 (Disabled Access)");
            ChoiceBox1.Sorted = true;
        }
        //Adds content to the room choice dropdown boxes 
        private void RoomChoiceContent2()
        {
            ChoiceBox2.Items.Add("Room 1");
            ChoiceBox2.Items.Add("Room 2");
            ChoiceBox2.Items.Add("Room 3");
            ChoiceBox2.Items.Add("Room 4 (Disabled Access)");
            ChoiceBox2.Sorted = true;
        }
        //Adds content to the room choice dropdown boxes 
        private void RoomChoiceContent3()
        {
            ChoiceBox3.Items.Add("Room 1");
            ChoiceBox3.Items.Add("Room 2");
            ChoiceBox3.Items.Add("Room 3");
            ChoiceBox3.Items.Add("Room 4 (Disabled Access)");
            ChoiceBox3.Sorted = true;
        }
        //Adds content to the room choice dropdown boxes 
        private void RoomChoiceContent4()
        {
            ChoiceBox4.Items.Add("Room 1");
            ChoiceBox4.Items.Add("Room 2");
            ChoiceBox4.Items.Add("Room 3");
            ChoiceBox4.Items.Add("Room 4 (Disabled Access)");
            ChoiceBox4.Sorted = true;
        }

        //Outputs most popular or overriden room choice when the confirm button is pressed 
        public string MeetingRoomChoice(string RoomChoice)
        {
            RoomChoice = "";
            
            if(ChoiceBox1.Text == "Room 4 (Disabled Access)" || ChoiceBox2.Text == "Room 4 (Disabled Access)" || ChoiceBox3.Text == "Room 4 (Disabled Access)" || ChoiceBox4.Text == "Room 4 (Disabled Access)")
            {
                RoomChoice = "Room 4 (Disabled Access)";
                if (SpecialEquip1.Text == "Projector" || SpecialEquip2.Text == "Projector" || SpecialEquip3.Text == "Projector" || SpecialEquip4.Text == "Projector")
                {
                    RoomChoice = "Room 4 (Disabled Access + Projector)";
                }
            }

            else if (SpecialEquip1.Text == "Projector" || SpecialEquip2.Text == "Projector" || SpecialEquip3.Text == "Projector" || SpecialEquip4.Text == "Projector")
            {
                RoomChoice = "Room 4 (Projector)";
                if (ChoiceBox1.Text == "Room 4 (Disabled Access)" || ChoiceBox2.Text == "Room 4 (Disabled Access)" || ChoiceBox3.Text == "Room 4 (Disabled Access)" || ChoiceBox4.Text == "Room 4 (Disabled Access)")
                {
                    RoomChoice = "Room 4 (Projector + Disabled Access)";
                }
                
            }

            if (ChoiceBox1.Text == "Room 1" && RoomChoice == "")
            {
                if (ChoiceBox2.Text == "Room 1" || ChoiceBox3.Text == "Room 1" || ChoiceBox4.Text == "Room 1")
                {
                    RoomChoice = "Room 1";
                }
            }
            
            else if (ChoiceBox1.Text == "Room 2")
            {
                if (ChoiceBox2.Text == "Room 2" || ChoiceBox3.Text == "Room 2" || ChoiceBox4.Text == "Room 2")
                {
                    RoomChoice = "Room 2";
                }
            }
            
            else if (ChoiceBox1.Text == "Room 3" )
            {
                if (ChoiceBox2.Text == "Room 3" || ChoiceBox3.Text == "Room 3" || ChoiceBox4.Text == "Room 3")
                {
                    RoomChoice = "Room 3";
                }
            }
            if (ChoiceBox2.Text == "Room 1" && RoomChoice == "")
            {
                if ( ChoiceBox3.Text == "Room 1" || ChoiceBox4.Text == "Room 1")
                {
                    RoomChoice = "Room 1";
                }
            }
            
            else if (ChoiceBox2.Text == "Room 2" )
            {
                if ( ChoiceBox3.Text == "Room 2" || ChoiceBox4.Text == "Room 2")
                {
                    RoomChoice = "Room 2";
                }
            }
            
            else if (ChoiceBox2.Text == "Room 3" )
            {
                if ( ChoiceBox3.Text == "Room 3" || ChoiceBox4.Text == "Room 3")
                {
                    RoomChoice = "Room 3";
                }
            }
            if (ChoiceBox3.Text == "Room 1" && RoomChoice == "")
            {
                if ( ChoiceBox4.Text == "Room 1")
                {
                    RoomChoice = "Room 1";
                }
            }
            
            else if (ChoiceBox3.Text == "Room 2" )
            {
                if ( ChoiceBox4.Text == "Room 2")
                {
                    RoomChoice = "Room 2";
                }
            }
            
            else if (ChoiceBox3.Text == "Room 3")
            {
                if (ChoiceBox4.Text == "Room 3")
                {
                    RoomChoice = "Room 3";
                }
            }
            if ( RoomChoice == "")
            {
                if (ChoiceBox1.Text != "")
                {
                    RoomChoice = ChoiceBox1.Text;
                }
                else if (ChoiceBox2.Text != "")
                {
                    RoomChoice = ChoiceBox2.Text;
                }
                else if (ChoiceBox3.Text != "")
                {
                    RoomChoice = ChoiceBox3.Text;
                }
                else if (ChoiceBox4.Text != "")
                {
                    RoomChoice = ChoiceBox4.Text;
                }
                else
                {
                    RoomChoice ="";
                }
               
            
            }
           
              string[] RoomChoiceArray = {RoomChoice};
              string room= path +  "\\Room.txt";
              System.IO.File.WriteAllLines(room, RoomChoiceArray);


            return RoomChoice;

        }


        private void SpecialEquip1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Item itm = (Item)SpecialEquip1.SelectedItem;
            ComboBox SpecialEquip1 = new ComboBox();
           
            
           
        }

        private void SpecialEquip2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox SpecialEquip2 = new ComboBox();
            
        }

        private void SpecialEquip3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox SpecialEquip3 = new ComboBox();
            
        }

        private void SpecialEquip4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox SpecialEquip4 = new ComboBox();
            
        }

        private void MeetingSelectCombo_SelectedIndexChanged(Object sender, EventArgs e)
        {
           ComboBox MeetingSelectCombo = new ComboBox();

        }

        private void MeetingChoiceTxt()
        {
              string MeetingChoice ="";
              if (MeetingSelectCombo.Text == "1")
              {
                 MeetingChoice="1";
              }
              else if (MeetingSelectCombo.Text == "2")
              {
                 MeetingChoice="2";
              }
               else if (MeetingSelectCombo.Text == "3")
              {
                 MeetingChoice="3";
              }
               else if (MeetingSelectCombo.Text == "4")
              {
                 MeetingChoice="4";
              }
              string[] MeetingChoiceArray = {MeetingChoice};
              string meetingPath= path +  "\\Meeting.txt";
              System.IO.File.WriteAllLines(meetingPath, MeetingChoiceArray);
        
        }

        //Meeting member combo boxes 
        private void ImportCombo1Content()
        {
            ImportCombo1.Items.Add("Important");
            ImportCombo1.Items.Add("Active");
            ImportCombo1.Items.Add("Special Needs");
            ImportCombo1.Items.Add("Guest");
            ImportCombo1.Items.Add("Ordinary");
            ImportCombo1.Sorted = true;
        }
        //Meeting member combo boxes 
        private void ImportCombo2Content()
        {
            ImportCombo2.Items.Add("Important");
            ImportCombo2.Items.Add("Active");
            ImportCombo2.Items.Add("Special Needs");
            ImportCombo2.Items.Add("Guest");
            ImportCombo2.Items.Add("Ordinary");
            ImportCombo2.Sorted = true;
        }
        //Meeting member combo boxes 
        private void ImportCombo3Content()
        {
            ImportCombo3.Items.Add("Important");
            ImportCombo3.Items.Add("Active");
            ImportCombo3.Items.Add("Special Needs");
            ImportCombo3.Items.Add("Guest");
            ImportCombo3.Items.Add("Ordinary");
            ImportCombo3.Sorted = true;
        }
        //Meeting member combo boxes 
        private void ImportCombo4Content()
        {
            ImportCombo4.Items.Add("Important");
            ImportCombo4.Items.Add("Active");
            ImportCombo4.Items.Add("Special Needs");
            ImportCombo4.Items.Add("Guest");
            ImportCombo4.Items.Add("Ordinary");
            ImportCombo4.Sorted = true;
        }

        //Content insert to combo box for the meeting selection 
        private void MeetingSelectContent()
        {
            MeetingSelectCombo.Items.Add("1");
            MeetingSelectCombo.Items.Add("2");
            MeetingSelectCombo.Items.Add("3");
            MeetingSelectCombo.Items.Add("4");

        }

        private void SpecialEquipTXT()
        {
        
              string[] SpecialEquipArray = {SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text};
              string SpecialEquip = path +  "\\SpecialEquip.txt";
              System.IO.File.WriteAllLines(SpecialEquip, SpecialEquipArray);

        }

        //Validation access depending on meeting members role on the system 
        private void SpecialEquipmentAccess()
        {
            string selected1 = ImportCombo1.Text;
            if (selected1 == "Guest" || selected1 == "Ordinary" || selected1 == "")
                {
                SpecialEquip1.Enabled = false;
                SpecialEquip1.Text="";
            }
            else
                SpecialEquip1.Enabled = true;

            string selected2 = this.ImportCombo2.GetItemText(this.ImportCombo2.SelectedItem);
            if (selected2 == "Guest" || selected2 == "Ordinary" || selected2 == "")
                {
                SpecialEquip2.Enabled = false;
                SpecialEquip2.Text="";
            }
            else
                SpecialEquip2.Enabled = true;

            string selected3 = this.ImportCombo3.GetItemText(this.ImportCombo3.SelectedItem);
            if (selected3 == "Guest" || selected3 == "Ordinary" || selected3 == "")
                {
                SpecialEquip3.Enabled = false;
                SpecialEquip3.Text="";
                }            
            else
            SpecialEquip3.Enabled = true;

            string selected4 = this.ImportCombo4.GetItemText(this.ImportCombo4.SelectedItem);
            if (selected4 == "Guest" || selected4 == "Ordinary" || selected4 == "")
                {
                SpecialEquip4.Enabled = false;
                SpecialEquip4.Text="";
                }
            else
            SpecialEquip4.Enabled = true;


        }

       // Validation access depending on meeting members role on the system 
        private void RoomSelectionAccess()
        {

           string selected1 = "";
           
           selected1 = ImportCombo1.Text;
           if (selected1 == "" || selected1 == "Ordinary" || selected1 == "Guest" || selected1 == "Active")
                {
                ChoiceBox1.Enabled = false;
                ChoiceBox1.Text="";       
                }
            else
                ChoiceBox1.Enabled = true;
                
            string selected2 = this.ImportCombo2.GetItemText(this.ImportCombo2.SelectedItem);
            if (selected2 == "" || selected2 == "Ordinary" || selected2 == "Guest" || selected2 == "Active")
                {
                ChoiceBox2.Enabled = false;
                ChoiceBox2.Text="";       
                }
            else
                ChoiceBox2.Enabled = true;
                

            string selected3 = this.ImportCombo3.GetItemText(this.ImportCombo3.SelectedItem);
           if (selected3 == "" || selected3 == "Ordinary" || selected3 == "Guest" || selected3 == "Active")
                {
                ChoiceBox3.Enabled = false;
                ChoiceBox3.Text="";       
                }
            else
                ChoiceBox3.Enabled = true;
                

            string selected4 = this.ImportCombo4.GetItemText(this.ImportCombo4.SelectedItem);
            if (selected4 == "" || selected4 == "Ordinary" || selected4 == "Guest" || selected4 == "Active")
                {
                ChoiceBox4.Enabled = false;
                ChoiceBox4.Text="";       
                }
            else
                ChoiceBox4.Enabled = true;
                
                
        }

        private void ImportCombo1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            ComboBox ImportCombo1 = new ComboBox();
            SpecialEquipmentAccess();
            RoomSelectionAccess();
        }

        private void ImportCombo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox ImportCombo2 = new ComboBox();
            SpecialEquipmentAccess();
            RoomSelectionAccess();
        }

        private void ImportCombo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox ImportCombo3 = new ComboBox();
            SpecialEquipmentAccess();
            RoomSelectionAccess();
        }

        private void ImportCombo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox ImportCombo4 = new ComboBox();
            SpecialEquipmentAccess();
            RoomSelectionAccess();
        }



        //Clearing the empty string boxes when the clear button is pressed 
        //private void ClearBtn_Click_1(object sender, EventArgs e)
        //{
        //    InitiatorTxt.Text = String.Empty;
        //    FromDateTxt.Text = String.Empty;
        //    ToDateTxt.Text = String.Empty;
        //    StatusTxt.Text = String.Empty;
        //    MeetingDateTxt.Text = String.Empty;
        //    MeetingSlotTxt.Text = String.Empty;
        //    ErrorTxt.Text = String.Empty;
        //    AdamResult.Text = String.Empty;
        //    SebResult.Text = String.Empty;
        //    NathanResult.Text = String.Empty;
        //    MattResult.Text = String.Empty;
        //    SpecialEquip1.Text = String.Empty;
        //    SpecialEquip2.Text = String.Empty;
        //    SpecialEquip3.Text = String.Empty;
        //    SpecialEquip4.Text = String.Empty;
        //    ImportCombo1.Text = String.Empty;
        //    ImportCombo2.Text = String.Empty;
        //    ImportCombo3.Text = String.Empty;
        //    ImportCombo4.Text = String.Empty;
        //    AdamPrefBox.Text = String.Empty;
        //    SebPrefBox.Text = String.Empty;
        //    NathanPrefBox.Text = String.Empty;
        //    MattPrefBox.Text = String.Empty;
        //    AdamExcluBox.Text = String.Empty;
        //    SebExcluBox.Text = String.Empty;
        //    NathanExcluBox.Text = String.Empty;
        //    MattExcluBox.Text = String.Empty;
        //    ChoiceBox1.Text = String.Empty;
        //    ChoiceBox2.Text = String.Empty;
        //    ChoiceBox3.Text = String.Empty;
        //    ChoiceBox4.Text = String.Empty;
        //}

        //Quits the program when the quit button is pressed on the form
        //private void QuitBtn_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //Function to load previously saved meeting into a text file 
        private void MeetingLoadBtn_Click(object sender, EventArgs e)
        {
            string[] lines;
            int index =  0;
            InitiatorTxt.Text = String.Empty;
            FromDateTxt.Text = String.Empty;
            ToDateTxt.Text = String.Empty;
            StatusTxt.Text = String.Empty;
            MeetingDateTxt.Text = String.Empty;
            MeetingSlotTxt.Text = String.Empty;
            ErrorTxt.Text = String.Empty;
            AdamResult.Text = String.Empty;
            SebResult.Text = String.Empty;
            NathanResult.Text = String.Empty;
            MattResult.Text = String.Empty;
            SpecialEquip1.Text = "";
            SpecialEquip2.Text = "";
            SpecialEquip3.Text = "";
            SpecialEquip4.Text = "";
            ImportCombo1.Text = "";
            ImportCombo2.Text = "";
            ImportCombo3.Text = "";
            ImportCombo4.Text = "";
            AdamPrefBox.Text = String.Empty;
            SebPrefBox.Text = String.Empty;
            NathanPrefBox.Text = String.Empty;
            MattPrefBox.Text = String.Empty;
            AdamExcluBox.Text = String.Empty;
            SebExcluBox.Text = String.Empty;
            NathanExcluBox.Text = String.Empty;
            MattExcluBox.Text = String.Empty;
            ChoiceBox1.Text = "";
            ChoiceBox2.Text = "";
            ChoiceBox3.Text = "";
            ChoiceBox4.Text = "";

            if (MeetingSelectCombo.Text == "1")
            {
              
                
                string file_name = path +"\\Meeting1.txt";
                
                if (System.IO.File.Exists(file_name) == true)
                {
                    lines = File.ReadAllLines(file_name);
                    
                 
                index++;
                index++;
                MeetingDateTxt.Text = lines[index];
                index++;
                MeetingSlotTxt.Text = lines[index];
                index++;
                ErrorTxt.Text = lines[index];
                index++;
                StatusTxt.Text = lines[index];
                index++;
                InitiatorTxt.Text = lines[index];
                index++;
                FromDateTxt.Text = lines[index];
                index++;
                ToDateTxt.Text = lines[index];
                index++;
                AdamPrefBox.AppendText ( lines[index++] + Environment.NewLine + lines[index]);
                index++; 
                AdamExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                SebPrefBox.AppendText( lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                SebExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                NathanPrefBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                NathanExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                MattPrefBox.AppendText ( lines[index++] + Environment.NewLine + lines[index]);
                index++;
               
                MattExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                AdamResult.Text = lines[index];
                index++;
                SebResult.Text = lines[index];
                index++;
                NathanResult.Text = lines[index];
                index++;
                MattResult.Text = lines[index];
                index++;
                ImportCombo1.Text = lines[index];
                index++;
                ImportCombo2.Text = lines[index];
                index++;
                ImportCombo3.Text = lines[index];
                index++;
                ImportCombo4.Text = lines[index];
                index++;
                SpecialEquip1.Text = lines[index];
                index++;
                SpecialEquip2.Text = lines[index];
                index++;
                SpecialEquip3.Text = lines[index];
                index++;
                SpecialEquip4.Text = lines[index];
                index++;
                ChoiceBox1.Text = lines[index];
                index++;
                ChoiceBox2.Text = lines[index];
                index++;
                ChoiceBox3.Text = lines[index];
                index++;
                ChoiceBox4.Text = lines[index];
                    MeetingChoiceTxt();
                    RoomSelectionAccess();
                    SpecialEquipmentAccess();
                    MessageBox.Show("Meeting 1 loaded");
                }
                else
                {
                    MeetingChoiceTxt();
                    RoomSelectionAccess();
                    SpecialEquipmentAccess();
                    MessageBox.Show("Meeting 1 loaded");
                }
            }
            else if (MeetingSelectCombo.Text == "2")
            {
                 
                string file_name = path + "\\Meeting2.txt";

                if (System.IO.File.Exists(file_name) == true)
                {
                    lines = File.ReadAllLines(file_name);

                    index++;
                    index++;
                    MeetingDateTxt.Text = lines[index];
                    index++;
                    MeetingSlotTxt.Text = lines[index];
                    index++;
                    ErrorTxt.Text = lines[index];
                    index++;
                    StatusTxt.Text = lines[index];
                    index++;
                    InitiatorTxt.Text = lines[index];
                    index++;
                    FromDateTxt.Text = lines[index];
                    index++;
                    ToDateTxt.Text = lines[index];
                    index++;
                    AdamPrefBox.AppendText ( lines[index++] + Environment.NewLine + lines[index]);
                    index++;
                    AdamExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                    index++;
                
                    SebPrefBox.AppendText( lines[index++] + Environment.NewLine + lines[index]);
                    index++;
                
                    SebExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                    index++;
                
                    NathanPrefBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                    index++;
                
                    NathanExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                    index++;
                
                    MattPrefBox.AppendText ( lines[index++] + Environment.NewLine + lines[index]);
                    index++;
               
                    MattExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                    index++;
                
                    AdamResult.Text = lines[index];
                    index++;
                    SebResult.Text = lines[index];
                    index++;
                    NathanResult.Text = lines[index];
                    index++;
                    MattResult.Text = lines[index];
                    index++;
                    ImportCombo1.Text = lines[index];
                    index++;
                ImportCombo2.Text = lines[index];
                index++;
                ImportCombo3.Text = lines[index];
                index++;
                ImportCombo4.Text = lines[index];
                index++;
                SpecialEquip1.Text = lines[index];
                index++;
                SpecialEquip2.Text = lines[index];
                index++;
                SpecialEquip3.Text = lines[index];
                index++;
                SpecialEquip4.Text = lines[index];
                index++;
                ChoiceBox1.Text = lines[index];
                index++;
                ChoiceBox2.Text = lines[index];
                index++;
                ChoiceBox3.Text = lines[index];
                index++;
                ChoiceBox4.Text = lines[index];
                    MeetingChoiceTxt();
                    RoomSelectionAccess();
                    SpecialEquipmentAccess();
                    MessageBox.Show("Meeting 2 loaded");
                }
                else
                {
                    MeetingChoiceTxt();
                    RoomSelectionAccess();
                    SpecialEquipmentAccess();
                    MessageBox.Show("Meeting 2 loaded");
                }
            }

            else if (MeetingSelectCombo.Text == "3")
            {
                string file_name = path + "\\Meeting3.txt";

                if (System.IO.File.Exists(file_name) == true)
                {
                    lines = File.ReadAllLines(file_name);

                    index++;
                index++;
                MeetingDateTxt.Text = lines[index];
                index++;
                MeetingSlotTxt.Text = lines[index];
                index++;
                ErrorTxt.Text = lines[index];
                index++;
                StatusTxt.Text = lines[index];
                index++;
                InitiatorTxt.Text = lines[index];
                index++;
                FromDateTxt.Text = lines[index];
                index++;
                ToDateTxt.Text = lines[index];
                index++;
                AdamPrefBox.Text = lines[index];
                index++;
                AdamPrefBox.AppendText ( Environment.NewLine + lines[index]);
                index++;
                AdamExcluBox.Text = lines[index];
                index++;
                AdamExcluBox.AppendText ( Environment.NewLine + lines[index]);
                index++;
                SebPrefBox.Text = lines[index];
                index++;
                SebPrefBox.AppendText(  Environment.NewLine + lines[index] );
                index++;
                SebExcluBox.Text = lines[index];
                index++;
                SebExcluBox.AppendText ( Environment.NewLine + lines[index]);
                index++;
                NathanPrefBox.Text = lines[index];
                index++;
                NathanPrefBox.AppendText (Environment.NewLine + lines[index]  );
                index++;
                NathanExcluBox.Text = lines[index];
                index++;
                NathanExcluBox.AppendText ( Environment.NewLine + lines[index]  );
                index++;
                MattPrefBox.Text = lines[index];
                index++;
                MattPrefBox.AppendText (  Environment.NewLine + lines[index] );
                index++;
                MattExcluBox.Text = lines[index];
                index++;
                MattExcluBox.AppendText ( Environment.NewLine + lines[index]);
                index++;
                AdamResult.Text = lines[index];
                index++;
                SebResult.Text = lines[index];
                index++;
                NathanResult.Text = lines[index];
                index++;
                MattResult.Text = lines[index];
                index++;
                ImportCombo1.Text = lines[index];
                index++;
                ImportCombo2.Text = lines[index];
                index++;
                ImportCombo3.Text = lines[index];
                index++;
                ImportCombo4.Text = lines[index];
                index++;
                SpecialEquip1.Text = lines[index];
                index++;
                SpecialEquip2.Text = lines[index];
                index++;
                SpecialEquip3.Text = lines[index];
                index++;
                SpecialEquip4.Text = lines[index];
                index++;
                ChoiceBox1.Text = lines[index];
                index++;
                ChoiceBox2.Text = lines[index];
                index++;
                ChoiceBox3.Text = lines[index];
                index++;
                ChoiceBox4.Text = lines[index];
                    MeetingChoiceTxt();
                    RoomSelectionAccess();
                    SpecialEquipmentAccess();
                    MessageBox.Show("Meeting 3 loaded");
                }
                else{
                    MeetingChoiceTxt();
                    RoomSelectionAccess();
                    SpecialEquipmentAccess();
                    MessageBox.Show("Meeting 3 loaded");
                    }
               }

            else if (MeetingSelectCombo.Text == "4")
            {
                string file_name = path + "\\Meeting4.txt";

                if (System.IO.File.Exists(file_name) == true)
                {
                    lines = File.ReadAllLines(file_name);
                    index++;
                index++;
                MeetingDateTxt.Text = lines[index];
                index++;
                MeetingSlotTxt.Text = lines[index];
                index++;
                ErrorTxt.Text = lines[index];
                index++;
                StatusTxt.Text = lines[index];
                index++;
                InitiatorTxt.Text = lines[index];
                index++;
                FromDateTxt.Text = lines[index];
                index++;
                ToDateTxt.Text = lines[index];
                index++;
                AdamPrefBox.AppendText ( lines[index++] + Environment.NewLine + lines[index]);
                index++;
                AdamExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                SebPrefBox.AppendText( lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                SebExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                NathanPrefBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                NathanExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                MattPrefBox.AppendText ( lines[index++] + Environment.NewLine + lines[index]);
                index++;
               
                MattExcluBox.AppendText (lines[index++] + Environment.NewLine + lines[index]);
                index++;
                
                AdamResult.Text = lines[index];
                index++;
                SebResult.Text = lines[index];
                index++;
                NathanResult.Text = lines[index];
                index++;
                MattResult.Text = lines[index];
                index++;
                ImportCombo1.Text = lines[index];
                index++;
                ImportCombo2.Text = lines[index];
                index++;
                ImportCombo3.Text = lines[index];
                index++;
                ImportCombo4.Text = lines[index];
                index++;
                SpecialEquip1.Text = lines[index];
                index++;
                SpecialEquip2.Text = lines[index];
                index++;
                SpecialEquip3.Text = lines[index];
                index++;
                SpecialEquip4.Text = lines[index];
                index++;
                ChoiceBox1.Text = lines[index];
                index++;
                ChoiceBox2.Text = lines[index];
                index++;
                ChoiceBox3.Text = lines[index];
                index++;
                ChoiceBox4.Text = lines[index];
                MeetingChoiceTxt();
                RoomSelectionAccess();
                SpecialEquipmentAccess();
                MessageBox.Show("Meeting 4 loaded");

                }
                else {
                    MeetingChoiceTxt();
                    RoomSelectionAccess();
                    SpecialEquipmentAccess();
                    MessageBox.Show("Meeting 4 loaded");
                    }
               }
            }                                               
        

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            InitiatorTxt.Text = String.Empty;
            FromDateTxt.Text = String.Empty;
            ToDateTxt.Text = String.Empty;
            StatusTxt.Text = String.Empty;
            MeetingDateTxt.Text = String.Empty;
            MeetingSlotTxt.Text = String.Empty;
            ErrorTxt.Text = String.Empty;
            AdamResult.Text = String.Empty;
            SebResult.Text = String.Empty;
            NathanResult.Text = String.Empty;
            MattResult.Text = String.Empty;
            SpecialEquip1.Text = String.Empty;
            SpecialEquip2.Text = String.Empty;
            SpecialEquip3.Text = String.Empty;
            SpecialEquip4.Text = String.Empty;
            ImportCombo1.Text = String.Empty;
            ImportCombo2.Text = String.Empty;
            ImportCombo3.Text = String.Empty;
            ImportCombo4.Text = String.Empty;
            AdamPrefBox.Text = String.Empty;
            SebPrefBox.Text = String.Empty;
            NathanPrefBox.Text = String.Empty;
            MattPrefBox.Text = String.Empty;
            AdamExcluBox.Text = String.Empty;
            SebExcluBox.Text = String.Empty;
            NathanExcluBox.Text = String.Empty;
            MattExcluBox.Text = String.Empty;
            ChoiceBox1.Text = String.Empty;
            ChoiceBox2.Text = String.Empty;
            ChoiceBox3.Text = String.Empty;
            ChoiceBox4.Text = String.Empty;
        }

        private void QuitBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string RoomChoice = "";
            string RoomDecision = MeetingRoomChoice(RoomChoice);
            if (AdamPrefBox.Text == "")
                AdamPrefBox.Text = " \n";
            if (AdamExcluBox.Text == "")
                AdamExcluBox.Text = " \n";

            if (SebPrefBox.Text == "")
                SebPrefBox.Text = " \n";
            if (SebExcluBox.Text == "")
	            SebExcluBox.Text = " \n";

            if (NathanPrefBox.Text == "")
                NathanPrefBox.Text = " \n";
            if (NathanExcluBox.Text == "")
                NathanExcluBox.Text = " \n";

            if (MattPrefBox.Text == "")
                MattPrefBox.Text = " \n";
            if (MattExcluBox.Text == "")
                MattExcluBox.Text = " \n";

            if (MeetingSelectCombo.Text == "1")
            {
                RoomDecision = MeetingRoomChoice(RoomChoice);
                string path1 = path + "\\Meeting1.txt";
                string[] fileLines = {Foundslot, RoomDecision, MeetingDateTxt.Text, MeetingSlotTxt.Text, ErrorTxt.Text, StatusTxt.Text, InitiatorTxt.Text,FromDateTxt.Text,
                ToDateTxt.Text, AdamPrefBox.Text, AdamExcluBox.Text, SebPrefBox.Text, SebExcluBox.Text, NathanPrefBox.Text, NathanExcluBox.Text, MattPrefBox.Text,
                MattExcluBox.Text, AdamResult.Text, SebResult.Text,NathanResult.Text, MattResult.Text, ImportCombo1.Text, ImportCombo2.Text, ImportCombo3.Text, ImportCombo4.Text,
                SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text, ChoiceBox1.Text, ChoiceBox2.Text, ChoiceBox3.Text,
                ChoiceBox4.Text,""};
                System.IO.File.WriteAllLines(path1, fileLines);

            }
            else if (MeetingSelectCombo.Text == "2")
            {
                RoomDecision = MeetingRoomChoice(RoomChoice);
                string path2 = path + "\\Meeting2.txt";
                string[] fileLines = {Foundslot, RoomDecision, MeetingDateTxt.Text, MeetingSlotTxt.Text, ErrorTxt.Text, StatusTxt.Text, InitiatorTxt.Text,FromDateTxt.Text,
                ToDateTxt.Text, AdamPrefBox.Text, AdamExcluBox.Text, SebPrefBox.Text, SebExcluBox.Text, NathanPrefBox.Text, NathanExcluBox.Text, MattPrefBox.Text,
                MattExcluBox.Text, AdamResult.Text, SebResult.Text,NathanResult.Text, MattResult.Text, ImportCombo1.Text, ImportCombo2.Text, ImportCombo3.Text, ImportCombo4.Text,
                SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text, ChoiceBox1.Text, ChoiceBox2.Text, ChoiceBox3.Text,
                ChoiceBox4.Text, ""};
                System.IO.File.WriteAllLines(path2, fileLines);
            }
            else if (MeetingSelectCombo.Text == "3")
            {
                RoomDecision = MeetingRoomChoice(RoomChoice);
                string path3 = path + "\\Meeting3.txt";
                string[] fileLines = {Foundslot, RoomDecision, MeetingDateTxt.Text, MeetingSlotTxt.Text, ErrorTxt.Text, StatusTxt.Text, InitiatorTxt.Text,FromDateTxt.Text,
                ToDateTxt.Text, AdamPrefBox.Text, AdamExcluBox.Text, SebPrefBox.Text, SebExcluBox.Text, NathanPrefBox.Text, NathanExcluBox.Text, MattPrefBox.Text,
                MattExcluBox.Text, AdamResult.Text, SebResult.Text,NathanResult.Text, MattResult.Text, ImportCombo1.Text, ImportCombo2.Text, ImportCombo3.Text, ImportCombo4.Text,
                SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text, ChoiceBox1.Text, ChoiceBox2.Text, ChoiceBox3.Text,
                ChoiceBox4.Text, ""};
                System.IO.File.WriteAllLines(path3, fileLines);
            }
            else if (MeetingSelectCombo.Text == "4")
            {
                RoomDecision = MeetingRoomChoice(RoomChoice);
                string path4 = path + "\\Meeting4.txt";
                string[] fileLines = {Foundslot, RoomDecision, MeetingDateTxt.Text, MeetingSlotTxt.Text, ErrorTxt.Text, StatusTxt.Text, InitiatorTxt.Text,FromDateTxt.Text,
                ToDateTxt.Text, AdamPrefBox.Text, AdamExcluBox.Text, SebPrefBox.Text, SebExcluBox.Text, NathanPrefBox.Text, NathanExcluBox.Text, MattPrefBox.Text,
                MattExcluBox.Text, AdamResult.Text, SebResult.Text,NathanResult.Text, MattResult.Text, ImportCombo1.Text, ImportCombo2.Text, ImportCombo3.Text, ImportCombo4.Text,
                SpecialEquip1.Text, SpecialEquip2.Text, SpecialEquip3.Text, SpecialEquip4.Text, ChoiceBox1.Text, ChoiceBox2.Text, ChoiceBox3.Text,
                ChoiceBox4.Text, ""};
                System.IO.File.WriteAllLines(path4, fileLines);
            }
        }
    }
}
