using MpmClient.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MpmClient.Core
{
    internal class ModuleFactory
    {
        public enum ApplicationModules { USERS }

        public static IAppModule CreateModule(ApplicationModules module)
        {
            return module switch
            {
                ApplicationModules.USERS => new Modules.Users.Base(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
