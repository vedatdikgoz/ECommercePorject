#pragma checksum "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "921545f168d3363b9312c20d444e3244f339cdf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Details), @"mvc.1.0.view", @"/Views/Shop/Details.cshtml")]
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
#line 1 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\_ViewImports.cshtml"
using ECommerceProject.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\_ViewImports.cshtml"
using ECommerceProject.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\_ViewImports.cshtml"
using ECommerceProject.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\_ViewImports.cshtml"
using ECommerceProject.WebUI.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\_ViewImports.cshtml"
using ECommerceProject.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"921545f168d3363b9312c20d444e3244f339cdf7", @"/Views/Shop/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d0230cc877bdf8a207d646cb4580aa7fbc07db9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductDetailModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link p-0 mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
  
    ViewData["Title"] = "Shop Page";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "921545f168d3363b9312c20d444e3244f339cdf77385", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 196, "~/img/", 196, 6, true);
#nullable restore
#line 11 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
AddHtmlAttributeValue("", 202, Model.Product.ImageUrl, 202, 23, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <h1 class=\"mb-3\">");
#nullable restore
#line 14 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
                    Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1> <hr />\r\n");
#nullable restore
#line 15 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
         foreach (var item in Model.Categories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "921545f168d3363b9312c20d444e3244f339cdf79603", async() => {
#nullable restore
#line 17 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
                                                                                                                Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-category", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
                                                                WriteLiteral(item.Url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-category", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"mb-3\">\r\n            <h4 class=\"text-primary mb-3\">\r\n                ₺ ");
#nullable restore
#line 21 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
             Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h4>\r\n\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "921545f168d3363b9312c20d444e3244f339cdf712998", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 836, "\"", 868, 1);
#nullable restore
#line 26 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
WriteAttributeValue("", 844, Model.Product.ProductId, 844, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                <div class=""input-group mb-3"">
                    <input type=""number"" name=""quantity"" value=""1"" class=""form-control"" min=""1"" step=""1"" style=""width: 100px"" />
                    <div class=""input-group-append"">
                        <button type=""submit"" class=""btn btn-primary"">
                            <i class=""fa fa-cart-plus""></i> Sepete Ekle
                        </button>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>



<ul class=""nav nav-tabs"">
    <li class=""nav-item"">
        <a class=""nav-link active"" data-toggle=""tab"" href=""#home"">Ürün Açıklaması</a>
    </li>
    <li class=""nav-item"">
        <a class=""nav-link"" data-toggle=""tab"" href=""#yorum"">Değerlendirmeler</a>
    </li>
    <li class=""nav-item"">
        <a class=""nav-link"" data-toggle=""tab"" href=""#taksit"">Taksit Seçenekleri</a>
    </li>
    <li class=""nav-item"">
        <a class=""nav-link"" data-toggle=""tab"" href=""#iade"">İade Koşulları</a>
    </li>
</ul>
<div id=""myTabContent"" class=""tab-content"">
    <div class=""tab-pane fade"" id=""home"">
        <p class=""p-3"">");
#nullable restore
#line 58 "C:\Users\vedat\OneDrive\Masaüstü\ECommerceProject\ECommerceProject.WebUI\Views\Shop\Details.cshtml"
                  Write(Html.Raw(Model.Product.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
    </div>
    <div class=""tab-pane fade active show"" id=""yorum"">
 
    </div>
    <div class=""tab-pane fade"" id=""taksit"">

    </div>
    <div class=""tab-pane fade"" id=""iade"">
        <p>İade işlemlerinizi aşağıdaki şekilde yapmalısınız:</p>
        <ul>
            <li>
                Ürünün adresinize teslim tarihinden itibaren 14 gün içinde ""Sipariş Takibi"" sayfasından ""İade ve Geri gönderim"" başvurusunda bulunarak iade sürecinizi başlatabilirsiniz.
            </li>
            <li>
                Ürünü iade etmek için, orijinal kutusuyla ve faturasıyla birlikte Shopapp.com’a göndermelisiniz. İadenizin kabul edilmesi için, ürünün hasar görmemiş ve kullanılmamış olması gerekmektedir.
            </li>
            <li>
                Daha detaylı bilgi için Çözüm Merkezi sayfasını ziyaret edebilirsiniz.
            </li>
        </ul>
        <p>Bedel İadesi:</p>
        <p>
            İade işlemi sonuçlandıktan sonra bedel ödemesi kredi kartınıza/banka hesabınıza 24 saat iç");
            WriteLiteral(@"inde yapılmaktadır. Ödeme işlemlerinin hesabınıza yansıma süresi bankanıza göre değişkenlik gösterebilir.

            Alışveriş kredisi ile satın alınan ürün iadelerinde; standart prosedür geçerlidir.

            Ürün iptal/iadeniz gerçekleştiği durumda, ürün tutarınız Shopapp tarafından tanımladığınız hesabınıza geri ödenir.

            Kredili siparişiniz iptal/iade alındığında krediniz kapanmış sayılmamaktadır. Ürün iptal/iadesinden sonra ayrıca krediden cayma talebiniz olur ise banka ile bireysel olarak iletişime geçmeniz gerekmektedir. Sipariş tarihinizden kredi kapama tarihinize kadar oluşan faizden sorumlu olacaksınız.
        </p>
        <a href=""#"">İade başvurusunda nasıl bulunabilirim?</a>
    </div>
</div>

<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />



<link href=""/node_modules/bootstrap/dist/css/bootstrap.min.css"" rel=""stylesheet"" media=""screen"">

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591