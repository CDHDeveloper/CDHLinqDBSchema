using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class TVSeriesMap : ClassMap<TVSeries>
	{
		public TVSeriesMap()
		{
			Table("[NTeract].[dbo].[TVSeries]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.TVNetwork).Column("NetworkId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(250);
			Map(x => x.FirstAirDate, "FirstAirDate");
			Map(x => x.LastAirDate, "LastAirDate");
			Map(x => x.Ongoing, "Ongoing");
			Map(x => x.OneTimeShow, "OneTimeShow");
			Map(x => x.ContentRatingId, "ContentRatingId");
			Map(x => x.WebSite, "WebSite");
			Map(x => x.IMDBId, "IMDBId").Length(50);
			Map(x => x.TvDbId, "TvDbId").Length(10);
			Map(x => x.Zap2ItId, "Zap2ItId");
			Map(x => x.LastUpdated, "LastUpdated");
			HasMany(x => x.TVSeasons);

		}
	}
}
