namespace ErrandBoy.Data.Entities
{
    public interface IVersionedEntity
    {
        byte[] Version { get; set; }
    }
}
