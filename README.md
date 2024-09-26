# SingletonSourceGenerator
This source generator helps you to automatically implement a singleton pattern.
To use this, simply add [Singleton] attribute to your partial class.
```
using SingletonSourceGenerator.Attributes;

namespace MyNamespace;

[Singleton]
public patial class MyClass{
}
```
This will generate
```
namespace MyNamespace;

public partial class MyClass{
	private static MyClass? instance;
	public static MyClass Instance => instance ??= new();
}
```