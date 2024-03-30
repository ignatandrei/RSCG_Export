using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RSCG_Export;

public class RefereeData : DataCollected
{
    public RefereeData(SyntaxNode syntaxNode)
    {
        var loc = syntaxNode.GetLocation();
        FileName = loc!.SourceTree!.FilePath;
        FileName += "";
        var parent = syntaxNode.Parent;
        while(parent !=null)
        {
            if (parent.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.LocalFunctionStatement))
            {
                MethodName = (parent as LocalFunctionStatementSyntax)!.Identifier.Text;
                break;
            }
            if (parent.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.MethodDeclaration))
            {
                MethodName = (parent as MethodDeclarationSyntax)!.Identifier.Text;
                break;
            }
            parent = parent!.Parent;
        }

        if (parent == null) return;//program.cs
                                   //
        //find class name
        while (parent != null )
        {
            if(parent.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.RecordDeclaration))
            {
                ClassName = (parent as RecordDeclarationSyntax)!.Identifier.Text;
                break;
            }
            if (parent.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.ClassDeclaration))
            {
                ClassName = (parent as ClassDeclarationSyntax)!.Identifier.Text;
                break;
            }
            parent = parent.Parent;
        }
        //if (parent == null) return;//program.cs

    }
    public string FileName { get; private set; }

}
