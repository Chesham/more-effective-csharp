using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace item36
{
    public class Item36
    {
        public void hideException()
        {
            try
            {
                ParallelEnumerable.Range(0, 30).Select(i => 100 / (i % 10)).ToList();
            }
            catch (AggregateException problems)
            {
                ReportAggregateError(problems);
            }
        }

        private static void ReportAggregateError(AggregateException aggregate)
        {
            foreach (var exception in aggregate.InnerExceptions)
            {
                if (exception is AggregateException agEx)
                    ReportAggregateError(agEx);
                else
                    Console.WriteLine(exception.Message);
            }
        }

        public void showException()
        {
            try
            {
                ParallelEnumerable.Range(0, 30).Select(i => 100 / (i % 10)).ToList();
            }
            catch (AggregateException problems)
            {
                var handlers = new Dictionary<Type, Action<Exception>>();
                handlers.Add(typeof(Exception), ex => Console.WriteLine(ex.Message));

                if (!HandlAggregateError(problems, handlers))
                    throw;
            }
        }

        private static bool HandlAggregateError(AggregateException aggregate,
            Dictionary<Type, Action<Exception>> exceptionHandlers)
        {
            foreach (var exception in aggregate.InnerExceptions)
            {
                if (exception is AggregateException agEx)
                {
                    if(!HandlAggregateError(agEx, exceptionHandlers))
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (exceptionHandlers.ContainsKey(exception.GetType()))
                {
                    exceptionHandlers[exception.GetType()](exception);
                }
                else
                {
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
