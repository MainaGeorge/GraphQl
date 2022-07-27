using CommanderGQL.Data;

namespace CommanderGQL.GraphQLArtifacts.Mutations.Platform
{
    public class PlatformMutations
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
    }
}
