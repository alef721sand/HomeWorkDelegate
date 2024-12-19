namespace HomeWorkDelegate
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null || !collection.Any())
                throw new ArgumentException("The collection is empty or null.");

            return collection.Aggregate((maxItem, nextItem) =>
                convertToNumber(nextItem) > convertToNumber(maxItem) ? nextItem : maxItem);
        }
    }
}
