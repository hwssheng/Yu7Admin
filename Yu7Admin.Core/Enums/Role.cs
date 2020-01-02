/********************************************************************************  
 * NameSpace:    Yu7Admin.Core.Enums
 * FileName:     Role 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/2 1:53:06
 
 * Description:
 * 
 
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Yu7Admin.Core.Enums
{
    /// <summary>
    /// 操作权限
    /// </summary>
    public enum Role
    {
        READ=1,
        ADD=2,
        MODIFY=4,
        DELETE=8
    }
}
