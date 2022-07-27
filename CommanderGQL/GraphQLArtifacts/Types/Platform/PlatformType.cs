using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQLArtifacts.Types.Platform
{
    public class PlatformType : ObjectType<Models.Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Models.Platform> descriptor)
        {
            descriptor.Description("Represents any software or service with a command line interface");

            descriptor.Field(f => f.Name)
                .Description("The name of the service or software");

            descriptor.Field(f => f.LicenseKey)
                .Ignore();

            descriptor
                .Field(f => f.Commands)
                .ResolveWith<CommandResolver>(c => c.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("A list of all available commands that can run this platform");

        }

        private class CommandResolver
        {
            public IQueryable<Command> GetCommands([Parent] Models.Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(c => c.PlatformId == platform.Id);
            }
        }
    }
}
