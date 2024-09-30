using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoving
{
    public abstract void Init(PlayerHandler playerHandler);

    public abstract void DoFixedUpdate();
    public abstract void DoUpdate();
    public abstract void DoLateUpdate();
    public abstract void Stop();
}
