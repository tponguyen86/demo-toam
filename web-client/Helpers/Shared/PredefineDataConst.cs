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
    
    public class SystemConfigurationKeys
    {
        public const string Group = "LAYOUT-KEY-WEB";
        public class Key
        {
            public const string ScriptSystem = "script-system";
            public const string Geo = "geo";
            public const string Tiktok = "tiktok";
            public const string Robot = "robot";
            public const string Sitemap = "sitemap";

            public const string Slogan = "slogan";
            public const string Slogan2 = "slogan-2";
            public const string PhoneNumber = "phone-number";

            public const string FooterDescription = "footer-description";
            public const string Company = "company";
            public const string Address = "address";

            public const string Email = "email";
            public const string EmailFooter = "email-footer";
            public const string PhoneNumberFooter = "phone-number-footer";

            public const string Facebook = "facebook";
            public const string Instagram = "instagram";
            public const string Twitter = "twitter";
        }
    }
}
