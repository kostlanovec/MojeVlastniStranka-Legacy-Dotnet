using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MojeVlastniStranka.DataAccess.Entities
{
    /// <summary>
    /// Definuje třídu reprezentující uživatele.
    /// </summary>
    public class User: IdentityUser<Guid>, IEntities
    {
    }
}
