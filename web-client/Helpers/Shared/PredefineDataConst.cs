namespace web_client.Helpers.Shared;

public class PredefineDataConst
{
    public class BaseStatus
    {
        public const string Group = "STATUS";
        public class Key
        {
            public const string Active = "active";
            public const string Disable = "disable";
        }
    }
    public class Status : BaseStatus { }

    public class SystemStatus
    {
        public const string Group = "SYSTEM-STATUS";
        public class Key : BaseStatus.Key
        {
            public const string Delete = "delete";
        }
    }
}
