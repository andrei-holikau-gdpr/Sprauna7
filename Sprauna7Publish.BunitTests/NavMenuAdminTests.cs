using Bunit;
using Bunit.TestDoubles;
using Sprauna7Publish.BunitTests.Utilities;
using Sprauna7Publish.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.BunitTests
{
    public class NavMenuAdminTests
    {
        [Fact]
        public void NavMenuAdmin_FindTextLogViewerForOnlyAdmin()
        {
            // Arrange
            using var ctx = new TestContext();

            var moduleInterop = AddModuleInterop.BootstrapBlazorComponentsTooltip(ctx);

            var authContext = ctx.AddTestAuthorization();
            authContext.SetPolicies("AdminOnly");

            var cut = ctx.RenderComponent<NavMenuAdmin>();
            var paraElm = cut.Find(".LogViewer");

            // Act
            //cut.Find("button").Click();
            var paraElmText = paraElm.TextContent;

            // Assert 
            paraElmText.Contains("Log Viewer");
            // cut.MarkupMatches("Log Viewer");
        }

        [Fact]
        public void NavMenuAdmin_NotFindTextLogViewerForNotAuthorized()
        {
            // Arrange
            using var ctx = new TestContext();
            var moduleInterop = AddModuleInterop.BootstrapBlazorComponentsTooltip(ctx);
            var authContext = ctx.AddTestAuthorization().SetPolicies("AdminOnly");
            var cut = ctx.RenderComponent<NavMenuAdmin>();
            var renderedMarkup = cut.Markup;

            // Act

            // Assert             
            Assert.NotEqual("Log Viewer", renderedMarkup);
        }

        // NotAuthorized
    }
}
