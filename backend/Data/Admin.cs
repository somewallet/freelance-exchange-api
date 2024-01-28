﻿using SQLite;

namespace SomeDAO.Backend.Data
{
	public class Admin : IAdminContent
	{
		[PrimaryKey]
		public long Index { get; set; }

		/// <summary>
		/// Smartcontract address - in bounceable form.
		/// </summary>
		[NotNull, Indexed(Unique = true)]
		public string Address { get; set; } = string.Empty;

		/// <summary>
		/// Admin wallet address - in non-bounceable form.
		/// </summary>
		[NotNull, Indexed]
		public string AdminAddress { get; set; } = string.Empty;

		public DateTimeOffset? RevokedAt { get; set; }

		#region IAdminContent

		public string? Category { get; set; }

		public bool CanApproveUser { get; set; }

		public bool CanRevokeUser { get; set; }

		public string? Nickname { get; set; }

		public string? About { get; set; }

		public string? Website { get; set; }

		public string? Portfolio { get; set; }

		public string? Resume { get; set; }

		public string? Specialization { get; set; }

		#endregion
	}
}
