using System;
using System.Collections.Generic;

namespace UserService.Models;

public partial class AuthCredential
{
    public int AuthCredentialId { get; set; }

    public long? UserId { get; set; }

    public string PasswordHash { get; set; } = null!;

    public DateTime PasswordChangedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User? User { get; set; }
}
