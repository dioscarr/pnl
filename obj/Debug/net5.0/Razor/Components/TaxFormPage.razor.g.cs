#pragma checksum "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6ca13efe5191c7351c3b8ed229b993f35dad21e"
// <auto-generated/>
#pragma warning disable 1591
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
    public partial class TaxFormPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "style", "flex-grow: 1;");
            __builder.OpenComponent<Skclusive.Material.Grid.Grid>(2);
            __builder.AddAttribute(3, "Container", true);
            __builder.AddAttribute(4, "Spacing", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Core.Component.Spacing>(
#nullable restore
#line 3 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                  Spacing.Three

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
#nullable restore
#line 4 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
             if (!canDisplay)
            {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<Skclusive.Material.Grid.Grid>(6);
                __builder2.AddAttribute(7, "Item", true);
                __builder2.AddAttribute(8, "Large", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 6 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                   GridSize.Twelve

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "ExtraSmall", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 6 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                                                 GridSize.Twelve

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<pnl.Components.NewTaxYear>(11);
                    __builder3.AddAttribute(12, "OnNewTaxYearEvent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, 
#nullable restore
#line 7 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                                   OnNewTaxYearEvent

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 9 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
             if (canDisplay)
            {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<Skclusive.Material.Grid.Grid>(13);
                __builder2.AddAttribute(14, "Item", true);
                __builder2.AddAttribute(15, "ExtraSmall", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 12 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                        GridSize.Twelve

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Skclusive.Material.Typography.Typography>(17);
                    __builder3.AddAttribute(18, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<pnl.Components.ApplicationHeader>(19);
                        __builder4.AddAttribute(20, "TaxFormID", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 14 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                                      taxFormId

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(21, "\r\n                ");
                __builder2.OpenComponent<Skclusive.Material.Grid.Grid>(22);
                __builder2.AddAttribute(23, "Item", true);
                __builder2.AddAttribute(24, "ExtraSmall", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 17 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                        GridSize.Twelve

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Skclusive.Material.Grid.Grid>(26);
                    __builder3.AddAttribute(27, "Container", true);
                    __builder3.AddAttribute(28, "Spacing", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Core.Component.Spacing>(
#nullable restore
#line 19 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                              Spacing.Three

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<Skclusive.Material.Grid.Grid>(30);
                        __builder4.AddAttribute(31, "Item", true);
                        __builder4.AddAttribute(32, "ExtraSmall", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 20 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                                GridSize.Six

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<pnl.Components.CurrentUserInfo>(34);
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(35, "\r\n                        ");
                        __builder4.OpenComponent<Skclusive.Material.Grid.Grid>(36);
                        __builder4.AddAttribute(37, "Item", true);
                        __builder4.AddAttribute(38, "ExtraSmall", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 23 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                                GridSize.Six

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(39, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<pnl.Components.CurrentAddress>(40);
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(41, "\r\n                ");
                __builder2.OpenComponent<Skclusive.Material.Grid.Grid>(42);
                __builder2.AddAttribute(43, "Item", true);
                __builder2.AddAttribute(44, "ExtraSmall", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 29 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                        GridSize.Twelve

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(45, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<pnl.Components.Toggled>(46);
                    __builder3.AddAttribute(47, "TaxformId", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 30 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                        taxFormId

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(48, "\r\n                ");
                __builder2.OpenComponent<Skclusive.Material.Grid.Grid>(49);
                __builder2.AddAttribute(50, "Item", true);
                __builder2.AddAttribute(51, "ExtraSmall", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 32 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                        GridSize.Twelve

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(52, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<pnl.Components.DependentForm>(53);
                    __builder3.AddAttribute(54, "TaxFormID", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 33 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                              taxFormId

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(55, "OnReloadDependetEvent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 33 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                                                                OnReloadDependetEvent

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(56, "\r\n                ");
                __builder2.OpenComponent<Skclusive.Material.Grid.Grid>(57);
                __builder2.AddAttribute(58, "Item", true);
                __builder2.AddAttribute(59, "ExtraSmall", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Skclusive.Material.Grid.GridSize>(
#nullable restore
#line 35 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                        GridSize.Twelve

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(60, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<pnl.Components.DependentList>(61);
                    __builder3.AddAttribute(62, "TaxFormID", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 36 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
                                              taxFormId

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 38 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
            }

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "D:\Users\diosc\Repos\pnl\Components\TaxFormPage.razor"
       

    private int taxFormId { set; get; }
    private bool ReloadDependentList { set; get; }
    private bool canDisplay { get; set; } = false;

   

    private void OnNewTaxYearEvent(int tFormId)
    {
        taxFormId = tFormId;
        if (taxFormId > 0)
        {
            canDisplay = true;            
        }

        StateHasChanged();
    }
    private void OnReloadDependetEvent(bool changed)
    {
        ReloadDependentList = changed;

       
        StateHasChanged();
    }

    protected override Task OnInitializedAsync()
    {
        if (taxFormId > 0)
        {
            canDisplay = true;
        }
        return base.OnInitializedAsync();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
