namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;

public partial class SourceFormatNodeRepository
{
    /// <inheritdoc />
    public async Task<SourceFormatNode> GetByIdAsync(long id)
    {
        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        if (id == 0)
            throw new ArgumentException($"{nameof(id)} cannot be zero.");

        SourceFormatNode? result = await ctx.SourceFormatNodes.FindAsync(id).ConfigureAwait(false);

        if (result is null)
            throw new InvalidOperationException(
                $"No {nameof(SourceFormatNode)} entity with id: {id}");

        return result;
    }
}