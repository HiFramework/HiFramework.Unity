//---------------------------------------------------------------------------------------------------
/*Description: 
 * 
 * 
 * Author: hiramtan@live.com
 */
//---------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    interface IZip
    {
        byte[] Zip(string path);
        byte[] Zip(byte[] bytes);

        byte[] Unzip(string path);
        byte[] Unzip(byte[] bytes);


    }
}
