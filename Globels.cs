using System.ComponentModel.DataAnnotations;

namespace Head_Chef
{
    public class Globals
    {
        [GroupDefinitions]
        public static class GroupNames
        {
            [Display(
                Name = "Metadata",
                Order = 10
            )]
            public const string MetaData = "Metadata";

            [Display(
                Name = "Specialized",
                Order = 20
            )]
            public const string Specialized = "Specialized";
        }
    }
}