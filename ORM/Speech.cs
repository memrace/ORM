using System;

namespace ORM.DOMAIN
{
	public class Speech
	{
		public string Theme { get; }

		public string Description { get; }

		public UserProfile Creator { get; }
#nullable enable
		public UserProfile Executor { get; }

		public DateTime CreateTime { get; }
		public DateTime EndTime { get; }

		public Speech(string theme, string description, UserProfile creator, UserProfile? executor, DateTime createTime,
			DateTime? endTime)
		{
			Theme = theme;
			Description = description;
			Creator = creator;
			if (executor != null) Executor = executor;

			CreateTime = createTime;
			EndTime = endTime.Value;
		}
	}
}