using CommanderGQL.Data;
using CommanderGQL.GraphQLArtifacts.Mutations.Command;
using CommanderGQL.GraphQLArtifacts.Mutations.Platform;

namespace CommanderGQL.GraphQLArtifacts.Mutations
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatform(AddPlatformInput input, [ScopedService] AppDbContext context)
        {
            var platform = new Models.Platform
            {
                Name = input.Name,
                LicenseKey = input?.LicenseKey
            };

            context.Add(platform);
            await context.SaveChangesAsync();

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommand(AddCommandInput input, [ScopedService] AppDbContext context)
        {
            var command = new Models.Command
            {
                HowTo = input.HowTo,
                PlatformId = input.PlatformId,
                CommandLineSnippet = input.CommandLineSnippet
            };

            context.Add(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}
