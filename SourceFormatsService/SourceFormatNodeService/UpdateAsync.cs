namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using FluentValidation;
using Interfaces;
using Interfaces.SourceFormatNode;
using ValidatorService;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeDto> UpdateSourceFormatNodeAsync(
        SourceFormatNodeDto? dto,
        CancellationToken cancellationToken = default)
    {
        await ValidateInputDataForUpdateAsync(dto).ConfigureAwait(false);
        SourceFormatNode updateTemplate = MapSourceFormatNodeDtoToSourceFormatNode(dto);
        SourceFormatNode updated = await _sourceFormatNodeRepository.UpdateAsync(updateTemplate, cancellationToken)
            .ConfigureAwait(false);
        // TODO: caching!
        return MapSourceFormatNodeToSourceFormatNodeDto(updated);
    }

    private async Task ValidateInputDataForUpdateAsync(SourceFormatNodeDto? inputDto)
    {
        ArgumentNullException.ThrowIfNull(inputDto);
        if (inputDto.Id == 0)
        {
            throw new ArgumentException($"{nameof(inputDto)}.Id cannot be zero.");
        }

        await _sourceFormatNodeDtoValidator.ValidateAsync(inputDto, options =>
        {
            options.IncludeRuleSets(SourceFormatNodeDtoValidator.Update);
            options.ThrowOnFailures();
        }).ConfigureAwait(false);
    }
}