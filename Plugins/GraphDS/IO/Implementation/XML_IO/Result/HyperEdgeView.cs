﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sones.GraphQL.Result;

namespace sones.XML_IO.Result
{
    public class HyperEdgeView : IHyperEdgeView
    {
        #region Data

        /// <summary>
        /// The list of properties of the edge.
        /// </summary>
        private readonly IDictionary<String, Object>    _propertyList;

        /// <summary>
        /// The list of target vertex of the edge.
        /// </summary>
        private readonly IEnumerable<IVertexView>       _targetVertices;

        /// <summary>
        /// The vertices, which belongs to the hyperedge.
        /// </summary>
        private readonly IEnumerable<ISingleEdgeView>   _edges;


        #endregion

        #region Constructor


        /// <summary>
        /// The edge view constructor.
        /// </summary>
        /// <param name="myProperties">The properties of the edge.</param>
        /// <param name="myTargetVertices">The target vertices of the edge.</param>
        /// <param name="myEdges">The vertices, which belongs to the hyperedge.</param>
        public HyperEdgeView(IDictionary<String, Object> myProperties, IEnumerable<IVertexView> myTargetVertices, IEnumerable<ISingleEdgeView> myEdges)
        {
            _propertyList = myProperties;
            _targetVertices = myTargetVertices;
            _edges = myEdges;
        }

        #endregion

        #region IHyperEdgeView

        public IEnumerable<ISingleEdgeView> GetEdges()
        {
            return _edges;
        }

        public IEnumerable<IVertexView> GetTargetVertices()
        {
            return _targetVertices;
        }

        public T GetProperty<T>(string myPropertyName)
        {
            Object outValue;

            if (_propertyList.TryGetValue(myPropertyName, out outValue))
            {
                return (T)outValue;
            }
            else
            {
                return default(T);
            }
        }

        public bool HasProperty(string myPropertyName)
        {
            return _propertyList.ContainsKey(myPropertyName);
        }

        public int GetCountOfProperties()
        {
            return _propertyList.Count;
        }

        public IEnumerable<Tuple<string, object>> GetAllProperties()
        {
            return _propertyList.Select(item => new Tuple<String, Object>(item.Key, item.Value));
        }

        public string GetPropertyAsString(string myPropertyName)
        {
            Object outValue;

            if (_propertyList.TryGetValue(myPropertyName, out outValue))
            {
                return outValue.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion
    }
}