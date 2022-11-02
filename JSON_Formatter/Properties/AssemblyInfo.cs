using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyCompany("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyTitle("Mobius")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("Mobius")]
[assembly: AssemblyTrademark("JoeWare")]
[assembly: AssemblyCopyright("Copyright © 2019")]
[assembly: AssemblyDescription("The Mobius Tool is designed to allow for more simple navigation within larger json files.\r\n\r\n" +
                               "By Right-Clicking on a node in the tree view, the object path can be copied to the clip board\r\n" +
                               "for ease of use in testing Asserts.\r\n\r\n" +
                               "JSON may be loaded from a file, pasted, or typed directly into the JSON Text area.\r\n\r\n" +
                               "* Right-Click on some things for control specific options.\r\n\r\n" +
                               "On the JSON Text:\r\n\r\n" +
                               "Search\t\t\tSearch through the Tree for a value\r\n" +
                               "Copy Selected Text:\tCopies the text that is highlighted\r\n" +
                               "Toggle JSON Format:\tMakes the JSON one line, or Formatted\r\n" +
                               "New JSON:\t\tClears the JSON and Tree, and makes ready for typing\r\n" +
                               "Build The Tree:\t\tAttempt to parse the text as JSON, and create a Tree View from it\r\n" +
                               "Fixuip JSON:\t\t(Token Related) attempts to wrap tokens in double quotes to parse better\r\n" +
                               "List Tokens:\t\tIf tokens are present in the JSON, returns a unique, sorted list of them\r\n\r\n" +
                               "On the Treeview:\r\n\r\n" +
                               "Copy:\t\t\tCopies the current node text\r\n" +
                               "Search:\t\t\tSearch through the Tree for a value\r\n" +
                               "Toggle Node Expansion:\tDeep node expansion (Can take a while)\r\n" +
                               "Copy Node Path:\t\tCopies the path for the given node to the Clipboard\r\n" +
                               "Decompose Node:\t\t(Specialized) Works best on Arrays, list the entries\r\n" +
                               "List Tokens:\t\tIf tokens are present in the JSON, returns a unique, sorted list of them\r\n\r\n")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("d248719d-7a08-4a44-89a8-84680d94d513")]

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

[assembly: AssemblyVersion("3.4.*")]
[assembly: AssemblyFileVersion("3.4.0.0")]
