using UniRx;
using System;

public class Enemy
{
    private int _id;
    private int _currentHealth;
    private int _maxHealth;

    /// <summary>
    /// �̗͂�ʒm����C���X�^���X
    /// </summary>
    Subject<int> _healthSubject;

    /// <summary>
    /// ���S��ʒm����C���X�^���X
    /// (Unit�͒ʒm����l�ɈӖ����Ȃ��Ƃ����Ӗ��ŁA�C�x���g�̃^�C�~���O��ʒm�������Ƃ��Ɏg��)
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
