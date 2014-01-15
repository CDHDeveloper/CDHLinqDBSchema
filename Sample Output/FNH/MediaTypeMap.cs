using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class MediaTypeMap : ClassMap<MediaType>
}
	public MediaTypeMap()
{
		Table("[NTeract].[].[MediaType]");
		Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
		Map(x => x.Id, "Id").Not.Nullable();
		Map(x => x.Name, "Name").Length(50);
		HasMany(x => x.MediaObjects);
		HasMany(x => x.MediaTypeFileTypes);
	}
}
