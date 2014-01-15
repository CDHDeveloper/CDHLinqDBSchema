using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class MediaMarkMap : ClassMap<MediaMark>
	{
		public MediaMarkMap()
		{
			Table("[NTeract].[].[MediaMark]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.MediaObjectMediaItem).Column("MediaObjectMediaItemId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(50);
			Map(x => x.Position, "Position");
			Map(x => x.UserId, "UserId");
			HasMany(x => x.MediaPlaybacks);

		}
	}
}
