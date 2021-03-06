/*
* sones GraphDB - Community Edition - http://www.sones.com
* Copyright (C) 2007-2011 sones GmbH
*
* This file is part of sones GraphDB Community Edition.
*
* sones GraphDB is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, version 3 of the License.
* 
* sones GraphDB is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with sones GraphDB. If not, see <http://www.gnu.org/licenses/>.
* 
*/

using System;
using Irony.Ast;
using Irony.Parsing;
using sones.GraphQL.GQL.Structure.Helper.Definition;
using sones.GraphQL.Structure.Nodes.DDL;
using sones.GraphQL.ErrorHandling;

namespace sones.GraphQL.Structure.Nodes.Misc
{
    /// <summary>
    /// This node is requested in case of a GraphType statement.
    /// </summary>
    public sealed class VertexTypeNode : AStructureNode, IAstNodeInit
    {
        #region Data

        public DBTypeOfAttributeDefinition DBTypeDefinition { get; private set; }

        #endregion

        #region constructor

        public VertexTypeNode()
        {

        }

        #endregion

        #region IAstNodeInit Members

        public void Init(ParsingContext context, ParseTreeNode parseNode)
        {
            if (parseNode.FirstChild.Term is IdentifierTerminal)
            {

                #region simple id

                DBTypeDefinition = new DBTypeOfAttributeDefinition()
                {
                    Type = SonesGQLConstants.SingleType,
                    Name = parseNode.ChildNodes[0].Token.ValueString
                };

                #endregion

            }

            else if (parseNode.FirstChild.Term.Name.ToUpper().Equals(SonesGQLConstants.INCOMINGEDGE.ToUpper()))
            {

                #region BackwardedgeDefinition

                var _TypeCharacteristics = new TypeCharacteristics();
                _TypeCharacteristics.IsIncomingEdge = true;
                DBTypeDefinition = new DBTypeOfAttributeDefinition()
                {
                    TypeCharacteristics = _TypeCharacteristics,
                    Name = parseNode.ChildNodes[0].Token.ValueString,
                    Type = SonesGQLConstants.INCOMINGEDGE
                };

                #endregion

            }

            else if (parseNode.FirstChild.AstNode is EdgeTypeDefNode)
            {

                #region EdgeType definition

                DBTypeDefinition = new DBTypeOfAttributeDefinition()
                {
                    Type = ((EdgeTypeDefNode)parseNode.FirstChild.AstNode).Type,
                    Name = ((EdgeTypeDefNode)parseNode.FirstChild.AstNode).Name,
                    TypeCharacteristics = ((EdgeTypeDefNode)parseNode.FirstChild.AstNode).TypeCharacteristics,
                    EdgeType = ((EdgeTypeDefNode)parseNode.FirstChild.AstNode).EdgeType,
                };

                #endregion

            }

            else if (parseNode.FirstChild.AstNode is SingleEdgeTypeDefNode)
            {

                #region Single edge type definition

                DBTypeDefinition = new DBTypeOfAttributeDefinition()
                {
                    Type = ((SingleEdgeTypeDefNode)parseNode.FirstChild.AstNode).Type,
                    Name = ((SingleEdgeTypeDefNode)parseNode.FirstChild.AstNode).Name,
                    TypeCharacteristics = ((SingleEdgeTypeDefNode)parseNode.FirstChild.AstNode).TypeCharacteristics,
                    EdgeType = ((SingleEdgeTypeDefNode)parseNode.FirstChild.AstNode).EdgeType,
                };

                #endregion

            }

            else if (parseNode.ChildNodes.Count >= 2)
            {

                String type;

                #region set
                if (parseNode.ChildNodes[0].Token.ValueString.ToUpper() == SonesGQLGrammar.TERMINAL_SET)
                {
                    type = SonesGQLGrammar.TERMINAL_SET;
                }
                #endregion

                #region list
                else if (parseNode.ChildNodes[0].Token.ValueString.ToUpper() == SonesGQLGrammar.TERMINAL_LIST)
                {
                    type = SonesGQLGrammar.TERMINAL_LIST;
                }
                #endregion

                else
                {
                    throw new NotImplementedQLException("");
                }

                DBTypeDefinition = new DBTypeOfAttributeDefinition()
                {
                    Type = type,
                    Name = parseNode.ChildNodes[2].Token.ValueString
                };
            }

            else
            {
                throw new ArgumentException("Invalid Graph type definition...");
            }
        }

        #endregion
    }
}
