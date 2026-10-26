//*********************************************************************************************************************************************************************************
//*Практическая работа №12                                                                                                                                                        *
//*Сделал Егоров Н.Н, группа 2-ИСП                                                                                                                                                *
//*Задание: Написать функцию, которая осуществляет шифрование латинской строки при помощи шифра Цезаря, то есть изменить букву на 3 сдвига вправо (например, A - D, B - E и т.д). *
//*********************************************************************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__12
{
    internal class Program
    {
        static void HandleError(FormatException fex)//функция с сообщением об исключении FormatException (входная строка имела неправильный формат)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void HandleError(OverflowException ofex)//функция с сообщением об исключении OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void HandleError(Exception ex)//функция с сообщением об исключении Exception (все ошибки в целом)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void CaesarCipher(string input)
        {
            int shift = 3;//сдвиг на 3 символа вправо
            char[] inputArr = input.ToCharArray();//преобразование строки в массив символов
            string encryptedResult = "";
            bool isValid = true;

            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] >= 'A' && inputArr[i] <= 'Z')//проверка на то, что ASCII-коды не выходят за границу заглавных латинских букв
                {
                    //символ сдвигается на 3 следующим образом: 1) у текущего символа отнимают ASCII-код первого символа текущей таблицы (в данном случае большая a)
                    //2)к этому коду символа прибавляется сдвиг 3 и используется оператор для остатка деления
                    //(для того, чтобы, к примеру, на букве Z программа не вывела ошибку выхода за границы массива)
                    //3)прибавляется код первого символа обратно, чтобы вывелся корректный символ вывода

                    char encryptedChar = (char)((inputArr[i] - 'A' + shift) % 26 + 'A');
                    encryptedResult += encryptedChar;
                }
                else if (inputArr[i] >= 'a' && inputArr[i] <= 'z')//проверка на то, что ASCII-коды не выходят за границу прописных латинских букв
                {
                    char encryptedChar = (char)((inputArr[i] - 'a' + shift) % 26 + 'a');
                    encryptedResult += encryptedChar;
                }
                else if (inputArr[i] == ' ' || inputArr[i] == '.' || inputArr[i] == ',')//проверка на то, что ASCII-коды равны либо пробелу, либо точке, либо запятой
                {
                    encryptedResult += inputArr[i];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели буквы другого алфавита или другие символы! Попробуйте ещё раз.");
                    Console.ForegroundColor = ConsoleColor.White;
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Изначальное предложение (слово): {input}");//вывод изначального предложения
                Console.Write($"Зашифрованное предложение (слово): {encryptedResult}\n");//вывод строки с текстом: "Зашифрованное предложение (слово): "
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа №12";
            Console.WriteLine("Здравствуйте!");
            bool exitProgram = false;//флаг для выхода из программы
            while (true)
            {
                try
                {

                    Console.Write("Напишите английское предложение (слово): ");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))//проверка на пустоту строки или состоит ли строка из одних пробелов
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы ничего не написали или строка состоит только из пробелов. Попробуйте ещё раз.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    CaesarCipher(input);//функция, которая вызывает шифровальщик Цезаря
                }
                catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                {
                    HandleError(ex);
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
                    catch (FormatException fex)//обработка исключения FormatException
                    {
                        HandleError(fex);//функция которая вызывает сообщение ошибки FormatException
                    }
                    catch (OverflowException ofex)//обработка исключения OverflowException
                    {
                        HandleError(ofex);//функция которая вызывает сообщение ошибки OverflowException
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);//функция которая вызывает сообщение ошибки Exception
                    }
                }
                if (exitProgram == true)//если выход из программы является истинным
                    break;//завершается внешний цикл
            }
            Console.ReadKey();
        }
    }
}
