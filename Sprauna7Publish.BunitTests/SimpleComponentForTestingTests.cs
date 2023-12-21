using BootstrapBlazor.Components;
using Bunit;
using Bunit.TestDoubles;
using Sprauna7Publish.BunitTests.Utilities;
using Sprauna7Publish.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.BunitTests
{
    public class SimpleComponentForTestingTests
    {
        [Fact]
        public void SimpleComponentFT_HasTooltip_IfAddComponentsTooltip()
        {
            // Arrange
            using var ctx = new TestContext();
            var moduleInterop = AddModuleInterop.BootstrapBlazorComponentsTooltip(ctx);
            var cut = ctx.RenderComponent<SimpleComponentForTesting>(
            //    parameters => parameters.Add(p => p.BunitTest, false)
            );
            var paraElm = cut.Find(".sp-navlink-text");

            // Act
            var paraElmText = paraElm.TextContent;

            // Assert
            paraElmText.MarkupMatches("Figma");
        }

        [Fact]
        public void SimpleComponentFT_HasH1_IfAddStubTooltip()
        {
            // Register the a stub substitution.
            using var ctx = new TestContext();
            ctx.ComponentFactories.AddStub<Tooltip>();

            // Render the component under test.
            IRenderedFragment cut = ctx.RenderComponent<SimpleComponentForTesting>();
            var paraElm = cut.Find("h1");
            var paraElmText = paraElm.TextContent;

            paraElmText.MarkupMatches("SimpleComponentForTesting");

            // Verify that the Bar component has 
            // been substituted in the render tree.
            // Assert.False(cut.HasComponent<Tooltip>());
            // Assert.True(cut.HasComponent<Stub<Tooltip>>());
        }
    }
}
