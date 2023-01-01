namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using Interfaces;
using Interfaces.SourceFormatNode;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeDto> GetByIdAsync(
        long id,
        CancellationToken cancellationToken = default)
    {
        if (id == 0)
        {
            throw new ArgumentException($"{nameof(id)} cannot be zero.");
        }
        SourceFormatNode result = await _sourceFormatNodeRepository.GetByIdWithRootNodeAsync(id, cancellationToken)
            .ConfigureAwait(false);
        return _sourceFormatMappers.SourceFormatNodeMappers
            .MapSourceFormatNodeToSourceFormatNodeDto(result);
    }
}