using System;

namespace SingletonSourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
[System.Diagnostics.Conditional("DEBUG")]
public class SingletonAttribute : Attribute {

}

