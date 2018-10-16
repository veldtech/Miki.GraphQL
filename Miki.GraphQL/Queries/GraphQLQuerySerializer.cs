using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public class GraphQLQuerySerializer
	{
		StringBuilder _builder;

		bool _prettyPrint;

		private GraphQLQuerySerializer(bool prettyPrint = false)
		{
			_builder = new StringBuilder();
			_prettyPrint = prettyPrint;
		}

		public static string Serialize(IQueryBuilder builder, IReadOnlyList<IGraphQLParameter> parameters)
		{
			GraphQLQuerySerializer s = new GraphQLQuerySerializer();

			return s.SerializeInternal(builder, parameters);
		}

		private string SerializeInternal(IQueryBuilder builder, IReadOnlyList<IGraphQLParameter> parameters)
		{
			_builder.Append("query");

			_builder.Append("(");

			for (int i = 0; i < parameters.Count; i++)
			{
				_builder.Append("$");
				_builder.Append(parameters[i].Name);
				_builder.Append(":");
				_builder.Append(ResolveType(parameters[i].ValueType));

				if (i != parameters.Count - 1)
				{
					_builder.Append(",");
				}
			}

			_builder.Append(")");

			AddScope();

			foreach(var type in builder.Types)
			{
				SerializeObject(type);
			}

			RemoveScope();

			return _builder.ToString();
		}

		private string ResolveType(Type valueType)
		{
			var type = "{0}";

			if(valueType.IsArray)
			{
				type = "[{0}]";
			}

			var nullableType = Nullable.GetUnderlyingType(valueType);
			if (nullableType == null)
			{
				type += "!";
			}
			else
			{
				valueType = nullableType;
			}

			if (valueType.IsPrimitive)
			{
				switch (valueType.Name)
				{
					case nameof(String):
						return string.Format(type, "String");
					case nameof(Int16):
					case nameof(Int32):
					case nameof(Int64):
						return string.Format(type, "Int");
					case nameof(Single):
					case nameof(Double):
					case nameof(Decimal):
						return string.Format(type, "Float");
					case nameof(Boolean):
						return string.Format(type, "Boolean");
					// TODO (Veld): Add ID
				}
			}
			return string.Format(type, valueType.Name);
		}

		private void AddScope()
		{
			_builder.Append("{");
			if(_prettyPrint)
			{
				_builder.Append("\n");
			}
		}

		private void RemoveScope()
		{
			_builder.Append("}");
		}

		private void SerializeType(IGraphQLType type)
		{
			if (type.Parameters.Count > 0)
			{
				_builder.Append("(");
				_builder.Append(string.Join(",", type.Parameters.Select(x => x.Name + ":" + x.Value).ToList()));
				_builder.Append(")");

				AddScope();

				foreach(var o in type.Types)
				{
					SerializeObject(o);
				}

				RemoveScope();
			}
		}

		private void SerializeObject(IGraphQLObject o)
		{
			_builder.Append(o.Name);

			if (o is IGraphQLType type)
			{
				SerializeType(type);
			}

			if (_prettyPrint)
			{
				_builder.Append("\n");
			}
			else
			{
				_builder.Append(" ");
			}
		}
	}
}
