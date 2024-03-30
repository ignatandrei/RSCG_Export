using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Immutable;

namespace RSCG_Export;
[Generator]
public class GenerateDocs : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classesToIntercept = context.SyntaxProvider.CreateSyntaxProvider(
              predicate: (s, _) => IsSyntaxTargetForGeneration(s),
              transform: static (context, token) =>
              {                  
                  var operation = context.SemanticModel.GetOperation(context.Node, token);
                  return operation;
              })
          .Where(static m => m is not null)!
          .Select((it,_)=>it!)
          .Collect();
          ;

        context.RegisterSourceOutput(classesToIntercept, Generate);
    }

    private void Generate(SourceProductionContext context, ImmutableArray<IOperation> array)
    {
        foreach (var operation in array)
        {
            var node=operation.Syntax;
            if(node == null)
                continue;   

            var location = node?.GetLocation();
            
            if (operation is IInvocationOperation invocationOperation)
            {
                
                var invocation = (IInvocationOperation)operation;
                var target = invocation.TargetMethod;
                var instance = invocation.Instance ;
                var data = new DataToBeWritten(node!, invocation);
                continue;
            }
            
            Console.WriteLine(operation?.ToString());
        }
    }

    private bool IsSyntaxTargetForGeneration(SyntaxNode s)
    {

        if (!TryGetMapMethodName(s, out var method))
            return false;
        return true;

    }
    public static bool TryGetMapMethodName(SyntaxNode node, out string? methodName)
    {
        if (node is not InvocationExpressionSyntax inv)
        {
            methodName = default;
            return false;
        }
        methodName = default;
        if (inv is InvocationExpressionSyntax { Expression: IdentifierNameSyntax { Identifier: { ValueText: var methodValue } } })
        {
            methodName = methodValue;
        }
        if (inv is InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax { Name: { Identifier: { ValueText: var method } } } })
        {
            methodName = method;
        }
        if (string.IsNullOrWhiteSpace(methodName))
            return false;
        return true;
    }
}
