namespace Coupon.Application.Interfaces
{
    public interface IQueryHandler<in Tin1, out TOut>
    {
        TOut ExecuteQuery(Tin1 input1);
    }
}
