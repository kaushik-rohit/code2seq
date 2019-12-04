internal static MethodBodySemanticModel Create(CSharpCompilation compilation, MethodSymbol owner, Binder rootBinder, CSharpSyntaxNode syntax)
        {
            var executableCodeBinder = new ExecutableCodeBinder(syntax, owner, rootBinder);
            return new MethodBodySemanticModel(compilation, owner, executableCodeBinder, syntax);
        }