using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class GroupMap : ClassMap<Group>
	{
		public GroupMap()
		{
			Table("[NTeract].[].[Group]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(100);
			Map(x => x.Description, "Description");
			HasMany(x => x.UserGroups);

		}
	}
}
