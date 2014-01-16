using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class AppRoleMap : ClassMap<AppRole>
	{
		public AppRoleMap()
		{
			Table("[NTeract].[dbo].[AppRole]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(10);
			Map(x => x.Description, "Description").Length(50);
			HasMany(x => x.UserAppRoles);

		}
	}
}
