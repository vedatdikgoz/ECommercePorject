using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceProject.Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
