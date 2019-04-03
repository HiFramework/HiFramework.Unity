/****************************************************************************
 * Description:释放对象基类（非mono）
 * 1.主动垃圾回收：主动调用Dispose接口回收垃圾
 * 2.系统垃圾回收：系统回收垃圾机制主动触发析构
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    // A class that implements IDisposable.
    // By implementing IDisposable, you are announcing that 
    // instances of this type allocate scarce resources.
    public abstract class ObjectBase : IDisposable
    {
        // Track whether Dispose has been called.
        private bool disposed = false;

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    DisposeManaged();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
                DisposeUnmanaged();
            }
            disposed = true;
        }

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method 
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~ObjectBase()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

        /// <summary>
        /// Dispose managed resources.
        /// </summary>
        protected abstract void DisposeManaged();

        /// <summary>
        /// Dispose unmanaged resources
        /// </summary>
        protected virtual void DisposeUnmanaged()
        {
        }
    }
}