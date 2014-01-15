using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class MediaItemMap : ClassMap<MediaItem>
	{
		public MediaItemMap()
		{
			Table("[NTeract].[].[MediaItem]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.FileType).Column("FileTypeId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.URI, "URI");
			Map(x => x.LastUpdate, "LastUpdate");
			HasMany(x => x.MediaObjectMediaItems);

		}
	}
}
