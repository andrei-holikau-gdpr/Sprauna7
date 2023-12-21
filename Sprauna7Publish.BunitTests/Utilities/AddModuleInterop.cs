using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.BunitTests.Utilities
{
    public static class AddModuleInterop
    {
        public static BunitJSModuleInterop BootstrapBlazorComponentsTooltip(TestContext ctx)
        {
            BunitJSModuleInterop moduleInterop 
                = ctx.JSInterop.SetupModule("./_content/BootstrapBlazor/Components/Tooltip/Tooltip.razor.js?v=7.8.6+87c25412eed65cf1367ea5b6ff1203ae08dcd5c3");
               // = ctx.JSInterop.SetupModule("./_content/BootstrapBlazor/Components/Tooltip/Tooltip.razor.js?v=7.8.5+ef653e62485b6146b335ff8607588478c69f274b");
            moduleInterop.SetupVoid("init", _ => true);
            ctx.Services.AddBootstrapBlazor();

            return moduleInterop;
        }
    }
}
