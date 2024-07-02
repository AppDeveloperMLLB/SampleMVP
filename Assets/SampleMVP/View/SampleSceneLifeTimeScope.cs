using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeTimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<Enemy>(Lifetime.Singleton);
        builder.Register<EnemyPresenter>(Lifetime.Singleton);
        builder.Register<PlayerPresenter>(Lifetime.Transient);
    }
}