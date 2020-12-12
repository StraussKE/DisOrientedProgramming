using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisOrientedProgramming.Models
{
	public class AppUser : IdentityUser
	{
		// User's First Name
		public string FirstName { get; set; }
		// User's Last Name
		public string LastName { get; set; }
		// When this account was created
		public DateTime CreatedAccount { get; set; }

		// AppUser Profile Image
		public Uri AppUserImage { get; set; }

		// option for user to have username displayed around site instead of first name and last name
		public bool HideName { get; set; }

		public string DisplayName()
		{
			if (HideName)
			{
				return this.UserName;
			}
			return (this.FirstName + " " + this.LastName);
		}
			// replace with forum list link
		// public virtual List<MeetingAppUser> AttendedMeetings { get; } = new List<MeetingAppUser>(); // one user may attend 0 to many meetings
	}
}
