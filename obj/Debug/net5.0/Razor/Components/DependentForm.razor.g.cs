#pragma checksum "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f14fee223abd65307ad7ab9935086bd889e857a"
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
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "add-dependent-form");
            __builder.AddMarkupContent(2, "<div class=\"dependentlist-info\">\r\n        If any dependent please complete the following form.\r\n    </div>\r\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(3);
            __builder.AddAttribute(4, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 7 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                     dependent

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 7 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                               AddDependent

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n    \r\n    \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(9);
                __builder2.AddAttribute(10, "placeholder", "first name");
                __builder2.AddAttribute(11, "style", "width:100%;");
                __builder2.AddAttribute(12, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                        dependent.FirstName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => dependent.FirstName = __value, dependent.FirstName))));
                __builder2.AddAttribute(14, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => dependent.FirstName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(15, "\r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateValidationMessage_0(__builder2, 16, 17, "color:red;", 18, 
#nullable restore
#line 12 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                                           ()=>dependent.FirstName

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(19, "\r\n    \r\n    \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(20);
                __builder2.AddAttribute(21, "placeholder", "first name");
                __builder2.AddAttribute(22, "style", "width:100%;");
                __builder2.AddAttribute(23, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                        dependent.LastName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(24, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => dependent.LastName = __value, dependent.LastName))));
                __builder2.AddAttribute(25, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => dependent.LastName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(26, "\r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateValidationMessage_1(__builder2, 27, 28, "color:red;", 29, 
#nullable restore
#line 16 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                                           ()=>dependent.LastName

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(30, "\r\n    \r\n    \r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateInputDate_2(__builder2, 31, 32, "birthday", 33, "width:100%;", 34, 
#nullable restore
#line 19 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                        dependent.Birthday

#line default
#line hidden
#nullable disable
                , 35, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => dependent.Birthday = __value, dependent.Birthday)), 36, () => dependent.Birthday);
                __builder2.AddMarkupContent(37, "\r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateValidationMessage_3(__builder2, 38, 39, "color:red;", 40, 
#nullable restore
#line 20 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                                           ()=>dependent.Birthday

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(41, "\r\n    \r\n    \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(42);
                __builder2.AddAttribute(43, "placeholder", "SSN");
                __builder2.AddAttribute(44, "style", "width:100%;");
                __builder2.AddAttribute(45, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                        dependent.SSN

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(46, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => dependent.SSN = __value, dependent.SSN))));
                __builder2.AddAttribute(47, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => dependent.SSN));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(48, "\r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateValidationMessage_4(__builder2, 49, 50, "color:red;", 51, 
#nullable restore
#line 24 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                                           ()=>dependent.SSN

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(52, "\r\n    \r\n    \r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateInputNumber_5(__builder2, 53, 54, "Month In Home", 55, "width:100%;", 56, 
#nullable restore
#line 27 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                          dependent.MonthInHome

#line default
#line hidden
#nullable disable
                , 57, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => dependent.MonthInHome = __value, dependent.MonthInHome)), 58, () => dependent.MonthInHome);
                __builder2.AddMarkupContent(59, "\r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateValidationMessage_6(__builder2, 60, 61, "color:red;", 62, 
#nullable restore
#line 28 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                                           ()=>dependent.MonthInHome

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(63, "\r\n    \r\n    \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(64);
                __builder2.AddAttribute(65, "placeholder", "Relationship");
                __builder2.AddAttribute(66, "style", "width:100%;");
                __builder2.AddAttribute(67, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                        dependent.RelationshipName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(68, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => dependent.RelationshipName = __value, dependent.RelationshipName))));
                __builder2.AddAttribute(69, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => dependent.RelationshipName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(70, "\r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateValidationMessage_7(__builder2, 71, 72, "color:red;", 73, 
#nullable restore
#line 32 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                                           ()=>dependent.RelationshipName

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(74, "\r\n    \r\n    \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(75);
                __builder2.AddAttribute(76, "placeholder", "Code");
                __builder2.AddAttribute(77, "style", "width:100%;");
                __builder2.AddAttribute(78, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                        dependent.Code

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(79, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => dependent.Code = __value, dependent.Code))));
                __builder2.AddAttribute(80, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => dependent.Code));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(81, "\r\n                ");
                __Blazor.pnl.Components.DependentForm.TypeInference.CreateValidationMessage_8(__builder2, 82, 83, "color:red;", 84, 
#nullable restore
#line 36 "D:\Users\diosc\Repos\pnl\Components\DependentForm.razor"
                                                           ()=>dependent.Code

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(85, "\r\n    \r\n    \r\n                ");
                __builder2.AddMarkupContent(86, "<button type=\"submit\" class=\"btn-Add-Dependent\">\r\n                   Add New Dependent\r\n                </button>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
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
namespace __Blazor.pnl.Components.DependentForm
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateInputDate_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputDate<TValue>>(seq);
        __builder.AddAttribute(__seq0, "placeholder", __arg0);
        __builder.AddAttribute(__seq1, "style", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateInputNumber_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "placeholder", __arg0);
        __builder.AddAttribute(__seq1, "style", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_6<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_7<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_8<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591