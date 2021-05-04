using System.Collections.Generic;

namespace BookStore.Api.GraphQL.Common
{
  public class PayloadBase<T> : Payload
  {
    public T? RequestModel { get; }

    protected PayloadBase(T request)
    {
      RequestModel = request;
    }

    protected PayloadBase(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
  }
}