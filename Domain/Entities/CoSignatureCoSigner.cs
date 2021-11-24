using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CoSignatureCoSigner
    {
		public User Member { get; set; }
		public User Deputy { get; set; }
		public string TeamRole { get; set; }
		public string RoleComment { get; set; }
		public DateTime? CoSignerDate { get; set; }
		public string CoSignerResult { get; set; }
		public User CoSignedBy { get; set; }
		public string Remark { get; set; }

		public int OmItemNumber { get; set; }
		public int VersionNumber { get; set; }
		public int CoSignatureId { get; set; }
	}
}
