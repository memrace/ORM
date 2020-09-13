using System;

namespace ORM.DOMAIN
{
	public class UserProfile
	{
		public Guid Id { get; }

		public UserProfile(Guid id)
		{
			Id = id;
		}
	}
}