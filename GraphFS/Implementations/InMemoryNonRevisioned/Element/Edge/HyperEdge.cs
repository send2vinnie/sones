﻿using System;
using System.Collections.Generic;
using sones.Library.Internal.Definitions;
using sones.GraphInfrastructure.Element;

namespace sones.InMemoryNonRevisioned.Element
{
    /// <summary>
    /// A hyper edge is a 1-N relation within the property hypergraph
    /// </summary>
    public sealed class HyperEdge : IHyperEdge
    {
        #region IHyperEdge

        public IEnumerable<ISingleEdge> GetEdges(Func<ISingleEdge, bool> myFilterFunction = null)
        {
            throw new NotImplementedException();
        }

        public IVertex GetSourceVertex()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVertex> GetTargetVertices(Func<IVertex, bool> myFilterFunc = null)
        {
            throw new NotImplementedException();
        }

        public T GetProperty<T>(PropertyID myPropertyID)
        {
            throw new NotImplementedException();
        }

        public bool HasProperty(PropertyID myPropertyID)
        {
            throw new NotImplementedException();
        }

        public ulong GetCountOfProperties()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<PropertyID, object>> GetAllProperties(Func<PropertyID, object, bool> myFilterFunc = null)
        {
            throw new NotImplementedException();
        }

        public T GetUnstructuredProperty<T>(string myPropertyName)
        {
            throw new NotImplementedException();
        }

        public bool HasUnstructuredProperty(string myPropertyName)
        {
            throw new NotImplementedException();
        }

        public ulong GetCountOfUnstructuredProperties()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, object>> GetAllProperties(Func<string, object, bool> myFilterFunc = null)
        {
            throw new NotImplementedException();
        }

        public string GetComment()
        {
            throw new NotImplementedException();
        }

        public new string GetType()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}