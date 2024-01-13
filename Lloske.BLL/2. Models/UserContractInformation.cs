using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.BLL._2._Models
{
    public class UserContractInformation
    {
        public int Id { get; set; }
        public string? Contract_type { get; set; }
        public string? Employment_type { get; set; }
        public string? Job_title { get; set; }
        public DateTime? Organization_entry_date { get; set; }
        public DateTime? Contract_start { get; set; }
        public DateTime? Probation_end_date { get; set; }
        public DateTime? Contract_end { get; set; }
        public string? Status { get; set; }
        public string? Professional_category { get; set; }
        public DateTime? Last_medical_checkup_date { get; set; }
        public int FK_id_user_personnal_information { get; set; }
    }

    public enum Contract_type
    {
        CDD = 1,
        CDI = 2,
        Stage = 3,
        Flexi_Job = 4,
        Mise_à_disposition = 5,
        Remplacement = 6,
        Etudiant = 7,
        Extra = 8,
        Apprenti = 9,
        Temporaire = 10
    }
    public enum Employment_type
    {
        Temps_plein = 1,
        Temps_partiel = 2,
    }
    public enum Status
    {
        Cadre = 1,
        Non_cadre = 2,
        Ouvriers_et_employés = 3,
        Techniciens_et_agents_de_maitrise = 4,
    }
    public enum Professional_category
    {
        Personnel_de_fabrication = 1,
        Personnel_de_vente = 2,
        Personnel_de_services = 3,
        Personnel_d_encadrement = 4,
    }
}
