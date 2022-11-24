using System.Collections.Generic; 

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetByID(int id);

        // farklı bir method id alımı için 
        T GetId(int id);
    }
}
