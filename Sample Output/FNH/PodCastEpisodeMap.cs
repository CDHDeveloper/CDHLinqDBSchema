using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class PodCastEpisodeMap : ClassMap<PodCastEpisode>
	{
		public PodCastEpisodeMap()
		{
			Table("[NTeract].[dbo].[PodCastEpisode]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.PodCast).Column("PodCastId");
			References(x => x.MediaObject).Column("MediaObjectId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.URI, "URI");
			Map(x => x.PostedDate, "PostedDate");
			Map(x => x.Description, "Description").Length(250);
			Map(x => x.FileSize, "FileSize");
			Map(x => x.Duration, "Duration");

		}
	}
}
