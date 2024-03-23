﻿using System.Text.Json.Serialization;
using SQLite;

namespace SomeDAO.Backend.Data
{
    public class Order : IOrderContent, IBlockchainEntity
    {
        // https://github.com/the-real-some-dao/a-careers-smc/blob/main/contracts/constants/constants.fc#L14
        public const int status_active = 1;

        [JsonIgnore]
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [NotNull, Indexed(Unique = true)]
        public long Index { get; set; }

        /// <summary>
        /// Smartcontract address - in bounceable form.
        /// </summary>
        [NotNull, Indexed(Unique = true)]
        public string Address { get; set; } = string.Empty;

        [Indexed]
        public int Status { get; set; }

        /// <summary>
        /// User wallet address - in non-bounceable form.
        /// </summary>
        [NotNull, Indexed]
        public string CustomerAddress { get; set; } = string.Empty;

        [Ignore]
        public User? Customer { get; set; }

        /// <summary>
        /// User wallet address - in non-bounceable form.
        /// </summary>
        [Indexed]
        public string? FreelancerAddress { get; set; }

        [Ignore]
        public User? Freelancer { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int ResponsesCount { get; set; }

        #region IOrderContent

        public string? Category { get; set; }

        public string? Language { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public string? Description { get; set; }

        public string? TechnicalTask { get; set; }

        #endregion

        #region IBlockchainEntity

        [JsonIgnore]
        public EntityType EntityType { get; } = EntityType.Order;

        [JsonIgnore]
        public long LastTxLt { get; set; }

        [JsonIgnore]
        public string? LastTxHash { get; set; }

        [JsonIgnore]
        public DateTimeOffset LastSync { get; set; }

        #endregion

        [JsonIgnore]
        public byte[]? NameHash { get; set; }

        [Ignore]
        public string? NameTranslated { get; set; }

        [JsonIgnore]
        public byte[]? DescriptionHash { get; set; }

        [Ignore]
        public string? DescriptionTranslated { get; set; }

        [JsonIgnore]
        public byte[]? TechnicalTaskHash { get; set; }

        [Ignore]
        public string? TechnicalTaskTranslated { get; set; }

        [JsonIgnore]
        public bool NeedTranslation { get; set; }

        [JsonIgnore]
        private string? textToSearch = null;

        [JsonIgnore]
        [Ignore]
        public string TextToSearch
        {
            get
            {
                textToSearch ??= Name?.ToUpperInvariant() + " " + Description?.ToUpperInvariant();
                return textToSearch;
            }
        }

        public Order ShallowCopy()
        {
            return (Order)MemberwiseClone();
        }
    }
}
