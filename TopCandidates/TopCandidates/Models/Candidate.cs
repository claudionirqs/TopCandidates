using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopCandidates.Models
{
    [Table("tabcandidates")]
    class Candidate
    {
        [PrimaryKey, Column("candidateId")]
        public string candidateId { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int gender { get; set; }
        public string profilePicture { get; set; }
        public string email { get; set; }
        public string favoriteMusicGenre { get; set; }
        public string dad { get; set; }
        public string mom { get; set; }
        public bool canSwim { get; set; }
        public string barcode { get; set; }
        public int status { get; set; }
        
    }
}
