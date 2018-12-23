namespace XO.Core.Abstracts
{
    public interface IGame
    {
        int Move(string[] field);
        void Clear();
    }
}
