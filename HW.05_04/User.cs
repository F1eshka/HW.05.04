using System;
using System.Data;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public DateTime RegisteredAt { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
}
