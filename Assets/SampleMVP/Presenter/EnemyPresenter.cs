using System;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public class EnemyPresenter
{
    public Subject<Unit> OnBulletHitEvent = new Subject<Unit>();
    public IObservable<Unit> DeadObservable => _dead;
    public IObservable<int> HealthObservable => _health;


    private Enemy _enemy;

    Subject<int> _health = new Subject<int>();

    Subject<Unit> _dead = new Subject<Unit>();

    public EnemyPresenter(Enemy enemy)
    {
        _enemy = enemy;
        _enemy.Health.Subscribe(OnHealthChanged);
        _enemy.Dead.Subscribe(OnDead);
        OnBulletHitEvent.Subscribe(OnBulletHit);
    }

    private void OnHealthChanged(int health)
    {
        _health.OnNext(health);
    }

    private void OnDead(Unit unit)
    {
        _dead.OnNext(unit);
    }

    private void OnBulletHit(Unit unit)
    {
        _enemy.Damage(10);
    }
}