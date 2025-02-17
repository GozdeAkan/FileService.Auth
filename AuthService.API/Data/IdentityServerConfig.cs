using Duende.IdentityServer.Models;

namespace AuthService.API.Data
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                    new Client
                    {
                        ClientId = "file-service-client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        ClientSecrets = { new Secret("supersecret".Sha256()) },
                        AllowedScopes = { "file-service.read", "file-service.write" }
                    }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                    new ApiScope("file-service.read", "File Service API - Read Access"),
                    new ApiScope("file-service.write", "File Service API - Write Access")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                    new ApiResource("file-service", "File Service API")
                    {
                        Scopes = { "file-service.read", "file-service.write" }
                    }
            };
    }
    }