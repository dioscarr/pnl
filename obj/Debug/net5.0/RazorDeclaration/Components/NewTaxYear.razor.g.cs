#pragma checksum "D:\Users\diosc\Repos\pnl\Components\NewTaxYear.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a62f3e197d3ae8f81d91ab27c390d95f7db3083"
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
#line 9 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using pnl.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Core.Component;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Transition.Component;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Script.DomHelpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Component;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Theme;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Form;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Input;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Typography;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Progress;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Transition;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Button;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Icon;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Paper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Avatar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Badge;

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Selection;

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Toolbar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.AppBar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Divider;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Grid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Table;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Baseline;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Card;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Hidden;

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.List;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Script;

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Drawer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Dialog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Popover;

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Tab;

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "D:\Users\diosc\Repos\pnl\_Imports.razor"
using Skclusive.Material.Container;

#line default
#line hidden
#nullable disable
    public partial class NewTaxYear : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 64 "D:\Users\diosc\Repos\pnl\Components\NewTaxYear.razor"
           

        [Parameter]
        public EventCallback<int> OnNewTaxYearEvent { get; set; }
        private int TaxYear { get; set; } = 0;
        private List<int> TaxYears { get; set; }
        private List<TaxForm> TaxYearsInProcess { get; set; }
        private int FilingStatus { get; set; } = -1;
        private int TaxFormId { set; get; } = 0;
        private bool isFilingStatusVisiable { get; set; } = false;
        private bool isSubmitVisiable { get; set; } = false;
        public List<FilingStatus> filingStatuses { get; set; }


        protected override void OnInitialized()
        {
            TaxYears = new List<int>();
            (TaxYears, TaxYearsInProcess) = service.GetTaxYears();
            filingStatuses = new List<FilingStatus>();
            filingStatuses = service.GetfilingStatuses();
            base.OnInitialized();
        }

        private void HandleTaxYearChange(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value?.ToString(), out int taxYear))
            {
                TaxYear = taxYear;
            }
        }
        private void HandleFilingStatusChange(ChangeEventArgs args)
        {

            if (int.TryParse(args.Value?.ToString(), out int filingstatus))
            {
                FilingStatus = filingstatus;
            }
            if (FilingStatus > 0)
            {
                isSubmitVisiable = true;
            }
            else
            {
                isSubmitVisiable = false;
            }
        }
        private async Task CheckIfTaxExist(int taxyear)
        {
            TaxYear = taxyear;
            isFilingStatusVisiable = true;
            TaxForm t = await service.CheckIfTaxExist(TaxYear);
            if (t != null)
            {
                TaxFormId = t.ID;
            }
            StateHasChanged();

        }


        private async Task CreateNewTaxFormAsync()
        {
            TaxForm t = await service.CreateNewTaxFormAsync(TaxYear, FilingStatus);
            TaxFormId = t.ID;
            TaxYears = new List<int>();
            TaxYears.Add(TaxYear);
            await OnNewTaxYearEvent.InvokeAsync(t.ID);
            StateHasChanged();
        }
    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private TaxFormService service { get; set; }
    }
}
#pragma warning restore 1591
