using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.GraphQLArtifacts.Mutations.Command
{
    public class AddCommandInput
    {
        [Required]
        public string HowTo { get; set; }

        [Required]
        public string CommandLineSnippet { get; set; }

        [Required]
        public int PlatformId { get; set; } 
    }
}
