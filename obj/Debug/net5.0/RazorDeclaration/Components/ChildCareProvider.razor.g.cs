// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace pnl.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl.Models.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Microsoft.AspNetCore.Mvc.TagHelpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using BlazorAnimate;

#line default
#line hidden
#nullable disable
    public partial class ChildCareProvider : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 48 "D:\Users\diosc\Repos\pnl\Components\ChildCareProvider.razor"
           


        [Parameter]
        public int TaxFormID { get; set; }

        public bool isSuccessfull { get; set; } = false;

        private DependentCareProviders CareProviderModel { get; set; } = new DependentCareProviders();
        protected override void OnInitialized()
        {
            CareProviderModel = service.GetCareProviderIfExist(TaxFormID);
            base.OnInitialized();
        }

        public void SaveCareProvider()
        {
            CareProviderModel.TaxFormID = TaxFormID;
            CareProviderModel = service.SaveCareProvider(CareProviderModel);
            if (CareProviderModel.id > 0)
                isSuccessfull = true;
            StateHasChanged();
        }
    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private TaxFormService service { get; set; }
    }
}
#pragma warning restore 1591
