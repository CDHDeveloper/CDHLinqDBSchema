using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class TVEpisodeMediaObjectMap : ClassMap<TVEpisodeMediaObject>
	{
		public TVEpisodeMediaObjectMap()
		{
			Table("[NTeract].[].[TVEpisodeMediaObject]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.TVEpisode).Column("TVEpisodeId");
			References(x => x.MediaObject).Column("MediaObjectId");
			Map(x => x.Id, "Id").Not.Nullable();

		}
	}
}
