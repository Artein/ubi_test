namespace Damage
{
    public interface IDamageReceiver
    {
        // returns true whether damage was applied
        bool ApplyDamage(IDamageProvider damageProvider);
    }
}
