# XmlObjectSerializer

# Description
Package that allows you to serialize an object in a XML file.
The parent class of the object must have:
  - A neutral ctor
  - The public properties whit getter and setter methods

# Usage
## Write
MyClass class = new MyClass();
string path = ".";
Serializer<MyClass> serializer = new Serializer<MyClass>();
serializer.ExportXml(stf, path);
