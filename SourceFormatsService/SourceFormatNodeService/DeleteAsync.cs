namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Interfaces;
using Interfaces.SourceFormatNode;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task DeleteAsync(
        SourceFormatNodeDto dto,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(dto);
        if (dto.Id == 0)
        {
            throw new ArgumentException($"{nameof(dto)}.Id cannot be zero.");
        }

        await _sourceFormatNodeRepository.DeleteAsync(dto.Id, cancellationToken).ConfigureAwait(false);
    }
}