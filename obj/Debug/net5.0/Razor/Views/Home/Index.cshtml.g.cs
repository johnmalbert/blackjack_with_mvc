#pragma checksum "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57e177f0e083edbd84961266e1c22d9456ea19cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\_ViewImports.cshtml"
using Cards;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\_ViewImports.cshtml"
using Cards.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
using System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57e177f0e083edbd84961266e1c22d9456ea19cd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"218d696472f75d68fed934370ccee98db1099256", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <div class=\"row\">\r\n        <div class=\"col\">\r\n            <h1 class=\"display-4\">Player 1</h1>\r\n            <hr>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
             for (int i = 0; i < ViewBag.Hand.Count; i++)
            {
                if(ViewBag.Hand[i].ImgURL == "https://deckofcardsapi.com/static/img/AD.png")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img src=\"AD.png\" alt=\"ace of diamonds\">\r\n");
#nullable restore
#line 17 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img");
            BeginWriteAttribute("src", " src=", 542, "", 570, 1);
#nullable restore
#line 20 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
WriteAttributeValue("", 547, ViewBag.Hand[i].ImgURL, 547, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=", 570, "", 591, 1);
#nullable restore
#line 20 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
WriteAttributeValue("", 575, ViewBag.Hand[i], 575, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 21 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
                }
            }            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>Score: ");
#nullable restore
#line 23 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
                  Write(ViewBag.playerScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        </div>\r\n        <div class=\"col\">\r\n            <h1 class=\"display-4\">Dealer</h1>\r\n            <hr>\r\n            \r\n");
#nullable restore
#line 29 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
             for(int i = 0; i < ViewBag.Dealer.Count; i++)
            {
                if(ViewBag.Dealer[i].ImgURL == "https://deckofcardsapi.com/static/img/AD.png")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img src=\"AD.png\" alt=\"ace of diamonds\">\r\n");
#nullable restore
#line 34 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img");
            BeginWriteAttribute("src", " src=", 1148, "", 1178, 1);
#nullable restore
#line 37 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
WriteAttributeValue("", 1153, ViewBag.Dealer[i].ImgURL, 1153, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=", 1178, "", 1201, 1);
#nullable restore
#line 37 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
WriteAttributeValue("", 1183, ViewBag.Dealer[i], 1183, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 38 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>Score: ");
#nullable restore
#line 40 "C:\Users\johnm\Documents\Coding_Dojo\C#\Cards\Views\Home\Index.cshtml"
                  Write(ViewBag.dealerScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        </div>\r\n    </div>\r\n    <a href=\"/\"><button class=\"btn btn-primary\">New Hand</button></a>\r\n</div>\r\n");
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