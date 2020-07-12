using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;

namespace UnMango.Rest.Serialization
{
    internal class SerializerCollection : Collection<ISerializer>, ISerializerCollection
    {
        private static readonly Lazy<SerializerCollection> _instance = new Lazy<SerializerCollection>();

        public static SerializerCollection Instance => _instance.Value;

        public bool Contains(ContentType key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISerializer> this[ContentType key] => throw new NotImplementedException();
        
        IEnumerator<IGrouping<ContentType, ISerializer>> IEnumerable<IGrouping<ContentType, ISerializer>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
