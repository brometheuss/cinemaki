#pragma checksum "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "763591f6af24cafd6ca9add34cfa136757a3f596"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Movies), @"mvc.1.0.view", @"/Views/Home/Movies.cshtml")]
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
#line 1 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
using WebMVC.Session;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
using Application.DataTransfer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"763591f6af24cafd6ca9add34cfa136757a3f596", @"/Views/Home/Movies.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5b3e85210568c19abe72d8bf552aecc7da3bc34", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Movies : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.DataTransfer.MovieDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid rounded mx-auto d-block text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 285px; width: 50%; display: block;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
  
    ViewData["Title"] = "Movies";
    var user = Context.Session.Get<ShowUserDto>("User");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Page Content -->\r\n<div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n\r\n        <!-- Post Content Column -->\r\n        <div class=\"col-lg-8\">\r\n\r\n            <!-- Title -->\r\n            <h1 class=\"mt-4\">");
#nullable restore
#line 20 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                        Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n            <!-- Author -->\r\n");
            WriteLiteral("\r\n            <hr>\r\n\r\n            <!-- Date/Time -->\r\n            <p>Theater release: ");
#nullable restore
#line 32 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                           Write(Convert.ToDateTime(Model.DebutDate).ToString("dd-MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n            <hr>\r\n            <div class=\"row\">\r\n                <div class=\"col-md-7\">\r\n                    <!-- Preview Image -->\r\n");
#nullable restore
#line 39 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                     foreach (var im in ViewBag.Posters)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "763591f6af24cafd6ca9add34cfa136757a3f5966034", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1114, "~/uploads/", 1114, 10, true);
#nullable restore
#line 41 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
AddHtmlAttributeValue("", 1124, im.Name, 1124, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 41 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
AddHtmlAttributeValue("", 1139, im.Alt, 1139, 7, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
                <div class=""col-md-5"">
                    <h5 class=""card-header"">Genres</h5>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-lg-6"">
                                <ul class=""list-unstyled mb-0"">
");
#nullable restore
#line 50 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                     foreach (var g in Model.GenresInfo)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"d-block\">\r\n                                            <a href=\"#\">");
#nullable restore
#line 53 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                                   Write(g.GenreName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </li>\r\n");
#nullable restore
#line 55 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr>

            <!-- Post Content -->
            <p class=""lead"">");
#nullable restore
#line 65 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                       Write(Model.Plot);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n            <hr />\r\n            <div class=\"row\">\r\n                <div class=\"col-md-5\">\r\n                    Country:<i><b> ");
#nullable restore
#line 70 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                              Write(Model.CountryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></i> <br />\r\n                    Production:<i><b> ");
#nullable restore
#line 71 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                 Write(Model.ProductionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></i> <br />\r\n                    Runtime:<i><b> ");
#nullable restore
#line 72 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                               Write(Model.LengthMinutes);

#line default
#line hidden
#nullable disable
            WriteLiteral("minutes</b></i><br />\r\n                    Box Office:<i><b> $");
#nullable restore
#line 73 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                   Write(Model.BoxOffice);

#line default
#line hidden
#nullable disable
            WriteLiteral("M</b></i> <br />\r\n                </div>\r\n                <div class=\"col-md-5\">\r\n                    Language(s):\r\n");
#nullable restore
#line 77 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                     foreach (var l in Model.LanguagesInfo)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i><b>");
#nullable restore
#line 79 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                         Write(l.LanguageName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </b></i> <br />\r\n");
#nullable restore
#line 80 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    Written by <br />\r\n");
#nullable restore
#line 82 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                     foreach (var wr in Model.WritersInfo)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i><b> ");
#nullable restore
#line 84 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                          Write(wr.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></i> <br />\r\n");
#nullable restore
#line 85 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    Starring:\r\n");
#nullable restore
#line 87 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                     foreach (var a in ViewBag.Actors)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i><b><a");
            BeginWriteAttribute("href", " href=\"", 3169, "\"", 3209, 2);
            WriteAttributeValue("", 3176, "https://www.imdb.com/name/", 3176, 26, true);
#nullable restore
#line 89 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
WriteAttributeValue("", 3202, a.Link, 3202, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 89 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                                                     Write(a.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 89 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                                                                  Write(a.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></b></i>\r\n");
#nullable restore
#line 90 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <hr />\r\n\r\n");
#nullable restore
#line 95 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
             if (Context.Session.GetString("User") != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"list-group col-md-8\">\r\n                <a href=\"#\" class=\"list-group-item list-group-item-action active\">\r\n                    Projections\r\n                </a>\r\n");
#nullable restore
#line 102 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                 foreach (var pr in ViewBag.Projections)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                     using (Html.BeginForm("ShowSeats", "Account", FormMethod.Get, new { @class="list-group-item list-group-item-action"}))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row\">\r\n                        <div class=\"list-group col-md-10\">\r\n                            <a href=\"#\" class=\"list-group-item list-group-item-action tryit\">");
#nullable restore
#line 108 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                                                                        Write(Convert.ToDateTime(pr.DateBegin).ToString("dd-MMMM HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            <button type=\"submit\" class=\"list-group-item list-group-item-action tryit\">Make a reservation</button>\r\n                            <input type=\"hidden\" name=\"projection\"");
            BeginWriteAttribute("value", " value=\"", 4323, "\"", 4337, 1);
#nullable restore
#line 110 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
WriteAttributeValue("", 4331, pr.Id, 4331, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <input type=\"hidden\" name=\"hall\"");
            BeginWriteAttribute("value", " value=\"", 4403, "\"", 4421, 1);
#nullable restore
#line 111 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
WriteAttributeValue("", 4411, pr.HallId, 4411, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 114 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 114 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n        </div>\r\n");
#nullable restore
#line 118 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"list-group col-md-8\">\r\n                        <a href=\"#\" class=\"list-group-item list-group-item-action active\">\r\n                            Projections\r\n                        </a>\r\n");
#nullable restore
#line 126 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                         foreach (var pr in ViewBag.Projections)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"#\" class=\"list-group-item list-group-item-action disabled\">");
#nullable restore
#line 128 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                                                                           Write(Convert.ToDateTime(pr.DateBegin).ToString("dd-MMMM HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Login to make a reservation</a>\r\n");
#nullable restore
#line 129 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n");
#nullable restore
#line 132 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("\r\n            <hr>\r\n\r\n            <!-- Comments Form -->\r\n            <div class=\"card my-4\">\r\n");
#nullable restore
#line 148 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                 using (Html.BeginForm("Create", "Comments", FormMethod.Post))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                     if (user != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 152 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                   Write(Html.Hidden("MovieId", Model.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 153 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                   Write(Html.Hidden("UserId", user.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 153 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                                       
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <h5 class=""card-header"">Leave a Comment:</h5>
                    <div class=""card-body"">

                            <p>Your rating:</p>
                            <span class=""rating"">
                                <input id=""rating5"" type=""radio"" name=""rating"" value=""5"">
                                <label for=""rating5"">5</label>
                                <input id=""rating4"" type=""radio"" name=""rating"" value=""4"">
                                <label for=""rating4"">4</label>
                                <input id=""rating3"" type=""radio"" name=""rating"" value=""3"">
                                <label for=""rating3"">3</label>
                                <input id=""rating2"" type=""radio"" name=""rating"" value=""2"">
                                <label for=""rating2"">2</label>
                                <input id=""rating1"" type=""radio"" name=""rating"" value=""1"">
                                <label for=""rating1"">1</label>
                                <inp");
            WriteLiteral(@"ut id=""rating0"" type=""radio"" name=""rating"" value=""0""hidden checked>
                                <label for=""rating0"">0</label>
                            </span>
                            <hr/>
                            <textarea name=""text"" class=""form-control"" rows=""3""></textarea>
                        
                        <button type=""submit"" class=""btn btn-primary"">Submit</button>

                    </div>
");
#nullable restore
#line 180 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n            <!-- Single Comment -->\r\n");
#nullable restore
#line 184 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
             foreach (var c in ViewBag.Comments)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"media mb-4\">\r\n                    <img class=\"d-flex mr-3 rounded-circle\" src=\"http://placehold.it/50x50\"");
            BeginWriteAttribute("alt", " alt=\"", 7802, "\"", 7808, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"media-body\">\r\n                        <h5 class=\"mt-0\">");
#nullable restore
#line 189 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                    Write(c.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        ");
#nullable restore
#line 190 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                   Write(c.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <i>Posted: <br/>");
#nullable restore
#line 192 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                               Write(Convert.ToDateTime(c.Posted).ToString("dd-MMM yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                </div>\r\n");
#nullable restore
#line 194 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <!-- Comment with nested comments -->\r\n");
            WriteLiteral(@"
        </div>

        <!-- Sidebar Widgets Column -->
        <div class=""col-md-4"">

            <!-- Search Widget -->
            <div class=""card my-4"">
                <h5 class=""card-header"">Search</h5>
                <div class=""card-body"">
                    <div class=""input-group"">
                        <input type=""text"" class=""form-control"" placeholder=""Search for..."">
                        <span class=""input-group-append"">
                            <button class=""btn btn-secondary"" type=""button"">Go!</button>
                        </span>
                    </div>
                </div>
            </div>

            <!-- Categories Widget -->
            <!-- Side Widget -->
");
#nullable restore
#line 242 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
             foreach (var pr in ViewBag.Projections)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card my-4\">\r\n                    <h5 class=\"card-header\">");
#nullable restore
#line 245 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                                       Write(pr.HallName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <div class=\"card-body\">\r\n                        Begins: ");
#nullable restore
#line 247 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                           Write(Convert.ToDateTime(pr.DateBegin).ToString("dd-MMMM HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                        Ends: ");
#nullable restore
#line 248 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
                         Write(Convert.ToDateTime(pr.DateEnd).ToString("dd-MMMM HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 251 "C:\Users\Makala\source\repos\BioskopV3\WebMVC\Views\Home\Movies.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n    <!-- /.row -->\r\n\r\n</div>\r\n<!-- /.container -->");
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