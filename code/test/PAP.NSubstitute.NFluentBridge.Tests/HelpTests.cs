using System;
using System.Data.SqlTypes;
using NFluent;
using NSubstitute;
using PAP.NSubstitute.NFluentBridge.Tests.TestUtils;
using Xunit;

namespace PAP.NSubstitute.NFluentBridge.Tests
{
    public class HelpTests
    {
        [Fact]
        public void should_check_method_arguments_using_nfluent()
        {
            var service = Substitute.For<IRegistrationService>();
            service.Register("Admin");

            service.Received(1).Register(Help.Me<string>(a => Check.That(a).StartsWith("Adm")));
        }

        [Fact]
        public void should_include_nfluent_message_in_exceptions()
        {
            var service = Substitute.For<IRegistrationService>();
            service.Register("FakeUser");
            void VerificationWithNSubstitute() =>
                service.Received(1)
                    .Register(Help.Me<string>(a => Check.That(a).StartsWith("adm")));

            var nsubstituteMessage = GetExceptionMessageOf(VerificationWithNSubstitute);

            Check.That(nsubstituteMessage).Contains("The checked string's start is different from the expected one.");
        }

        private string GetExceptionMessageOf(Action action)
        {
            try
            {
                action();
                return string.Empty;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
