using web_client.Models.Base;

namespace web_client.Models.Htmls.Base
{
    public class BaseAttributeItemModel : BaseTitleModel
    {
        //key ex: size-type
        public string? Key { get; set; }
        //key ex: Size
        public string? Label { get; set; }
        //Is this attribute is featured, show on product list
        public bool? Featured { get; set; }
        //Title is value ex: 12px
        public BaseAttributeItemModel() { }
        public BaseAttributeItemModel(string label, string title) { Label = label; Title = title; }
        public BaseAttributeItemModel(string label, string title, string key) : this(label, title) { Key = key; }
    }
}
