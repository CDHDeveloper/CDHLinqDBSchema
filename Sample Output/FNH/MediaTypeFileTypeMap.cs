using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class MediaTypeFileTypeMap : ClassMap<MediaTypeFileType>
}
	public MediaTypeFileTypeMap()
{
		Table("[NTeract].[].[MediaTypeFileType]");
		Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
		References(x => x.MediaType).Column("MediaTypeId");
		References(x => x.FileType).Column("FileTypeId");
		Map(x => x.Id, "Id").Not.Nullable();
	}
}
