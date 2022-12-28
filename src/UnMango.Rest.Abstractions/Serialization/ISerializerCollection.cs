namespace UnMango.Rest.Serialization;

public interface ISerializerCollection
{
    ISerializer Default { get; }
    
    ISerializer Get(SerializerKey key);
}
