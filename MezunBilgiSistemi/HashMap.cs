using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class HashMap
    {
        int TABLE_SIZE = 10;
        HashEntry[] table;

        public HashMap()
        {
            table = new HashEntry[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                table[i] = null;
        }
        public void AddHeap(int key, Heap bolum)
        {
            int hash = (key % TABLE_SIZE);
            while (table[hash] != null && table[hash].Anahtar != key)
                hash = (hash + 1) % TABLE_SIZE;
            table[hash] = new HashEntry(key, bolum);
        }
        public Heap GetHeap(int key)
        {
            int hash = (key % TABLE_SIZE);
            while (table[hash] != null && table[hash].Anahtar != key)
                hash = (hash + 1) % TABLE_SIZE;
            if (table[hash] == null)
                return null;
            else
                return (Heap)table[hash].Deger;
        }
    }
}
