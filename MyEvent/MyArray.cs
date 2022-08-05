using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvent
{
    public class MyArray<T> : EventArgs
    {
        private static readonly int INIT_SIZE = 16;
        private static readonly int CUT_RATE = 4;
        private Object[] array = new Object[INIT_SIZE];
        private int pointer = 0;

        public EventHandler<string> eventHandler;
        
        protected virtual void SampleChange(string e)
        {
            eventHandler?.Invoke(this, e);
        }
       
        public void Add(T item)
        {
            if (SampleChange != null)
            {

                if (pointer == array.Length - 1)
                    resize(array.Length * 2); 
                array[pointer++] = item;
                SampleChange("SampleEvent Handler: Calling Method");
                Console.WriteLine("Add Result: {0}", array[pointer++] = item);
            }
            else
            {
                Console.WriteLine("Not Subscribed to Event");
            }
        }
        public void Remove(int index)
        {

            if (SampleChange != null)
            {

                for (int i = index; i < pointer; i++)
                    array[i] = array[i + 1];
                array[pointer] = null;
                pointer--;
                if (array.Length > INIT_SIZE && pointer < array.Length / CUT_RATE)
                    resize(array.Length / 2); 
                SampleChange("SampleEvent Handler: Calling Method");
                Console.WriteLine("Remove");
            }
            else
            {
                Console.WriteLine("Not Subscribed to Event");
            }
        }

        public T get(int index)
        {
            return (T)array[index];
        }

        public int size()
        {
            return pointer;
        }

        private void resize(int newLength)
        {
            Object[] newArray = new Object[newLength];
            Array.Copy(array, 0, newArray, 0, pointer);
            array = newArray;
        }
    }
}
