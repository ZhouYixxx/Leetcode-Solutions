using System.Linq;

namespace CodePractice.NewCoder.HuaWei
{
    public class No03_SortAndRemoveDuplicate
    {
        public static int[] RandomNumber(int count, int[] source)
        {
            if (count <= 0)
            {
                return source;
            }
            MergeSort(source, 0, source.Length - 1);
            var newArr = RemoveDuplis(source);
            return newArr;
        }

        private static void MergeSort(int[] source, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            var middle = (startIndex + endIndex) / 2;
            //var leftArray = new int[middle - startIndex +1];
            //for (int i = startIndex; i <= middle; i++)
            //{
            //    leftArray[i-startIndex] = source[i];
            //}
            //var rightArray = new int[endIndex- middle];
            //for (int i = middle+1; i <= endIndex; i++)
            //{
            //    rightArray[i-middle-1] = source[i];
            //}
            MergeSort(source, startIndex, middle);
            MergeSort(source, middle + 1, endIndex);
            Merge(source, middle, startIndex, endIndex);
        }

        private static void Merge(int[] source, int middle, int startIndex, int endIndex)
        {
            var temp = new int[endIndex - startIndex + 1];
            int i = 0;
            var leftIndex = startIndex;
            var rightIndex = middle + 1;
            while (leftIndex < middle + 1 && rightIndex <= endIndex)
            {
                if (source[leftIndex] <= source[rightIndex])
                {
                    temp[i] = source[leftIndex];
                    leftIndex++;
                }
                else
                {
                    temp[i] = source[rightIndex];
                    rightIndex++;
                }
                i++;
            }

            while (leftIndex < middle + 1)
            {
                temp[i] = source[leftIndex];
                i++;
                leftIndex++;
            }

            while (rightIndex <= endIndex)
            {
                temp[i] = source[rightIndex];
                i++;
                rightIndex++;
            }

            for (int j = 0; j < temp.Length; j++)
            {
                source[startIndex + j] = temp[j];
            }
        }

        private static int[] RemoveDuplis(int[] source)
        {
            var newArray = new int[source.Length];
            newArray[0] = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] != source[i - 1])
                {
                    newArray[i] = source[i];
                }
            }
            return newArray.Where(t => t != 0).ToArray();
        }
    }
}