using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class ObjectTypeMap : ClassMap<ObjectType>
	{
		public ObjectTypeMap()
		{
			Table("[NTeract].[].[ObjectType]");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Description, "Description").Length(50);

		}
	}
}
