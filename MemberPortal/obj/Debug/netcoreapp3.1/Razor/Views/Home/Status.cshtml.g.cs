#pragma checksum "C:\Users\sud44\OneDrive\Desktop\new pull\MemberPortal\Views\Home\Status.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "607f0e8e37be5bd78ecb208d3469f1536b6bce54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Status), @"mvc.1.0.view", @"/Views/Home/Status.cshtml")]
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
#line 1 "C:\Users\sud44\OneDrive\Desktop\new pull\MemberPortal\Views\_ViewImports.cshtml"
using MemberPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sud44\OneDrive\Desktop\new pull\MemberPortal\Views\_ViewImports.cshtml"
using MemberPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"607f0e8e37be5bd78ecb208d3469f1536b6bce54", @"/Views/Home/Status.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7216ac1859b9bf8d04551214c524c26eb9c89140", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Status : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\sud44\OneDrive\Desktop\new pull\MemberPortal\Views\Home\Status.cshtml"
  
    ViewData["Title"] = "SaveClaim";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 8 "C:\Users\sud44\OneDrive\Desktop\new pull\MemberPortal\Views\Home\Status.cshtml"
 if(ViewBag.Status!="")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"jumbotron\">\r\n        <h1 style=\"text-align:center\">Your current status ");
#nullable restore
#line 12 "C:\Users\sud44\OneDrive\Desktop\new pull\MemberPortal\Views\Home\Status.cshtml"
                                                     Write(ViewBag.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 15 "C:\Users\sud44\OneDrive\Desktop\new pull\MemberPortal\Views\Home\Status.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"jumbotron\">\r\n        <h1 style=\"color:red;text-align:center\">Input data is not valid</h1>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 23 "C:\Users\sud44\OneDrive\Desktop\new pull\MemberPortal\Views\Home\Status.cshtml"
}

#line default
#line hidden
#nullable disable
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
