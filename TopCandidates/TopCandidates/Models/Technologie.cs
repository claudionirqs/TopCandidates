using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopCandidates.Models
{
    [Table("tabtechnologies")]
    public class Technologie
    {
        [PrimaryKey, Column("guid")]
        public string guid { get; set; }
        public string name { get; set; }
        [Ignore]
        public string img {
            get
            {
                if (name == "C#")
                {
                    return "ccharp.png";
                }
                if (name == "C++")
                {
                    return "cplus.png";
                }
                if (name == "Java")
                {
                    return "java.png";
                }
                if (name == "JavaScript")
                {
                    return "javascript.png";
                }
                if (name == "Python")
                {
                    return "python.png";
                }
                if (name == "Kotlin")
                {
                    return "kotlin.png";
                }
                if (name == "Swift")
                {
                    return "swift.png";
                }
                if (name == "SQL")
                {
                    return "sql.png";
                }
                else
                {
                    return "question.png";
                }
            }
        }
    }
}
