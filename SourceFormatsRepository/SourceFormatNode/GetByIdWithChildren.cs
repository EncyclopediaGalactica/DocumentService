namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;
using Microsoft.EntityFrameworkCore;

public partial class SourceFormatNodeRepository
{
    /// <inheritdoc />
    public async Task<SourceFormatNode> GetByIdWithChildrenAsync(long id, CancellationToken cancellationToken = default)
    {
        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        if (id == 0)
            throw new ArgumentException($"{nameof(id)} cannot be zero.");

        SourceFormatNode result = await ctx.SourceFormatNodes
            .Include(i => i.ChildrenSourceFormatNodes)
            .FirstAsync(w => w.Id == id, cancellationToken)
            .ConfigureAwait(false);
        return result;
    }
}