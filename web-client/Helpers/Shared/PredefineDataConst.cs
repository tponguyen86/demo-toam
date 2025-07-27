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
    
    public class CategoryDiscriminator
    {
        public const string Group = "Discriminator";
        public class Key
        {
            public const string Category = "Category";
            public const string ProductCategory = "ProductCategory";
        }
    }
    public class CategoryParentId
    {
        public const string Group = "CategoryParentId";
        public class Key
        {
            public const string News = "6cd4cf5d-d265-41cf-ba35-f2bd6c6d48d3";
            public const string Service = "a245a6e7-c072-4123-b57d-22edadeb657e";
        }
    }
}
