using System;
using System.Diagnostics;
class ConsoleApp1
{
    static void Main(string[] args)
    {
        int[] arr = new int[10000];
        Random rand = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next(10000);
        }
        Stopwatch stopwatch = new Stopwatch();
        // Сортировка вставками
        stopwatch.Start();
        InsertionSort(arr);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения сортировки вставками: {stopwatch.ElapsedMilliseconds} мс");
        // Сортировка выбором
        stopwatch.Reset();
        stopwatch.Start();
        SelectionSort(arr);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения сортировки выбором: {stopwatch.ElapsedMilliseconds} мс");
        // Сортировка обменом
        stopwatch.Reset();
        stopwatch.Start();
        BubbleSort(arr);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения сортировки обменом: {stopwatch.ElapsedMilliseconds} мс");

        int[] arrr = new int[5000];
        Random randd = new Random();
        for (int i = 0; i < arrr.Length; i++)
        {
            arrr[i] = randd.Next(10000);
        }
        Array.Sort(arrr); // сортировка для бинарного поиска

        int searchValue = arrr[randd.Next(arrr.Length)]; // выбираем случайный элемент для поиска
                                                         // Прямой поиск
        stopwatch.Start();
        LinearSearch(arrr, searchValue);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения прямого поиска в массиве: {stopwatch.ElapsedMilliseconds} мс");
        // Бинарный поиск
        stopwatch.Reset();
        stopwatch.Start();
        BinarySearch(arrr, searchValue, 1, arrr.Length);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения бинарного поиска в массиве: {stopwatch.ElapsedMilliseconds} мс");



    }
    static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }
    static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }
    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static int LinearSearch(int[] arr, int searchValue)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == searchValue)
            {
                return i;
            }
        }
        return -1;
    }
    static int BinarySearch(int[] array, int searchedValue, int first, int last)
    {
        //средний индекс подмассива
        var middle = (first + last) / 2;
        //значение в средине подмассива
        var middleValue = array[middle];

        if (middleValue == searchedValue)
        {
            return middle;
        }
        else
        {
            if (middleValue > searchedValue)
            {
                //рекурсивный вызов поиска для левого подмассива
                return BinarySearch(array, searchedValue, first, middle - 1);
            }
            else
            {
                //рекурсивный вызов поиска для правого подмассива
                return BinarySearch(array, searchedValue, middle + 1, last);
            }
        }
    }




}