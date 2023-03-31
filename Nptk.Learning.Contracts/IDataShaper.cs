using Nptk.Learning.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nptk.Learning.Contracts
{
    public interface IDataShaper<T>
    {
        IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string fieldsString);
        Entity ShapeData(T entity, string fieldsString);

    }
}
