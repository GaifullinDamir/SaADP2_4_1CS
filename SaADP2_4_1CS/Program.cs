using System;

namespace SaADP2_4_1CS
{
   
    class Program
    {
        const int arraySize = 10;
        public static int Hash(string key)
        {
            int code = 0;
            for (int i = 0; i < key.Length; i++)
            {
                code += (int)key[i];
            }
            return code % arraySize;
        }
        public static void CreateHashTable(ref string[] hashTable, string[] keys)
        {
            for (int i = 0; i < arraySize; i++)
            {
                hashTable[Hash(keys[i])] = keys[i];
            }
        }
        public static void PrintHashTable(string[] hashTable)
        {
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"{i} - {hashTable[i]} , ");
            }
        }
        public static int KeySearch(string key, string[] hashTable)
        {
            if (hashTable[Hash(key)] == key)
            {
                return Hash(key);
            }
            return -1;
        }

        public static int Input()
        {
            string strInput; bool stop = false;
            int number = -1;
            while(!stop)
            {
                try
                {
                    strInput = Console.ReadLine();
                    number = int.Parse(strInput); stop = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Не верный ввод.");
                    stop = false;
                    throw;
                }
            }
            return number;
        }

        public static void PrintMenu()
        {
            Console.WriteLine(
                "1. Заполнить хеш таблицу.\n"
               +"2. Вывести хеш таблицу на экран.\n"
               +"3. Найти ключ в хеш таблице.\n"
               +"4. Завершить работу.");
        }

        public static void CasePrint(string[] hashTable)
        {
            if (!(hashTable[0] == null))
            {
                PrintHashTable(hashTable);
            }
            else
                Console.WriteLine("Хеш таблица пуста.");
        }

        public static void CaseSearch(string[] hashTable)
        {
            if (!(hashTable[0] == null))
            {
                Console.Write("Введите ключ для поиска: ");
                string key = Console.ReadLine();
                int index = KeySearch(key, hashTable);
                if (index == -1) { Console.WriteLine("Такого ключа нет."); }
                else
                    Console.WriteLine($"Ключ {key} в хеш таблице имеет место {index}.");
            }
            else
                Console.WriteLine("Хеш таблица пуста.");
        }

        public static void ClearMemory(ref string[] hashTable, ref string[] keys)
        {
            for (int i = 0; i < arraySize; i++)
            {
                hashTable[i] = keys[i] = null;
            }
            hashTable = keys = null;
        }

        public static void Interface(ref string[] hashTable, ref string[] keys)
        {
            bool stop = false; PrintMenu();
            while(!stop)
            {
                switch (Input())
                {
                    case 0:
                        PrintMenu();
                        break;
                    case 1:
                        CreateHashTable(ref hashTable, keys);
                        break;
                    case 2:
                        CasePrint(hashTable);
                        break;
                    case 3:
                        CaseSearch(hashTable);
                        break;
                    case 4:
                        ClearMemory(ref hashTable, ref keys);
                        stop = true;
                        break;

                    default:
                        Console.WriteLine("Такого пункта меню нет.");
                        break;
                }
                Console.WriteLine("0. Показать меню.");
            }
        }
        static void Main(string[] args)
        {
            string[] keys = { "WHILE", "AND", "RETURN", "STRUct", "OUT", "Ref", "FOREACH", "PROGRAM", "THEN", "Class" };
            string[] hashTable = new string[arraySize];
            Interface(ref hashTable, ref keys);
        }

    }

}
