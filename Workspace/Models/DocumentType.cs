
namespace Workspace.Models
{
    public class DocumentType
    {
        public int Id { get; set; } // Код типа
        public string? Name { get; set; } // Типы
        public List<Document> Documents { get; set; } = new();
    }
}
