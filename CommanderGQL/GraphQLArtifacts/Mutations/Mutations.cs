using CommanderGQL.Data;
using CommanderGQL.GraphQLArtifacts.Mutations.Command;
using CommanderGQL.GraphQLArtifacts.Mutations.Platform;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQLArtifacts.Mutations
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [ScopedService] AppDbContext context)
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
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext context)
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


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePlatformPayload> DeletePlatformAsync(DeletePlatformInput input,
            [ScopedService] AppDbContext context)
        {
            var platform = context.Platforms.FirstOrDefault(p => p.Id == input.PlatformId);

            if (platform == null) return new DeletePlatformPayload(false);
            context.Remove(platform);
            return new DeletePlatformPayload(await context.SaveChangesAsync() > 0);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteCommandPayload> DeleteCommandAsync(DeleteCommandInput input,
            [ScopedService] AppDbContext context)
        {
            var command = context.Commands.FirstOrDefault(p => p.Id == input.CommandId);

            if (command == null) return new DeleteCommandPayload(false);
            context.Remove(command);
            return new DeleteCommandPayload(await context.SaveChangesAsync() > 0);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UpdateCommandPayload> UpdateCommandAsync(UpdateCommandInput input,
            [ScopedService] AppDbContext context)
        {
            var commandToUpdate = await context.Commands.FirstOrDefaultAsync(c => c.Id == input.CommandId);

            if (commandToUpdate is null) return new UpdateCommandPayload { UpdateSucceeded = false };

            commandToUpdate.CommandLineSnippet = input.CommandLineSnippet ?? commandToUpdate.CommandLineSnippet;
            commandToUpdate.HowTo = input.HowTo ?? commandToUpdate.HowTo;


            return new UpdateCommandPayload
            {
                UpdateSucceeded = await context.SaveChangesAsync() > 0
            };
        }
    }
}
