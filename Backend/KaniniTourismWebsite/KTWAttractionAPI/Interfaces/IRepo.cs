namespace KTWAttractionAPI.Interfaces
{
    public interface IRepo <T,K> : IBaseRepo<T,K>
    {
        public Task<T?> Get(K id);
        public Task<T?> Update(T item);

    }

}
