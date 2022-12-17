using Workspace.Models;

namespace Workspace.Models
{
    public class Document
    {
        public int Id { get; set; } // Код документа
        public string? Date { get; set; } // Дата
        public string? Content { get; set; } // Содержание
        public Status? Status { get; set; } // Текущий статус
        public string? Changes { get; set; } // Правки и изменения
        public DocumentType? Type { get; set; } // Тип документа


    }



 
}
