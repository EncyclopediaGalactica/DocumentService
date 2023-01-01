namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using Interfaces;
using Interfaces.SourceFormatNode;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeDto> AddChildToParentAsync(
        SourceFormatNodeDto childDto,
        SourceFormatNodeDto parentDto,
        CancellationToken cancellationToken = default)
    {
        AddChildToParentAsyncInputValidation(childDto, parentDto);

        SourceFormatNode rootNode = await _sourceFormatNodeRepository.GetByIdWithRootNodeAsync(
                parentDto.Id,
                cancellationToken)
            .ConfigureAwait(false);
        SourceFormatNode resultNode = await _sourceFormatNodeRepository.AddChildNodeAsync(
                childDto.Id,
                parentDto.Id,
                rootNode.Id,
                cancellationToken)
            .ConfigureAwait(false);
        return _sourceFormatMappers.SourceFormatNodeMappers
            .MapSourceFormatNodeToSourceFormatNodeDtoInFlatFashion(resultNode);
    }

    private static void AddChildToParentAsyncInputValidation(
        SourceFormatNodeDto childDto, 
        SourceFormatNodeDto parentDto)
    {
        ArgumentNullException.ThrowIfNull(childDto);
        ArgumentNullException.ThrowIfNull(parentDto);
        if (childDto.Id == 0
            || parentDto.Id == 0
            || (parentDto.Id == childDto.Id))
        {
            throw new ArgumentException(
                "Error happened. " +
                $"{nameof(childDto)}.Id cannot be zero. " +
                $"{nameof(parentDto)}.Id cannot be zero. " +
                $"{nameof(parentDto)}.Id cannot be equal to {nameof(childDto)}.Id. " +
                $"Values: {nameof(parentDto)}.Id = {parentDto.Id}; {nameof(childDto)}.Id = {childDto.Id}");
        }
    }
}