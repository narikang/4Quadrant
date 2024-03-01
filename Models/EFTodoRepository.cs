
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
    }
}
