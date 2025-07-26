using System.Collections.Generic;
using UnityEngine;
namespace Ain.ObjectPool
{
    public interface IObjectPool<T> where T : ObjectBase
    {
        // ============================================================================
        // CORE PROPERTIES (Essential Information)
        // ============================================================================

        /// <summary>
        /// Pool name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Current object count in pool
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Pool capacity limit
        /// </summary>
        int Capacity { get; set; }

        // ============================================================================
        // CORE METHODS (Essential Operations)
        // ============================================================================

        /// <summary>
        /// Get an object from pool
        /// </summary>
        /// <returns>Object instance or null if none available</returns>
        T Get();

        /// <summary>
        /// Return an object to pool
        /// </summary>
        /// <param name="obj">Object to return</param>
        void Return(T obj);

        /// <summary>
        /// Clear all objects from pool
        /// </summary>
        void Clear();
    }

    public interface IAdvancedObjectPool<T> : IObjectPool<T> where T : ObjectBase
    {
        // ============================================================================
        // ADVANCED PROPERTIES
        // ============================================================================

        /// <summary>
        /// Objects that can be released
        /// </summary>
        int AvailableCount { get; }

        /// <summary>
        /// Auto cleanup interval in seconds
        /// </summary>
        float CleanupInterval { get; set; }

        // ============================================================================
        // ADVANCED METHODS
        // ============================================================================

        /// <summary>
        /// Check if object is available
        /// </summary>
        bool HasAvailable();

        /// <summary>
        /// Get object by name
        /// </summary>
        T Get(string name);

        /// <summary>
        /// Pre-fill pool with objects
        /// </summary>
        void Preload(int count);

        /// <summary>
        /// Release unused objects
        /// </summary>
        void Cleanup();

        /// <summary>
        /// Release specific number of objects
        /// </summary>
        void Cleanup(int count);
    }

    
}
