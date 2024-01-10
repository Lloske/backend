using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.BLL._2._Models
{
    public class UserHumanRessourcesInformation
    {
        public int Id { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Birthplace { get; set; }
        public short? Birthland { get; set; }
        public short? Nationality { get; set; }
        public short? Gender { get; set; }
        public string? Address_street { get; set; }
        public string? Adress_postal_code { get; set; }
        public string? Adress_city { get; set; }
        public short? Adress_country { get; set; }
        public string? Iban { get; set; }
        public string? Bic { get; set; }
        public string? Social_security_number { get; set; }
        public string? User_note { get; set; }
    }
}
