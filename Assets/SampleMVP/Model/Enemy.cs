using UniRx;
using System;

public class Enemy
{
    private int _id;
    private int _currentHealth;
    private int _maxHealth;

    /// <summary>
    /// 体力を通知するインスタンス
    /// </summary>
    Subject<int> _healthSubject;

    /// <summary>
    /// 死亡を通知するインスタンス
    /// (Unitは通知する値に意味がないという意味で、イベントのタイミングを通知したいときに使う)
    /// </summary>
    Subject<Unit> _deadSubject;

    public IObservable<int> Health => _healthSubject;
    public IObservable<Unit> Dead => _deadSubject;

    public int CurrentHealth => _currentHealth;

    public Enemy()
    {
        _id = 0;
        _maxHealth = 100;
        _currentHealth = _maxHealth;
        _healthSubject = new Subject<int>();
        _deadSubject = new Subject<Unit>();
    }

    public void Damage(int damage)
    {
        _currentHealth = Math.Max(0, _currentHealth - damage);
        _healthSubject.OnNext(damage);

        if(_currentHealth == 0)
        {
            _deadSubject.OnNext(Unit.Default);
        }
    }
}
