namespace Catalog.API.Utils.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |  System.AttributeTargets.Struct)]  
    public class CollectionName : Attribute
    {
        public string Name { get; private set; }

        public CollectionName(string name)
        {
            Name = name;
        }
    }
}