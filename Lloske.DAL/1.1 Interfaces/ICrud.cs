using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.DAL._1._1_Interfaces
{
    // Interface implémentant les méthodes indispensables à un Crud : Sera pratique pour créer nos Repositories
    // On pourrait aussi, dans un gros projet, pour aller plus loin, faire des interfaces pour IRead (avec juste les Get), ICreate (pour Creation), IUpdate (pour Update), IDelete (pour Delete). Notre ICrud implémenterait toutes ces interfaces.
    // Ainsi, un Repository qui n'aurait besoin que des Get, n'implémenterait que IRead
    // Résumé des 2 lignes ci dessus: plutot que ICRUD implémente toutes les méthodes (GetAll, GetById, ...) on fait une interface par méthode et l'interface ICRUD implémente toute les méthodes
    // La ligne 19 ressemblerait à: public interface ICrud<TId, TEntity> : IRead, IWrite ...
    public interface ICrud<TId, TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity? GetById(TId id);

        TEntity Create(TEntity entity);

        bool Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
