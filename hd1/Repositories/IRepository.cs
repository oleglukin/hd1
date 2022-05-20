namespace hd1.Repositories;

public interface IRepository<TId, TModel>
{
    /// <summary>
    /// Find model object by its id
    /// </summary>
    public TModel? GetById(TId id);

    /// <summary>
    /// Find all model objects by some filtering / predicate function
    /// </summary>
    public IEnumerable<TModel> Filter(Func<TModel, bool> predicate);
}
