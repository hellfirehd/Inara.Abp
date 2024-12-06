﻿namespace Inara.Abp.OpenId;

public interface IOpenIdEndpointProvider : IEnumerable<OpenIdEndpoint>
{
    OpenIdEndpoint this[String key] { get; }
}