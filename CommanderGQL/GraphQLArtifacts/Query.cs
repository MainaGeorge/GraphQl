using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQLArtifacts
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}
