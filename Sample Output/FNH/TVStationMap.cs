using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class TVStationMap : ClassMap<TVStation>
	{
		public TVStationMap()
		{
			Table("[NTeract].[dbo].[TVStation]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.TVNetwork).Column("NetworkId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(10);
			Map(x => x.HasHD, "HasHD");
			Map(x => x.HDOnly, "HDOnly");
			Map(x => x.URI, "URI");
			HasMany(x => x.TVChannels);

		}
	}
}
