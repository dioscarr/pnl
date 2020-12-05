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
    public partial class NewTaxYear : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 74 "D:\Users\diosc\Repos\pnl\Components\NewTaxYear.razor"
       
    [Parameter]
    public EventCallback<int> OnNewTaxYearEvent { get; set; }
 
    private int TaxYear { get; set; } = 0;
    private List<int> TaxYears { get; set; }
    private List<TaxForm> TaxYearsInProcess { get; set; }
    public List<state> states { get; set; }
    private int FilingStatus { get; set; } = -1;
    private int TaxFormId { set; get; } = 0;
    private bool isFilingStatusVisiable { get; set; } = false;
    private bool isSubmitVisiable { get; set; } = false;
    public List<FilingStatus> filingStatuses { get; set; }
    public string selectedState { get; set; }
    private bool FileNewPosition { get; set; } = true;
    private bool FileNew { get; set; } = false;


    private string setFileNewPosition(bool value)
    {
        FileNewPosition = value;
        return "";
    }

    protected override void OnInitialized()
    {
        TaxYears = new List<int>();
        (TaxYears, TaxYearsInProcess) = service.GetTaxYears();
        states = service.GetStates();
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
    private async Task CheckIfTaxExist(ChangeEventArgs args)
    {
        if (int.TryParse(args.Value?.ToString(), out int taxYear))
        {
            TaxYear = taxYear;
            isFilingStatusVisiable = true;
            TaxForm t = await service.CheckIfTaxExist(TaxYear);
            if (t != null)
            {
                TaxFormId = t.ID;
            }
            StateHasChanged();
        }
    }

    private void handleStatesClick(string abbr)
    {
        selectedState = abbr;
    }

  
    private async Task CreateNewTaxFormAsync()
    {
        if (TaxYear.ToString().Count() == 4)
        {
            TaxForm t = await service.CreateNewTaxFormAsync(TaxYear, FilingStatus);
            TaxFormId = t.ID;
            TaxYears = new List<int>();
            TaxYears.Add(TaxYear);
            await OnNewTaxYearEvent.InvokeAsync(t.ID);
            StateHasChanged();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private TaxFormService service { get; set; }
    }
}
#pragma warning restore 1591