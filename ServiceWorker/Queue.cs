namespace ServiceWorker
{
    public interface IQueue
    {
        void Enqueue(MathExpression item);
        MathExpression Dequeue();
    }   
    public class Queue : IQueue
    {
        private Queue<MathExpression> _queue = new Queue<MathExpression>();
        public Queue() 
        {
        }
        public void Enqueue(MathExpression item)
        {
            if (item == null && item.Value == null)
            {
                throw new ArgumentNullException();
            }
            _queue.Enqueue(item);
        }
        public MathExpression Dequeue() 
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _queue.Dequeue();
        }
    }
}
