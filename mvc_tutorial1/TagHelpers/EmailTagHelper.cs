using Microsoft.AspNetCore.Razor.TagHelpers;

namespace mvc_tutorial1.TagHelpers
{
    [HtmlTargetElement("email")] // tag adı verilebilir
    public class EmailTagHelper : TagHelper //bunun taghelperi default olarak email isminde olur
    {
        public string Mail { get; set; }
        public string Display{ get; set; }

        // Process metodu override edilerek taghelperin çalışma mantığı değiştirilebilir.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; // <a> tagi oluşturulacak
            output.Attributes.SetAttribute("href", $"mailto:{Mail}");
            output.Content.SetContent(Display);
            //base.Process(context, output);
        }

    }
    //public class MailGonderFormTagHelper : TagHelper
    //{
    //    //bunun taghelperi mail-gonder-form isminde
    //}
}
