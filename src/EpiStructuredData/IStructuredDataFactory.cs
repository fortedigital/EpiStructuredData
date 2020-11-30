namespace EpiStructuredData
{
    public interface IStructuredDataFactory<T>
    {
        T GetStructuredData();
    }
}