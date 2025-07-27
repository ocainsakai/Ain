using Ain.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace Ain.Pool
{
    public class PoolManager : Singleton<PoolManager>
    {
        private Dictionary<GameObject, ObjectPool> dicPools = new Dictionary<GameObject, ObjectPool>();
        GameObject tmp;
        public GameObject Get(GameObject obj)
        {
            if (dicPools.ContainsKey(obj) == false)
            {
                dicPools.Add(obj, new ObjectPool(obj));
            }
            return dicPools[obj].Get();
        }
        public GameObject Get(GameObject obj, Vector3 position)
        {
            tmp = Get(obj);
            tmp.transform.position = position;
            return tmp;
        }
        public T Get<T>(T obj) where T : Component
        {
            tmp = Get(obj.gameObject);
            if (tmp == null) return default;
            return tmp.GetComponent<T>();
        }
        public T Get<T>(GameObject obj, Vector3 position) where T : Component
        {
            tmp = Get(obj);
            if (tmp == null) return default;
            tmp.transform.position = position;
            return tmp.GetComponent<T>();
        }
    }

}