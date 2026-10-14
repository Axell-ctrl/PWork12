//****************************************************************************************************************************
//*Практическая работа №12                                                                                                   *
//*Сделал Егоров Н.Н, группа 2-ИСП                                                                                           *
//*Задание: Написать функцию, которая осуществляет шифрование строки при помощи шифра Цезаря (например, A - D, B - E и т.д). *
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__12
{
    internal class Program
    {
        static string ExitProgram()
        {
            return null;
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа №12";
            bool exitProgram = false;
            while (true)
            {
                try
                {
                    char[] upperAlphabet = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                    char[] lowerAlphabet = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                    Console.Write("Напишите английское предложение: ");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы ничего не написали или строка состоит только из пробелов. Попробуйте ещё раз.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    char[] inputArr = input.ToCharArray();
                    for (int i = 0; i < inputArr.Length; i++)
                    {
                        Console.Write(inputArr[i]);
                    }
                    Console.WriteLine();
                    for (int i = 0; i < inputArr.Length; i++)
                    {
                        for (int j = 0; j < lowerAlphabet.Length; j++)
                        {
                            if (Char.IsWhiteSpace(inputArr[i]))
                            {
                                Console.Write(" ");
                                break;
                            }
                            if (upperAlphabet[j] == inputArr[i])
                            {
                                inputArr[i] = upperAlphabet[(j + 3) % upperAlphabet.Length];
                                Console.Write(inputArr[i]);
                                break;
                            }
                            if (lowerAlphabet[j] == inputArr[i])
                            {
                                inputArr[i] = lowerAlphabet[(j + 3) % lowerAlphabet.Length];
                                Console.Write(inputArr[i]);
                                break;
                            }
                        }
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                while (true)//повторное выполнение цикла с вопросом: Хотите продолжить выполнение? (1-Да/0-Нет).
                {
                    try
                    {
                        Console.Write("Хотите продолжить выполнение? (1-Да/0-Нет): ");
                        int answer = Int32.Parse(Console.ReadLine());
                        if (answer < 0 || answer > 1)//если ответ пользователя меньше 0 или больше 1
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");//некорректное число, просит пользователя попробовать ещё раз ввести значение
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;//продолжает итерацию внутреннего цикла
                        }
                        else//иначе
                        {
                            if (answer == 0)//если ответ пользователя равен 0
                            {
                                exitProgram = true;//флаг выхода из программы становится истинным
                                Console.WriteLine("Завершение программы. Нажмите для продолжения...");//выводится сообщение: Завершение программы.
                            }
                            break;
                        }
                    }
                    catch (FormatException fex)//обработчик исключения FormatException (входная строка имела неправильный формат)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (OverflowException ofex)//обработчик исключения OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }

                if (exitProgram == true)//если выход из программы является истинным
                    break;//завершается внешний цикл
            }
            Console.ReadKey();
        }
    }
}
