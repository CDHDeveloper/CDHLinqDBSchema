using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class TVNetworkMap : ClassMap<TVNetwork>
	{
		public TVNetworkMap()
		{
			Table("[NTeract].[dbo].[TVNetwork]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(50);
			Map(x => x.URI, "URI");
			HasMany(x => x.TVSeriess);
			HasMany(x => x.TVStations);

		}
	}
}
