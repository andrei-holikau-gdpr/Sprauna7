using AngleSharp.Dom;
using BootstrapBlazor.Components;
using Bunit;
using Bunit.TestDoubles;
using CoreBusiness;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using NuGet.Protocol.Core.Types;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using Sprauna7Publish.BunitTests.Utilities;
using Sprauna7Publish.Data;
using Sprauna7Publish.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.PurchasesUseCases;
using UseCases.UseCaseInterfaces;

namespace Sprauna7Publish.BunitTests
{
    public class PackagesComponentTests
    {
        [Fact]
        public void PackagesComponent_ViewTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var moduleInterop = AddModuleInterop.BootstrapBlazorComponentsTooltip(ctx);

            //var navRep = ctx.Services.GetRequiredService<PurchaseInMemoryRepository>();
            //Services.AddSingleton<IEditPurchaseUseCase>(new EditPurchaseUseCase());

            var navRep = ctx.Services.AddSingleton<IPurchaseRepository>(new PurchaseInMemoryRepository());

            //var navRep = ctx.Services.GetRequiredService<PurchaseInMemoryRepository>();
            var navMan = ctx.Services.GetRequiredService<IEditPurchaseUseCase>();
            //var serviceEditPurchase = ctx.Services.GetRequiredService<EditPurchaseUseCase>();


            //ctx.Services.AddSingleton<IEditPurchaseUseCase>(new EditPurchaseUseCase(navRep));

            var cut = ctx.RenderComponent<PackagesComponent>(
            // parameters => parameters
            //    .Add(p => p.BunitTest, false)
            );
            var paraElm = cut.Find("all-packages");

            // Act
            var paraElmText = paraElm.TextContent;

            // Assert
            Assert.NotNull(paraElmText);
        }

        [Fact]
        public void SimpleComponentFT_HasH1_IfAddStubTooltip()
        {
            // Register the a stub substitution.
            using var ctx = new TestContext();
            ctx.ComponentFactories.AddStub<Tooltip>();

            // var navRep = ctx.Services.AddSingleton<IPurchaseRepository>(new PurchaseInMemoryRepository());

            var mock = new Mock<IPurchaseRepository>();
            var navMan = ctx.Services.AddSingleton<IEditPurchaseUseCase>(new EditPurchaseUseCase(mock.Object));
            //var navMan = ctx.Services.GetRequiredService<IEditPurchaseUseCase>();

            // Register a mock component factory to replace multiple Bar components
            // ctx.ComponentFactories.Add<EditPurchaseUseCase>(() => Mock.Of<EditPurchaseUseCase>());

            // Render the component under test.
            IRenderedFragment cut = ctx.RenderComponent<PackagesComponent>();
            var paraElm = cut.Find("h1");
            var paraElmText = paraElm.TextContent;

            paraElmText.MarkupMatches("SimpleComponentForTesting");
        }
    }
}
