#pragma checksum "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\Views\Config\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "295162a36fb7aa9df6ed21d1e9bd6190666cf877"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PnlAccess_Views_Config_Index), @"mvc.1.0.view", @"/Areas/PnlAccess/Views/Config/Index.cshtml")]
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
#line 1 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using pnl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using pnl.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using pnl.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\_ViewImports.cshtml"
using pnl.Components;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"295162a36fb7aa9df6ed21d1e9bd6190666cf877", @"/Areas/PnlAccess/Views/Config/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ab4866b16495b7faaebfadf2fc05352893a0cbb", @"/Areas/PnlAccess/_ViewImports.cshtml")]
    public class Areas_PnlAccess_Views_Config_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<pnl.Data.Models.PagesConfig>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "295162a36fb7aa9df6ed21d1e9bd6190666cf8774815", async() => {
                WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12 col-md-5\">\r\n            ");
#nullable restore
#line 5 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\Views\Config\Index.cshtml"
       Write(Html.LabelFor(c => c.TopSubTitle));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n            ");
#nullable restore
#line 6 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\Views\Config\Index.cshtml"
       Write(Html.TextAreaFor(c => c.TopSubTitle, 5, 10, new { @class = "", @id = "editor_TopSubTitle" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-12 col-md-5\">\r\n            ");
#nullable restore
#line 9 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\Views\Config\Index.cshtml"
       Write(Html.LabelFor(c => c.Title));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n            ");
#nullable restore
#line 10 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\Views\Config\Index.cshtml"
       Write(Html.TextAreaFor(c => c.Title, 5, 10, new { @class = "", @id = "editor_Title" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12 col-md-5\">\r\n            ");
#nullable restore
#line 15 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\Views\Config\Index.cshtml"
       Write(Html.LabelFor(c => c.TopSubTitle));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n            ");
#nullable restore
#line 16 "D:\Users\diosc\Repos\pnl\Areas\PnlAccess\Views\Config\Index.cshtml"
       Write(Html.TextAreaFor(c => c.Message, 5, 10, new { @class = "", @id = "editor_Message" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n            <button type=\"submit\">Update</button>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script src=""https://cdn.ckeditor.com/ckeditor5/23.1.0/classic/ckeditor.js""></script>
<script type=""text/javascript"">
    ClassicEditor.create(document.querySelector('#editor_TopSubTitle')).then(editor => { console.log(editor); }).catch(error => { console.error(error); });
    ClassicEditor.create(document.querySelector('#editor_Title')).then(editor => { console.log(editor); }).catch(error => { console.error(error); });
    ClassicEditor.create(document.querySelector('#editor_Message')).then(editor => { console.log(editor); }).catch(error => { console.error(error); });
</script>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<pnl.Data.Models.PagesConfig> Html { get; private set; }
    }
}
#pragma warning restore 1591