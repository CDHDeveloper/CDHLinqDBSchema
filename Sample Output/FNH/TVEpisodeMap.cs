using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class TVEpisodeMap : ClassMap<TVEpisode>
	{
		public TVEpisodeMap()
		{
			Table("[NTeract].[].[TVEpisode]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.TVSeason).Column("SeasonId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Number, "Number");
			Map(x => x.Name, "Name");
			Map(x => x.AirDate, "AirDate");
			HasMany(x => x.TVEpisodeMediaObjects);

		}
	}
}
