using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA.BusinessLogic
{
  
    public interface ILogic: ICarService, ICarAnalytics
    {
        event Action<string>? OnOperationCompleted;
    }
}
