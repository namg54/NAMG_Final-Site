#pragma checksum "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3db8e0f4142a32859b77a763c5ab56e530cd8aae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\_ViewImports.cshtml"
using NAMG_Final;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\_ViewImports.cshtml"
using NAMG_Final.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3db8e0f4142a32859b77a763c5ab56e530cd8aae", @"/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"602363e5772e2a5838d0ab6b867e68a8eee41dea", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
  
    ViewData["Title"] = "جزئیات محصول" + Model.Product.Name;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section id=""Home"" class=""about"">
    <div class=""container aos-init aos-animate"" data-aos=""fade-up"">
      
            <div class=""row"">

                <div class=""col-lg-6 order-1 order-lg-2 aos-init aos-animate"" data-aos=""fade-left"" data-aos-delay=""100"">
                    <img");
            BeginWriteAttribute("src", " src=\"", 389, "\"", 440, 1);
#nullable restore
#line 13 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
WriteAttributeValue("", 395, $"/Images/Products/{Model.Product.Id}.jpg", 395, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid img-thumbnail\"");
            BeginWriteAttribute("alt", " alt=\"", 473, "\"", 498, 1);
#nullable restore
#line 13 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
WriteAttributeValue("", 479, Model.Product.Name, 479, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n                <div style=\"text-overflow:clip\" class=\"col-lg-6 pt-4 pt-lg-0 order-2 order-lg-1 content aos-init aos-animate \" data-aos=\"fade-right\" data-aos-delay=\"100\">\r\n                    <h3 >");
#nullable restore
#line 16 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
                    Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <p style=\"text-align:justify\" class=\"order-1\">\r\n                        ");
#nullable restore
#line 18 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
                   Write(Model.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                    <p class=\"fst-italic order-2\">قیمت این محصول : ");
#nullable restore
#line 20 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
                                                              Write(Model.Product.Item.Price.ToString("##,###"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان </p>\r\n                    <ul>\r\n                        این محصول در دسته بندی های زیر قرار دارد: \r\n");
#nullable restore
#line 23 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
                         foreach (var item in Model.Categories)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ol type=\"i\">\r\n                        <li class=\"order-3\">");
#nullable restore
#line 26 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            </ol>\r\n");
#nullable restore
#line 28 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3db8e0f4142a32859b77a763c5ab56e530cd8aae7736", async() => {
                WriteLiteral("افزودن به سبد خرید");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-itemid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\NAMG\Desktop\See My Power\NAMG_Final\NAMG_Final\Views\Product\Details.cshtml"
                                                                                                     WriteLiteral(Model.Product.ItemId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["itemid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-itemid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["itemid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n     =\r\n    </div>\r\n</section>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591