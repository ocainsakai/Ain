using System;
using UnityEngine;

namespace Ain.ObjectPool
{
    public abstract class ObjectBase : IDisposable
    {
        private string _name;
        private bool _isInUse;
        private DateTime _lastUseTime;

        // ============================================================================
        // CORE PROPERTIES
        // ============================================================================

        /// <summary>
        /// Object name (optional)
        /// </summary>
        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        /// <summary>
        /// Whether object is currently in use
        /// </summary>
        public bool IsInUse
        {
            get => _isInUse;
            internal set => _isInUse = value;
        }

        /// <summary>
        /// Last time this object was used
        /// </summary>
        public DateTime LastUseTime
        {
            get => _lastUseTime;
            internal set => _lastUseTime = value;
        }

        // ============================================================================
        // CONSTRUCTOR
        // ============================================================================

        protected ObjectBase(string name = null)
        {
            _name = name ?? string.Empty;
            _isInUse = false;
            _lastUseTime = DateTime.UtcNow;
        }
        // ============================================================================
        // CORE METHODS
        // ============================================================================

        /// <summary>
        /// Reset object to initial state (called when returning to pool)
        /// </summary>
        public virtual void Reset()
        {
            _isInUse = false;
            _lastUseTime = DateTime.UtcNow;
            OnReset();
        }

        /// <summary>
        /// Initialize object (called when getting from pool)
        /// </summary>
        public virtual void Initialize()
        {
            _isInUse = true;
            _lastUseTime = DateTime.UtcNow;
            OnInitialize();
        }

        public void Dispose()
        {
            OnDispose();
            _name = null;
            _isInUse = false;
        }
        // ============================================================================
        // VIRTUAL METHODS (Override in derived classes)
        // ============================================================================

        /// <summary>
        /// Called when object is reset (override in derived classes)
        /// </summary>
        protected virtual void OnReset() { }

        /// <summary>
        /// Called when object is initialized (override in derived classes)
        /// </summary>
        protected virtual void OnInitialize() { }

        /// <summary>
        /// Called when object is disposed (override in derived classes)
        /// </summary>
        protected virtual void OnDispose() { }
    }

    public abstract class AdvancedObjectBase : ObjectBase
    {
        private object _target;
        private int _priority;

        /// <summary>
        /// Target object reference
        /// </summary>
        public object Target
        {
            get => _target;
            protected set => _target = value;
        }

        /// <summary>
        /// Object priority for sorting/management
        /// </summary>
        public int Priority
        {
            get => _priority;
            set => _priority = value;
        }

        protected AdvancedObjectBase(string name = null) : base(name)
        {
            _priority = 0;
        }

        protected void SetTarget(object target)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target));
        }

        protected override void OnReset()
        {
            base.OnReset();
            _priority = 0;
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _target = null;
        }
    }

}

