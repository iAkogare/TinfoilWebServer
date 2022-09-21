﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using TinfoilWebServer.Services;

namespace TinfoilWebServer.Settings;

public interface IAppSettings
{
    string[] AllowedExt { get; }

    /// <summary>
    /// The list of served directories rooted
    /// </summary>
    string[] ServedDirectories { get; }

    IConfiguration KestrelConfig { get; }

    IConfiguration LoggingConfig { get; }

    string? MessageOfTheDay { get; }

    TinfoilIndexType IndexType { get; }

    TimeSpan CacheExpiration { get; }

    IAuthenticationSettings? AuthenticationSettings { get; }
}

public class AuthenticationSettings : IAuthenticationSettings
{
    public bool Enabled { get; init; }

    public IReadOnlyList<IAllowedUser> AllowedUsers { get; init; } = Array.Empty<IAllowedUser>();
}

public interface IAuthenticationSettings
{
    public bool Enabled { get; }

    public IReadOnlyList<IAllowedUser> AllowedUsers { get; }
}

public interface IAllowedUser
{
    public string Name { get; }

    public string Password { get; }
}

public class AllowedUser : IAllowedUser
{
    public string Name { get; init; }

    public string Password { get; init; }
}