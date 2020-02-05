using Microsoft.Extensions.Options;
using System;

namespace UserSecrets
{
    public class SecretService : ISecretService
    {
        private readonly Secrets _secrets;
        public SecretService(IOptions<Secrets> secrets)
        {
            // We want to know if secrets is null so we throw an exception if it is
            _secrets = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
        }

        public string GetASecret()
        {
            return _secrets.ApiKey;
        }
    }
}
