﻿using System;

namespace sones.GraphQL.ErrorHandling
{
    /// <summary>
    /// The vertex attribute is ambiguous  
    /// </summary>
    public sealed class AmbiguousVertexAttributeException : AGraphQLVertexAttributeException
    {
        public String Info { get; private set; }

        /// <summary>
        /// Creates a new AmbiguousVertexAttributeException exception
        /// </summary>
        /// <param name="myInfo"></param>
        public AmbiguousVertexAttributeException(String myInfo)
        {
            Info = myInfo;
            _msg = Info;
        }
                
    }
}