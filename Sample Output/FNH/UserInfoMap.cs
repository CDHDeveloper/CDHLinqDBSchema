using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class UserInfoMap : ClassMap<UserInfo>
}
	public UserInfoMap()
{
		Table("[NTeract].[].[UserInfo]");
		Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
		Map(x => x.UserId, "UserId").Not.Nullable();
		Map(x => x.Email, "Email");
		Map(x => x.DateAdded, "DateAdded");
		Map(x => x.LastUpdate, "LastUpdate");
		Map(x => x.LastLogin, "LastLogin");
		Map(x => x.Password, "Password").Length(15);
		Map(x => x.IsApproved, "IsApproved");
		Map(x => x.IsLockedOut, "IsLockedOut");
		Map(x => x.LoginFailures, "LoginFailures");
		Map(x => x.LastLockedOut, "LastLockedOut");
		HasMany(x => x.Users);
	}
}
