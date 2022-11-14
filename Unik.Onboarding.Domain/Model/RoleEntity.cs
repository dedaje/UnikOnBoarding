using System.ComponentModel.DataAnnotations;

namespace Unik.Onboarding.Domain.Model;

public class RoleEntity
{
    // For Entity Framework only!!!
    internal RoleEntity()
    {
    }

    public RoleEntity(string roleName)
    {
        RoleName = roleName;
    }

    public int RoleId { get; } // PK
    public string RoleName { get; private set; }

    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(string roleName, byte[] rowVersion)
    {
        RoleName = roleName;
        RowVersion = rowVersion;

        throw new NotImplementedException();
    }
}