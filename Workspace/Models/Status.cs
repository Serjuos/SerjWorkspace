using Workspace.Models;

namespace Workspace.Models
{
    public class Status
    {
            public int Id { get; set; } // Код статуса
            public string? Name { get; set; } // Статусы
            public List<Document> Documents { get; set; } = new();
        
    }
}
