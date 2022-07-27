using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.GraphQLArtifacts.Mutations.Platform
{
    public class AddPlatformInput
    {
        [Required]
        public string Name { get; set; }

        public string LicenseKey { get; set; }
    }
}
