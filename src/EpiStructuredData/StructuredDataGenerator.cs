namespace EpiStructuredData
{
    public abstract class StructuredDataGenerator<T, TStructuredData> : IStructuredDataGenerator
    {
        public object GetStructuredData(object input)
        {
            if (!(input is T data)) return null;
            return GetStructuredData(data);
        }

        protected abstract TStructuredData GetStructuredData(T input);
    }
}