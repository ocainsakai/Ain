using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ain.Pool
{
    public enum PoolKey
    {
        Bullet,
        Enemy,
        VFX_Explosion,
        UI_Popup
    }

    public class ObjectPool
    {
        private Stack<GameObject> stack = new Stack<GameObject>();
        private GameObject baseObj;
        private GameObject tmp;
        private ReturnToMyPool returnPool;

        public ObjectPool(GameObject baseObj)
        {
            this.baseObj = baseObj;
        }

        public GameObject Get()
        {
            while (stack.Count > 0)
            {
                tmp = stack.Pop();
                if (tmp != null)
                {
                    tmp.SetActive(true);
                    return tmp;
                }
                else
                {
                    Debug.LogWarning($"game object with key {baseObj.name} has been destroyed!");
                }
            }
            tmp = GameObject.Instantiate(baseObj);
            returnPool = tmp.AddComponent<ReturnToMyPool>();
            returnPool.pool = this;
            return tmp;
        }

        public void Release(GameObject obj)
        {
            stack.Push(obj);
        }
    }
}