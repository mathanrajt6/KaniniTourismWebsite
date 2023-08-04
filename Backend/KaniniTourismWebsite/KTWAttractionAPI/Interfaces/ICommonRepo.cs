namespace KTWAttractionAPI.Interfaces
{
    public interface ICommonRepo<T,K>
    { 
        public Task<ICollection<T>?> GetAll();
    }
}
