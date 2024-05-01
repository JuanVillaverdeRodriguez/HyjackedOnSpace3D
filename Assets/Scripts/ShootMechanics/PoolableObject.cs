using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// namespace projecto.ImpactSystem.Pool
public class PoolableObject : MonoBehaviour
{
    public ObjectPool<GameObject> Parent;

        private void OnDisable()
        {
            if (Parent != null)
            {
                Parent.Release(gameObject);
            }
        }
}
