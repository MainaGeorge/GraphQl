using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Represents any software or service with a command line interface")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }    
        
        [Required]
        [MaxLength(20)]
        [GraphQLDescription("Represents the name of the service or software")]
        public string Name { get; set; }

        [GraphQLDescription("Represents a purchased license for the platform")]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
