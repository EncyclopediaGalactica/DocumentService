namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Document;

using Dtos;
using Entities;

public partial class DocumentService
{
    /// <inheritdoc />
    public async Task<DocumentDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        if (id == 0)
        {
            throw new ArgumentException($"{nameof(id)} cannot be zero");
        }
        Document result = await _repository.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        DocumentDto dto = _mappers.DocumentMappers.MapDocumentToDocumentDto(result);
        return dto;
    }
}