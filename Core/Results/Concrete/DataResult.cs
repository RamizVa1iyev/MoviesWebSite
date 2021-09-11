﻿using Core.Results.Abstract;

namespace Core.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; set; }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            this.Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            this.Data = data;
        }
        public DataResult()
        {

        }
    }
}
