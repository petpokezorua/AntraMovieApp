﻿namespace ApplicationCore.Entities;

public class UserRole
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
    
    // Navigation 
    public User User { get; set; }
    public Role Role { get; set; }
}