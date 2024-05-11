using Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }

        public DataResult(T data,string message, bool isSuccess) : base(message, isSuccess)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
