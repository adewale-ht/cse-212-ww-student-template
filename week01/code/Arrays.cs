public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of doubles with the requested length.
        // 2. Loop i from 0 to length-1 and compute the (i+1)-th multiple as number * (i+1).
        // 3. Store each computed multiple into result[i].
        // 4. Return the populated array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Handle edge cases: if data is null or empty, do nothing.
        // 2. Normalize the rotation amount using modulo with data.Count. If normalized amount is 0, nothing to do.
        // 3. Use GetRange to take the tail (last 'shift' elements) and the head (first Count-shift elements).
        // 4. Clear the original list and AddRange the tail then the head so the list is rotated in-place.

        if (data == null || data.Count == 0)
        {
            return;
        }

        int n = data.Count;
        int shift = amount % n;
        if (shift == 0)
        {
            return;
        }

        List<int> tail = data.GetRange(n - shift, shift);
        List<int> head = data.GetRange(0, n - shift);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
