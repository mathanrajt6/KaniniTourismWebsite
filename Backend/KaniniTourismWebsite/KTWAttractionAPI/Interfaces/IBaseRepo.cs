namespace KTWAttractionAPI.Interfaces
{
    public interface IBaseRepo<T,K> : ICommonRepo<T,K>
    {
        public Task<T?> Add(T item);
        public Task<T?> Delete(K id);
    }
}
