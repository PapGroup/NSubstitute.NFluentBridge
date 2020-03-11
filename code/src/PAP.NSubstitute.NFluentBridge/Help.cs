using System;
using NFluent;
using NSubstitute.Core.Arguments;

namespace PAP.NSubstitute.NFluentBridge
{
    /// <summary>
    /// The class that integrates NSubstitute with NFluent
    /// </summary>
    public static class Help
    {
        /// <summary>
        /// The method that verifies the arguments of called methods using NFluent
        /// </summary>
        /// <typeparam name="T">type of arguments to verify</typeparam>
        /// <param name="check">delegate that contains assertion</param>
        /// <returns>parameter of called method</returns>
        public static T Me<T>(Func<T, ICheckLink<ICheck<T>>> check)
        {
            return ArgumentMatcher.Enqueue(new NFluentMatcherAdapter<T>(check));
        }
    }
}