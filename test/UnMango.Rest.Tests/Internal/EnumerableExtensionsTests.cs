using System.Collections.Generic;
using UnMango.Rest.Internal;
using Xunit;

namespace UnMango.Rest.Tests.Internal
{
    [Trait("Category", "Unit")]
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void ToDictionary_CreatesNewDictionary()
        {
            const string key = "bleh", value = "blah";
            
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(key, value)
            };

            var dictionary = pairs.ToDictionary();
            
            Assert.IsType<Dictionary<string, string>>(dictionary);
            Assert.Contains(
                dictionary,
                x => x.Key == key && x.Value == value);
        }
    }
}
