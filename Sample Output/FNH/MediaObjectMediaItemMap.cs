using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class MediaObjectMediaItemMap : ClassMap<MediaObjectMediaItem>
}
	public MediaObjectMediaItemMap()
{
		Table("[NTeract].[].[MediaObjectMediaItem]");
		Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
		References(x => x.MediaObject).Column("MediaObjectId");
		References(x => x.MediaItem).Column("MediaItemId");
		Map(x => x.Id, "Id").Not.Nullable();
		Map(x => x.Ordinal, "Ordinal");
		HasMany(x => x.MediaMarks);
	}
}
