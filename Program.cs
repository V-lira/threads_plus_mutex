using System;
//MUTEX!
class Program
{
    private static int counter = 0;
    private static Mutex mutex = new Mutex();
    static void Main(string[] args)
    {
        //create two threads
        Thread thread1 = new Thread(COUNTER);
        Thread thread2 = new Thread(COUNTER);
        //launching threads
        thread1.Start(1);
        thread2.Start(2);
        //waiting for the completion of threads
        thread1.Join();
        thread2.Join();
        Console.WriteLine($"the final value of the counter: {counter}");
        //release the mutex
        mutex.Dispose();
    }
    static void COUNTER(object threadId)
    {
        while (true)
        {
            //cquire a mutex
            mutex.WaitOne();
            try
            {
                //check the exit condition
                if (counter >= 10000)
                {
                    return;
                }
                //increment the counter and output the information;
                counter++;
                Console.WriteLine($"thread {threadId}: counter => {counter}");
            }
            finally
            {
                //always get release the mutex
                mutex.ReleaseMutex();
            }
            //short pause for threads to work sequentially.
            Thread.Sleep(1);
        }
    }
}