using SQLite;
using TopCandidates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopCandidates.Models
{
    [Table("tabexperiences")]
    public class Experience
    {
        public string candidateId {get; set; }
        public string Candidate { get; set; }
        public string technologyId { get; set; }
        public string Technology { get; set; }
        public int yearsOfExperience { get; set; }
    }

}
