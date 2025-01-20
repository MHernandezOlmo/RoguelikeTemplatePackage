//Required to uses C#8 init funtionality. It is declared on net5 or above, to use it on older target framewroks we need to manually define this.
//
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}