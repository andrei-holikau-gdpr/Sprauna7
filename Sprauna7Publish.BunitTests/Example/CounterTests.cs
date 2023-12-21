using Bunit;
using Bunit.TestDoubles;
using Sprauna7Publish.Pages;
using Sprauna7Publish.Shared;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Humanizer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
// using Moq;
// using Sprauna7Publish.BunitTests.Utilities;

namespace Sprauna7Publish.BunitTests.Example
{
    public class CounterTests
    {
        [Fact]
        public void Counter_ShouldIncrement_WhenSelected()
        {
            // Arrange
            using var ctx = new TestContext();
            var navMan = ctx.Services.GetRequiredService<FakeNavigationManager>();
            var cut = ctx.RenderComponent<Counter>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button").Click();
            var paraElmText = paraElm.TextContent;

            // Assert
            paraElmText.MarkupMatches("Current count: 1");
        }
    }
}