using IdentityServer4.Models;
using System.Collections.Generic;

namespace AgbIdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope("inventoryapi.read"),

            new ApiScope("inventoryapi.write")
        };

       public static IEnumerable<Client> Clients => new[]
       {
            new Client
            {
                ClientId="Inventory",
                ClientName="Inventory Api",
                AllowedGrantTypes=GrantTypes.ClientCredentials,//it is used by client to obtain access token outside user context
                ClientSecrets={new Secret("MyCientSecret".Sha256()) },//client is aware of this value
                AllowedScopes={ "inventoryapi.read", "inventoryapi.write" }

            }

        };
        public static IEnumerable<ApiResource> ApiResources => new[]// this is what we try to protect
       {
            new ApiResource("inventoryapi")
            {
                Scopes= new List<string>{"inventoryapi.read", "inventoryapi.write"},
                ApiSecrets=new List<Secret>{new Secret("ScopeSecret".Sha256())},//client is aware of this value
                UserClaims= new List<string>{"role" }

            }

        };
    }
}
