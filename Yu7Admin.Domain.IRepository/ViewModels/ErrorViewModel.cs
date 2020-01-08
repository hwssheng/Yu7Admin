/********************************************************************************  
 * NameSpace:    Yu7Admin.Domain.IRepository.ViewModels
 * FileName:     ErrorViewModel 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/2 10:01:04
 
 * Description:
 * 
 
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Yu7Admin.Domain.IRepository.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
