using Plugin.Test.Abstractions;
using System;

namespace Plugin.Test
{
    public static class CrossTest
    {
        static readonly Lazy<ITest> Implementation = new Lazy<ITest>(CreateImplementation, System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current bluetooth LE implementation.
        /// </summary>
        public static ITest Current
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("CrossTest.Current");
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static ITest CreateImplementation()
        {
#if PORTABLE
            System.Diagnostics.Debug.WriteLine("CrossTest.CreateImplementation,ret=null");
            return null;
#else
            var implementation = new TestImplementation();
            System.Diagnostics.Debug.WriteLine($"CrossTest.CreateImplementation,ret={implementation.Text}");
            return implementation;
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
