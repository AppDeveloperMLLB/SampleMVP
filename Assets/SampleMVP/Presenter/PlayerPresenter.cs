using System;
using UniRx;

public class PlayerPresenter: IDisposable
{
    const float FIRE_INTERVAL = 1.0f;
    const float MOVE_SPEED = 0.3f;

    private long _prevFireTime;
    Subject<Unit> _fireBullet = new Subject<Unit>();
    public IObservable<Unit> FireBulletObservable => _fireBullet;

    Subject<float> _move = new Subject<float>();
    public IObservable<float> MoveObservable => _move;

    public Subject<Unit> onClickEvent = new Subject<Unit>();
    public Subject<float> OnInputHorizontalEvent = new Subject<float>();


    public PlayerPresenter()
    {
        onClickEvent.Subscribe(_onClickEvent);
        OnInputHorizontalEvent.Subscribe(_onInputHorizontalEvent);
    }

    private void _onClickEvent(Unit unit)
    {
        var timeSpan = new TimeSpan(DateTime.Now.Ticks - _prevFireTime);
        if(timeSpan.TotalSeconds > FIRE_INTERVAL )
        {
            _prevFireTime = DateTime.Now.Ticks;
            _fireBullet.OnNext(unit);
            return;
        }
    }

    private void _onInputHorizontalEvent(float value)
    {
        // サンプルでは定数だが、実際のげーむではプレイヤーの移動速度などによって変わる
        var moveValue = value * MOVE_SPEED;
        _move.OnNext(moveValue);
    }

    public void Dispose()
    {
       // none
    }
}
