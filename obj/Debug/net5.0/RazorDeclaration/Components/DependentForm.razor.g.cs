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
    public partial class DependentForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
       
        [Parameter]
        public int TaxFormID { get; set; }
        [Parameter]
        public EventCallback<bool> OnReloadDependetEvent { get; set; }

        public Dependent dependent { get; set; }

        private string FirstName { get; set; }
        private string LastName { get; set; }
        private DateTime Birthday { get; set; }
        private string SSN { get; set; }
        private int MonthInHome { get; set; }
        private string RelationshipName { get; set; }
        private string Code { get; set; }
        private void HandleFirstNameChange(ChangeEventArgs args) => FirstName = args.Value?.ToString();
        private void HandleLastNameChange(ChangeEventArgs args) => LastName = args.Value?.ToString();
        private void HandleBirthdayChange(ChangeEventArgs args)
        {
            if (DateTime.TryParse(args.Value?.ToString(), out DateTime birthday))
            {
                Birthday = birthday;
            }
        }
        private void HandleSSNChange(ChangeEventArgs args) => SSN = args.Value?.ToString();
        private void HandleMonthInHomeChange(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value?.ToString(), out int monthInHome))
            {
                MonthInHome = monthInHome;
            }
        }
        private void HandleRelationshipNameChange(ChangeEventArgs args) => RelationshipName = args.Value?.ToString();
        private void HandleCodeChange(ChangeEventArgs args) => Code = args.Value?.ToString();

        protected override void OnInitialized()
        {
            dependent = new Dependent();
            base.OnInitialized();
        }

        private async Task AddDependent()
        {
            dependent.TaxFormID = TaxFormID;
            var d = await service.AddDependentAsync(dependent);
            if (dependent.id > 0)
            {
                await OnReloadDependetEvent.InvokeAsync(true);
            }
            dependent = new Dependent();
        }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private TaxFormService service { get; set; }
    }
}
#pragma warning restore 1591