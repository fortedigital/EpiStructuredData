using System;

namespace EpiStructuredData.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class StructuredDataAttribute : Attribute
    {
        public readonly Type GeneratorType;

        public StructuredDataAttribute(Type generatorType)
        {
            GeneratorType = generatorType;
        }
    }
}