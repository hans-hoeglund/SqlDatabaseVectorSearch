namespace SqlDatabaseVectorSearch.Models;

public record class VectorSearchResponse(string Question, string Answer, IEnumerable<Citation> Citations);

public record class Citation(Guid DocumentId, Guid ChunkId, string Content);
