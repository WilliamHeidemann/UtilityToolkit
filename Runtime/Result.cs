using System;

namespace UtilityToolkit.Runtime
{
    public class Result
    {
        protected readonly string Error;
        public readonly bool IsSuccess;
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Ok() => new(isSuccess: true, error: null);
        public static Result Fail(string error) => new(isSuccess: false, error);

        public void Match(Action onSuccess, Action<string> onError)
        {
            if (IsSuccess)
            {
                onSuccess();
            }
            else
            {
                onError(Error);
            }
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;

        private Result(bool isSuccess, T value, string error) : base(isSuccess, error)
        {
            _value = value;
        }

        public static Result<T> Ok(T value) => new(isSuccess: true, value, error: null);
        public new static Result<T> Fail(string error) => new(isSuccess: false, default, error);

        public void Match(Action<T> onSuccess, Action<string> onError)
        {
            if (IsSuccess)
            {
                onSuccess(_value);
            }
            else
            {
                onError(Error);
            }
        }
    }
}