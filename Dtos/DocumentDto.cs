namespace EncyclopediaGalactica.SourceFormats.Dtos;

/// <summary>
/// 
/// </summary>
public class DocumentDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Uri? Uri { get; set; }
}