#pragma checksum "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dc7bbc3565c012ce344d928ce055cb0cf64992b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__DoctorsPartialView), @"mvc.1.0.view", @"/Views/Shared/_DoctorsPartialView.cshtml")]
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
#line 1 "C:\Users\User\source\repos\SAF\SAF\Views\_ViewImports.cshtml"
using SAF;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\SAF\SAF\Views\_ViewImports.cshtml"
using SAF.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\source\repos\SAF\SAF\Views\_ViewImports.cshtml"
using SAF.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dc7bbc3565c012ce344d928ce055cb0cf64992b", @"/Views/Shared/_DoctorsPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63ef4507d1f7f85c0265e14954a3d574acde703e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__DoctorsPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Doctor>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
 foreach (var d in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" class=\"update-model-id\"");
            BeginWriteAttribute("value", " value=\"", 143, "\"", 156, 1);
#nullable restore
#line 10 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
WriteAttributeValue("", 151, d.Id, 151, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n    <tr>\r\n        <td>");
#nullable restore
#line 12 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
       Write(d.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 13 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
       Write(d.Profession);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 14 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
       Write(d.WorkPlace);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 15 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
       Write(d.Region);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 16 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
       Write(d.MobileNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n");
#nullable restore
#line 18 "C:\Users\User\source\repos\SAF\SAF\Views\Shared\_DoctorsPartialView.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Doctor>> Html { get; private set; }
    }
}
#pragma warning restore 1591