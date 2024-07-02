using UniRx;
using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameLifeTimeScope _lifeTimeScope;

    private PlayerPresenter _playerPresenter;
    // Start is called before the first frame update
    void Start()
    {
        if(_lifeTimeScope == null)
        {
            Debug.Log("Lifetime is null");
        }
        _playerPresenter = _lifeTimeScope.Container.Resolve<PlayerPresenter>();
        if (_playerPresenter == null)
        {
            Debug.Log("NULL");
        }
        _playerPresenter.FireBulletObservable.Subscribe(Fire);
        _playerPresenter.MoveObservable.Subscribe(Move);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _playerPresenter.onClickEvent.OnNext(Unit.Default);
        }

        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            _playerPresenter.OnInputHorizontalEvent.OnNext(horizontal);
        }
    }

    void Fire(Unit unit)
    {
        var pos = transform.position;
        var bulletPos = new Vector3(pos.x, pos.y, pos.z + 1);
        Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
    }

    private void Move(float value)
    {
        transform.Translate(value, 0, 0);
    }
}
