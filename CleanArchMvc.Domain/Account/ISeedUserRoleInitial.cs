using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Account;

// Interface para a criação de usuários com roles inicias
public interface ISeedUserRoleInitial
{
    void SeedUsers();
    void SeedRoles();
}
