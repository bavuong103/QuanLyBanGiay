#pragma checksum "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cb94b4bbbf30f5e24fad6b2caba7f123f2bc895"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Master_Change), @"mvc.1.0.view", @"/Areas/admin/Views/Master/Change.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/admin/Views/Master/Change.cshtml", typeof(AspNetCore.Areas_admin_Views_Master_Change))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cb94b4bbbf30f5e24fad6b2caba7f123f2bc895", @"/Areas/admin/Views/Master/Change.cshtml")]
    public class Areas_admin_Views_Master_Change : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml"
  
    ViewBag.Title = "Change Password";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(106, 254, true);
            WriteLiteral("<div class=\"col-sm-8 col-sm-offset-2\">\r\n    <div class=\"panel panel-default\">\r\n        <div class=\"panel-heading\">\r\n            <span class=\"glyphicon glyphicon-user\"></span> CHANGE PASSWORD\r\n        </div>\r\n        <div class=\"panel-body\">\r\n            ");
            EndContext();
            BeginContext(361, 24, false);
#line 11 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml"
       Write(Html.ValidationSummary());

#line default
#line hidden
            EndContext();
            BeginContext(385, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml"
             using (Html.BeginForm())
            {

#line default
#line hidden
            BeginContext(441, 108, true);
            WriteLiteral("                <div class=\"form-group\">\r\n                    <label>User name</label>\r\n                    ");
            EndContext();
            BeginContext(550, 57, false);
#line 16 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml"
               Write(Html.TextBox("Id", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(607, 141, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label>Current Password</label>\r\n                    ");
            EndContext();
            BeginContext(749, 63, false);
#line 20 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml"
               Write(Html.TextBox("Password", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(812, 137, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label>New Password</label>\r\n                    ");
            EndContext();
            BeginContext(950, 64, false);
#line 24 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml"
               Write(Html.TextBox("Password1", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1014, 145, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label>Confirm New Password</label>\r\n                    ");
            EndContext();
            BeginContext(1160, 64, false);
#line 28 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml"
               Write(Html.TextBox("Password2", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1224, 258, true);
            WriteLiteral(@"
                </div>
                <div class=""form-group"">
                    <button class=""btn btn-default"">
                        <span class=""glyphicon glyphicon-log-in""></span> Change
                    </button>
                </div>
");
            EndContext();
#line 35 "C:\Users\Admin\Desktop\8. ASP.NET CORE MVC\SHOPONLINE\SHOPONLINE\Areas\admin\Views\Master\Change.cshtml"
            }

#line default
#line hidden
            BeginContext(1497, 76, true);
            WriteLiteral("        </div>\r\n        <div class=\"panel-footer\"></div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591