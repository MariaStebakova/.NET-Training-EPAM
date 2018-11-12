namespace ArrayTransform.ArrayTransformation
{
    public interface IPredicate<in TSource>
    {
        bool IsMatch(TSource source);
    }
}
