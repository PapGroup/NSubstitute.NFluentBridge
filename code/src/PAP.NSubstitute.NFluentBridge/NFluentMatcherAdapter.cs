using System;
using NFluent;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;

namespace PAP.NSubstitute.NFluentBridge
{
    internal class NFluentMatcherAdapter<T> : IArgumentMatcher<T>, IDescribeNonMatches
    {
        private string _error = "";
        private readonly Func<T, ICheckLink<ICheck<T>>> _check;
        public NFluentMatcherAdapter(Func<T, ICheckLink<ICheck<T>>> check)
        {
            _check = check;
        }
        public bool IsSatisfiedBy(T argument)
        {
            try
            {
                _check.Invoke(argument);
                return true;
            }
            catch (Exception e)
            {
                _error = e.Message;
                return false;
            }
        }
        public string DescribeFor(object argument)
        {
            return _error;
        }
    }
}