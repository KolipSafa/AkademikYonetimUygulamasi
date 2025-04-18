#pragma checksum "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbeae60079259d3a9e530768eaab2ae4efb9ab31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DersProgrami_HaftalikProgram), @"mvc.1.0.view", @"/Views/DersProgrami/HaftalikProgram.cshtml")]
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
#line 1 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\_ViewImports.cshtml"
using AkademikProgramYonetimi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\_ViewImports.cshtml"
using AkademikProgramYonetimi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbeae60079259d3a9e530768eaab2ae4efb9ab31", @"/Views/DersProgrami/HaftalikProgram.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a71ead7bae16e4bf4b4e847ea65f1cce80c4a76c", @"/Views/_ViewImports.cshtml")]
    public class Views_DersProgrami_HaftalikProgram : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AkademikProgramYonetimi.Models.DersProgrami>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
  
    ViewData["Title"] = "Haftalık Ders Programı";
    
    var gunler = Enum.GetValues(typeof(AkademikProgramYonetimi.Models.DersGunu))
        .Cast<AkademikProgramYonetimi.Models.DersGunu>()
        .ToList();
    
    var derslikler = Model.Select(d => d.Derslik).Distinct().OrderBy(d => d.DerslikAdi).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"mb-4\">Haftalık Ders Programı</h1>\r\n\r\n");
#nullable restore
#line 15 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-info\">\r\n        <i class=\"bi bi-info-circle\"></i> Henüz ders programı oluşturulmamış.\r\n    </div>\r\n");
#nullable restore
#line 20 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
     foreach (var derslik in derslikler)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card mb-4\">\r\n            <div class=\"card-header bg-primary text-white\">\r\n                <h5 class=\"card-title mb-0\">\r\n                    <i class=\"bi bi-building\"></i> ");
#nullable restore
#line 28 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                              Write(derslik.DerslikAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 28 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                                                    Write(derslik.Bina);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n                    <span class=\"badge bg-info float-end\">Kapasite: ");
#nullable restore
#line 29 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                                               Write(derslik.Kapasite);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </h5>
            </div>
            <div class=""card-body p-0"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-striped mb-0"">
                        <thead class=""table-dark"">
                            <tr>
                                <th style=""width: 100px;"">Saat / Gün</th>
");
#nullable restore
#line 38 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                 foreach (var gun in gunler)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <th>");
#nullable restore
#line 40 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                   Write(gun);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 41 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 45 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                              
                                // Saat aralıklarını oluştur (08:00'den 18:00'e kadar saatlik dilimler)
                                var saatler = new List<TimeSpan>();
                                for (int i = 8; i < 18; i++)
                                {
                                    saatler.Add(new TimeSpan(i, 0, 0));
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            \r\n");
#nullable restore
#line 54 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                             foreach (var saat in saatler)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"fw-bold\">");
#nullable restore
#line 57 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                                   Write(saat.ToString(@"hh\:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 58 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                     foreach (var gun in gunler)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>\r\n");
#nullable restore
#line 61 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                              
                                                var programlar = Model.Where(d => d.DerslikId == derslik.Id && 
                                                                                d.Gun == gun && 
                                                                                d.BaslangicSaati <= saat && 
                                                                                d.BitisSaati > saat).ToList();
                                                
                                                foreach (var program in programlar)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"bg-light p-2 mb-1 rounded border\">\r\n                                                        <strong>");
#nullable restore
#line 70 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                                           Write(program.Ders.DersAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br />\r\n                                                        <small>");
#nullable restore
#line 71 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                                          Write(program.BaslangicSaati.ToString(@"hh\:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 71 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                                                                                        Write(program.BitisSaati.ToString(@"hh\:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small><br />\r\n                                                        <span class=\"badge bg-secondary\">");
#nullable restore
#line 72 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                                                                    Write(program.OgretimElemani.TamAd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                    </div>\r\n");
#nullable restore
#line 74 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                                }
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n");
#nullable restore
#line 77 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tr>\r\n");
#nullable restore
#line 79 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 85 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "D:\Yeni klasör\AkademikYönetimUygulaması\AkademikProgramYonetimi_Yeni\Views\DersProgrami\HaftalikProgram.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"mt-3\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbeae60079259d3a9e530768eaab2ae4efb9ab3114256", async() => {
                WriteLiteral("Programa Dön");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AkademikProgramYonetimi.Models.DersProgrami>> Html { get; private set; }
    }
}
#pragma warning restore 1591
