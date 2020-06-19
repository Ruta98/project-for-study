using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PresenceDTO
    {
        public int PresenceID { get; set; }
        public int UserID { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
