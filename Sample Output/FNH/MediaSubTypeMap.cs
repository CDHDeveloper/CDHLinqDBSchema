using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class MediaSubTypeMap : ClassMap<MediaSubType>
	{
		public MediaSubTypeMap()
		{
			Table("[NTeract].[].[MediaSubType]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(50);
			HasMany(x => x.MediaObjects);
			HasMany(x => x.MediaObjectMediaSubTypes);

		}
	}
}
