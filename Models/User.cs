using System;
using System.Collections.Generic;

namespace UserService.Models;

public partial class User
{
    public long UserId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? ProfileImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AuthCredential> AuthCredentials { get; set; } = new List<AuthCredential>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
