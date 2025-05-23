﻿using System.Text;

namespace Tabibi.Domain.Shared.Helpers;

public class JwtSettings
{
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifeTime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }

    public byte[] GenerateSymmetricKey()
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(Secret);

        if (keyBytes.Length < 32)
        {
            Array.Resize(ref keyBytes, 32);
        }

        return keyBytes;
    }
}
