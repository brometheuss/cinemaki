#pragma checksum "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5e8a26d66810e68734769cee431e2dfe5b648a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
#line 1 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\_ViewImports.cshtml"
using WebMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\_ViewImports.cshtml"
using WebMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5e8a26d66810e68734769cee431e2dfe5b648a6", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5b3e85210568c19abe72d8bf552aecc7da3bc34", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.DataTransfer.MovieDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GenresInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 28 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
             foreach (var g in Model.GenresInfo)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
            Write("Id: ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                     Write(g.GenreId);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                                 Write(" - ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                                         Write(g.GenreName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                                                      Write(Html.Raw("<br>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                                                                            
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 34 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WritersInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 37 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
             foreach (var v in Model.WritersInfo)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
           Write(v.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                   Write(Html.Raw("<br>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                                         
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LengthMinutes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.LengthMinutes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Plot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.Plot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 61 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BoxOffice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 64 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.BoxOffice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 67 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DebutDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 70 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Model.DebutDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 73 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 76 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Model.EndDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 79 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Is3D));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 82 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.Is3D));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 85 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CountryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 88 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.CountryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 91 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LanguagesInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 94 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
             foreach (var l in Model.LanguagesInfo)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
           Write(l.LanguageName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                           Write(Html.Raw("<br>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
                                                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 100 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductionName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 103 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductionName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 106 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RatedName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 109 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
       Write(Html.DisplayFor(model => model.RatedName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 114 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Movies\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5e8a26d66810e68734769cee431e2dfe5b648a615914", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.DataTransfer.MovieDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
