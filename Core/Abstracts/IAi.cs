using XO.Core.Enums;

namespace XO.Core.Abstracts
{
    public interface IAi
    {
        Complexity Complexity { get;}
        int Move(string[] field);
        void Clear();
    }
}
