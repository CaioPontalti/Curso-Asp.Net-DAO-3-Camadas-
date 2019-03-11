using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public interface IMetodosDb<Classe> //Ao invés de 'Classe', poderia ser qq nome.
    {
        void Create(Classe obj);
        void Delete(Classe obj);
        void Update(Classe obj);
        bool Find(Classe obj);
        List<Classe> FindAll();
    }
}
