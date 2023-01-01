namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using FluentValidation;
using Interfaces.SourceFormatNode;
using Mappers.Interfaces;
using Microsoft.Extensions.Logging;
using SourceFormatsRepository.Interfaces;

public partial class SourceFormatNodeService : ISourceFormatNodeService
{
    private const string SourceFormatNodesListKey = "SourceFormatNodesList";
    private readonly int _cacheExpiresInMinutes = 60;
    private readonly ILogger _logger;
    private readonly ISourceFormatMappers _sourceFormatMappers;
    private readonly IValidator<SourceFormatNodeDto> _sourceFormatNodeDtoValidator;
    private readonly ISourceFormatNodeRepository _sourceFormatNodeRepository;

    public SourceFormatNodeService(
        IValidator<SourceFormatNodeDto> sourceFormatNodeDtoValidator,
        ISourceFormatMappers sourceFormatMappers,
        ISourceFormatNodeRepository sourceFormatNodeRepository,
        ILogger<SourceFormatNodeService> logger)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatNodeDtoValidator);
        ArgumentNullException.ThrowIfNull(sourceFormatMappers);
        ArgumentNullException.ThrowIfNull(sourceFormatNodeRepository);
        ArgumentNullException.ThrowIfNull(logger);

        _sourceFormatNodeDtoValidator = sourceFormatNodeDtoValidator;
        _sourceFormatMappers = sourceFormatMappers;
        _sourceFormatNodeRepository = sourceFormatNodeRepository;
        _logger = logger;
    }

    public async Task<SourceFormatNodeDto> GetSourceFormatNodeByIdWithChildrenAsync(long id,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<SourceFormatNodeDto> GetSourceFormatNodeByIdWithNodeTreeAsync(long id,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<SourceFormatNode>> GetSourceFormatNodesAsync(
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}