#pragma checksum "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52781a91312ac29ce89709abfd9cc87c657ccdcb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Services), @"mvc.1.0.view", @"/Views/Home/Services.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Services.cshtml", typeof(AspNetCore.Views_Home_Services))]
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
#line 1 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\_ViewImports.cshtml"
using BlackSeaConstruction.Web;

#line default
#line hidden
#line 2 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
using static BlackSeaConstruction.Web.Extensions.Extensions.ImageExtensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52781a91312ac29ce89709abfd9cc87c657ccdcb", @"/Views/Home/Services.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4c790d88762dc81cd2c557d276583fc400d2759", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Services : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlackSeaConstruction.Web.Models.ServicesVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail shadow w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(130, 42, true);
            WriteLiteral("\r\n\r\n\r\n<div class=\"row\" id=\"service-tab\">\r\n");
            EndContext();
#line 7 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
     if (Model.Service == null)
    {

#line default
#line hidden
            BeginContext(212, 428, true);
            WriteLiteral(@"        <div class=""col-12 animated slideInLeft"">
            <p>
                <h1>Our services</h1>
            </p>
            <p>
                We are pleased to offer wide variety of services from structural wood framing or small renovation
                to a commercial building or multi-family being build.
                Be it small or big work, we could tackle it all.
            </p>
        </div>
");
            EndContext();
#line 19 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(664, 80, true);
            WriteLiteral("        <div class=\"col-12 animated slideInUp\">\r\n            <h1>Our services › ");
            EndContext();
            BeginContext(745, 25, false);
#line 23 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
                          Write(Model.Service.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(770, 23, true);
            WriteLiteral("</h1>\r\n            <h2>");
            EndContext();
            BeginContext(794, 25, false);
#line 24 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
           Write(Model.Service.ServiceType);

#line default
#line hidden
            EndContext();
            BeginContext(819, 40, true);
            WriteLiteral("</h2>\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(860, 25, false);
#line 26 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
           Write(Model.Service.Description);

#line default
#line hidden
            EndContext();
            BeginContext(885, 56, true);
            WriteLiteral("\r\n            </p>\r\n            <div class=\"row my-2\">\r\n");
            EndContext();
#line 29 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
                 foreach (var image in Model.Service.Images)
                {

#line default
#line hidden
            BeginContext(1022, 83, true);
            WriteLiteral("                    <div class=\"col-6 col-md-4 col-lg-3\">\r\n                        ");
            EndContext();
            BeginContext(1105, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "859c0c4c349546f19523f69ef62f4e3e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1115, "~/", 1115, 2, true);
#line 32 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
AddHtmlAttributeValue("", 1117, ServicesImage(image), 1117, 21, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1175, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
#line 34 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
                }

#line default
#line hidden
            BeginContext(1224, 36, true);
            WriteLiteral("            </div>\r\n        </div>\r\n");
            EndContext();
#line 37 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
    }

#line default
#line hidden
            BeginContext(1267, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 38 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
     foreach (var type in Model.Services)
    {

#line default
#line hidden
            BeginContext(1317, 120, true);
            WriteLiteral("        <div class=\"col-12 col-lg-6\">\r\n            <ul class=\"our-services\">\r\n                <li>\r\n                    ");
            EndContext();
            BeginContext(1438, 13, false);
#line 43 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
               Write(type.TypeName);

#line default
#line hidden
            EndContext();
            BeginContext(1451, 28, true);
            WriteLiteral("\r\n                    <ul>\r\n");
            EndContext();
#line 45 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
                         foreach (var service in type.Services)
                        {

#line default
#line hidden
            BeginContext(1571, 34, true);
            WriteLiteral("                            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1605, "\"", 1668, 1);
#line 47 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
WriteAttributeValue("", 1612, Url.Action("Services", "Home", new { id = service.Id }), 1612, 56, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1669, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1671, 19, false);
#line 47 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
                                                                                              Write(service.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(1690, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 48 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
                        }

#line default
#line hidden
            BeginContext(1728, 85, true);
            WriteLiteral("                    </ul>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n");
            EndContext();
#line 53 "D:\Projects\BlackSeaConstruction\BlackSeaConstruction.Web\Views\Home\Services.cshtml"
    }

#line default
#line hidden
            BeginContext(1820, 12, true);
            WriteLiteral("</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1849, 216, true);
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#link-our-services\').addClass(\'active\');\r\n            $(\'.our-services\').parent().addClass(\'animated slideInLeft\')\r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlackSeaConstruction.Web.Models.ServicesVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
