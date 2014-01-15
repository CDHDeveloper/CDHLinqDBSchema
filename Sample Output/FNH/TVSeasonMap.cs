using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class TVSeasonMap : ClassMap<TVSeason>
}
	public TVSeasonMap()
{
		Table("[NTeract].[].[TVSeason]");
		Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
		References(x => x.TVSeries).Column("SeriesId");
		Map(x => x.Id, "Id").Not.Nullable();
		Map(x => x.SeasonNumber, "SeasonNumber");
		Map(x => x.StartDate, "StartDate");
		Map(x => x.EndDate, "EndDate");
		HasMany(x => x.TVEpisodes);
	}
}
