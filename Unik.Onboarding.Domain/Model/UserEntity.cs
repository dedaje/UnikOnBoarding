using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Unik.Onboarding.Domain.Model;

public class UserEntity : IdentityUser
{
    // For Entity Framework only!!!
    internal UserEntity()
    {
    }

    public UserEntity(string firstName, string lastName, string email, int phone, int roleId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        RoleId = roleId;
    }

    public int UserId { get; } // PK
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public int Phone { get; private set; }
    [ForeignKey("RoleId")] public RoleEntity RoleEntity { get; set; }
    public int RoleId { get; set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(string firstName, string lastName, string email, int phone, int roleId, byte[] rowVersion)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        RoleId = roleId;
        RowVersion = rowVersion;

        throw new NotImplementedException();
    }
}