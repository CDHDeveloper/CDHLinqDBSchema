using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class TagObjectMap : ClassMap<TagObject>
	{
		public TagObjectMap()
		{
			Table("[NTeract].[].[TagObject]");
			Map(x => x.Id, "Id");
			Map(x => x.TagId, "TagId");
			Map(x => x.ObjectId, "ObjectId");

		}
	}
}
