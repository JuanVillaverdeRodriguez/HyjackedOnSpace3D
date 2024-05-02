using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    private List<GameObject> _pooledObjects;
    private int _amountToPool;
    public void setPoolObject(GameObject objectToPool, int amountToPool) {
        _pooledObjects = new List<GameObject>();
        _amountToPool = amountToPool;
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }
    }

    public GameObject getPooledObject()
    {
        for(int i = 0; i < _amountToPool; i++)
        {
            if(!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}
