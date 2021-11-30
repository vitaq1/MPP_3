using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowsing
{
    public class AssemblyBrowser
    {
        public AssemblyInformation BrowseAssembly(Assembly assembly)
        {
            Type[] types;
            string assemblyName = assembly.FullName;
            AssemblyInformation assemblyInfo = new AssemblyInformation(assemblyName);

            types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (!type.IsDefined(typeof(CompilerGeneratedAttribute), false))
                {
                    NamespaceInformation namespaceInfo = new NamespaceInformation(type.Namespace);
                    string namespaceName = namespaceInfo.NamespaceName;
                    if (!assemblyInfo.NamespaceList.ContainsKey(namespaceName))
                    {
                        assemblyInfo.NamespaceList.Add(namespaceName, namespaceInfo);
                    }
                    TypeInformation typeInfo = new TypeInformation(type);
                    FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (fields != null)
                    {
                        foreach (FieldInfo field in fields)
                        {
                            if (!field.IsDefined(typeof(CompilerGeneratedAttribute), false))
                            {
                                typeInfo.FieldList.Add(field);
                            }
                        }
                    }
                    PropertyInfo[] properties = type.GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (properties != null)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            if (!property.IsDefined(typeof(CompilerGeneratedAttribute), false))
                            {
                                typeInfo.PropertyList.Add(property);
                            }
                        }
                    }
                    MethodInfo[] methods = type.GetMethods();
                    if (methods != null)
                    {
                        foreach (MethodInfo method in methods)
                        {
                            if (!method.IsDefined(typeof(CompilerGeneratedAttribute), false))
                            {
                                typeInfo.MethodList.Add(method);
                            }
                        }
                    }
                    assemblyInfo.NamespaceList[namespaceName].TypeList.Add(typeInfo);
                }
            }
            return assemblyInfo;
        }
    }
}
