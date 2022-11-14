# Files with Nuget

```
*.csproj
*.fsproj
*.vbproj
*.proj
*.xproj
Directory.Build.props
Directory.Build.targets
Directory.Build.packages
global.json
*.cake
*.csx
*.props
*.targets
packages.config
```

https://docs.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference


## XML editing


XmlDocument has a property PreserveWhitespace. If you set this to true insignificant whitespace will be preserved.

See MSDN

EDIT

If I execute the following code, whitespace including line breaks is preserved. (It's true that a space is inserted between <b and />)

XmlDocument doc = new XmlDocument();
doc.PreserveWhitespace = true;
doc.LoadXml(
    @"<a>
       <b/>
    </a>");
Console.WriteLine(doc.InnerXml);

        XmlDocument testDoc = new XmlDocument();
        testDoc.PreserveWhitespace = true;
        testDoc.Load("Test.xml");
        testDoc.Save("Output.xml");

To change this behaviour, set PreserveWhitespace = true before loading your XML:

var xmlDocument = new XmlDocument
{
    PreserveWhitespace = true
};


LINQ to XML

As an aside, I'd strongly suggest looking at LINQ to XML instead of the old XmlDocument API. To get the similar behaviour in XDocument, you would parse and write like so:

var doc = XDocument.Load(filePath, LoadOptions.PreserveWhitespace);
doc.WriteTo(writer);
If, as your code suggests, you are removing attributes then code as simple as this would remove all attributes with the name string from elements with the name xmlField:

doc.Descendants("xmlField")
    .SelectMany(e => e.Attributes("string"))
    .Remove();

https://docs.microsoft.com/en-us/dotnet/standard/linq/preserve-white-space-loading-parsing-xml

