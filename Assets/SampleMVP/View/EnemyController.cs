using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using VContainer;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameLifeTimeScope _lifeTimeScope;

    private int _id;
    private EnemyPresenter _enemyPresenter;


    // Start is called before the first frame update
    void Start()
    {
        _enemyPresenter = _lifeTimeScope.Container.Resolve<EnemyPresenter>();
        _enemyPresenter.HealthObservable.Subscribe(OnHealthChanged);
        _enemyPresenter.DeadObservable.Subscribe(OnDead);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int id)
    {
        _id = id;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Bullet")
        {
            Debug.Log("OnTriggerEnter");
            _enemyPresenter.OnBulletHitEvent.OnNext(Unit.Default);
        }
    }

    private void OnHealthChanged(int health)
    {

    }

    private void OnDead(Unit unit)
    {
        Destroy(gameObject);
    }
}
