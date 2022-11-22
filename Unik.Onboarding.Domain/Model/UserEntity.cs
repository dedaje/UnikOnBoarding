using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unik.Onboarding.Domain.Model;

public class UserEntity
{
    // For Entity Framework only!!!
    internal UserEntity()
    {
    }

    public UserEntity(string userId, string name, int phone, int roleId)
    {
        UserId = userId;
        Name = name;
        Phone = phone;
        RoleId = roleId;
    }

    public int Id { get; private set; }
    public string UserId { get; private set; } // Email
    public string Name { get; private set; }
    public int Phone { get; private set; }
    [ForeignKey("RoleId")] public RoleEntity RoleEntity { get; set; }
    public int RoleId { get; private set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(string userId, string name, int phone, int roleId, byte[] rowVersion)
    {
        UserId = userId;
        Name = name;
        Phone = phone;
        RoleId = roleId;
        RowVersion = rowVersion;
    }
}