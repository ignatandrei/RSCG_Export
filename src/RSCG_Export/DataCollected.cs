using System.Diagnostics;

namespace RSCG_Export;

[DebuggerDisplay("{AssemblyName} {ClassName} {MethodName} ")]
public class DataCollected
{

    public string ClassName { get; protected set; } = "";
    public string MethodName { get; protected set; } = "";
    public string AssemblyName { get; protected set; } = "";
}
