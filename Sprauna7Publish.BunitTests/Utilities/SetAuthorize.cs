using Bunit;
using Bunit.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.BunitTests.Utilities
{
    public static class SetAuthorize
    {
        public static TestAuthorizationContext Execute(TestContext ctx)
        {
            var authContext = ctx.AddTestAuthorization(); //authContext.SetAuthorizing();
            authContext.SetAuthorized("kudesnik.Net@gmail.com");
            authContext.SetRoles("Admin");
            authContext.SetPolicies("AdminOnly");

            return authContext;
        }
    }
}
