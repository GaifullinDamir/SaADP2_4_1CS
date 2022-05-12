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

        public static void createHashTable(ref string[] hashTable, string[] keys)
        {
            for (int i = 0; i < arraySize; i++)
            {
                hashTable[Hash(keys[i])] = keys[i];
            }
        }

        public static void printHashTable(string[] hashTable)
        {
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"{i} - {hashTable[i]} , ");
            }
        }

        static void Main(string[] args)
        {
            string[] keys = { "WHILE", "AND", "RETURN", "STRUct", "OUT", "Ref", "FOREACH", "PROGRAM", "THEN", "Class" };
            string[] hashTable = new string[arraySize];
            createHashTable(ref hashTable, keys);
            printHashTable(hashTable);
        }

    }

}
