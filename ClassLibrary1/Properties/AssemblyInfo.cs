using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("DAL.Test.Unit")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("DAL.Test.Unit")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("2effd9a8-3bd2-4bec-a980-ca17c6e26222")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

//The job of a remote API client is to issue certain calls - no more, no less. Therefore, its test should verify that it issues those calls - no more, no less.
//Sure, if the API provider changes the semantics of their responses, then your system will fail in production. 
//But that isn't your client class's fault; it's something that can only be caught in integration tests.
//By relying on code not under your control you have given up the ability to verify correctness via internal testing - it was a trade-off, and this is the price.
//That said, testing a class that consists only of delegations to another class may be low-priority, because there is comparatively little risk of complex errors. 
//    But that goes for any class that consists only of uniform one-liners, it has nothing to do with calling out into another vendor's code.