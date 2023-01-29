using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_sell_user.Domain.Entities.Base
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public DateTime CreateDdate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}