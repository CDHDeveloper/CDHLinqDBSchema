using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class MediaObjectMap : ClassMap<MediaObject>
	{
		public MediaObjectMap()
		{
			Table("[NTeract].[].[MediaObject]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.MediaType).Column("MediaType");
			References(x => x.MediaSubType).Column("MediaSubType");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(250);
			HasMany(x => x.EBookFormatItems);
			HasMany(x => x.MediaObjectFileTypes);
			HasMany(x => x.MediaObjectMediaItems);
			HasMany(x => x.MediaObjectMediaSubTypes);
			HasMany(x => x.PodCastEpisodes);
			HasMany(x => x.TVEpisodeMediaObjects);

		}
	}
}
