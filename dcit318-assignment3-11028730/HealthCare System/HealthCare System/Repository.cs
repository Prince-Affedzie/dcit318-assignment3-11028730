using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare_System
{
    public class Repository<T>
    {

        private readonly List<T> items = new();

        public void Add(T item) => items.Add(item);

        public List<T> GetAll() => new List<T>(items);

        public T? GetById(Func<T, bool> predicate)
        {
            return items.FirstOrDefault(predicate);
        }

        public bool Remove(Func<T, bool> predicate)
        {
            var match = items.FirstOrDefault(predicate);
            if (match != null)
            {
                items.Remove(match);
                return true;
            }
            return false;
        }
    }
}
