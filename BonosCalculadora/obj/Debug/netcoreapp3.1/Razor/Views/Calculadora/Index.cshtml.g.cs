#pragma checksum "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba5f145c074f139ea23039cbef83a677b8d120c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Calculadora_Index), @"mvc.1.0.view", @"/Views/Calculadora/Index.cshtml")]
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
#line 1 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\_ViewImports.cshtml"
using BonosCalculadora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\_ViewImports.cshtml"
using BonosCalculadora.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba5f145c074f139ea23039cbef83a677b8d120c3", @"/Views/Calculadora/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2297b97b25c74054c3b2f8257dcf80c7f6034f25", @"/Views/_ViewImports.cshtml")]
    public class Views_Calculadora_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BonosCalculadora.Models.Calculadora>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba5f145c074f139ea23039cbef83a677b8d120c34635", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table-bordered  table-responsive \">\r\n    <thead >\r\n        <tr class=\"table-info\">\r\n            <th >\r\n                ");
#nullable restore
#line 16 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Vnominal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Vcomercial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Tasa\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NAños));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Dias (Año)     \r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Cok));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaEmision));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Prima));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Estructuración));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Colocación));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Flotacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Cavali));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 52 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FrecuenciaPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 55 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TasaInteres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 58 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Capitalizacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 61 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MetodoPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 67 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Vnominal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 73 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Vcomercial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 76 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TasaDeInteres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 79 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NAños));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 82 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DiasAño));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 85 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cok));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 88 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FechaEmision));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 91 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Prima));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 94 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Estructuración));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 97 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Colocación));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 100 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Flotacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 103 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cavali));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 106 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FrecuenciaPago.Tipofrecuencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 109 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TasaInteres.TipoTasa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 112 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Capitalizacion.TipoCapitalizacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 115 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.MetodoPago.TipoMetodo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <small> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba5f145c074f139ea23039cbef83a677b8d120c316283", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 118 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
                                               WriteLiteral(item.CalculadoraId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</small> \r\n                <small>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba5f145c074f139ea23039cbef83a677b8d120c318491", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 119 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
                                                 WriteLiteral(item.CalculadoraId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</small> \r\n                <small> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba5f145c074f139ea23039cbef83a677b8d120c320705", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 120 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
                                                 WriteLiteral(item.CalculadoraId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</small>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 123 "D:\Escritorio\repos\RepositorioFinanzas\BonosCalculadora\Views\Calculadora\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BonosCalculadora.Models.Calculadora>> Html { get; private set; }
    }
}
#pragma warning restore 1591
