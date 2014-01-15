using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class MediaPlaybackMap : ClassMap<MediaPlayback>
	{
		public MediaPlaybackMap()
		{
			Table("[NTeract].[].[MediaPlayback]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.MediaMark).Column("MediaMarkId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.ModifiedTime, "ModifiedTime");

		}
	}
}
