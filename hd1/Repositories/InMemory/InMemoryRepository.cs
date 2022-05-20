using System.Text.Json;
using System.Text.Json.Serialization;

namespace hd1.Repositories.InMemory;

public abstract class InMemoryRepository<TId, TModel> : IInMemoryRepository<TId, TModel>
    where TId: notnull
    where TModel: class
{
    private readonly Dictionary<TId, TModel> _data = new();

    protected static TModel[] ReadSampleItems(byte[] content)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        return JsonSerializer.Deserialize<TModel[]>(ReadResourceFile(content), options) ?? Array.Empty<TModel>();
    }

    private static string ReadResourceFile(byte[] content)
    {
        var reader = new StreamReader(new MemoryStream(content));
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        return reader.ReadToEnd();
    }

    protected void Add(TId id, TModel model) => _data.Add(id, model);

    public TModel? GetById(TId id)
    {
        return _data.TryGetValue(id, out var model) switch
        {
            true => model,
            _ => null
        };
    }
    
    public IEnumerable<TModel> Filter(Func<TModel, bool> predicate) => _data.Values.Where(predicate);
}
