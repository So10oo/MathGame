using LevelsDAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace LevelsDAL.Models
{
    public partial class Level : EntityBase
    {
        [StringLength(50)]
        public string? Name { get; set; }

        public int Number { get; set; }

        [StringLength(50)]
        public string? Answer { get; set; }

        public string? XamlRiddle { get; set; }
    }
}
