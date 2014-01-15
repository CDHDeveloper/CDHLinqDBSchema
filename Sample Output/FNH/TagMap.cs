using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class TagMap : ClassMap<Tag>
	{
		public TagMap()
		{
			Table("[NTeract].[].[Tag]");
			Map(x => x.Id, "Id");
			Map(x => x.Name, "Name").Length(50);

		}
	}
}
