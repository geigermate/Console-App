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
    public class CarBrand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<CarModel>? CarModels { get; set; }

        [ForeignKey(nameof(CarModels))]
        public int CarModelId { get; set; }
    }
}
