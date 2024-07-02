using NUnit.Framework;

public class EnemyTest
{
    [Test]
    public void Damage10HealthDecreasesBy10()
    {
        var damage = 10;
        var sut = new Enemy();
        var currentHealth = sut.CurrentHealth;
        sut.Damage(damage);
        Assert.That(sut.CurrentHealth == currentHealth - damage);
    }
}
