namespace Health
{
    public delegate void HealthChangedDelegate(int currHealth, int prevHealth);
    
    public interface IHealthProvider
    {
        int Health { get; }
        
        event HealthChangedDelegate HealthChanged;
    }
}
