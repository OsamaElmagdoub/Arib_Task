using System.Reflection;
using System.Runtime.Loader;

namespace Arib_Task.Areas.Admin.Helpers
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            if (!File.Exists(absolutePath))
                throw new FileNotFoundException($"DLL not found: {absolutePath}");

            try
            {
                return LoadUnmanagedDllFromPath(absolutePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to load unmanaged DLL from path: {absolutePath}", ex);
            }
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            // مش هنحمل مكتبات Managed في السياق ده
            return null;
        }
    }
}



//using System;
//using System.IO;
//using System.Reflection;
//using System.Runtime.Loader;

//namespace Arib_Task.Areas.Admin.Helpers
//{
//    public class CustomAssemblyLoadContext : AssemblyLoadContext
//    {
//        public IntPtr LoadUnmanagedLibrary(string absolutePath)
//        {
//            if (!File.Exists(absolutePath))
//                throw new FileNotFoundException($"DLL not found: {absolutePath}");

//            try
//            {
//                return LoadUnmanagedDllFromPath(absolutePath);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Unable to load unmanaged DLL from path: {absolutePath}", ex);
//            }
//        }

//        protected override Assembly Load(AssemblyName assemblyName)
//        {
//            // إحنا مش بنحمل مكتبات Managed هنا
//            return null;
//        }
//    }
//}
