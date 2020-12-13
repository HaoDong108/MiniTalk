using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniTalk
{
    public class CBlockQueue<T>
    {
        protected readonly Queue<T> queue = new Queue<T>();

        /// <summary>
        /// 入列
        /// </summary>
        /// <param >item</param>
        public virtual void Enqueue(T item)
        {
            lock (queue)
            {
                queue.Enqueue(item);

                //若队列中对象不为0，则通知释放所有正在等待的线程
                if (queue.Count >=1)
                {
                    Monitor.PulseAll(queue);
                }
            }
        }

        /// <summary>
        /// 出列头部元素并将其删除
        /// </summary>
        /// <param >value</param>
        public virtual T Dequeue()
        {
            lock (queue)
            {
                while (queue.Count == 0)
                {
                    Monitor.Wait(queue);
                }
                T value = queue.Dequeue();
                return value;
            }
        }

        /// <summary>
        /// 获取队列计数
        /// </summary>
        /// <param ></param>
        public int Count()
        {
            lock (queue)
            {
                return queue.Count;
            }
        }
    }
}
