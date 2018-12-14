using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    interface IRepository<T, Tid>
    {
        /// <summary>
        /// Method that adds an object to the database
        /// </summary>
        /// <param name="item">the item to be added</param>
        void Add(T item);
        /// <summary>
        /// Method that removes an object from the database
        /// </summary>
        /// <param name="item">object to be removed</param>
        void Remove(T item);
        /// <summary>
        /// Method to get the specific object in the database
        /// </summary>
        /// <param name="id">the id of the object to get</param>
        /// <returns>the object that has the given id</returns>
        T Find(Tid id);
        /// <summary>
        /// Method to edit the specified object in database
        /// </summary>
        /// <param name="item">Id of the item to edit</param>
        void Edit(T item);
        /// <summary>
        /// Method to get all objects from the database
        /// </summary>
        /// <returns>IEnumerable of objects</returns>
        IEnumerable<T> All();
    }
}
