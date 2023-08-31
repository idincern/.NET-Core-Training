using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace mvc_tutorial1.Extensions
{
    static public class Extensions
    {
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string value, object htmlAttributes) // html helper => kod maliyeti fazla, bunun yerine TagHelper kullanabilirsin.
        =>
            htmlHelper.TextBox(name, value, new
            {
                style="background-color:green; color:white; font-weight:bold;",
                @class= "form-input",
                a="a",
                b="b",
                placeholder="Test Custom PlaceHolder"
            });
    }
}
