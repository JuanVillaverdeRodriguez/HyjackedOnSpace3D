using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Gun
{
    public void Shoot(Vector3 dir);
    public void Reload();
}
