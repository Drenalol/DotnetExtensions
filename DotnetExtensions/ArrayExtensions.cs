namespace DotnetExtensions
{
    /// <summary>
    /// Collection of the methods that similar LINQ methods, but with the <see cref="System.Range"/> for indexed collection like <see cref="System.Array"/>.
    /// <para/>
    /// For zero (at-least) allocation.
    /// </summary>
    public static class ArrayExtensions
    {
        public static TResult[][] TakeEvery<TResult>(this TResult[] array, int value)
        {
            var iterateCount = (int)Math.Ceiling(array.Length / (double)value);

            var result = new TResult[iterateCount][];
            
            for (var i = 0; i < iterateCount; i++)
                result[i] = array.SkipTake(value, i);

            return result;
        }

        public static T[] SkipTake<T>(this T[] array, int value, int offset) => array[SkipTake(value, offset, array.Length)];
        
        public static T[] Take<T>(this T[] array, int value) => array[Take(value, array.Length)];

        private static Range SkipTake(int value, int offset, int maxLength)
        {
            var start = offset * value;
            var end = start + value;
			
            if (end > maxLength)
                end = maxLength;
            
            return new Range(start, end);
        }

        private static Range Take(int value, int maxLength)
        {
            var end = value;
            
            if (value > maxLength)
                end = maxLength;
            
            return new Range(0, end);
        }
    }
}