#pragma checksum "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "009df4bcf43630f533787f53da5239d0a784cb02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Category_Index), @"mvc.1.0.view", @"/Areas/admin/Views/Category/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/admin/Views/Category/Index.cshtml", typeof(AspNetCore.Areas_admin_Views_Category_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"009df4bcf43630f533787f53da5239d0a784cb02", @"/Areas/admin/Views/Category/Index.cshtml")]
    public class Areas_admin_Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SHOPONLINE.Models.ShopOnline.Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(142, 1077, true);
            WriteLiteral(@"
<h2>Category Manager</h2>

<div>
    <!-- Nav tabs -->
    <ul class=""nav nav-tabs"" role=""tablist"">
        <li role=""presentation"" class=""active"">
            <a href=""#edit"" aria-controls=""home"" role=""tab"" data-toggle=""tab"">
                <span class=""glyphicon glyphicon-edit""></span>
                Edition
            </a>
        </li>
        <li role=""presentation"">
            <a href=""#list"" aria-controls=""profile"" role=""tab"" data-toggle=""tab"">
                <span class=""glyphicon glyphicon-list""></span>
                List
            </a>
        </li>
    </ul>

    <!-- Tab panes -->
    <div class=""tab-content"">
        <div role=""tabpanel"" class=""tab-pane active"" id=""edit"">
            <div class=""panel panel-default"">
                <div class=""panel-heading"">
                    <h3 class=""panel-title"">
                        <span class=""glyphicon glyphicon-briefcase""></span>
                        Category Edition
                    </h3>
             ");
            WriteLiteral("   </div>\r\n                <div class=\"panel-body\">\r\n");
            EndContext();
#line 37 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                     using (Html.BeginForm())
                    {
                        if (!Html.ValidationSummary().ToString().Contains(":none"))
                        {

#line default
#line hidden
            BeginContext(1401, 107, true);
            WriteLiteral("                            <div class=\"pull-right label label-danger\">\r\n\r\n                                ");
            EndContext();
            BeginContext(1509, 24, false);
#line 43 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                           Write(Html.ValidationSummary());

#line default
#line hidden
            EndContext();
            BeginContext(1533, 40, true);
            WriteLiteral("\r\n\r\n                            </div>\r\n");
            EndContext();
#line 46 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(1600, 125, true);
            WriteLiteral("                        <div class=\"form-group\">\r\n                            <label>Id</label>\r\n                            ");
            EndContext();
            BeginContext(1726, 77, false);
#line 49 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.Id, new { @class = "form-control", @readonly = true }));

#line default
#line hidden
            EndContext();
            BeginContext(1803, 161, true);
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            <label>Name</label>\r\n                            ");
            EndContext();
            BeginContext(1965, 61, false);
#line 53 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2026, 164, true);
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            <label>Name VN</label>\r\n                            ");
            EndContext();
            BeginContext(2191, 63, false);
#line 57 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                       Write(Html.TextBoxFor(m => m.NameVN, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2254, 1080, true);
            WriteLiteral(@"
                        </div>
                        <div class=""form-group"">
                            <div class=""text-center btn-crud"">
                                <button class=""btn btn-default"" data-action=""Insert"">Insert</button>
                                <button class=""btn btn-default"" data-action=""Update"">Update</button>
                                <button class=""btn btn-default"" data-action=""Delete"">Delete</button>
                                <button class=""btn btn-default"" data-action=""Index"">Reset</button>
                            </div>
                            <script>
                                $(function () {
                                    $(""button[data-action]"").click(function () {
                                        var action = $(this).attr(""data-action"");
                                        this.form.action = ""/Admin/Category/"" + action;
                                    });
                                });
               ");
            WriteLiteral("             </script>\r\n                        </div>\r\n");
            EndContext();
#line 75 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(3357, 872, true);
            WriteLiteral(@"                </div>
                <div class=""panel-footer""></div>
            </div>
        </div>
        <div role=""tabpanel"" class=""tab-pane"" id=""list"">
            <div class=""panel panel-default"">
                <div class=""panel-heading"">
                    <h3 class=""panel-title"">
                        <span class=""glyphicon glyphicon-briefcase""></span>
                        Category List
                    </h3>
                </div>
                <table class=""table table-hover table-condensed table-striped"">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Name VN</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 98 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                         foreach (SHOPONLINE.Models.ShopOnline.Category Item in ViewBag.Items)
                        {

#line default
#line hidden
            BeginContext(4352, 70, true);
            WriteLiteral("                            <tr>\r\n                                <td>");
            EndContext();
            BeginContext(4423, 7, false);
#line 101 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                               Write(Item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4430, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(4474, 9, false);
#line 102 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                               Write(Item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(4483, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(4527, 11, false);
#line 103 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                               Write(Item.NameVN);

#line default
#line hidden
            EndContext();
            BeginContext(4538, 113, true);
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a class=\"btn btn-sm btn-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4651, "\"", 4687, 2);
            WriteAttributeValue("", 4658, "/Admin/Category/Edit/", 4658, 21, true);
#line 105 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
WriteAttributeValue("", 4679, Item.Id, 4679, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4688, 122, true);
            WriteLiteral("><span class=\"glyphicon glyphicon-edit\"></span></a>\r\n                                    <a class=\"btn btn-sm btn-warning\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4810, "\"", 4848, 2);
            WriteAttributeValue("", 4817, "/Admin/Category/Delete/", 4817, 23, true);
#line 106 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
WriteAttributeValue("", 4840, Item.Id, 4840, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4849, 128, true);
            WriteLiteral("><span class=\"glyphicon glyphicon-trash\"></span></a>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 109 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Category\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(5004, 162, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n                <div class=\"panel-footer\"></div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SHOPONLINE.Models.ShopOnline.Category> Html { get; private set; }
    }
}
#pragma warning restore 1591