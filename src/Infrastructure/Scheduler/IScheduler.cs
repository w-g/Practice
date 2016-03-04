using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.IoC
{
    public interface IScheduler
    {
        Queue<IJob> Queue { get; }

        void AddJob(IJob job);

        void RemoveJob(IJob job);

        void TriggerJob(IJob job);

        void Start();

        void Stop();
    }

    public interface IJob
    {
        string Key { get; }

        TriggerRule Rule { get; }

        void Execute();
    }

    public abstract class TriggerRule
    {

    }
}
