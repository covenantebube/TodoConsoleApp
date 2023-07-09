using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Console_App
{
    public class TodoRepository
    {
        public void AddTodoItem(TodoItem item)
        {
            using (var context = new TodoContext())
            {
                context.TodoItems.Add(item);
                context.SaveChanges();
            }
        }

        public void UpdateTodoItem(TodoItem item)
        {
            using (var context = new TodoContext())
            {
                context.TodoItems.Update(item);
                context.SaveChanges();
            }
        }

        public void DeleteTodoItem(int id)
        {
            using (var context = new TodoContext())
            {
                var item = context.TodoItems.Find(id);
                if (item != null)
                {
                    context.TodoItems.Remove(item);
                    context.SaveChanges();
                }
            }
        }

        public List<TodoItem> SearchTodoItems(DateTime? date, string keyword)
        {
            using (var context = new TodoContext())
            {
                 
                var query = context.TodoItems.AsQueryable().AsEnumerable();

                if (date.HasValue)
                {
                    query = query.Where(item => item.DueDate.Date == date.Value.Date);
                }

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(item =>
                        item.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        item.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                }

                return query.ToList();
            }
        }
    }

}
