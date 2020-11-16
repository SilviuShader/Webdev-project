using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crowd_knowledge_contribution.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}