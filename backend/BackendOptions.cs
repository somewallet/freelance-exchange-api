﻿namespace SomeDAO.Backend
{
    public class BackendOptions
    {
        public string MasterAddress { get; set; } = string.Empty;

        public string DatabaseFile { get; set; } = "./backend.sqlite";

        public string CacheDirectory { get; set; } = "./cache";

        public TimeSpan SearchCacheForceReloadInterval { get; set; } = TimeSpan.FromMinutes(5);

        public TimeSpan MasterResyncInterval { get; set; } = TimeSpan.FromSeconds(10);

        public TimeSpan AdminForceResyncInterval { get; set; } = TimeSpan.FromDays(1);

        public TimeSpan UserForceResyncInterval { get; set; } = TimeSpan.FromDays(1);

        public TimeSpan OrderForceResyncInterval { get; set; } = TimeSpan.FromDays(1);

        public Dictionary<string, string> Categories { get; set; } = new();

        public Dictionary<string, string> Languages { get; set; } = new();
    }
}
