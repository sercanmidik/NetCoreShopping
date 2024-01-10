using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Comment
	{
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime Date { get; set; }
        public string CommentDetail { get; set; }

    }
}
