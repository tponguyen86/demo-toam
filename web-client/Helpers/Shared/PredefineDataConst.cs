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

            public const string SidebarAboutus = "sidebar-about-us";
        }
    }
    public class PageId
    {
        public const string Group = "PAGEID";
        public class Key
        {
            public const string GioiThieu = "4c1a4535-9d20-4cc3-ba41-a8070365b754";
            public const string VeChungToi = "4f52660b-dd9f-4b99-bd46-ca6b725f5bbf";
            public const string LienHe = "5347e10c-de61-49e5-b384-5c59260ae83e";
            public const string TrangChu = "874ac0cc-5760-444b-b924-4d8282b1006c";
            public const string ChinhSach = "892bf10b-4eaa-4a9d-b88b-cd2b17c3f3ea";
            public const string DieuKhoan = "924c3ba5-a90f-4dbd-aff9-57cfcb75f931";
            public const string TuyenDung = "e0ba6136-1f8e-49a0-a2de-8652392fd346";
        }
    }
    public class PageConfigurationName
    {
        public const string Group = "PageConfigurationName";
        public class Key
        {
            public const string CarouselSlider = "carousel-slider";

        }
    }
}
