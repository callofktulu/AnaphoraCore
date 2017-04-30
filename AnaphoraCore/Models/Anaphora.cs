using System.Collections.Generic;

namespace AnaphoraCore.Models
{
    public class Anaphora
    {
        public List<string> NounPhrases { get; set; }
        public List<string> PersonalPronouns { get; set; }
        public List<string> PossessivePronouns { get; set; }
        public List<string> OtherNameSets { get; set; }
    }
}
