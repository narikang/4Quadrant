namespace _4Quantrant.Models
{
    public interface ITodoRepository
    {
        List<Item> Items{get; }
        List<Category> Categories { get; }
        public void Add(Item item);
        public void Update(Item item);
        public void Delete(Item item);
        Item GetItemById(int ItemId);


    }
}
