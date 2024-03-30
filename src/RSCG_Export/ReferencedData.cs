using Microsoft.CodeAnalysis.Operations;

namespace RSCG_Export;

public class ReferencedData: DataCollected
{
    public ReferencedData(IInvocationOperation invocation)
    {
        var target = invocation.TargetMethod;
        //var instance = invocation.Instance;
        this.AssemblyName = target.ContainingAssembly.Name;
        this.ClassName = target.ContainingType.Name;
        this.MethodName = target.Name;

    }
}
