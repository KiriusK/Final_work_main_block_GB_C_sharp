

string[] NewStringArray() // функция создания и ввода нового сторокового массива
{
    Console.Write("Введите размер массива для последущего ввода элементов с клавиатуры, целое число: ");
    bool checker = false; // переменная показывает что не введено корректное число, когда получим корректное число изменяем на true
    int length = 0; // сюда запишем длину будущего массива
    while (!checker) // в цикле запрашиваем ввод, пока не получим корректное значение
    {
        string input = Console.ReadLine()!;
        Console.WriteLine();
        if (!int.TryParse(input, out length) || int.Parse(input) < 1)
        {
            Console.Write("Для корректной работы требуется число, больше 0, введите еще раз: ");
            continue;
        }

        checker = true;
    }
    string[] inputArr = new string[length]; // создаю массив длиной length

    for (int i = 0; i < length; i++) // вводим элементы массива по очереди
    {
        Console.WriteLine($"Введите элемент массива с номером {i}: ");
        inputArr[i] = Console.ReadLine()!;
    }
    Console.WriteLine("Массив готов");
    return inputArr;
}

void PrintArr(string[] array) // функция печати одномерного массива
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        Console.Write($"{array[i]}, ");
    }
    Console.Write(array[array.Length - 1]);
    Console.WriteLine();
}

string[] SelectionShortStringFromArr(string[] inputArr) // функция выбора строк короче или равных 3 символам
{
    string[] resArr = new string[inputArr.Length]; // создаю массив длиной с входной массив
    int count = 0; // для подсчета подходящих элементов, нужно при обрезке массива
    foreach (string item in inputArr) // в цикле проверяю элементы и добавляю подходящие в результирующий массив
    {
        if (item.Length < 4)
        {
            resArr[count] = item;
            count++;
        }
    }
    if (count == 0) count++; // если коротких строк нет, то возвращаю пустой массив в один элемент
    Array.Resize(ref resArr, count); // обрезаю массив по количеству элементов
    return resArr;
}


string[] inputArr = NewStringArray();
string[] resArr = SelectionShortStringFromArr(inputArr);
Console.WriteLine("Массив с элементами короче или равных 3 символам:");
PrintArr(resArr);
