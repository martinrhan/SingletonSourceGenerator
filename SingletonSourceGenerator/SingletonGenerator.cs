using Microsoft.CodeAnalysis;
using System;

namespace SingletonSourceGenerator;

[Generator]
public class SingletonGenerator : IIncrementalGenerator {
    public void Initialize(IncrementalGeneratorInitializationContext context) {
        var provider_typeSymbols =
            context.SyntaxProvider
                .ForAttributeWithMetadataName("SingletonSourceGenerator.Attributes.SingletonAttribute", (_, _) => true,
                    (context, token) => {
                        var symbol = context.SemanticModel.GetDeclaredSymbol(context.TargetNode, token);
                        var ts = symbol as ITypeSymbol;
                        return ts;
                    }
                );

        context.RegisterSourceOutput(provider_typeSymbols, static (context, ts) => {
            if (ts == null) return;
            string code = $$"""
            #nullable enable
            namespace {{ts.ContainingNamespace}};
            public partial class {{ts.Name}}{
                private static {{ts.Name}}? instance;
                public static {{ts.Name}} Instance => instance ??= new();
            }
            """;
            context.AddSource($"{ts.Name}.Singleton.cs", code);
        });
    }
}
