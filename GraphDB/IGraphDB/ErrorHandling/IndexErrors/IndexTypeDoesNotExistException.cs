﻿using System;
using sones.Library.ErrorHandling;

namespace sones.GraphDB.ErrorHandling
{
    /// <summary>
    /// The index type does not exists
    /// </summary>
    public sealed class IndexTypeDoesNotExistException : AGraphDBIndexException
    {
        public String IndexTypeName { get; private set; }

        /// <summary>
        /// Creates a new IndexTypeDoesNotExistException exception
        /// </summary>
        /// <param name="myIndexTypeName"></param>
        public IndexTypeDoesNotExistException(String myIndexTypeName)
        {
            IndexTypeName = myIndexTypeName;
            _msg = String.Format("The index type \"{0}\" does not exist!", IndexTypeName);
        }
      
    }
}