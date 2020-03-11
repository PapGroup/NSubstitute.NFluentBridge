# NSubstitute.NFluentBridge
a library for bridging between NSubstitute and NFluent

## Build
| Branch | Status |
|:------:|:------:|
| Master | [![Build Status](https://dev.azure.com/papgroup/NSubstitute.NFluentBridge/_apis/build/status/PapGroup.NSubstitute.NFluentBridge?branchName=master)](https://dev.azure.com/papgroup/NSubstitute.NFluentBridge/_build/latest?definitionId=1&branchName=master) |
| Develop | [![Build Status](https://dev.azure.com/papgroup/NSubstitute.NFluentBridge/_apis/build/status/PapGroup.NSubstitute.NFluentBridge?branchName=develop)](https://dev.azure.com/papgroup/NSubstitute.NFluentBridge/_build/latest?definitionId=1&branchName=develop) |

## Usage
The library provides a static method called 'Help.Me<T>' that takes an 'Func' which returns an 'ICheck'.
For example, the following code verifies that 'Register' method called with expected object one time :

```c#
using PAP.NSubstitute.NFluentBridge;

...
var service = Substitute.For<IRegistrationService>();
...
...
service.Received(1).Register(Help.Me<string>(username => Check.That(username).Not.Contains("Joker").And.StartsWith("Bat")));
```