using UnityEngine;

namespace Ain
{
    /// <summary>
    /// Base class for Ain modules.
    /// </summary>
    /// <remarks>
    /// This class serves as a base for all modules in the Ain framework.
    /// It can be extended to create specific modules with additional functionality.
    /// </remarks>
    internal abstract class AinModule
    {
        internal virtual int Priority
        {
            get => 0;
            set { } // Priority is not used in the base class, but can be overridden in derived classes.
        }
        internal abstract void Initialize();
        internal abstract void Update(float elapseSeconds, float realElapseSeconds);
        
        internal abstract void Dispose();
    }
}

