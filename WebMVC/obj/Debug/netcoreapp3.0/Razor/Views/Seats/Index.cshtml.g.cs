#pragma checksum "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68194dd28be0aff68aa85f1018eaab5707b04453"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seats_Index), @"mvc.1.0.view", @"/Views/Seats/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68194dd28be0aff68aa85f1018eaab5707b04453", @"/Views/Seats/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5b3e85210568c19abe72d8bf552aecc7da3bc34", @"/Views/_ViewImports.cshtml")]
    public class Views_Seats_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.Responses.PagedResponse<Application.DataTransfer.SeatRowDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PaginationPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
  
    ViewData["Title"] = "Seats";
    ViewData["Controller"] = "seats";
    ViewData["Action"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
 using(Html.BeginForm("Index", "Seats", FormMethod.Get))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <input type=""text"" name=""name"" id=""name"" class=""form-control col-sm-2"" placeholder=""Seat row letter""/>
        <input type=""text"" name=""number"" id=""number"" class=""form-control col-sm-2"" placeholder=""Seat number""/>
        <input type=""text"" name=""hallid"" id=""hallid"" class=""form-control col-sm-1 offset-sm-1"" placeholder=""Hall id""/>
        <input type=""text"" name=""hallname"" id=""hallname"" class=""form-control col-sm-2"" placeholder=""Hall name""/>
        <label for=""isbroken"" class=""form-control col-sm-1"">Is it broken ?</label>
        <input type=""checkbox"" name=""isbroken"" id=""isbroken"" class=""form-control col-sm-1""/>
    </div><br/>
    <button type=""submit"" class=""form-control btn btn-primary"">Search</button>
");
#nullable restore
#line 20 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68194dd28be0aff68aa85f1018eaab5707b044535398", async() => {
                WriteLiteral("Add new Seat");
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
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Number
            </th>
            <th>
                IsBroken
            </th>
            <th>
                HallId
            </th>
            <th>
                HallName
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 50 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
         foreach (var item in Model.Data)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
             foreach (var seat in item.Seats)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => seat.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => seat.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => seat.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => seat.IsBroken));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => seat.HallId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => seat.HallName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id = seat.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 75 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id = seat.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 76 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { id = seat.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 79 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "68194dd28be0aff68aa85f1018eaab5707b0445310939", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 83 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 83 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Seats\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.ViewData = ViewData;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("view-data", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.ViewData, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.Responses.PagedResponse<Application.DataTransfer.SeatRowDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
