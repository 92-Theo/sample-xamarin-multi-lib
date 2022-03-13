using System;

namespace Plugin.Test.Abstractions
{
    public class TestImplementationBase : ITest
    {
        public string Text { get; protected set; }
    }
}
