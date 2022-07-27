using CommanderGQL.Data;

namespace CommanderGQL.GraphQLArtifacts.Types.Command
{
    public class CommandType : ObjectType<Models.Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Models.Command> descriptor)
        {
            descriptor.Description("This represents a command that you can run on a service or a platform");

            descriptor.Field(f => f.HowTo)
                .Description("A short description of what the command does");

            descriptor.Field(f => f.CommandLineSnippet)
                .Description("Represents how to run the command on the given platform");

            descriptor.Field(f => f.Platform)
                .ResolveWith<PlatformResolver>(p => p.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Represents the platform the command runs on");
        }

        private class PlatformResolver
        {
            public Models.Platform GetPlatform([Parent] Models.Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}
