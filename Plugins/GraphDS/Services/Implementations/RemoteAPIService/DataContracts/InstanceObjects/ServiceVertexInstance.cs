﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using sones.Library.PropertyHyperGraph;

namespace sones.GraphDS.Services.RemoteAPIService.DataContracts.InstanceObjects
{
    [DataContract(Namespace = sonesRPCServer.Namespace)]
    public class ServiceVertexInstance : AGraphElement
    {
        public ServiceVertexInstance(IVertex myVertex) : base(myVertex.VertexTypeID)
        {
            this.VertexID = myVertex.VertexID;
            this.Edition =  myVertex.EditionName;
        }
            

        [DataMember]
        public Int64 VertexID;
        
        [DataMember]
        public String Edition;
    }
}