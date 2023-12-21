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
    public class SbsRecipientTable_Tests
    {
        [Fact]
        public void SbsRecipientTable_ComponentOpensWithoutError_WhenListIsFill()
        {   // Arrange
            using var ctx = new TestContext();
            ctx.JSInterop.SetupVoid("InitialiseTable").SetVoidResult();
            var cut = ctx.RenderComponent<SbsRecipientTable>(
                parameters => parameters
                    .Add(p => p.RecipientSbss, new List<RecipientItem>() {
                        new RecipientItem()
                        {
                            //gipermall_id= 1,

                        }})
                    .Add(p => p.Update, true));
            AngleSharp.Dom.IElement elementSbsPvzTable = cut.Find("table");

            // Act

            // Assert
            Assert.NotNull(elementSbsPvzTable);
        }

        [Fact]
        public void SbsRecipientTable_ComponentOpensWithoutError_WhenListIsNull()
        {   // Arrange
            using var ctx = new TestContext();
            ctx.JSInterop.SetupVoid("InitialiseTable").SetVoidResult();
            var cut = ctx.RenderComponent<SbsRecipientTable>(
                parameters => parameters
                    .Add(p => p.RecipientSbss, null)
                    .Add(p => p.Update, true));
            var elementListPvzIsNull = cut.Find(".ListPvzIsNull");

            // Act

            // Assert
            Assert.NotNull(elementListPvzIsNull);
        }
    }
}
