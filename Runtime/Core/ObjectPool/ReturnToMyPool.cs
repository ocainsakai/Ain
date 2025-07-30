using UnityEngine;

namespace Ain
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