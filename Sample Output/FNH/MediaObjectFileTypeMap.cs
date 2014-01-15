using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class MediaObjectFileTypeMap : ClassMap<MediaObjectFileType>
}
	public MediaObjectFileTypeMap()
{
		Table("[NTeract].[].[MediaObjectFileType]");
		Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
		References(x => x.MediaObject).Column("MediaObjectId");
		References(x => x.FileType).Column("FileTypeId");
		Map(x => x.Id, "Id").Not.Nullable();
	}
}
