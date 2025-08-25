namespace IWantApp.Domain;

public abstract class Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public string CreatedBy { get; set; }
    public string EditedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime EditedAt { get; set; }

    public Entity() { 
        Id = Guid.NewGuid();
    }
}
