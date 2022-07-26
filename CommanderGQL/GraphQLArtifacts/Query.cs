using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQLArtifacts
{
    public class Query
    {
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}
