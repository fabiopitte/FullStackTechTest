using System;
using System.Collections.Generic;

namespace TestDFO.Application.IoC
{
    public class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var types = new Dictionary<Type, Type>();

            types.Add(typeof(Interface.IUserAppService), typeof(UserAppService));

            return types;
        }
    }
}
