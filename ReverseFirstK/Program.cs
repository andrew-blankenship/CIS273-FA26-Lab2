using System.Globalization;

namespace ReverseFirstK;

public class Program
{
     public static void Main(string[] args)
     {
          
     }

     /// <summary>
     /// Write a method void ReverseFirstK(Queue q, int k) that reverses the first k elements of the given queue. 
     /// You may only use stacks and queues (NOT deques) to do this. 
     /// </summary>
     /// <typeparam name="T"></typeparam>
     /// <param name="queue"></param>
     /// <param name="k"></param>
     /// <returns></returns>
     public static void ReverseFirstK<T>(Queue<T> queue, int k)
     {
          // if k > length, then just reverse the entire queue
          // if queue is null, throw an ArgumentNullException
          // if k < 0, throw an ArgumentException
          Stack<T> nums = new Stack<T>();

          if (k > queue.Count())
          {
               k = queue.Count();
          }

          if (queue == null)
          {
               throw new ArgumentNullException();
          }
          
          if (k < 0)
          {
               throw new ArgumentException();
          }

          // 1) dequeue first k elements and push them on a stack
          for (int i =0; i<k; i++)
          {
               nums.Push(queue.Dequeue());
          }
          // 2) pop elements from stack and enqueue on queue 
          for (int i=0; i<k; i++)
          {
               queue.Enqueue(nums.Pop());
          }
          // 3)  dequeue and enqueue q.length - k times
          for (int i =0; i < queue.Count()-k; i++)
          {
               queue.Enqueue(queue.Dequeue());
          }


     }
}

