using System;
using Domain.UserScope.ValueObjects;

namespace Domain.AuthScope.Actions;

public record AuthData(string UserId, string Role, string Email);