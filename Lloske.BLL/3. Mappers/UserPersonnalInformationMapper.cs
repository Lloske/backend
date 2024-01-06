using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/* Alias des classes
 * 
*/
using Models = Lloske.BLL._2._Models;
using Entities = Lloske.DAL._2._Entities;

namespace Lloske.BLL._3._Mappers
{
    /* Classe static
     * Une classe static en C# est un type de classe qui ne peut pas être instanciée. 
     * En d'autres termes, vous ne pouvez pas créer d'objet à partir d'une classe statique en utilisant l'opérateur new. 
     * 
     * 
     * Les caractéristiques d'une classe statique sont :
     * Pas d'Instanciation : Vous ne pouvez pas créer d'instances d'une classe statique.
     * Membres Statiques Uniquement : Tous les membres (méthodes, propriétés, champs) d'une classe statique doivent également être statiques.
     * Accès Direct via le Nom de la Classe : Les membres statiques sont accessibles directement en utilisant le nom de la classe.
     * Utilisation Courante pour les Outils et Méthodes d'Aide (Helpers) : Les classes statiques sont souvent utilisées pour regrouper des méthodes utilitaires ou des fonctions qui ne nécessitent pas de données d'état spécifiques à un objet.
     */
    public static class UserPersonnalInformationMapper
    {
        /* Méthode d'extension = !!THIS!!  dans le ToModel et ToEntities
         * Les méthodes d'extension permettent d'ajouter de nouvelles méthodes à des types existants sans modifier leur code source ou créer une nouvelle classe dérivée.
         * Elles sont déclarées dans des classes statiques et elles-mêmes doivent être des méthodes statiques.
         * Le premier paramètre de la méthode d'extension utilise le mot-clé 'this' suivi du type auquel la méthode est ajoutée. Cela indique sur quel type la méthode ét

         */
        public static Models.UserPersonnalInformation ToModel(this Entities.UserPersonnalInformation entity)
        {
            return new Models.UserPersonnalInformation
            {
                Id = entity.Id,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
                Payroll_identity = entity.Payroll_identity,
                Email = entity.Email,
                Phone = entity.Phone,
                Is_in_employee_registrer = entity.Is_in_employee_registrer,
                Is_archived = entity.Is_archived,
                Password_hash = entity.Password_hash,
            };
        }

        public static Entities.UserPersonnalInformation ToEntity(this Models.UserPersonnalInformation model)
        {
            return new Entities.UserPersonnalInformation
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Payroll_identity = model.Payroll_identity,
                Email = model.Email,
                Phone = model.Phone,
                Is_in_employee_registrer = model.Is_in_employee_registrer,
                Is_archived = model.Is_archived,
                Password_hash = model.Password_hash,
            };
        }
    }
}
