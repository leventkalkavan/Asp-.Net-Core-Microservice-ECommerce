using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
        new ApiResource("ResourceDiscount") { Scopes = { "DiscountFullPermission" } },
        new ApiResource("ResourceOrder") { Scopes = { "OrderFullPermission" } },
    };

    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope("CatalogFullPermission", "Full authority for Catalog"),
        new ApiScope("CatalogReadPermission", "Reading authority for Catalog"),
        new ApiScope("DiscountFullPermission", "Full authority for Permission"),
        new ApiScope("OrderFullPermission", "Full authority for Order")
    };

    public static IEnumerable<Client> Clients => new Client[]
    {
        new Client()
        {
            ClientId = "MultiShopVisitorId",
            ClientName = "Multi Shop Visitor User",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes = { "CatalogReadPermission" }
        },

        new Client()
        {
            ClientId = "MultiShopManagerId",
            ClientName = "Multi Shop Manager User",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission" }
        },

        new Client()
        {
            ClientId = "MultiShopAdminId",
            ClientName = "Multi Shop Admin User",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes =
            {
                "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
            },
            AccessTokenLifetime = 1200
        }
    };
}