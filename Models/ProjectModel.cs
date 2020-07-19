using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PortfolioWebsite.Models
{
    public class ProjectModel
    {
        public string FileName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string[] MadeWith { get; set; }

        public string SourceLink { get; set; }

        public string ReleaseLink { get; set; }

        public string Asset { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
