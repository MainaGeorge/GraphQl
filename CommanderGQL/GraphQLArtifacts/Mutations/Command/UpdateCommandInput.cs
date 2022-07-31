namespace CommanderGQL.GraphQLArtifacts.Mutations.Command
{
    public class UpdateCommandInput
    {
        public string HowTo { get; set; }
        public string CommandLineSnippet { get; set; }
        public int CommandId { get; set; }
    }
}
