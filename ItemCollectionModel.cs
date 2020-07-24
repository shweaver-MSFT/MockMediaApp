using System.Collections.Generic;

namespace MockMediaApp
{
    public class ItemCollectionModel
    {
        public string Name { get; set; }
        public List<ItemModel> Items { get; set; }

        public ItemCollectionModel(string name = null, List<ItemModel> items = null)
        {
            Name = name;
            Items = items ?? new List<ItemModel>();
        }
    }
}
