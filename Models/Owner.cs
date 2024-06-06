using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<CarModel> BoughtModels { get; set; }

        public Owner()
        {
            this.BoughtModels = new HashSet<CarModel>();
        }
    }
}
