namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Unit.Tests.SourceFormatNode;

using System;
using System.Diagnostics.CodeAnalysis;
using Ctx;
using EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ValidatorService;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SourceFormatNode_Should
{
    [Fact]
    public void Throw_WhenInjectedServicesAreNull()
    {
        Action action = () => { new SourceFormatNodeRepository(null!, null!); };

        action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Throw_WhenInjectedDbOptionsIsNull()
    {
        Action action = () =>
        {
            new SourceFormatNodeRepository(null!, new SourceFormatNodeValidator());
        };

        action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Throw_WhenInjectedValidatorIsNull()
    {
        DbContextOptions<SourceFormatsDbContext> options = new DbContextOptionsBuilder<SourceFormatsDbContext>()
            .Options;
        Action action = () => { new SourceFormatNodeRepository(options, null!); };

        action.Should().ThrowExactly<ArgumentNullException>();
    }

}