using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Join2AD
{
    class Hostname
    {
        private string lname;
        private string fname;
        private string room;
        private int directorate;
        private int location;
        private int type;
        private string name;

        public Hostname()
        {
            this.lname = String.Empty;
            this.fname = String.Empty;
            this.room = String.Empty;
            this.directorate = -1;
            this.location = -1;
            this.type = -1;
        }

        public Hostname(string fname, string lname, string room, int type, int directorate, int location)
        {
            this.fname = fname;
            this.lname = lname;
            this.room = room;
            this.type = type;
            this.directorate = directorate;
            this.location = location;
        }

        public void SetAll(string fname, string lname, string room, int type, int directorate, int location)
        {
            this.fname = fname;
            this.lname = lname;
            this.room = room;
            this.type = type;
            this.directorate = directorate;
            this.location = location;
        }

        public string Name
        {
            get { return name; }
        }
        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }

        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        public string Room
        {
            get { return room; }
            set { room = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Directorate
        {
            get { return directorate; }
            set { directorate = value; }
        }

        public int Location
        {
            get { return location; }
            set { location = value; }
        }

        private string convertFirstName() {
            if (isValidFirstName())
            {
                return this.fname.Substring(0, 1);
            }
            return String.Empty;
        }

        private string convertLastName()
        {
            string r = String.Empty;
            if (isValidLastName())
            {
                int max = 6;
                int idx = 0;
                
                foreach (char l in this.lname) {
                    if (idx > max) {
                        break;
                    }
                    idx++;
                    r += l;
                }

                while (idx <= max) {
                    r += '-';
                    idx++;
                }
            }
            return r;
        }

        private string convertRoom()
        {
            if (isValidRoom()) {
              
                switch (this.room.Length) {
                    case 1:
                        return "00" + room;
                    case 2:
                        return "0" + room;
                    default:
                        return room;
                }
            }
            return "000";
        }

        private bool isValidFirstName() {
            Regex r = new Regex("^[a-zA-Z0-9-_]*$");
            if (this.fname.Length > 0 && r.IsMatch(this.fname)) {
                return true;
            }
            return false;
        }

        private bool isValidLastName() {
            Regex r = new Regex("^[a-zA-Z0-9-_]*$");
            if (this.lname.Length > 2 && r.IsMatch(this.lname))
            {
                return true;
            }
            return false;
        }

        private bool isValidRoom()
        {
            Regex r = new Regex("^[0-9]*$");
            if (this.room.Length > 0 && this.room.Length < 4 &&  r.IsMatch(this.room))
            {
                return true;
            }
            return false;
        }

        private bool isValidType()
        {
            Regex r = new Regex("^[PLTAV]*$");
            if (this.type != -1)
            {
                return true;
            }
            return false;
        }

        private bool isValidLocation() 
        {
            if (this.location != -1)
            {
                return true;
            }
            return false;
        }

        private bool isValidLength() 
        {
            if (this.name.Length != 15) {
                return false;
            }
            return true;
        }
        private string getLocationName() 
        {
            return Data.locations[location.ToString()];
        }

        private string getDirectorateName()
        {
            return Data.dictorates[directorate.ToString()];
        }

        private string geTypeName()
        {
            return Data.types[type.ToString()];
        }

        private bool isValidDirectorate()
        {
            if (this.directorate != -1)
            {
                return true;
            }
            return false;
        }

        private bool emptyString(string txt) {
            if (String.IsNullOrEmpty(txt)) {
                return true;
            }
            return false;
        }

        private List<string> hasEmpty()
        {
            List<string> msg = new List<string>();

            if (emptyString(this.fname)) { msg.Add("Полето за име е празно."); }
            if (emptyString(this.lname)) { msg.Add("Полето за фамилия е празно."); }
            if (emptyString(this.room)) { msg.Add("Полето за стая е празно."); }

            return msg;
        }

        private List<string> hasError() {

            List<string> msg = new List<string>();

            if (!isValidDirectorate()) { msg.Add("Проверете каква дирекция сте избрали. Тя трябва да е от падащото меню."); }
            if (!isValidLocation()) { msg.Add("Проверете каква локация сте избрали. Тя трябва да е от падащато меню."); }
            if (!isValidType()) { msg.Add("Проверете какъв вид устройство сте избрали."); }
            if (!isValidRoom()) { msg.Add("Проверете каква инфорамация сте въвели за стая. Трябва да съдържа максимум три цифри и да няма букви или специални символи."); }
            if (!isValidLastName()) { msg.Add("Проверете дължината за фамилия, тя трябва да е минимум 3 символа и да са изписани на латиница. Фамилията може да съдържа невалидни символи."); }
            if (!isValidFirstName()) { msg.Add("Проверете дължината на името, то трябва да е минимум 1 символ и да е изписано на латиница. Името може да съдържа невалидни символи."); }

            return msg;
        }

        private List<string> finalCheck()
        {

            List<string> msg = new List<string>();

            if (!isValidLength()) { msg.Add("Дължината на името не е равна на 15 символа!"); }

            return msg;
        }

        public List<string> GenerateHostname() {
            
            List<string> empty = this.hasEmpty();
            if (empty.Count() != 0) {
                return empty;            
            }

            List<string> error = this.hasError();
            if (error.Count() != 0) {
                return error;
            }

            Program.OU = Data.List2OU()[this.directorate];

            this.name = String.Format("{0}{1}{2}{3}{4}{5}",
                convertFirstName(),
                convertLastName(),
                convertRoom(),
                Data.List2Type()[this.type],
                (this.directorate + 1).ToString("0#"),
                Data.List2Location()[this.location]);

            List<string> final = this.finalCheck();
            if (final.Count() != 0) {
                return final;
            }
            
            return new List<string>();
        }
    }
}
