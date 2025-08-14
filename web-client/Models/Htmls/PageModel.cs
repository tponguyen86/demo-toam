namespace web_client.Models.Htmls
{
    public class PageModel
    {
        //title of page <title>Title</title>
        public string Title { get; set; }
        //<meta name="description" content="Description"/>
        public string? Description { get; set; }
        //<meta name="keywords" content="Keywords" />
        public string? Keywords { get; set; }
        // <body class="BodyClassName" />
        public string? BodyClassName { get; set; }
        // <body class="BodyClassName" />
        public string? MainClassName { get; set; }

        public string PageKeyName { get; set; }
    }
}
