using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace item32
{
    public class Item32
    {
        public async Task<List<int>> ReadStockTicker(IEnumerable<int> Symbols)
        {
            var results = new List<int>();
            foreach (var symbol in Symbols)
            {
                var result = await ReadSymbol(symbol);
                results.Add(result);
            }
            return results;
        }

        public static async Task<int> ReadSymbol(int symbol)
        {
            await Task.Delay(1000 / symbol);
            return symbol;
        }

        //----------------------------------------------------------------------
        //WhenAll
        public async Task<List<int>> ReadStockTicker2(IEnumerable<int> Symbols)
        {
            var resultTasks = new List<Task<int>>();
            foreach (var symbol in Symbols)
            {
                resultTasks.Add(ReadSymbol(symbol));
            }
            var results = await Task.WhenAll(resultTasks);
            return results.ToList();
        }

        //----------------------------------------------------------------------
        //WhenAny
        public async Task<int> ReadStockTicker3(IEnumerable<int> Symbols)
        {
            var resultTasks = new List<Task<int>>();
            foreach (var symbol in Symbols)
            {
                resultTasks.Add(ReadSymbol(symbol));
            }
            return await await Task.WhenAny(resultTasks);
        }

        //----------------------------------------------------------------------
        public async Task<List<int>> ReadStockTicker4(IEnumerable<int> Symbols)
        {
            var resultTasks = new List<Task<int>>();
            var results = new List<int>();
            foreach (var symbol in Symbols)
            {
                resultTasks.Add(ReadSymbol(symbol));
            }
            foreach (var task in resultTasks)
            {
                var result = await task;
                results.Add(result);
            }
            return results;
        }

        //----------------------------------------------------------------------
        //WhenAny2
        public async Task<List<int>> ReadStockTicker5(IEnumerable<int> Symbols)
        {
            var resultTasks = new List<Task<int>>();
            var results = new List<int>();
            foreach (var symbol in Symbols)
            {
                resultTasks.Add(ReadSymbol(symbol));
            }
            while (resultTasks.Any())
            {
                Task<int> finishedTask = await Task.WhenAny(resultTasks);
                var result = await finishedTask;
                resultTasks.Remove(finishedTask);
                results.Add(result);
            }
            return results;
        }
    }



    //----------------------------------------------------------------------
    //TaskCompletionSource
    public static class taskcompletionsource
    {
        
        public static Task<T>[] OrderByCompletion<T>(this IEnumerable<Task<T>> tasks)
        {
            var sourceTasks = tasks.ToList();

            //配置來源,配置目標task
            //每一個目標task是Completion Source的對應task
            var completionSources = new TaskCompletionSource<T>[sourceTasks.Count];
            var outputTasks = new Task<T>[completionSources.Length];
            for(int i = 0; i < completionSources.Length; i++)
            {
                completionSources[i] = new TaskCompletionSource<T>();
                outputTasks[i] = completionSources[i].Task;
            }

            //每一個task都有一個接續工作把結果放置到Completion Source陣列下一個開放的位置
            int nextTaskIndex = -1;
            Action<Task<T>> continuaction = completed =>
            {
                var bucket = completionSources[Interlocked.Increment(ref nextTaskIndex)];
                if (completed.IsCompleted)
                    bucket.TrySetResult(completed.Result);
                else if (completed.IsFaulted)
                    bucket.TrySetException(completed.Exception);
            };

            //為每一個input task,設定接續工作來指定output task
            //在每一task完成時,它會使用下一個位置
            foreach(var inputTask in sourceTasks)
            {
                inputTask.ContinueWith(
                    continuaction, 
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
            }

            return outputTasks;
        }

        public static async Task<List<int>> ReadStockTicker(IEnumerable<int> Symbols)
        {
            var resultTasks = new List<Task<int>>();
            var results = new List<int>();
            foreach (var symbol in Symbols)
            {
                resultTasks.Add(ReadSymbol(symbol));
            }
            var results2 = OrderByCompletion(resultTasks);
            foreach (var result2 in results2)
            {
                results.Add(result2.Result);
            }
            return results;
        }

        public static async Task<int> ReadSymbol(int symbol)
        {
            await Task.Delay(1000 / symbol);
            return symbol;
        }
    }
}
