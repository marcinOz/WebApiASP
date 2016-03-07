using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoRepository : ITodoRepository
    {
        static ConcurrentDictionary<string, TodoItem> todos = new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem { Name = "Item1" });
        }

        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            todos[item.Key] = item;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            todos.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return todos.Values;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            //todos.TryGetValue(key, out item);
            todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            todos[item.Key] = item;
        }
    }
}
