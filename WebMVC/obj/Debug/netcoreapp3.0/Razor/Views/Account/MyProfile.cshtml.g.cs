#pragma checksum "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b49fa28af64aa8447b396ad5a690f822e323ff0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_MyProfile), @"mvc.1.0.view", @"/Views/Account/MyProfile.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
using WebMVC.Session;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
using Application.DataTransfer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b49fa28af64aa8447b396ad5a690f822e323ff0", @"/Views/Account/MyProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5b3e85210568c19abe72d8bf552aecc7da3bc34", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_MyProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.DataTransfer.ShowUserDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
  
    ViewData["Title"] = "MyProfile";
    var user = Context.Session.Get<ShowUserDto>("User");


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>My Profile</h1>\r\n\r\n<div class=\"container\">\r\n    <hr />\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-4\">\r\n");
#nullable restore
#line 18 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
             using (Html.BeginForm("Edit", "Users", FormMethod.Post))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <table>\r\n                    ");
#nullable restore
#line 21 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
               Write(Html.Hidden("UserId", user.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <tr class=\"col-sm-2 col-md-4\">\r\n                        <td>\r\n                            ");
#nullable restore
#line 24 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input class=\"form-control\" type=\"text\" name=\"FirstName\"");
            BeginWriteAttribute("value", " value=\"", 829, "\"", 852, 1);
#nullable restore
#line 27 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
WriteAttributeValue("", 837, user.FirstName, 837, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </td>\r\n                    </tr>\r\n                    <tr class=\"col-sm-2 col-md-4\">\r\n                        <td>\r\n                            ");
#nullable restore
#line 32 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input class=\"form-control\" type=\"text\" name=\"LastName\"");
            BeginWriteAttribute("value", " value=\"", 1217, "\"", 1239, 1);
#nullable restore
#line 35 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
WriteAttributeValue("", 1225, user.LastName, 1225, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </td>\r\n                    </tr>\r\n                    <tr class=\"col-sm-2\">\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input class=\"form-control\" type=\"text\" name=\"Email\"");
            BeginWriteAttribute("value", " value=\"", 1589, "\"", 1608, 1);
#nullable restore
#line 43 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
WriteAttributeValue("", 1597, user.Email, 1597, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                     if (user.RoleId == 2)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr class=\"col-sm-2\">\r\n                            <td>\r\n                                ");
#nullable restore
#line 50 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                           Write(Html.DisplayNameFor(model => model.RoleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 53 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                           Write(Html.DisplayFor(model => model.RoleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr class=\"col-sm-2\">\r\n                            <td>\r\n                                ");
#nullable restore
#line 58 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                           Write(Html.DisplayNameFor(model => model.RoleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                <input type=\"text\" class=\"form-control\" name=\"RoleId\"");
            BeginWriteAttribute("value", " value=\"", 2421, "\"", 2441, 1);
#nullable restore
#line 61 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
WriteAttributeValue("", 2429, user.RoleId, 2429, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"col-sm-2\">\r\n                        <td>\r\n                            ");
#nullable restore
#line 67 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                       Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input type=\"password\" class=\"form-control\" name=\"Password\"");
            BeginWriteAttribute("value", " value=\"", 2832, "\"", 2854, 1);
#nullable restore
#line 70 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
WriteAttributeValue("", 2840, user.Password, 2840, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                        </td>
                    </tr>
                    <tr>
                        <td>Confirm your password</td>
                        <td>
                            <input type=""password"" class=""form-control"" name=""ConfirmPassword""");
            BeginWriteAttribute("value", " value=\"", 3124, "\"", 3153, 1);
#nullable restore
#line 76 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
WriteAttributeValue("", 3132, user.ConfirmPassword, 3132, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n                        </td>\r\n                    </tr>\r\n                </table><hr />\r\n                <button type=\"submit\" class=\"btn-block btn-lg btn-info\">Update profile</button>\r\n");
#nullable restore
#line 81 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"col-lg-7\">\r\n            <h3>Active reservations:</h3>\r\n");
#nullable restore
#line 85 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
             foreach(var r in ViewBag.Reservations)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-info\" role=\"alert\">\r\n                    <h4>");
#nullable restore
#line 88 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                   Write(r.MovieName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 88 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                                  Write(Convert.ToDateTime(r.ProjectionBegin).ToString("dd-MMM yy. HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <p>Seats: \r\n");
#nullable restore
#line 90 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                         foreach(var s in r.SeatsInfo)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                        Write(s.SeatName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                                    Write(Html.Raw("-"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                                                   Write(s.SeatNumber);

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                                                                 Write(Html.Raw(", "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
                                                                                     
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </p>\r\n                    <hr/>\r\n                </div>\r\n");
#nullable restore
#line 97 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Account\MyProfile.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.DataTransfer.ShowUserDto> Html { get; private set; }
    }
}
#pragma warning restore 1591