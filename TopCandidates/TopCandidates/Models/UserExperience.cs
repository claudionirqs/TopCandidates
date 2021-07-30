using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopCandidates.Models
{
    
    public class UserExperience
    {
        public string candidateId { get; set; }
        public string technologyId { get; set; }
        public int yearsOfExperience { get; set; }
    }
}
