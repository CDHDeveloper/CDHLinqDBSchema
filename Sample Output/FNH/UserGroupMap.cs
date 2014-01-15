using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class UserGroupMap : ClassMap<UserGroup>
}
	public UserGroupMap()
{
		Table("[NTeract].[].[UserGroup]");
		References(x => x.Group).Column("GroupId");
		References(x => x.User).Column("UserId");
		Map(x => x.Id, "Id").Not.Nullable();
	}
}
