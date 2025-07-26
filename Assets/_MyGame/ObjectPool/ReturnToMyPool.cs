using UnityEngine;

namespace Ain.Pool
{
    public class ReturnToMyPool : MonoBehaviour
    {
        public ObjectPool pool;

        public void OnDisable()
        {
            pool.Release(gameObject);
        }
    }
}