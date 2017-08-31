using StudentApi.Core;

namespace StudentApi.Models
{
    public class BaseEntity : IEntityBase
    {
        public int Id { get; set; }
    }
}