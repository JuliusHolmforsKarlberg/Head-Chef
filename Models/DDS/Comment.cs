using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace Models.DDS
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class Comment : IDynamicData
    {
        public Identity Id { get; set; }
        public int PageId { get; set; }
        public string Text { get; set; }

    }
}
