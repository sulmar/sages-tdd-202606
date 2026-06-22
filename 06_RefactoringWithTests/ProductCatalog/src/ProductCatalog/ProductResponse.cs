namespace ProductCatalog;

public record ProductResponse(
    int Id,
    string Name,
    int CacheHit);
