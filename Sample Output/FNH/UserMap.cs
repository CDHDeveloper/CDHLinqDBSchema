using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			Table("[NTeract].[dbo].[User]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.UserInfo).Column("Id");
			Map(x => x.LoginName, "LoginName").Length(50);
			Map(x => x.DateAdded, "DateAdded");
			Map(x => x.LastUpdate, "LastUpdate");
			Map(x => x.NameOnSite, "NameOnSite").Length(25);
			HasMany(x => x.UserAppRoles);
			HasMany(x => x.UserGroups);

		}
	}
}
