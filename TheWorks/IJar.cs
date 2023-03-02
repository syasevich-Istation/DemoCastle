
namespace TheWorks
{
    public interface IJar
    {
        string Name { get; }
        void Open();
        void Close();
        ISpreadablePortion GetPortion(int quantity);
    }
}
