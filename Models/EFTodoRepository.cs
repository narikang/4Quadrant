using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _4Quantrant.Models
{
    public class EFTodoRepository : ITodoRepository
    {
        private TodoqContext _context;
        public EFTodoRepository(TodoqContext temp)
        {
           _context = temp;
        }
        public List<Item> Items => _context.Items.ToList();
        public List<Category> Categories => _context.Categories.ToList();
        public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        public void Update(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
        public void Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
        public Item GetItemById(int itemId)
        {
            return _context.Items.Include(t => t.Category).FirstOrDefault(t => t.ItemId == itemId);
        }

    }
}
