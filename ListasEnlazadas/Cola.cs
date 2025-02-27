using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasEnlazadas
{
    public class Cola
    {
        private class Nodo
        {
            public int key;
            public Nodo next;
            public Nodo(int key) 
            {
                this.key = key;
                this.next = null;
            }
        }
        Nodo front, rear;
        private int maxsize;
        private int currentsize = 0;

        public int Maxsize { get => maxsize; set => maxsize = value; }
        public int Currentsize { get => currentsize; set => currentsize = value; }

        public Cola(int max) {
            this.front = this.rear = null;
            Maxsize = max;
        }

        public void enqueue(int key)
        {
            if (Currentsize < Maxsize)
            {
                Nodo temp = new Nodo(key);
                if(this.rear == null)
                {
                    Currentsize++;
                    this.front = this.rear = temp;
                    return;
                }
                this.rear.next = temp;
                this.rear = temp;
                Currentsize++;
            }
            else
            {
                return;
            }
        }
        public void dequeue()
        {
            if(this.front == null)
            {
                Currentsize--;
                return;
            }
            this.front = this.front.next;
            Currentsize--;
            if (this.front == null)
                this.rear = null;
        }
        public bool isEmpty()
        {
            return Currentsize == 0;
        }
        public bool isFull()
        {
            return (Currentsize == Maxsize);
        }
        public string topElement()
        {
            string result;
            if (!isEmpty())
            {
                result = front.key.ToString();
                return result;
            }
            else
            {
                return "Cola vacia";
            }    
        }
        public int MaxSize()
        {
            return Maxsize;
        }
        public void resetsize()
        {
            this.front = null;
            this.rear = null;
            Currentsize = 0;
        }

    }
}
