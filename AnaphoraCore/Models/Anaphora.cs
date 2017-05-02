using System.Collections.Generic;

namespace AnaphoraCore.Models
{
    public class Anaphora
    {
        public List<string> ProperNouns { get; set; }
        public List<string> PluralCommonNouns { get; set; }
        public List<string> SingularCommonNouns { get; set; }
        public List<string> PersonalPronouns { get; set; }
        public List<string> PossessivePronouns { get; set; }
        public List<string> OtherNameSets { get; set; }
        public string Sentence { get; set; }
        public string Analysis { get; set; }
    }
}
