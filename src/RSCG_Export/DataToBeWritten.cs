using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;

namespace RSCG_Export;
internal class DataToBeWritten
{
    public DataToBeWritten(SyntaxNode syntaxNode,IInvocationOperation invocation)
    {
        this.referee = new RefereeData(syntaxNode);
        this.referencedData = new ReferencedData(invocation);

    }
    public ReferencedData referencedData { get; private set; }
    public RefereeData referee { get; private set; }

}
