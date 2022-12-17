using Workspace.Models;
namespace Workspace.Models
{
    public class History
    {
        public int Id { get; set; } // Код истории
        public string? Route { get; set; } // Маршрут
        public string? Employees { get; set; } // Сотрудник
        public string? Сontent { get; set; } // Документ название
        public string? Date_take { get; set; } // Дата получения 
        public string? Date_drop { get; set; } // Дата отправки
    }
}
