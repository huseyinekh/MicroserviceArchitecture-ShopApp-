// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace MyIdentityServer
{

    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("catalog_resource"){Scopes={"full_permission_catalog"}},
                new ApiResource("photostock_resource"){Scopes={"full_permission_photostock"}},
                new ApiResource("basket_resource"){Scopes={"full_permission_basket"}},
                new ApiResource("discount_resource"){Scopes={"full_permission_discount"}},
                new ApiResource("order_resource"){Scopes={"full_permission_order"}},
                new ApiResource("payment_resource"){Scopes={"full_permission_payment"}},
                new ApiResource("webgateway_resource"){Scopes={"full_permission_webgateway"}}




            };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email()
                       , new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){ Name="roles", DisplayName="Roles"
                                    , Description="user rollar",UserClaims= new []{"role"} }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
               new ApiScope("full_permission_catalog","full access catalog"),
               new ApiScope("full_permission_photostock","full access photostock"),
               new ApiScope("full_permission_basket","full access basket"),
               new ApiScope("full_permission_discount","full access discount"),
               new ApiScope("full_permission_order","full access order"),
               new ApiScope("full_permission_payment","full access payment"),
               new ApiScope("full_permission_webgateway","full access webgateway_resource"),


               new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                      ClientName="huseyn",
                      ClientId="myid",
                      ClientSecrets={new Secret("secret".Sha256())},
                      AllowedGrantTypes=GrantTypes.ClientCredentials,
                      AllowedScopes={ "full_permission_catalog"
                                    , "full_permission_photostock",
                                      "full_permission_webgateway",
                                       IdentityServerConstants.LocalApi.ScopeName }
                }
                ,
                new Client()
                {
                      ClientName="huseynUser",
                      ClientId="myid2",
                      AllowOfflineAccess=true,
                      ClientSecrets={new Secret("secret".Sha256())},
                       AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,

                       AllowedScopes={
                                        "full_permission_discount",
                                        "full_permission_webgateway",
                                        "full_permission_order",
                                        "full_permission_basket",
                                        "full_permission_payment",
                                        IdentityServerConstants.StandardScopes.Email,
                                        IdentityServerConstants.StandardScopes.Profile
                                       ,IdentityServerConstants.StandardScopes.OpenId
                                       ,IdentityServerConstants.StandardScopes.OfflineAccess,"roles",
                                        IdentityServerConstants.LocalApi.ScopeName}
                    ,AccessTokenLifetime=1*60*60,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds
                    ,RefreshTokenExpiration=TokenExpiration.Absolute,
                    RefreshTokenUsage=TokenUsage.ReUse
                }

            };
    }
}