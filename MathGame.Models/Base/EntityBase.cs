using System.ComponentModel.DataAnnotations;

namespace LevelsDAL.Models.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
