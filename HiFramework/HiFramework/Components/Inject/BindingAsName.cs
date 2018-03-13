/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////

namespace HiFramework
{
    class BindingAsName : IBindingAsName
    {
        private IBinding _iBinding;
        public BindingAsName(IBinding iBinding)
        {
            _iBinding = iBinding;
        }
        public void AsName(string name)
        {
            _iBinding.AsName = name;
        }
    }
}
