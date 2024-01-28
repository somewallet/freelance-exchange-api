﻿using SQLite;

namespace SomeDAO.Backend.Data
{
	public class User : IUserContent
	{
		[PrimaryKey]
		public long Index { get; set; }

		/// <summary>
		/// Smartcontract address - in bounceable form.
		/// </summary>
		[NotNull, Indexed(Unique = true)]
		public string Address { get; set; } = string.Empty;

		/// <summary>
		/// User wallet address - in non-bounceable form.
		/// </summary>
		[NotNull, Indexed]
		public string UserAddress { get; set; } = string.Empty;

		public DateTimeOffset? RevokedAt { get; set; }

		#region IUserContent

		public bool IsUser { get; set; }

		public bool IsFreelancer { get; set; }

		public string? Nickname { get; set; }

		public string? Telegram { get; set; }

		public string? About { get; set; }

		public string? Website { get; set; }

		public string? Portfolio { get; set; }

		public string? Resume { get; set; }

		public string? Specialization { get; set; }

		#endregion
	}
}
