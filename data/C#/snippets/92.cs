internal static MethodBodySemanticModel Create(CSharpCompilation compilation, MethodSymbol owner, Binder rootBinder, ArrowExpressionClauseSyntax syntax)
        {
            Binder binder = new ExecutableCodeBinder(syntax, owner, rootBinder);
            return new MethodBodySemanticModel(compilation, owner, binder, syntax);
        }