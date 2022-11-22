namespace BorderControl.Models.Interfaces
{
    public interface IIdentifiable
    {
        string Id { get; }
        string Name { get; }

        void CheckId(string id);
    }
}
