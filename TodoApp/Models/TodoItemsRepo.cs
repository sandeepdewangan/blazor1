namespace TodoApp.Models
{
    public class TodoItemsRepo
    {
        private static List<TodoItem> items = new List<TodoItem>()
        {
            new TodoItem {Id = 1, Name = "Item 1"},
            new TodoItem {Id = 2, Name = "Item 2"},
            new TodoItem {Id = 3, Name = "Item 3"},
        };

        public static void AddItem(TodoItem item)
        {
            if (items.Count > 0)
            {
                var maxId = items.Max(s => s.Id);
                item.Id = maxId + 1;
                items.Add(item);
            }
            else
            {
                item.Id = 1;
                items.Add(item);
            }
        }

        public static List<TodoItem> GetItems()
        {
            var sorted = items.OrderBy(s => s.IsCompleted).ThenByDescending(i => i.Id).ToList();
            return sorted;
        }

        public static TodoItem? GetItemById(int Id)
        {
            TodoItem? item = items.FirstOrDefault(s => s.Id == Id);
            if (item != null)
            {
                return new TodoItem { Id = item.Id, Name = item.Name };
            }
            return null;
        }

        public static void UpdateItem(int itemId, TodoItem item)
        {
            if (itemId != item.Id) return;
            var itemToUpdate = items.FirstOrDefault(s => s.Id == itemId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
            }
        }

        public static void DeleteItem(int id)
        {
            var item = items.FirstOrDefault(s => s.Id == id);
            if (item != null)
            {
                items.Remove(item);
            }
        }
        public static List<TodoItem> SearchItems(string itemFilter)
        {
            return items.Where(s => s.Name.Contains(itemFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
