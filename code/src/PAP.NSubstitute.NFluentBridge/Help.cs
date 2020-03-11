using System;
using NFluent;
using NSubstitute.Core.Arguments;

namespace PAP.NSubstitute.NFluentBridge
{
    public static class Help
    {
        public static T Me<T>(Func<T, ICheckLink<ICheck<T>>> check)
        {
            return ArgumentMatcher.Enqueue(new NFluentMatcherAdapter<T>(check));
        }
    }
}