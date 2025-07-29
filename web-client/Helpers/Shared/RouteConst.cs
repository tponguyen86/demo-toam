namespace web_client.Helpers.Shared
{
    public class RouteConst
    {
        public const string Group = "ROUTE";
        public const string Home = "home";
        public const string Login = "login";
        public const string Logout = "logout";
        public const string Register = "register";
        public const string ResetPassword = "reset-password";
        public const string ChangePassword = "change-password";
        public const string Product = "product";
        public const string ProductDetail = "product-detail";
        public const string ProductCategory = "product-category";
        public const string UserProfile = "user-profile";
        public const string UserProfileEdit = "user-profile-edit";
        public const string NotFound = "not-found";
        public const string Service = "service";
        public const string ServiceDetail = "service-detail";
        public const string News = "news";
        public const string NewsDetail = "news-detail";

        public static string GetRoute(string routeName)
        {
            var href = routeName switch
            {
                Home => "/",
                Login => "/login",
                Logout => "/logout",
                Register => "/register",
                ResetPassword => "/reset-password",
                ChangePassword => "/change-password",
                UserProfile => "/user/profile",
                UserProfileEdit => "/user/profile/edit",
                NotFound => "/not-found",
                Product => "/san-pham",
                ProductDetail => "/san-pham/{0}/chi-tiet",//page-key-name of product
                ProductCategory => "/san-pham/{0}",//page-key-name of category,
                Service => "/dich-vu",
                ServiceDetail => "/dich-vu/{0}/chi-tiet",//page-key-name of service
                News => "/tin-tuc",
                NewsDetail => "/tin-tuc/{0}/chi-tiet",//page-key-name of service
                _ => throw new ArgumentException($"Unknown route name: {routeName}")
            };

            return href;
        }
    }
}
