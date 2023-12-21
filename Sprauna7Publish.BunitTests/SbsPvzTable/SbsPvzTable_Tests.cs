using Bunit;
using CoreBusiness.ShopByShop.Models;
using Sprauna7Publish.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.BunitTests
{
    public class SbsPvzTable_Tests
    {
        [Fact]
        public void SbsPvz_ComponentOpensWithoutError_WhenListIsFill()
        {   // Arrange
            using var ctx = new TestContext();
            ctx.JSInterop.SetupVoid("InitialiseTable").SetVoidResult(); 
            var cut = ctx.RenderComponent<SbsPvzTable>(
                parameters => parameters
                    .Add(p => p.PvzSbss, new List<PvzItem>() {
                        new PvzItem()
                        {
                            gipermall_id= 1,
                            hide = 0,
                            value = "Минск"
                        }})
                    .Add( p => p.Update, true));
            AngleSharp.Dom.IElement elementSbsPvzTable = cut.Find("table");
            // Act
            // Assert
            Assert.NotNull(elementSbsPvzTable);
        }

        [Fact]
        public void SbsPvz_ComponentOpensWithoutError_WhenListIsNull()
        {   // Arrange
            using var ctx = new TestContext();
            ctx.JSInterop.SetupVoid("InitialiseTable").SetVoidResult();
            var cut = ctx.RenderComponent<SbsPvzTable>(
                parameters => parameters
                    .Add(p => p.PvzSbss, null)
                    .Add(p => p.Update, true));
            var elementListIsNull = cut.Find(".ListPvzIsNull");
            // Act
            // Assert
            Assert.NotNull(elementListIsNull);
        }
    }
}
