namespace SqlDatabaseVectorSearch.Models;

public record class ChatResponse(string Answer, IEnumerable<Guid> Sources);
