#pragma checksum "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66dff4080568fb93170376de6b557032f71b61c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Calculadora_Delete), @"mvc.1.0.view", @"/Views/Calculadora/Delete.cshtml")]
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
#line 1 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\_ViewImports.cshtml"
using BonosCalculadora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\_ViewImports.cshtml"
using BonosCalculadora.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66dff4080568fb93170376de6b557032f71b61c1", @"/Views/Calculadora/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2297b97b25c74054c3b2f8257dcf80c7f6034f25", @"/Views/_ViewImports.cshtml")]
    public class Views_Calculadora_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BonosCalculadora.Models.Calculadora>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Calculadora</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Vnominal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Vnominal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Vcomercial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Vcomercial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TasaDeInteres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TasaDeInteres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.NAños));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.NAños));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DiasAño));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DiasAño));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Cok));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Cok));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.FechaEmision));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.FechaEmision));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Prima));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Prima));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Estructuración));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Estructuración));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Colocación));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Colocación));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Flotacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Flotacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 81 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Cavali));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 84 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Cavali));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 87 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.FrecuenciaPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.FrecuenciaPago.Tipofrecuencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 93 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TasaInteres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 96 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TasaInteres.TasaInteresId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 99 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Capitalizacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 102 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Capitalizacion.TipoCapitalizacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 105 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MetodoPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 108 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MetodoPago.TipoMetodo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66dff4080568fb93170376de6b557032f71b61c115404", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "66dff4080568fb93170376de6b557032f71b61c115671", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 113 "E:\Finanzas\Bonos\BonosCalculadora\BonosCalculadora\Views\Calculadora\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CalculadoraId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66dff4080568fb93170376de6b557032f71b61c117474", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BonosCalculadora.Models.Calculadora> Html { get; private set; }
    }
}
#pragma warning restore 1591
