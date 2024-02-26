﻿// See https://aka.ms/new-console-template for more information
using TaskDemo24;

Console.WriteLine("Hello, TaskDemo24");

#region Methods example 1
static void DoUnitOfWorkB()
{
    int milliseconds = 10;
    Thread.Sleep(milliseconds);
    System.Console.WriteLine("Hi I am in B");
}

static void DoUnitOfWorkA()
{
    int milliseconds = 10;
    Thread.Sleep(milliseconds);
    System.Console.WriteLine("Hi I am in A");
}
#endregion

#region Methods example 2
static void DoUnitOfWorkC(Object data)
{
    foreach (int tal in (List<int>)data)
    {
        Thread.Sleep(10);
        Console.WriteLine("Hi I am in C " + tal);
    }
}

#endregion

#region Methods example 3

//static void DoUnitOfWorkD(Task obj)
//{
//    Thread.Sleep(10);
//    System.Console.WriteLine("Hi I am in D");
//}

#endregion

#region Methods example 4

//static void Calculate()
//{
//    int milliseconds = 10;
//    Thread.Sleep(milliseconds);
//    System.Console.WriteLine("Hi I am in Calculate");
//}


#endregion



#region Methods example 7

static void CalcA(CancellationToken token)
{
    int counter = 0;
    while (!token.IsCancellationRequested && counter < 20)
    {
        // Keep doing work
        int milliseconds = 20;
        Thread.Sleep(milliseconds);
        System.Console.WriteLine($"Hi I am in CalA {counter}");
        counter++;
    }
    if (token.IsCancellationRequested)
    {
        Console.WriteLine("Operation was cancelled in CalA! ");
    }
}

static void CalcB(CancellationToken token)
{
    while (!token.IsCancellationRequested)
    {
        // Keep doing work
        int milliseconds = 2;
        Thread.Sleep(milliseconds);
        System.Console.WriteLine("Hi I am in CalB");
    }
    if (token.IsCancellationRequested)
    {
        Console.WriteLine("Operation was cancelled in CalB! ");
    }
}


#endregion

#region Methods example 8

static void Calculate(int obj)
{
    Console.WriteLine($"Calculate {obj}");
}
#endregion


#region Example 1

//Task taskA = new Task(DoUnitOfWorkA);
//Task taskB = new Task(DoUnitOfWorkB);
//taskA.Start();
//taskB.Start();

//Task taskA = Task.Run(()=> DoUnitOfWorkA());

#endregion

#region Example 2

//Object data = new List<int>() { 1, 3, 7, 9 };
//Task taskC = new Task(DoUnitOfWorkC, data);
//taskC.Start();
//Task taskA = Task.Run(DoUnitOfWorkA);

#endregion

#region Example 3

//Task taskAD = new Task(DoUnitOfWorkA);
//    taskAD.ContinueWith(DoUnitOfWorkD, TaskContinuationOptions.OnlyOnRanToCompletion);
//    taskAD.Start();

#endregion

#region Example 4

//Task taskCalculate = new Task(Calculate);
//taskCalculate.Start();
//// ... Do other preparations
//// All preparations except calculation are done,
//// so wait here until it is done
//taskCalculate.Wait();
//Console.WriteLine("All done");
//Console.WriteLine("Now we can open the dialog");
//Dialog.Open();


#endregion

#region Example 5

//Task taskA = new Task(DoUnitOfWorkA);
//Task taskB = new Task(DoUnitOfWorkB);
//Task taskC = new Task(Calculate);
//taskA.Start();
//taskB.Start();
//taskC.Start();
//// ...do some work
//Task.WaitAll(taskA, taskB, taskC);
//Console.WriteLine("After waitAll");

#endregion

#region Example 6

//Task taskA = new Task(DoUnitOfWorkA);
//Task taskB = new Task(DoUnitOfWorkB);
//Task taskC = new Task(Calculate);
//taskA.Start();
//taskB.Start();
//taskC.Start();
//...do some work

//Task.WaitAny(taskA, taskB, taskC);
//Console.WriteLine("After waitAny");

#endregion

#region Example 7

//CancellationTokenSource tokenSource = new CancellationTokenSource();
//CancellationToken token = tokenSource.Token;

//Task taskCalcA = Task.Run(() => CalcA(token), token);
//Task taskCalcB = Task.Run(() => CalcB(token), token);
//Task.WaitAny(taskCalcA, taskCalcB);
//Console.WriteLine("After waitAny");
//tokenSource.Cancel();

#endregion

#region Example 8

Parallel.For(0, 100, Calculate);
Console.WriteLine("Done for good");

#endregion

Console.ReadLine();