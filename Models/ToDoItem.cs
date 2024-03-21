namespace Task2MVC.Models
{
    public class ToDoItem

    {
        public int Id { get; set; }
        public String? Title { get; set; }
        public String? Description { get; set; }
        public DateTime? Deadline { get; set; }

        public List<ToDoItem> Items { get; set; }

    }
}
