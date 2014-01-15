using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class UserAppRoleMap : ClassMap<UserAppRole>
	{
		public UserAppRoleMap()
		{
			Table("[NTeract].[].[UserAppRole]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.AppRole).Column("RoleId");
			References(x => x.User).Column("UserId");
			Map(x => x.Id, "Id").Not.Nullable();

		}
	}
}
