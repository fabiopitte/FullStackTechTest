using System;
using System.Collections.Generic;
using System.Text;

namespace TestDFO.Domain.IoC
{
    public class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var types = new Dictionary<Type, Type>();

            types.Add(typeof(Interface.IUserService), typeof(UserService));

            return types;
        }
    }
}
